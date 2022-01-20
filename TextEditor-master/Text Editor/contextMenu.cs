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
    public partial class contextMenu : Form
    {
        //global static variable
        public static bool isOpen = false; //context menu is closed by default

        public contextMenu()
        {
            InitializeComponent();
        }

        private void contextMenuWindow_Deactivate(object sender, EventArgs e)
        {
            //close the context menu window when lose focus
            this.Close();
        }
    }
}
