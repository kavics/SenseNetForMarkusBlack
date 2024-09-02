using SenseNet.Client;
using System.Net.Http;
using System.Text;
using AngleSharp.Dom;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Icao;
using SenseNet.Testing;

namespace SenseNetForMarkusBlack
{
    public partial class Form1 : Form
    {
        private readonly IRepositoryCollection _repositoryCollection;

        public Form1(IRepositoryCollection repositoryCollection)
        {
            InitializeComponent();

            _repositoryCollection = repositoryCollection;

            InitializeTree();
        }

        private async void InitializeTree()
        {
            await InitializeRoot();
        }

        private async Task InitializeRoot()
        {
            var node = await LoadContentAsync("/Root", CancellationToken.None);
            var root = new TreeNode
            {
                Text = "Root",
                Tag = node
            };
            treeView1.Nodes.Add(root);
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            goButton.Enabled = false;
            var contents = await Test(CancellationToken.None);
            //debugTextBox.Text = string.Join("\r\n", contents.Select(c => c.Path));
            goButton.Enabled = true;
        }

        private async Task<IEnumerable<Content>> Test(CancellationToken cancel)
        {
            var repository = await _repositoryCollection.GetRepositoryAsync(cancel);

            var contents = await repository.LoadCollectionAsync(new()
            {
                Path = locationTextBox.Text,
                Expand = new[] { "Actions" },
                Select = new[] { "Id", "Type", "Path", "Name", "Actions" },
                Parameters = { new KeyValuePair<string, string>("scenario", "ContextMenu") }
            }, cancel);

            return contents;
        }

        private async void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // select node
            var node = e.Node;
            locationTextBox.Text = node.FullPath;
            var children = await LoadChildren(node, CancellationToken.None);

            // Update subtree
            node.Nodes.Clear();
            foreach (var content in children)
            {
                var childNode = new TreeNode
                {
                    Text = content.Name,
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

        private async Task<Content> LoadContentAsync(string path, CancellationToken cancel)
        {
            var repository = await _repositoryCollection.GetRepositoryAsync(cancel);

            var content = await repository.LoadContentAsync(new LoadContentRequest
            {
                Path = path,
                Expand = new[] { "Actions" },
                Select = new[] { "Id", "Type", "Path", "Name", "Actions" },
                Parameters = { new KeyValuePair<string, string>("scenario", "ContextMenu") }
            }, cancel);

            return content;
        }

        private async Task<IContentCollection<Content>> LoadChildren(TreeNode node, CancellationToken cancel)
        {
            var content = (Content)node.Tag;
            if (content == null)
                throw new ArgumentException("TreeNode has no Content");
            if (content.Path == null)
                throw new ArgumentException("TreeNode's Content has no Path");

            var repository = await _repositoryCollection.GetRepositoryAsync(cancel);

            var contents = await repository.LoadCollectionAsync(new()
            {
                Path = content.Path,
                Expand = new[] { "Actions" },
                Select = new[] { "Id", "Type", "Path", "Name", "Actions" },
                OrderBy = new[] { "Name" },
                Parameters = { new KeyValuePair<string, string>("scenario", "ContextMenu") }
            }, cancel);

            return contents;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var selection = dataGridView1.SelectedRows;
            detailsTextBox.Clear();
            if (selection.Count == 1)
            {
                var content = (Content)selection[0].Tag;
                if(content != null)
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
            if(string.IsNullOrEmpty(actionsJson))
                return Array.Empty<ContentAction>();
            var actions = JsonConvert.DeserializeObject<ContentAction[]>(actionsJson);
            return actions ?? Array.Empty<ContentAction>();
        }
    }
}
