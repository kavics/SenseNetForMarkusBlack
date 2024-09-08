namespace SenseNetForMarkusBlack
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            locationTextBox = new TextBox();
            statusStrip1 = new StatusStrip();
            connectionStatusStatusbarLabel = new ToolStripStatusLabel();
            goButton = new Button();
            topPanel = new Panel();
            splitContainer1 = new SplitContainer();
            treeView1 = new TreeView();
            splitContainer2 = new SplitContainer();
            dataGridView1 = new DataGridView();
            detailsTextBox = new TextBox();
            connectionTimer = new System.Windows.Forms.Timer(components);
            statusStrip1.SuspendLayout();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // locationTextBox
            // 
            locationTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            locationTextBox.Location = new Point(3, 3);
            locationTextBox.Name = "locationTextBox";
            locationTextBox.ReadOnly = true;
            locationTextBox.Size = new Size(1055, 23);
            locationTextBox.TabIndex = 1;
            locationTextBox.Text = "/Root/Content";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { connectionStatusStatusbarLabel });
            statusStrip1.Location = new Point(0, 415);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1106, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // connectionStatusStatusbarLabel
            // 
            connectionStatusStatusbarLabel.Name = "connectionStatusStatusbarLabel";
            connectionStatusStatusbarLabel.Size = new Size(36, 17);
            connectionStatusStatusbarLabel.Text = "initial";
            // 
            // goButton
            // 
            goButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            goButton.Enabled = false;
            goButton.Location = new Point(1064, 3);
            goButton.Name = "goButton";
            goButton.Size = new Size(39, 23);
            goButton.TabIndex = 4;
            goButton.Text = "Go";
            goButton.UseVisualStyleBackColor = true;
            // 
            // topPanel
            // 
            topPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            topPanel.Controls.Add(locationTextBox);
            topPanel.Controls.Add(goButton);
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1106, 28);
            topPanel.TabIndex = 5;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(3, 32);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1100, 380);
            splitContainer1.SplitterDistance = 283;
            splitContainer1.TabIndex = 8;
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView1.BorderStyle = BorderStyle.FixedSingle;
            treeView1.Location = new Point(0, 1);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(280, 377);
            treeView1.TabIndex = 0;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            treeView1.NodeMouseDoubleClick += treeView1_NodeMouseDoubleClick;
            // 
            // splitContainer2
            // 
            splitContainer2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer2.Location = new Point(3, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(detailsTextBox);
            splitContainer2.Size = new Size(810, 380);
            splitContainer2.SplitterDistance = 412;
            splitContainer2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 20;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(406, 376);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellMouseDoubleClick += dataGridView1_CellMouseDoubleClick;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // detailsTextBox
            // 
            detailsTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            detailsTextBox.Location = new Point(3, 0);
            detailsTextBox.Multiline = true;
            detailsTextBox.Name = "detailsTextBox";
            detailsTextBox.ScrollBars = ScrollBars.Both;
            detailsTextBox.Size = new Size(391, 376);
            detailsTextBox.TabIndex = 0;
            // 
            // connectionTimer
            // 
            connectionTimer.Interval = 1000;
            connectionTimer.Tick += connectionTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1106, 437);
            Controls.Add(splitContainer1);
            Controls.Add(topPanel);
            Controls.Add(statusStrip1);
            Name = "Form1";
            Text = "Form1";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox locationTextBox;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel connectionStatusStatusbarLabel;
        private Button goButton;
        private Panel topPanel;
        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private DataGridView dataGridView1;
        private SplitContainer splitContainer2;
        private TextBox detailsTextBox;
        private System.Windows.Forms.Timer connectionTimer;
    }
}
