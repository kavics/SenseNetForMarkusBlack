using SenseNet.Client;
// ReSharper disable LocalizableElement

namespace SenseNetForMarkusBlack
{
    public partial class EditForm : Form
    {
        private readonly string _appName = "????";
        private readonly Content _content;
        private bool _changed;

        public EditForm(Content content)
        {
            _content = content;

            InitializeComponent();

            InitializeUi();
        }

        private void InitializeUi()
        {
            pathTextBox.Text = _content.Path;
            this.Text = _content.Path;
            indexTextBox.Select();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveContentAndClose();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            SaveIfNeededAndClose();
        }

        private void Common_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // (char)Keys.Enter '\n'
                SaveContentAndClose();
            if (e.KeyChar == (char)Keys.Escape)
                SaveIfNeededAndClose();
            _changed = true;
            e.Handled = false;
        }
        private void SaveIfNeededAndClose()
        {
            if (_changed)
            {
                var x = MessageBox.Show($"Do you want to save changes to {_content.Path}", _appName, MessageBoxButtons.YesNoCancel);
                if (x == DialogResult.Yes)
                    SaveContentAndClose();
                if (x == DialogResult.No)
                    Close();
                // Cancel: do nothing
            }
            else
            {
                Close();
            }
        }
        private void SaveContentAndClose()
        {
            if (_changed)
                MessageBox.Show($"Save content {_content.Path}");
            Close();
        }

    }
}
