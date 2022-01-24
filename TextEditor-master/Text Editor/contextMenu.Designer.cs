namespace Text_Editor { 
    partial class ContextMenu
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.copyBtn = new System.Windows.Forms.Button();
            this.pasteBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.selectAllBtn = new System.Windows.Forms.Button();
            this.clearAllBtn = new System.Windows.Forms.Button();
            this.cutBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.copyBtn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pasteBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DeleteBtn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.selectAllBtn, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.clearAllBtn, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cutBtn, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(274, 213);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // copyBtn
            // 
            this.copyBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.copyBtn.BackColor = System.Drawing.SystemColors.Control;
            this.copyBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.copyBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.copyBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.copyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyBtn.Location = new System.Drawing.Point(140, 9);
            this.copyBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(131, 52);
            this.copyBtn.TabIndex = 1;
            this.copyBtn.Text = "Copy";
            this.copyBtn.UseVisualStyleBackColor = false;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // pasteBtn
            // 
            this.pasteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pasteBtn.BackColor = System.Drawing.SystemColors.Control;
            this.pasteBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.pasteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.pasteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pasteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pasteBtn.Location = new System.Drawing.Point(3, 79);
            this.pasteBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pasteBtn.Name = "pasteBtn";
            this.pasteBtn.Size = new System.Drawing.Size(131, 52);
            this.pasteBtn.TabIndex = 2;
            this.pasteBtn.Text = "Paste";
            this.pasteBtn.UseVisualStyleBackColor = false;
            this.pasteBtn.Click += new System.EventHandler(this.pasteBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteBtn.BackColor = System.Drawing.SystemColors.Control;
            this.DeleteBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.DeleteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.DeleteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Location = new System.Drawing.Point(140, 79);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(131, 52);
            this.DeleteBtn.TabIndex = 3;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.selectAllBtn.BackColor = System.Drawing.SystemColors.Control;
            this.selectAllBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.selectAllBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.selectAllBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.selectAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectAllBtn.Location = new System.Drawing.Point(3, 150);
            this.selectAllBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(131, 52);
            this.selectAllBtn.TabIndex = 4;
            this.selectAllBtn.Text = "Select All";
            this.selectAllBtn.UseVisualStyleBackColor = false;
            this.selectAllBtn.Click += new System.EventHandler(this.selectAllBtn_Click);
            // 
            // clearAllBtn
            // 
            this.clearAllBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clearAllBtn.BackColor = System.Drawing.SystemColors.Control;
            this.clearAllBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.clearAllBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.clearAllBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.clearAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearAllBtn.Location = new System.Drawing.Point(140, 150);
            this.clearAllBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearAllBtn.Name = "clearAllBtn";
            this.clearAllBtn.Size = new System.Drawing.Size(131, 52);
            this.clearAllBtn.TabIndex = 5;
            this.clearAllBtn.Text = "Clear All";
            this.clearAllBtn.UseVisualStyleBackColor = false;
            this.clearAllBtn.Click += new System.EventHandler(this.clearAllBtn_Click);
            // 
            // cutBtn
            // 
            this.cutBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cutBtn.BackColor = System.Drawing.SystemColors.Control;
            this.cutBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.cutBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.cutBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cutBtn.Location = new System.Drawing.Point(3, 9);
            this.cutBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cutBtn.Name = "cutBtn";
            this.cutBtn.Size = new System.Drawing.Size(131, 52);
            this.cutBtn.TabIndex = 0;
            this.cutBtn.Text = "Cut";
            this.cutBtn.UseVisualStyleBackColor = false;
            this.cutBtn.Click += new System.EventHandler(this.cutBtn_Click);
            // 
            // ContextMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(277, 215);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContextMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.theContextMenu_Deactivate);
            this.Load += new System.EventHandler(this.ContextMenu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private bool ctrlKeyIsDown = false; //false by default

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button cutBtn;
        private System.Windows.Forms.Button pasteBtn;
        private System.Windows.Forms.Button selectAllBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button clearAllBtn;
    }
}