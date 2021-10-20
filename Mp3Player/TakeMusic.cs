using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Mp3Player
{
    public partial class TakeMusic : Form
    {
        DJ_SHARP Root;
        ActionsMain act = new ActionsMain();
        string[] taked_file;

        #region MouseMoving
        public const int WM_NCLBUTTONDOWN = 0XA1;
        public const int HT_CAPTION = 0X2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        public TakeMusic(DJ_SHARP Root)
        {
            InitializeComponent();
            this.Root = Root;
        }

        private void TakeMusic_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Panel_Moving(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Label_moving(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #region OpenEffect
        private void OpenEffect_Click(object sender, EventArgs e) { BoxLineEffect.Text = act.TakeFile(); }
        private void OpenEffect2_Click(object sender, EventArgs e) { BoxLineEffect2.Text = act.TakeFile(); }
        private void OpenEffect3_Click(object sender, EventArgs e) { BoxLineEffect3.Text = act.TakeFile(); }
        private void OpenEffect4_Click(object sender, EventArgs e) { BoxLineEffect4.Text = act.TakeFile(); }
        private void OpenEffect5_Click(object sender, EventArgs e) { BoxLineEffect5.Text = act.TakeFile(); }
        private void OpenEffect6_Click(object sender, EventArgs e) { BoxLineEffect6.Text = act.TakeFile(); }
        private void OpenEffect7_Click(object sender, EventArgs e) { BoxLineEffect7.Text = act.TakeFile(); }
        private void OpenEffect8_Click(object sender, EventArgs e) { BoxLineEffect8.Text = act.TakeFile(); }
        private void OpenEffect9_Click(object sender, EventArgs e) { BoxLineEffect9.Text = act.TakeFile(); }
        private void OpenEffect10_Click(object sender, EventArgs e) { BoxLineEffect10.Text = act.TakeFile(); }
        private void OpenEffect11_Click(object sender, EventArgs e) { BoxLineEffect11.Text = act.TakeFile(); }
        private void OpenEffect12_Click(object sender, EventArgs e) { BoxLineEffect12.Text = act.TakeFile(); }
        private void OpenEffect13_Click(object sender, EventArgs e) { BoxLineEffect13.Text = act.TakeFile(); }
        private void OpenEffect14_Click(object sender, EventArgs e) { BoxLineEffect14.Text = act.TakeFile(); }
        private void OpenEffect15_Click(object sender, EventArgs e) { BoxLineEffect15.Text = act.TakeFile(); }
        private void OpenEffect16_Click(object sender, EventArgs e) { BoxLineEffect16.Text = act.TakeFile(); }
        private void OpenEffect17_Click(object sender, EventArgs e) { BoxLineEffect17.Text = act.TakeFile(); }
        private void OpenEffect18_Click(object sender, EventArgs e) { BoxLineEffect18.Text = act.TakeFile(); }
        private void OpenEffect19_Click(object sender, EventArgs e) { BoxLineEffect19.Text = act.TakeFile(); }
        private void OpenEffect20_Click(object sender, EventArgs e) { BoxLineEffect20.Text = act.TakeFile(); }
        #endregion

        #region DragNDrop
        private void BoxLineEffect_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect.Text = taked_file[0];
        }

        private void BoxLineEffect2_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect2.Text = taked_file[0];
        }

        private void BoxLineEffect3_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect3.Text = taked_file[0];
        }

        private void BoxLineEffect4_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect4.Text = taked_file[0];
        }

        private void BoxLineEffect5_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect5.Text = taked_file[0];
        }

        private void BoxLineEffect6_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect6.Text = taked_file[0];
        }

        private void BoxLineEffect7_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect7.Text = taked_file[0];
        }

        private void BoxLineEffect8_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect8.Text = taked_file[0];
        }

        private void BoxLineEffect9_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect9.Text = taked_file[0];
        }

        private void BoxLineEffect10_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect10.Text = taked_file[0];
        }

        private void BoxLineEffect_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect5_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect6_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect7_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect8_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect9_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect10_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect11_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect11.Text = taked_file[0];
        }

        private void BoxLineEffect11_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect12_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect12.Text = taked_file[0];
        }

        private void BoxLineEffect12_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect13_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect13.Text = taked_file[0];
        }

        private void BoxLineEffect13_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect14_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect14.Text = taked_file[0];
        }

        private void BoxLineEffect14_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect15_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect15.Text = taked_file[0];
        }

        private void BoxLineEffect15_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect16_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect16.Text = taked_file[0];
        }

        private void BoxLineEffect16_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect17_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect17.Text = taked_file[0];
        }

        private void BoxLineEffect17_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect18_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect18.Text = taked_file[0];
        }

        private void BoxLineEffect18_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect19_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect19.Text = taked_file[0];
        }

        private void BoxLineEffect19_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BoxLineEffect20_DragDrop(object sender, DragEventArgs e)
        {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            BoxLineEffect20.Text = taked_file[0];
        }

        private void BoxLineEffect20_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }
        #endregion

        #region BoxLine_TextChanged
        private void BoxLineEffect_TextChanged(object sender, EventArgs e) {
            Root.EffectName.Text = Path.GetFileName(BoxLineEffect.Text);
        }

        private void BoxLineEffect2_TextChanged(object sender, EventArgs e) {
            Root.EffectName2.Text = Path.GetFileName(BoxLineEffect2.Text);
        }

        private void BoxLineEffect3_TextChanged(object sender, EventArgs e) {
            Root.EffectName3.Text = Path.GetFileName(BoxLineEffect3.Text);
        }

        private void BoxLineEffect8_TextChanged(object sender, EventArgs e) {
            Root.EffectName8.Text = Path.GetFileName(BoxLineEffect8.Text);
        }

        private void BoxLineEffect5_TextChanged(object sender, EventArgs e) {
            Root.EffectName5.Text = Path.GetFileName(BoxLineEffect5.Text);
        }

        private void BoxLineEffect6_TextChanged(object sender, EventArgs e) {
            Root.EffectName6.Text = Path.GetFileName(BoxLineEffect6.Text);
        }

        private void BoxLineEffect7_TextChanged(object sender, EventArgs e) {
            Root.EffectName7.Text = Path.GetFileName(BoxLineEffect7.Text);
        }

        private void BoxLineEffect4_TextChanged(object sender, EventArgs e) {
            Root.EffectName4.Text = Path.GetFileName(BoxLineEffect4.Text);
        }

        private void BoxLineEffect9_TextChanged(object sender, EventArgs e) {
            Root.EffectName9.Text = Path.GetFileName(BoxLineEffect9.Text);
        }

        private void BoxLineEffect10_TextChanged(object sender, EventArgs e) {
            Root.EffectName10.Text = Path.GetFileName(BoxLineEffect10.Text);
        }

        private void BoxLineEffect11_TextChanged(object sender, EventArgs e) {
            Root.EffectName11.Text = Path.GetFileName(BoxLineEffect11.Text);
        }

        private void BoxLineEffect12_TextChanged(object sender, EventArgs e) {
            Root.EffectName12.Text = Path.GetFileName(BoxLineEffect12.Text);
        }

        private void BoxLineEffect13_TextChanged(object sender, EventArgs e) {
            Root.EffectName13.Text = Path.GetFileName(BoxLineEffect13.Text);
        }

        private void BoxLineEffect14_TextChanged(object sender, EventArgs e) {
            Root.EffectName14.Text = Path.GetFileName(BoxLineEffect14.Text);
        }

        private void BoxLineEffect15_TextChanged(object sender, EventArgs e) {
            Root.EffectName15.Text = Path.GetFileName(BoxLineEffect15.Text);
        }

        private void BoxLineEffect16_TextChanged(object sender, EventArgs e) {
            Root.EffectName16.Text = Path.GetFileName(BoxLineEffect16.Text);
        }

        private void BoxLineEffect17_TextChanged(object sender, EventArgs e) {
            Root.EffectName17.Text = Path.GetFileName(BoxLineEffect17.Text);
        }

        private void BoxLineEffect18_TextChanged(object sender, EventArgs e) {
            Root.EffectName18.Text = Path.GetFileName(BoxLineEffect18.Text);
        }

        private void BoxLineEffect19_TextChanged(object sender, EventArgs e) {
            Root.EffectName19.Text = Path.GetFileName(BoxLineEffect19.Text);
        }

        private void BoxLineEffect20_TextChanged(object sender, EventArgs e) {
            Root.EffectName20.Text = Path.GetFileName(BoxLineEffect20.Text);
        }
        #endregion

        private void MinimizeWindow_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }
    }
}
