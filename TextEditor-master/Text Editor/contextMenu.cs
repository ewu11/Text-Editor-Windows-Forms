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
        //TextEditor theRichTextBoxObj;

        public ContextMenu()
        {
            InitializeComponent();
        }

        public bool ctrlKeyIsDownSetter
        {
            get { return ctrlKeyIsDown; }   // get method
            set { ctrlKeyIsDown = value; }  // set method
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
            /*theRichTextBoxObj = new TextEditor();
            RichTextBox myTextBox = theRichTextBoxObj.RichTextBoxSetterGetter;
            myTextBox.Copy();*/
            string theMsg = "Hello World!";
            string theTle = "Message";
            MessageBox.Show(theMsg, theTle, MessageBoxButtons.OKCancel);
        }

        private void pasteBtn_Click(object sender, EventArgs e)
        {
            /*theRichTextBoxObj = new TextEditor();
            RichTextBox myTextBox = theRichTextBoxObj.RichTextBoxSetterGetter;
            myTextBox.Paste();*/
        }
    }
}
