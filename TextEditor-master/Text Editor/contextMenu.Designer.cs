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
            this.deleteBtn = new System.Windows.Forms.Button();
            this.selectAllBtn = new System.Windows.Forms.Button();
            this.clearAllBtn = new System.Windows.Forms.Button();
            this.cutBtn = new System.Windows.Forms.Button();
            this.pasteBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.copyBtn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.deleteBtn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.selectAllBtn, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.clearAllBtn, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cutBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pasteBtn, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(277, 98);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // copyBtn
            // 
            this.copyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.copyBtn.AutoSize = true;
            this.copyBtn.BackColor = System.Drawing.SystemColors.Window;
            this.copyBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.copyBtn.FlatAppearance.BorderSize = 0;
            this.copyBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.copyBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.copyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyBtn.Location = new System.Drawing.Point(141, 0);
            this.copyBtn.Margin = new System.Windows.Forms.Padding(0);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(136, 32);
            this.copyBtn.TabIndex = 1;
            this.copyBtn.Text = "Copy         Ctrl+C";
            this.copyBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.copyBtn.UseVisualStyleBackColor = false;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteBtn.AutoSize = true;
            this.deleteBtn.BackColor = System.Drawing.SystemColors.Window;
            this.deleteBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.deleteBtn.FlatAppearance.BorderSize = 0;
            this.deleteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.deleteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(141, 32);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(0);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(136, 32);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete       Del";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteBtn.UseVisualStyleBackColor = false;
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selectAllBtn.AutoSize = true;
            this.selectAllBtn.BackColor = System.Drawing.SystemColors.Window;
            this.selectAllBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.selectAllBtn.FlatAppearance.BorderSize = 0;
            this.selectAllBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.selectAllBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.selectAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectAllBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllBtn.Location = new System.Drawing.Point(0, 64);
            this.selectAllBtn.Margin = new System.Windows.Forms.Padding(0);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectAllBtn.Size = new System.Drawing.Size(138, 34);
            this.selectAllBtn.TabIndex = 4;
            this.selectAllBtn.Text = "Ctrl+A     Select All";
            this.selectAllBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selectAllBtn.UseVisualStyleBackColor = false;
            // 
            // clearAllBtn
            // 
            this.clearAllBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clearAllBtn.AutoSize = true;
            this.clearAllBtn.BackColor = System.Drawing.SystemColors.Window;
            this.clearAllBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.clearAllBtn.FlatAppearance.BorderSize = 0;
            this.clearAllBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.clearAllBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.clearAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearAllBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearAllBtn.Location = new System.Drawing.Point(141, 64);
            this.clearAllBtn.Margin = new System.Windows.Forms.Padding(0);
            this.clearAllBtn.Name = "clearAllBtn";
            this.clearAllBtn.Size = new System.Drawing.Size(136, 34);
            this.clearAllBtn.TabIndex = 5;
            this.clearAllBtn.Text = "Clear All";
            this.clearAllBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clearAllBtn.UseVisualStyleBackColor = false;
            // 
            // cutBtn
            // 
            this.cutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cutBtn.AutoSize = true;
            this.cutBtn.BackColor = System.Drawing.SystemColors.Window;
            this.cutBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.cutBtn.FlatAppearance.BorderSize = 0;
            this.cutBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cutBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cutBtn.Location = new System.Drawing.Point(0, 0);
            this.cutBtn.Margin = new System.Windows.Forms.Padding(0);
            this.cutBtn.Name = "cutBtn";
            this.cutBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cutBtn.Size = new System.Drawing.Size(136, 32);
            this.cutBtn.TabIndex = 0;
            this.cutBtn.Text = "Ctrl+X             Cut";
            this.cutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cutBtn.UseVisualStyleBackColor = false;
            // 
            // pasteBtn
            // 
            this.pasteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pasteBtn.AutoSize = true;
            this.pasteBtn.BackColor = System.Drawing.SystemColors.Window;
            this.pasteBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.pasteBtn.FlatAppearance.BorderSize = 0;
            this.pasteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pasteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pasteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pasteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pasteBtn.Location = new System.Drawing.Point(0, 32);
            this.pasteBtn.Margin = new System.Windows.Forms.Padding(0);
            this.pasteBtn.Name = "pasteBtn";
            this.pasteBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pasteBtn.Size = new System.Drawing.Size(137, 32);
            this.pasteBtn.TabIndex = 2;
            this.pasteBtn.Text = "Ctrl+V          Paste";
            this.pasteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pasteBtn.UseVisualStyleBackColor = false;
            // 
            // ContextMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(277, 98);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContextMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        protected override void OnLostFocus(System.EventArgs e)
        {
            base.OnLostFocus(e);
            this.Focus();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button cutBtn;
        public System.Windows.Forms.Button pasteBtn;
        public System.Windows.Forms.Button selectAllBtn;
        public System.Windows.Forms.Button copyBtn;
        public System.Windows.Forms.Button deleteBtn;
        public System.Windows.Forms.Button clearAllBtn;
    }
}