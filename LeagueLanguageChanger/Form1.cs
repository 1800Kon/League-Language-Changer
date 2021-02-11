using System;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace LeagueLanguageChanger
{
    public partial class Form1 : Form
    {
        String Filepath = null;
        String LanguageArg = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateShortcut();
        }

        private void CreateShortcut()
        {
            if (LanguageArg != null)
            {
                if(Filepath != null)
                {
                    object shDesktop = (object)"Desktop";
                    WshShell shell = new WshShell();
                    string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\" + LanguageArg + ".lnk";
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                    shortcut.Arguments = "--locale=" + LanguageArg;
                    shortcut.Description = "League shortcut to launch with certain language";
                    shortcut.TargetPath = Filepath;
                    shortcut.Save();
                }
                else
                {
                    button1.Text = "Set exe";
                }
               
            }
            else
            {
                button1.Text = "Set lang";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                Filepath = choofdlog.FileName;
                button2.Text = "Executable set";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LanguageArg = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
        }
    }
}
