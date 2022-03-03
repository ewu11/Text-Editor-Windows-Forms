using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor
{
    public partial class PopupMenu : Form
    {
        //global variables
        //frmEditor frmEditorObjLocal;
        //RichTextBox theRTB;
        private frmEditor parentFormObj;

        public PopupMenu() //unused, 'cuz doesn't have parent's object info
        {
            InitializeComponent();
        }

        public PopupMenu(frmEditor parentForm) //used; 'cuz have required parents obj info
        {
            parentFormObj = parentForm;
            InitializeComponent();
        }

        private void PopupMenu_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false; //close the popup menu

            parentFormObj.toolStripStatusLabelSetterGetter.Text = "...";
        }

        public Point SetPopupLocation(Screen screen, Form form, Point initPosition)
        {
            var p = new Point();
            var wrkArea = screen.WorkingArea;
            p.X = wrkArea.Right - (initPosition.X + form.Width);
            p.Y = wrkArea.Bottom - (initPosition.Y + form.Height);
            p.X = p.X < 0 ? wrkArea.Right - form.Width : initPosition.X;
            p.Y = p.Y < 0 ? wrkArea.Bottom - form.Height : initPosition.Y;
            return p;
        }

        public Point SetCursorLocation(Point thePopupLocation)
        {
            Point newCursorPoint = new Point();

            int popupWidth = this.Width;
            int popupHeight = this.Height;

            newCursorPoint.X = thePopupLocation.X + (popupWidth / 2);
            newCursorPoint.Y = thePopupLocation.Y + (popupHeight / 2);

            return newCursorPoint;
        }

        public void PopUpMenuFunctions(RichTextBox theRTB, string theFunction)
        {
            //frmEditor frmEditorObjLocal = new frmEditor();
            //RichTextBox theRTB = frmEditorObjLocal.richTextBoxSetterGetter;

            if (theFunction == "cut")
            {
                theRTB.Cut();
                this.Visible = false;
            }
            if (theFunction == "copy")
            {
                theRTB.Copy();
            }
            if (theFunction == "paste")
            {
                theRTB.Paste();
                this.Visible = false;
            }
            if (theFunction == "delete")
            {
                theRTB.SelectedText = "";
                theRTB.Focus();
                this.Visible = false;
            }
            if (theFunction == "selectAll")
            {
                theRTB.SelectAll();
                this.Visible = false;
            }
            if (theFunction == "clearAll")
            {
                theRTB.Clear();
                theRTB.Focus();
                this.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopUpMenuFunctions(parentFormObj.richTextBoxSetterGetter, "cut");
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PopUpMenuFunctions(parentFormObj.richTextBoxSetterGetter, "copy");
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PopUpMenuFunctions(parentFormObj.richTextBoxSetterGetter, "paste");
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PopUpMenuFunctions(parentFormObj.richTextBoxSetterGetter, "delete");
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PopUpMenuFunctions(parentFormObj.richTextBoxSetterGetter, "selectAll");
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PopUpMenuFunctions(parentFormObj.richTextBoxSetterGetter, "clearAll");
            this.Visible = false;
        }

        private void PopupMenu_Activated(object sender, EventArgs e)
        {
            //to maintain highlighted text
            parentFormObj.richTextBoxSetterGetter.HideSelection = false;
        }
    }
}
