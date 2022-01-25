using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Text_Editor
{
    public partial class ContextMenu : Form
    {
        //global variable
        TextEditor textEditorObj; //text editor object instantiation

        //msg uses
        string theMsg = "Hello World!";
        string theTle = "Message";

        public ContextMenu()
        {
            InitializeComponent();
        }

        public bool ctrlKeyIsDownSetter
        {
            get { return ctrlKeyIsDown; }   // get method
            set { ctrlKeyIsDown = value; }  // set method
        }

        private void ContextMenu_Load(object sender, EventArgs e)
        {
            textEditorObj = new TextEditor(); //text editor object instantiation
        }

        private void theContextMenu_Deactivate(object sender, EventArgs e)
        {
            ctrlKeyIsDown = false;
            this.Close();
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            /*string theMessage = "Hello World!";
            string theTitle = "MessageBox";
            MessageBox.Show(this, theMessage, theTitle);*/
            //textEditorObj.RichTextBoxSetterGetter.Copy();

            //textEditorObj.copyToolStripMenuItem1_Click(sender, e);
            //copyToolStripMenuItem1_Click(sender, )

            MessageBox.Show(TextEditor.testingObject, theMsg, theTle);
            //this.Close();
            //textEditorObj.ShowDialog();
        }

        private void pasteBtn_Click(object sender, EventArgs e)
        {
            /*theRichTextBoxObj = new TextEditor();
            RichTextBox myTextBox = theRichTextBoxObj.RichTextBoxSetterGetter;
            myTextBox.Paste();*/
            //textEditorObj.RichTextBoxSetterGetter.Paste();

            //textEditorObj.pasteToolStripMenuItem1_Click(sender, e);
            //TextEditor.testingObject.RichTextBoxSetterGetter.Text += " Appended text";
            TextEditor.testingObject.RichTextBoxSetterGetter.AppendText("chicken yes!");

            this.Close();
        }

        private void cutBtn_Click(object sender, EventArgs e)
        {
            textEditorObj.RichTextBoxSetterGetter.Cut();
            this.Close();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            // delete selected text
            textEditorObj.RichTextBoxSetterGetter.SelectedText = "";
            textEditorObj.RichTextBoxSetterGetter.Focus();
            this.Close();
        }

        private void selectAllBtn_Click(object sender, EventArgs e)
        {
            textEditorObj.RichTextBoxSetterGetter.SelectAll();
            this.Close();
        }

        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            // clear the rich text box
            textEditorObj.RichTextBoxSetterGetter.Clear();
            textEditorObj.RichTextBoxSetterGetter.Focus();
            this.Close();
        }
    }
}
