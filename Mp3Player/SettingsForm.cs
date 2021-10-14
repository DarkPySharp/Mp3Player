using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Mp3Player
{
    public partial class SettingsForm : Form
    {
        // mouse moving
        public const int WM_NCLBUTTONDOWN = 0XA1;
        public const int HT_CAPTION = 0X2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        // mouse moving end

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e) { }

        private void delayTransition_TextChanged(object sender, EventArgs e)
        {
            try { DJ_SHARP.delayTransition = Convert.ToInt32(delayTransition.Text); } 
            catch { delayTransition.Text = "300"; }
        }

        private void delayUpdateProgress_TextChanged(object sender, EventArgs e)
        {
            try { DJ_SHARP.delayUpdateProgress = Convert.ToInt32(delayUpdateProgress.Text); }
            catch { delayUpdateProgress.Text = "120"; }
        }
        
        private void SaveInFile_Click(object sender, EventArgs e)
        {
            using (RegistryKey regEdit = Registry.CurrentUser.CreateSubKey(@"Software\DJ-Sharp")) {
                try {
                    int TrFl;
                    int Smooth;

                    if (MultiMusicRadio.Checked)
                        TrFl = 1;
                    else
                        TrFl = 0;

                    if (SmoothStartStopCheck.Checked)
                        Smooth = 1;
                    else
                        Smooth = 0;

                    regEdit.SetValue("delayTransition", DJ_SHARP.delayTransition, RegistryValueKind.String);
                    regEdit.SetValue("delayUpdateProgress", DJ_SHARP.delayUpdateProgress, RegistryValueKind.String);
                    regEdit.SetValue("StandartVolume", StandartVolume.Text, RegistryValueKind.String);
                    regEdit.SetValue("CheckedStatus", TrFl, RegistryValueKind.String);
                    regEdit.SetValue("Smoothing", Smooth, RegistryValueKind.String);

                } catch (Exception error) { MessageBox.Show(error.Message, "DJ_SHARP", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void closeButton_Click(object sender, EventArgs e) => Hide();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void LabelTag_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void SetSettings(string _delayTransition, string _delayUpdateProgress, string _StandartVolume, bool CheckedStatus, bool CheckedStatusSmooth)
        {
            delayTransition.Text = _delayTransition;
            delayUpdateProgress.Text = _delayUpdateProgress;
            StandartVolume.Text = _StandartVolume;
            MultiMusicRadio.Checked = CheckedStatus;
            SmoothStartStopCheck.Checked = CheckedStatusSmooth;
        }
    }
}
