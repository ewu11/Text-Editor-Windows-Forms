﻿
namespace Text_Editor
{
    partial class contextMenu
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(304, 381);
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
            this.copyBtn.Location = new System.Drawing.Point(155, 48);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(146, 29);
            this.copyBtn.TabIndex = 1;
            this.copyBtn.Text = "Copy";
            this.copyBtn.UseVisualStyleBackColor = false;
            // 
            // pasteBtn
            // 
            this.pasteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pasteBtn.BackColor = System.Drawing.SystemColors.Control;
            this.pasteBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.pasteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.pasteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pasteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pasteBtn.Location = new System.Drawing.Point(3, 174);
            this.pasteBtn.Name = "pasteBtn";
            this.pasteBtn.Size = new System.Drawing.Size(146, 29);
            this.pasteBtn.TabIndex = 2;
            this.pasteBtn.Text = "Paste";
            this.pasteBtn.UseVisualStyleBackColor = false;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteBtn.BackColor = System.Drawing.SystemColors.Control;
            this.DeleteBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.DeleteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.DeleteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Location = new System.Drawing.Point(155, 174);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(146, 29);
            this.DeleteBtn.TabIndex = 3;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.selectAllBtn.BackColor = System.Drawing.SystemColors.Control;
            this.selectAllBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.selectAllBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.selectAllBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.selectAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectAllBtn.Location = new System.Drawing.Point(3, 302);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(146, 29);
            this.selectAllBtn.TabIndex = 4;
            this.selectAllBtn.Text = "Select All";
            this.selectAllBtn.UseVisualStyleBackColor = false;
            // 
            // clearAllBtn
            // 
            this.clearAllBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clearAllBtn.BackColor = System.Drawing.SystemColors.Control;
            this.clearAllBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.clearAllBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.clearAllBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.clearAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearAllBtn.Location = new System.Drawing.Point(155, 302);
            this.clearAllBtn.Name = "clearAllBtn";
            this.clearAllBtn.Size = new System.Drawing.Size(146, 29);
            this.clearAllBtn.TabIndex = 5;
            this.clearAllBtn.Text = "Clear All";
            this.clearAllBtn.UseVisualStyleBackColor = false;
            // 
            // cutBtn
            // 
            this.cutBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cutBtn.BackColor = System.Drawing.SystemColors.Control;
            this.cutBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.cutBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.cutBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cutBtn.Location = new System.Drawing.Point(3, 48);
            this.cutBtn.Name = "cutBtn";
            this.cutBtn.Size = new System.Drawing.Size(146, 29);
            this.cutBtn.TabIndex = 0;
            this.cutBtn.Text = "Cut";
            this.cutBtn.UseVisualStyleBackColor = false;
            // 
            // contextMenuWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(328, 405);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "contextMenuWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.contextMenuWindow_Deactivate);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button cutBtn;
        private System.Windows.Forms.Button pasteBtn;
        private System.Windows.Forms.Button selectAllBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button clearAllBtn;
    }
}