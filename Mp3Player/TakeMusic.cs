using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Mp3Player
{
    public partial class TakeMusic : Form
    {
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

        public TakeMusic()
        {
            InitializeComponent();
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

        #region BoxLineEffect
        public string text_BoxLineEffect { get { return BoxLineEffect.Text; } }
        public string text_BoxLineEffect2 { get { return BoxLineEffect2.Text; } }
        public string text_BoxLineEffect3 { get { return BoxLineEffect3.Text; } }
        public string text_BoxLineEffect4 { get { return BoxLineEffect4.Text; } }
        public string text_BoxLineEffect5 { get { return BoxLineEffect5.Text; } }
        public string text_BoxLineEffect6 { get { return BoxLineEffect6.Text; } }
        public string text_BoxLineEffect7 { get { return BoxLineEffect7.Text; } }
        public string text_BoxLineEffect8 { get { return BoxLineEffect8.Text; } }
        public string text_BoxLineEffect9 { get { return BoxLineEffect9.Text; } }
        public string text_BoxLineEffect10 { get { return BoxLineEffect10.Text; } }
        public string text_BoxLineEffect11 { get { return BoxLineEffect11.Text; } }
        public string text_BoxLineEffect12 { get { return BoxLineEffect12.Text; } }
        public string text_BoxLineEffect13 { get { return BoxLineEffect13.Text; } }
        public string text_BoxLineEffect14 { get { return BoxLineEffect14.Text; } }
        public string text_BoxLineEffect15 { get { return BoxLineEffect15.Text; } }
        public string text_BoxLineEffect16 { get { return BoxLineEffect16.Text; } }
        public string text_BoxLineEffect17 { get { return BoxLineEffect17.Text; } }
        public string text_BoxLineEffect18 { get { return BoxLineEffect18.Text; } }
        public string text_BoxLineEffect19 { get { return BoxLineEffect19.Text; } }
        public string text_BoxLineEffect20 { get { return BoxLineEffect20.Text; } }
        #endregion

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
    }
}
