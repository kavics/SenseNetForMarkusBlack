using SenseNet.Client;
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
// ReSharper disable LocalizableElement

namespace SenseNetForMarkusBlack
{
    public partial class Form1 : Form
    {
        private readonly IDataHandler _dataHandler;
        private readonly string _url;

        public Form1(IDataHandler dataHandler, IOptions<RepositoryOptions> repositoryOptions)
        {
            InitializeComponent();

            _dataHandler = dataHandler;
            _url = repositoryOptions.Value.Url;

            InitializeApp();
        }

        private void InitializeApp()
        {
            this.Text = "BROWSE " + _url;
            connectionStatusStatusbarLabel.Text = $"Connecting...";
            connectionTimer.Enabled = true;
            InitializeTree();
        }

        private async void InitializeTree()
        {
            await InitializeRoot();
        }

        private async Task InitializeRoot()
        {
            var node = await _dataHandler.LoadContentAsync("/Root", CancellationToken.None);
            var root = new TreeNode
            {
                Text = "Root",
                Tag = node
            };
            treeView1.Nodes.Add(root);
        }

        private async void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // select node
            var node = e.Node;
            locationTextBox.Text = node.FullPath;
            var children = await _dataHandler.LoadChildren((Content)node.Tag, CancellationToken.None);

            // Update subtree
            node.Nodes.Clear();
            foreach (var content in children)
            {
                var childNode = new TreeNode
                {
                    Text = content.Name ?? "???",
                    Tag = content
                };
                node.Nodes.Add(childNode);
            }

            // Update grid
            dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Type", "Type");
            dataGridView1.Columns.Add("Name", "Name");


            dataGridView1.Columns.Clear();
            var columns = new[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "Id",
                    HeaderText = "Id",
                    Width = 60
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Type",
                    HeaderText = "Type",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Name",
                    HeaderText = "Name",
                    Width = 400
                },
            };
            foreach (var column in columns)
            {
                dataGridView1.Columns.Add(column);
            }

            dataGridView1.Rows.Clear();
            foreach (var content in children)
            {
                var index = dataGridView1.Rows.Add(content.Id, content.Type, content.Name);
                var row = dataGridView1.Rows[index];
                row.Tag = content;
            }

            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows[0].Selected = false;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows[0].Selected = true;
            else
                detailsTextBox.Clear();
        }

        private void dataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            var selection = dataGridView1.SelectedRows;
            detailsTextBox.Clear();
            if (selection.Count == 1)
            {
                var content = (Content?)selection[0].Tag;
                if (content != null)
                {
                    var text = new StringBuilder();
                    foreach (var fieldName in content.FieldNames.Except(new[] { "Actions" }))
                    {
                        text.AppendLine(fieldName);
                        text.Append("    ");
                        text.AppendLine(content[fieldName].ToString());
                    }

                    //if (content.FieldNames.Contains("Actions"))
                    //{
                    //    text.AppendLine();
                    //    text.AppendLine("Actions");
                    //    text.AppendLine(content["Actions"].ToString());
                    //}
                    if (content.FieldNames.Contains("Actions"))
                    {
                        text.AppendLine("Actions:");
                        foreach (var contentAction in GetActions(content))
                        {
                            text.Append("    ");
                            text.Append(contentAction.Name);
                            if (contentAction.ActionParameters.Length > 0)
                            {
                                text.Append("(");
                                text.Append(string.Join(", ", contentAction.ActionParameters));
                                text.Append(")");
                            }
                            text.AppendLine();
                        }
                    }

                    detailsTextBox.Text = text.ToString();
                }
            }

        }

        private ContentAction[] GetActions(Content content)
        {
            if (!content.FieldNames.Contains("Actions"))
                return Array.Empty<ContentAction>();
            var actionsJson = content["Actions"].ToString();
            if (string.IsNullOrEmpty(actionsJson))
                return Array.Empty<ContentAction>();
            var actions = JsonConvert.DeserializeObject<ContentAction[]>(actionsJson);
            return actions ?? Array.Empty<ContentAction>();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //var selectedContent = e.Node.Tag as Content;
            //if (selectedContent == null)
            //    return;

            //var editForm = new EditForm(selectedContent);
            //editForm.ShowDialog();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OpenContentForEditing(dataGridView1.Rows[e.RowIndex].Tag as Content);
        }

        private void OpenContentForEditing(Content? selectedContent)
        {
            if (selectedContent == null)
                return;

            var editForm = new EditForm(selectedContent);
            editForm.Show();
        }

        private async void connectionTimer_Tick(object sender, EventArgs e)
        {
            var status = await _dataHandler.CheckConnectionAsync(1000);
            switch (status)
            {
                case ConnectionStatus.Connecting:
                    connectionStatusStatusbarLabel.Text = "Connecting...";
                    break;
                case ConnectionStatus.Connected:
                    connectionStatusStatusbarLabel.Text = "Connected";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
