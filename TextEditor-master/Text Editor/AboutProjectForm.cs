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
    public partial class AboutProjectForm : Form
    {
        //global variable(s)
        string newLine = Environment.NewLine; //equivalent -> "\n"

        public AboutProjectForm()
        {
            InitializeComponent();
        }

        private void AboutProjectForm_Load(object sender, EventArgs e)
        {
            //----SET LABEL'S VALUES HERE ONLY----
            string description = "An open source Text Editor program, done by hjohnson12, sam-wheat, yoshiask, and RobbyRobbyRobby." + newLine +
                                 "This version is a Final Year Project coded by Eliasaph Wan Uyo(1181101266) in order to test user reactions to different styles of context menus." + newLine + newLine +
                                 "To test the different context menu layouts, simply choose the context menus from the 'Choose Context Menu..' panel in the Text Editor program. Next, simply right click in the text box area to open the selected context menu.";

            string projectName = "Text Editor - Windows Forms";

            string version = "6.1.6.0";

            string oriCopyright = "©️ 2019 hjohnson12";

            string copyright = "©️ 2022 Eliasaph Wan Uyo and ©️ Multimedia University(MMU)";

            string companyName = "Multimedia University Cyberjaya(MMU)";

            string license = "Open Source MIT License - https://opensource.org/licenses/MIT";

            string linkToProject = "https://github.com/hjohnson12/TextEditor";
            //----SET LABEL'S VALUES HERE ONLY----

            //once this form is called/ loaded, insert labels and values accordingly
            //--manage logo picture--
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox1.Image = global::Text_Editor.Properties.Resources.MMU_New_logo_png;
            pictureBox1.Location = new System.Drawing.Point(3, 3);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            //--manage logo picture--

            descriptionTxtBox.Text = description;

            projNameVal.Text = projectName;

            versionVal.Text = version;

            oriCopyrightVal.Text = oriCopyright;

            copyrightVal.Text = copyright;

            companyNameVal.Text = companyName;

            licenseVal.Text = license;
            //to add onClick event
            licenseVal.Click += delegate { System.Diagnostics.Process.Start("https://opensource.org/licenses/MIT"); };

            linkToProjVal.Text = linkToProject;
            //to add onClick event
            linkToProjVal.Click += delegate { System.Diagnostics.Process.Start("https://github.com/hjohnson12/TextEditor"); };
        }

        //--to handle font when mouse hover--
        private void licenseVal_MouseEnter(object sender, EventArgs e)
        {
            licenseVal.Font = new Font(licenseVal.Font.Name, licenseVal.Font.SizeInPoints, FontStyle.Underline);
        }

        private void licenseVal_MouseLeave(object sender, EventArgs e)
        {
            licenseVal.Font = new Font(licenseVal.Font.Name, licenseVal.Font.SizeInPoints, FontStyle.Regular);
        }
        //--to handle font when mouse hover--

        //--to handle font when mouse hover--
        private void linkToProjVal_MouseEnter(object sender, EventArgs e)
        {
            linkToProjVal.Font = new Font(licenseVal.Font.Name, licenseVal.Font.SizeInPoints, FontStyle.Underline);
        }

        private void linkToProjVal_MouseLeave(object sender, EventArgs e)
        {
            linkToProjVal.Font = new Font(licenseVal.Font.Name, licenseVal.Font.SizeInPoints, FontStyle.Regular);
        }
        //--to handle font when mouse hover--
    }
}
