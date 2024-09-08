namespace SenseNetForMarkusBlack
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cancelButton = new Button();
            pathTextBox = new TextBox();
            saveButton = new Button();
            toolTip1 = new ToolTip(components);
            label1 = new Label();
            indexTextBox = new TextBox();
            indexLabel = new Label();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(632, 415);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Cancel";
            toolTip1.SetToolTip(cancelButton, "Close without save (ESC)");
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // pathTextBox
            // 
            pathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pathTextBox.Location = new Point(51, 0);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.ReadOnly = true;
            pathTextBox.Size = new Size(749, 23);
            pathTextBox.TabIndex = 1;
            // 
            // saveButton
            // 
            saveButton.Enabled = false;
            saveButton.Location = new Point(713, 415);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 2;
            saveButton.Text = "Save";
            toolTip1.SetToolTip(saveButton, "Save Content (CTRL+S or ENTER)");
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(45, 21);
            label1.TabIndex = 3;
            label1.Text = "EDIT";
            // 
            // indexTextBox
            // 
            indexTextBox.Location = new Point(204, 52);
            indexTextBox.Name = "indexTextBox";
            indexTextBox.Size = new Size(100, 23);
            indexTextBox.TabIndex = 4;
            indexTextBox.KeyPress += Common_KeyPress;
            // 
            // indexLabel
            // 
            indexLabel.AutoSize = true;
            indexLabel.Location = new Point(51, 55);
            indexLabel.Name = "indexLabel";
            indexLabel.Size = new Size(36, 15);
            indexLabel.TabIndex = 5;
            indexLabel.Text = "Index";
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(indexLabel);
            Controls.Add(indexTextBox);
            Controls.Add(label1);
            Controls.Add(saveButton);
            Controls.Add(pathTextBox);
            Controls.Add(cancelButton);
            Name = "EditForm";
            Text = "EditForm";
            KeyPress += Common_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private TextBox pathTextBox;
        private Button saveButton;
        private ToolTip toolTip1;
        private Label label1;
        private TextBox indexTextBox;
        private Label indexLabel;
    }
}