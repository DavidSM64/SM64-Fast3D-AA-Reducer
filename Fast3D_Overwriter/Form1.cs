using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fast3D_Overwriter
{
    public partial class MainForm : Form
    {
        private byte[] rom;
        private OpenFileDialog openFileDialog;
        private Fast3D_Overwrite overwrite;

        public MainForm()
        {
            InitializeComponent();

            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "N64 ROM (*.z64, *.v64, *.n64)|*.z64;*.v64;*.n64|All files (*.*)|*.*";

            overwrite = new Fast3D_Overwrite();
            buttonReduce.Enabled = false;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    romPathTextBox.Text = openFileDialog.FileName;
                    rom = File.ReadAllBytes(openFileDialog.FileName);

                    if (overwrite.DoesROMHaveVanillaFast3D(rom))
                    {
                        labelStatusText.Text = "Status: Ready.";
                        buttonReduce.Enabled = true;
                    }
                    else if (overwrite.DoesROMHaveModdedFast3D(rom))
                    {
                        labelStatusText.Text = "Status: This ROM already has the modded microcode.";
                        buttonReduce.Enabled = false;
                    }
                    else
                    {
                        labelStatusText.Text = "Status: This ROM is not compatible.";
                        buttonReduce.Enabled = false;
                    }
                }
                catch (SecurityException ex)
                {
                   MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" + $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void buttonReduce_Click(object sender, EventArgs e)
        {
            labelStatusText.Text = "Status: Creating a new ROM, please wait...";
            overwrite.Overwrite(ref rom);
            string newFileName = romPathTextBox.Text.Insert(romPathTextBox.Text.LastIndexOf('.'), ".ra");
            string displayName = newFileName.Replace('\\', '/');
            displayName = displayName.Substring(displayName.LastIndexOf('/') + 1);
            labelStatusText.Text = "Status: New ROM saved as: " + displayName;
            File.WriteAllBytes(newFileName, rom);
            buttonReduce.Enabled = false;
        }
    }
}
