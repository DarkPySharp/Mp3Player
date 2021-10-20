using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WMPLib;
using Microsoft.Win32;

namespace Mp3Player
{
    public partial class DJ_SHARP : Form
    {
        #region variable
        WindowsMediaPlayer MainMedia = new WindowsMediaPlayer();
        WindowsMediaPlayer SecondMedia = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect2 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect3 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect4 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect5 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect6 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect7 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect8 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect9 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect10 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect11 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect12 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect13 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect14 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect15 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect16 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect17 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect18 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect19 = new WindowsMediaPlayer();
        WindowsMediaPlayer MediaEffect20 = new WindowsMediaPlayer();

        bool musicIsPlaying = false;
        bool MainMusicIsInited = false;
        bool SecondMusicIsInited = false;
        bool IsInitedEffect = false;
        bool IsInitedEffect2 = false;
        bool IsInitedEffect3 = false;
        bool IsInitedEffect4 = false;
        bool IsInitedEffect5 = false;
        bool IsInitedEffect6 = false;
        bool IsInitedEffect7 = false;
        bool IsInitedEffect8 = false;
        bool IsInitedEffect9 = false;
        bool IsInitedEffect10 = false;
        bool IsInitedEffect11 = false;
        bool IsInitedEffect12 = false;
        bool IsInitedEffect13 = false;
        bool IsInitedEffect14 = false;
        bool IsInitedEffect15 = false;
        bool IsInitedEffect16 = false;
        bool IsInitedEffect17 = false;
        bool IsInitedEffect18 = false;
        bool IsInitedEffect19 = false;
        bool IsInitedEffect20 = false;
        public static bool transisting = false;

        TakeMusic effectsApplication;
        SettingsForm settingsApp = new SettingsForm();
        ActionsMain act = new ActionsMain();
        InteregetArgs args = new InteregetArgs();

        public static double time = 0;
        public static double timeSecond = 0;
        public static double timeEffect = 0;
        public static double timeEffect2 = 0;
        public static double timeEffect3 = 0;
        public static double timeEffect4 = 0;
        public static double timeEffect5 = 0;
        public static double timeEffect6 = 0;
        public static double timeEffect7 = 0;
        public static double timeEffect8 = 0;
        public static double timeEffect9 = 0;
        public static double timeEffect10 = 0;
        public static double timeEffect11 = 0;
        public static double timeEffect12 = 0;
        public static double timeEffect13 = 0;
        public static double timeEffect14 = 0;
        public static double timeEffect15 = 0;
        public static double timeEffect16 = 0;
        public static double timeEffect17 = 0;
        public static double timeEffect18 = 0;
        public static double timeEffect19 = 0;
        public static double timeEffect20 = 0;
        public static double OffTime = 0;
        public static int MainVolume = 100;
        public static int delayTransition = 0;
        public static int delayUpdateProgress = 120;

        float absoluteMouse;
        float calcFactor;
        float relativeMouse;

        string[] taked_file;
        #endregion

        #region mouse moving
        public const int WM_NCLBUTTONDOWN = 0XA1;
        public const int HT_CAPTION = 0X2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        public DJ_SHARP() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e) {
            using (RegistryKey regEdit = Registry.CurrentUser.OpenSubKey(@"Software\DJ-Sharp", false)) {
                string REGdelayTransition = regEdit?.GetValue("delayTransition")?.ToString();
                string REGdelayUpdateProgress = regEdit?.GetValue("delayUpdateProgress")?.ToString();
                string REGStandartVolume = regEdit?.GetValue("StandartVolume")?.ToString();
                string REGCheckedStatus = regEdit?.GetValue("CheckedStatus")?.ToString();
                string REGSmoothing = regEdit?.GetValue("Smoothing")?.ToString();

                try {
                    bool CheckStateMany;
                    bool CheckStateSmooth;

                    delayTransition = Convert.ToInt32(REGdelayTransition);
                    delayUpdateProgress = Convert.ToInt32(REGdelayUpdateProgress);

                    if (Convert.ToInt32(REGStandartVolume) < 100)
                        MainVolume = Convert.ToInt32(REGStandartVolume);
                    else
                        MainVolume = 100;

                    switch (REGCheckedStatus) {
                        case "1":
                            CheckStateMany = true; 
                            break;
                        default:
                            CheckStateMany = false; 
                            break;
                    }

                    switch (REGSmoothing) {
                        case "1":
                            CheckStateSmooth = true;
                            break;
                        default:
                            CheckStateSmooth = false;
                            break;
                    }

                    settingsApp.SetSettings(REGdelayTransition, REGdelayUpdateProgress, REGStandartVolume, CheckStateMany, CheckStateSmooth);

                    VolumeMain.Value = MainVolume;
                    VolumeEffects.Value = MainVolume;
                    timer1.Interval = delayUpdateProgress;
                } catch { }
            }

            effectsApplication = new TakeMusic(this);
        }

        #region MainMusic
        private void OpenMainMusic_Click(object sender, EventArgs e) {
            string NewMusic = act.TakeFile();
            if (NewMusic != "")
                MainMusic.Text = NewMusic;
        }
        private void OpenMainMusicSecond_Click(object sender, EventArgs e) {
            string NewMusic = act.TakeFile();
            if (NewMusic != "")
                MainMusicSecond.Text = NewMusic;
        }
        // main
        private void PlayButton_Click(object sender, EventArgs e) {
            if (MainMusic.Text != "") {
                MainMedia.URL = MainMusic.Text;

                if (!musicIsPlaying) {
                    MainMedia.controls.currentPosition = time;
                    MainMedia.settings.volume = MainVolume;

                    if (!settingsApp.SmoothStartStopCheck.Checked)
                        MainMedia.controls.play();
                    else
                        MP3Music.smoothStart(MainMedia);

                    musicIsPlaying = true;
                    MainMusicIsInited = true;
                    MP3Music.ReHideWidgets(PauseButton, PlayButton);
                } else {
                    args.On = MainMedia;
                    args.Off = SecondMedia;
                    MP3Music.treads(args);
                    MP3Music.ReHideWidgets(PauseButton, PlayButton);
                    MP3Music.ReHideWidgets(PlayButtonSecond, PauseButtonSecond);
                }
            }
        }

        private async void PouseButton_Click(object sender, EventArgs e) {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MainMedia.controls.pause();
            else
                await MP3Music.smoothStop(MainMedia, PauseButton);

            time = MainMedia.controls.currentPosition;
            musicIsPlaying = false;
            MP3Music.ReHideWidgets(PlayButton, PauseButton);
        }

        private void resetMainMusic_Click(object sender, EventArgs e) {
            MainMedia.controls.currentPosition = 0;
            time = 0;
        }

        private void MainMusic_DragDrop(object sender, DragEventArgs e) {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            MainMusic.Text = taked_file[0];
        }

        private void MainMusic_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void progressBarMainMusic_Click(object sender, EventArgs e) {
            if (MainMusic.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarMainMusic.Bounds.X);
                calcFactor = progressBarMainMusic.Width / (float)progressBarMainMusic.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarMainMusic.Value = Convert.ToInt32(relativeMouse);

                if (MainMusicIsInited)
                    MainMedia.controls.currentPosition = relativeMouse;

                time = Convert.ToInt32(relativeMouse);
            }
        }

        private void MainMusic_TextChanged(object sender, EventArgs e) {
            if (MainMusicIsInited) {
                time = 0;
                MainMedia.controls.pause();
                MainMedia.controls.currentPosition = 0;
                musicIsPlaying = false;
                MP3Music.ReHideWidgets(PlayButton, PauseButton);
            }
        }
        // second
        private void PlayButtonSecond_Click(object sender, EventArgs e) {
            if (MainMusicSecond.Text != "") {
                SecondMedia.URL = MainMusicSecond.Text;

                if (!musicIsPlaying) {
                    SecondMedia.controls.currentPosition = timeSecond;
                    SecondMedia.settings.volume = MainVolume;

                    if (!settingsApp.SmoothStartStopCheck.Checked)
                        SecondMedia.controls.play();
                    else
                        MP3Music.smoothStart(SecondMedia);

                    musicIsPlaying = true;
                    SecondMusicIsInited = true;
                    MP3Music.ReHideWidgets(PauseButtonSecond, PlayButtonSecond);
                } else {
                    args.Off = MainMedia;
                    args.On = SecondMedia;
                    MP3Music.treads(args);
                    MP3Music.ReHideWidgets(PauseButtonSecond, PlayButtonSecond);
                    MP3Music.ReHideWidgets(PlayButton, PauseButton);
                }
            }
        }
        
        private async void PauseButtonSecond_Click(object sender, EventArgs e) {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                SecondMedia.controls.pause();
            else
                await MP3Music.smoothStop(SecondMedia, PauseButtonSecond);

            timeSecond = SecondMedia.controls.currentPosition;
            musicIsPlaying = false;
            MP3Music.ReHideWidgets(PlayButtonSecond, PauseButtonSecond);
        }

        private void ResetSecondMusic_Click(object sender, EventArgs e) {
            SecondMedia.controls.currentPosition = 0;
            timeSecond = 0;
        }

        private void MainMusicSecond_DragDrop(object sender, DragEventArgs e) {
            taked_file = (string[])e.Data.GetData(DataFormats.FileDrop);
            MainMusicSecond.Text = taked_file[0];
        }

        private void MainMusicSecond_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void progressBarMainMusicSecond_Click(object sender, EventArgs e) {
            absoluteMouse = (PointToClient(MousePosition).X - progressBarMainMusicSecond.Bounds.X);
            calcFactor = progressBarMainMusicSecond.Width / (float)progressBarMainMusicSecond.Maximum;
            relativeMouse = absoluteMouse / calcFactor;

            progressBarMainMusicSecond.Value = Convert.ToInt32(relativeMouse);

            if (SecondMusicIsInited)
                SecondMedia.controls.currentPosition = relativeMouse;

            timeSecond = Convert.ToInt32(relativeMouse);
        }

        private void SecondMusic_TextChanged(object sender, EventArgs e) {
            if (SecondMusicIsInited) {
                timeSecond = 0;
                SecondMedia.controls.pause();
                SecondMedia.controls.currentPosition = 0;
                musicIsPlaying = false;
                MP3Music.ReHideWidgets(PlayButtonSecond, PauseButtonSecond);
            }
        }
        #endregion MainMusic

        #region Effect
        private void playEffect_Click(object sender, EventArgs e)
        {
            if (effectsApplication.BoxLineEffect.Text != "")
            {
                pauseEffects(1);
                MediaEffect.URL = effectsApplication.BoxLineEffect.Text;
                MediaEffect.controls.currentPosition = timeEffect;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect);

                IsInitedEffect = true;
                MP3Music.ReHideWidgets(pauseEffect, playEffect);
            }
        }

        private void playEffect2_Click(object sender, EventArgs e)
        {
            if (effectsApplication.BoxLineEffect2.Text != "")
            {
                pauseEffects(2);
                MediaEffect2.URL = effectsApplication.BoxLineEffect2.Text;
                MediaEffect2.controls.currentPosition = timeEffect2;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect2.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect2);

                IsInitedEffect2 = true;
                MP3Music.ReHideWidgets(pauseEffect2, playEffect2);
            }
        }

        private void playEffect3_Click(object sender, EventArgs e)
        {
            if (effectsApplication.BoxLineEffect3.Text != "")
            {
                pauseEffects(3);
                MediaEffect3.URL = effectsApplication.BoxLineEffect3.Text;
                MediaEffect3.controls.currentPosition = timeEffect3;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect3.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect3);

                IsInitedEffect3 = true;
                MP3Music.ReHideWidgets(pauseEffect3, playEffect3);
            }
        }

        private void playEffect4_Click(object sender, EventArgs e)
        {
            if (effectsApplication.BoxLineEffect4.Text != "")
            {
                pauseEffects(4);
                MediaEffect4.URL = effectsApplication.BoxLineEffect4.Text;
                MediaEffect4.controls.currentPosition = timeEffect4;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect4.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect4);

                IsInitedEffect4 = true;
                MP3Music.ReHideWidgets(pauseEffect4, playEffect4);
            }
        }

        private void playEffect5_Click(object sender, EventArgs e)
        {
            if (effectsApplication.BoxLineEffect5.Text != "")
            {
                pauseEffects(5);
                MediaEffect5.URL = effectsApplication.BoxLineEffect5.Text;
                MediaEffect5.controls.currentPosition = timeEffect5;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect5.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect5);

                IsInitedEffect5 = true;
                MP3Music.ReHideWidgets(pauseEffect5, playEffect5);
            }
        }

        private void playEffect6_Click(object sender, EventArgs e)
        {
            if (effectsApplication.BoxLineEffect6.Text != "")
            {
                pauseEffects(6);
                MediaEffect6.URL = effectsApplication.BoxLineEffect6.Text;
                MediaEffect6.controls.currentPosition = timeEffect6;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect6.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect6);

                IsInitedEffect6 = true;
                MP3Music.ReHideWidgets(pauseEffect6, playEffect6);
            }
        }

        private void playEffect7_Click(object sender, EventArgs e)
        {
            if (effectsApplication.BoxLineEffect7.Text != "")
            {
                pauseEffects(7);
                MediaEffect7.URL = effectsApplication.BoxLineEffect8.Text;
                MediaEffect7.controls.currentPosition = timeEffect7;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect7.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect7);

                IsInitedEffect7 = true;
                MP3Music.ReHideWidgets(pauseEffect7, playEffect7);
            }
        }

        private void playEffect8_Click(object sender, EventArgs e)
        {
            if (effectsApplication.BoxLineEffect8.Text != "")
            {
                pauseEffects(8);
                MediaEffect8.URL = effectsApplication.BoxLineEffect8.Text;
                MediaEffect8.controls.currentPosition = timeEffect8;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect8.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect8);

                IsInitedEffect8 = true;
                MP3Music.ReHideWidgets(pauseEffect8, playEffect8);
            }
        }

        private void playEffect9_Click(object sender, EventArgs e)
        {
            if (effectsApplication.BoxLineEffect9.Text != "")
            {
                pauseEffects(9);
                MediaEffect9.URL = effectsApplication.BoxLineEffect9.Text;
                MediaEffect9.controls.currentPosition = timeEffect9;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect9.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect9);

                IsInitedEffect9 = true;
                MP3Music.ReHideWidgets(pauseEffect9, playEffect9);
            }
        }

        private void playEffect10_Click(object sender, EventArgs e)
        {
            if (effectsApplication.BoxLineEffect10.Text != "")
            {
                pauseEffects(10);
                MediaEffect10.URL = effectsApplication.BoxLineEffect10.Text;
                MediaEffect10.controls.currentPosition = timeEffect10;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect10.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect10);

                IsInitedEffect10 = true;
                MP3Music.ReHideWidgets(pauseEffect10, playEffect10);
            }
        }

        private void playEffect17_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect17.Text != "") {
                pauseEffects(17);
                MediaEffect17.URL = effectsApplication.BoxLineEffect17.Text;
                MediaEffect17.controls.currentPosition = timeEffect17;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect17.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect17);

                IsInitedEffect17 = true;
                MP3Music.ReHideWidgets(pauseEffect17, playEffect17);
            }
        }

        private void playEffect12_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect12.Text != "") {
                pauseEffects(12);
                MediaEffect12.URL = effectsApplication.BoxLineEffect12.Text;
                MediaEffect12.controls.currentPosition = timeEffect12;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect12.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect12);

                IsInitedEffect12 = true;
                MP3Music.ReHideWidgets(pauseEffect12, playEffect12);
            }
        }

        private void playEffect13_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect13.Text != "") {
                pauseEffects(13);
                MediaEffect13.URL = effectsApplication.BoxLineEffect13.Text;
                MediaEffect13.controls.currentPosition = timeEffect13;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect13.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect13);

                IsInitedEffect13 = true;
                MP3Music.ReHideWidgets(pauseEffect13, playEffect13);
            }
        }

        private void playEffect14_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect14.Text != "") {
                pauseEffects(14);
                MediaEffect14.URL = effectsApplication.BoxLineEffect14.Text;
                MediaEffect14.controls.currentPosition = timeEffect14;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect14.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect14);

                IsInitedEffect14 = true;
                MP3Music.ReHideWidgets(pauseEffect14, playEffect14);
            }
        }

        private void playEffect15_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect15.Text != "") {
                pauseEffects(15);
                MediaEffect15.URL = effectsApplication.BoxLineEffect15.Text;
                MediaEffect15.controls.currentPosition = timeEffect15;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect15.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect15);

                IsInitedEffect15 = true;
                MP3Music.ReHideWidgets(pauseEffect15, playEffect15);
            }
        }

        private void playEffect16_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect16.Text != "") {
                pauseEffects(16);
                MediaEffect16.URL = effectsApplication.BoxLineEffect16.Text;
                MediaEffect16.controls.currentPosition = timeEffect16;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect16.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect16);

                IsInitedEffect16 = true;
                MP3Music.ReHideWidgets(pauseEffect16, playEffect16);
            }
        }

        private void playEffect11_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect11.Text != "") {
                pauseEffects(11);
                MediaEffect11.URL = effectsApplication.BoxLineEffect11.Text;
                MediaEffect11.controls.currentPosition = timeEffect11;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect11.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect11);

                IsInitedEffect11 = true;
                MP3Music.ReHideWidgets(pauseEffect11, playEffect11);
            }
        }

        private void playEffect18_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect18.Text != "") {
                pauseEffects(18);
                MediaEffect18.URL = effectsApplication.BoxLineEffect18.Text;
                MediaEffect18.controls.currentPosition = timeEffect18;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect18.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect18);

                IsInitedEffect18 = true;
                MP3Music.ReHideWidgets(pauseEffect18, playEffect18);
            }
        }

        private void playEffect19_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect19.Text != "") {
                pauseEffects(19);
                MediaEffect19.URL = effectsApplication.BoxLineEffect19.Text;
                MediaEffect19.controls.currentPosition = timeEffect19;

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect19.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect19);

                IsInitedEffect19 = true;
                MP3Music.ReHideWidgets(pauseEffect19, playEffect19);
            }
        }

        private void playEffect20_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect20.Text != "") {
                pauseEffects(20);

                if (!settingsApp.SmoothStartStopCheck.Checked)
                    MediaEffect20.controls.play();
                else
                    MP3Music.smoothStart(MediaEffect20);

                MediaEffect20.URL = effectsApplication.BoxLineEffect20.Text;
                MediaEffect20.controls.currentPosition = timeEffect20;
                IsInitedEffect20 = true;
                MP3Music.ReHideWidgets(pauseEffect20, playEffect20);
            }
        }

        public async void pauseEffect_Click(object sender, EventArgs e)
        {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect, pauseEffect);

            timeEffect = MediaEffect.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect, pauseEffect);
        }

        public async void pauseEffect2_Click(object sender, EventArgs e) 
        {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect2.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect2, pauseEffect2);

            timeEffect2 = MediaEffect2.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect2, pauseEffect2);
        }

        public async void pauseEffect3_Click(object sender, EventArgs e) 
        {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect3.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect3, pauseEffect3);

            timeEffect3 = MediaEffect3.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect3, pauseEffect3);
        }

        public async void pauseEffect4_Click(object sender, EventArgs e) 
        {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect4.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect4, pauseEffect4);

            timeEffect4 = MediaEffect4.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect4, pauseEffect4);
        }

        public async void pauseEffect5_Click(object sender, EventArgs e)
        {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect5.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect5, pauseEffect5);

            timeEffect5 = MediaEffect5.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect5, pauseEffect5);
        }

        public async void pauseEffect6_Click(object sender, EventArgs e)
        {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect6.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect6, pauseEffect6);

            timeEffect6 = MediaEffect6.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect6, pauseEffect6);
        }

        public async void pauseEffect7_Click(object sender, EventArgs e) 
        {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect7.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect7, pauseEffect7);

            timeEffect7 = MediaEffect7.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect7, pauseEffect7);
        }

        public async void pauseEffect8_Click(object sender, EventArgs e)
        {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect8.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect8, pauseEffect8);

            timeEffect8 = MediaEffect8.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect8, pauseEffect8);
        }

        public async void pauseEffect9_Click(object sender, EventArgs e)
        {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect9.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect9, pauseEffect9);

            timeEffect9 = MediaEffect9.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect9, pauseEffect9);
        }

        public async void pauseEffect10_Click(object sender, EventArgs e)
        {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect10.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect10, pauseEffect10);

            timeEffect10 = MediaEffect10.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect10, pauseEffect10);
        }

        private async void pauseEffect17_Click(object sender, EventArgs e) {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect17.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect17, pauseEffect17);

            timeEffect17 = MediaEffect17.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect17, pauseEffect17);
        }

        private async void pauseEffect12_Click(object sender, EventArgs e) {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect12.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect12, pauseEffect12);

            timeEffect12 = MediaEffect12.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect12, pauseEffect12);
        }

        private async void pauseEffect13_Click(object sender, EventArgs e) {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect13.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect13, pauseEffect13);

            timeEffect13 = MediaEffect13.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect13, pauseEffect13);
        }

        private async void pauseEffect14_Click(object sender, EventArgs e) {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect14.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect14, pauseEffect14);

            timeEffect14 = MediaEffect14.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect14, pauseEffect14);
        }

        private async void pauseEffect15_Click(object sender, EventArgs e) {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect15.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect15, pauseEffect15);

            timeEffect15 = MediaEffect15.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect15, pauseEffect15);
        }

        private async void pauseEffect16_Click(object sender, EventArgs e) {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect16.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect16, pauseEffect16);

            timeEffect16 = MediaEffect16.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect16, pauseEffect16);
        }

        private async void pauseEffect11_Click(object sender, EventArgs e) {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect11.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect11, pauseEffect11);

            timeEffect11 = MediaEffect11.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect11, pauseEffect11);
        }

        private async void pauseEffect18_Click(object sender, EventArgs e) {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect18.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect18, pauseEffect18);

            timeEffect18 = MediaEffect18.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect18, pauseEffect18);
        }

        private async void pauseEffect19_Click(object sender, EventArgs e) {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect19.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect19, pauseEffect19);

            timeEffect19 = MediaEffect19.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect19, pauseEffect19);
        }

        private async void pauseEffect20_Click(object sender, EventArgs e) {
            if (!settingsApp.SmoothStartStopCheck.Checked)
                MediaEffect20.controls.pause();
            else
                await MP3Music.smoothStop(MediaEffect20, pauseEffect20);

            timeEffect20 = MediaEffect20.controls.currentPosition;
            MP3Music.ReHideWidgets(playEffect20, pauseEffect20);
        }

        public void pauseEffects(int numberButton)
        {
            if (!settingsApp.MultiMusicRadio.Checked)
            {
                // сделать так чтобы эффекты ставились на паузу, кроме того, что запустили
                if (!(numberButton == 1))
                {
                    MediaEffect.controls.pause();
                    timeEffect = MediaEffect.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect, pauseEffect);
                }
                if (!(numberButton == 2))
                {
                    MediaEffect2.controls.pause();
                    timeEffect2 = MediaEffect2.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect2, pauseEffect2);
                }
                if (!(numberButton == 3))
                {
                    MediaEffect3.controls.pause();
                    timeEffect3 = MediaEffect3.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect3, pauseEffect3);
                }
                if (!(numberButton == 4))
                {
                    MediaEffect4.controls.pause();
                    timeEffect4 = MediaEffect4.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect4, pauseEffect4);
                }
                if (!(numberButton == 5))
                {
                    MediaEffect5.controls.pause();
                    timeEffect5 = MediaEffect5.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect5, pauseEffect5);
                }
                if (!(numberButton == 6))
                {
                    MediaEffect6.controls.pause();
                    timeEffect6 = MediaEffect6.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect6, pauseEffect6);
                }
                if (!(numberButton == 7))
                {
                    MediaEffect7.controls.pause();
                    timeEffect7 = MediaEffect7.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect7, pauseEffect7);
                }
                if (!(numberButton == 8))
                {
                    MediaEffect8.controls.pause();
                    timeEffect8 = MediaEffect8.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect8, pauseEffect8);
                }
                if (!(numberButton == 9))
                {
                    MediaEffect9.controls.pause();
                    timeEffect9 = MediaEffect9.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect9, pauseEffect9);
                }
                if (!(numberButton == 10))
                {
                    MediaEffect10.controls.pause();
                    timeEffect10 = MediaEffect10.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect10, pauseEffect10);
                }
                if (!(numberButton == 11))
                {
                    MediaEffect11.controls.pause();
                    timeEffect11 = MediaEffect11.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect11, pauseEffect11);
                }
                if (!(numberButton == 12))
                {
                    MediaEffect12.controls.pause();
                    timeEffect12 = MediaEffect12.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect12, pauseEffect12);
                }
                if (!(numberButton == 13))
                {
                    MediaEffect13.controls.pause();
                    timeEffect13 = MediaEffect13.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect13, pauseEffect13);
                }
                if (!(numberButton == 14))
                {
                    MediaEffect14.controls.pause();
                    timeEffect14 = MediaEffect14.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect14, pauseEffect14);
                }
                if (!(numberButton == 15))
                {
                    MediaEffect15.controls.pause();
                    timeEffect15 = MediaEffect15.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect15, pauseEffect15);
                }
                if (!(numberButton == 16))
                {
                    MediaEffect16.controls.pause();
                    timeEffect16 = MediaEffect16.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect16, pauseEffect16);
                }
                if (!(numberButton == 17))
                {
                    MediaEffect17.controls.pause();
                    timeEffect17 = MediaEffect17.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect17, pauseEffect17);
                }
                if (!(numberButton == 18))
                {
                    MediaEffect18.controls.pause();
                    timeEffect18 = MediaEffect18.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect18, pauseEffect18);
                }
                if (!(numberButton == 19))
                {
                    MediaEffect19.controls.pause();
                    timeEffect19 = MediaEffect19.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect19, pauseEffect19);
                }
                if (!(numberButton == 20))
                {
                    MediaEffect20.controls.pause();
                    timeEffect20 = MediaEffect20.controls.currentPosition;
                    MP3Music.ReHideWidgets(playEffect20, pauseEffect20);
                }
            }
        }

        private void ResetEffect_Click(object sender, EventArgs e) {
            MediaEffect.controls.currentPosition = 0;
            timeEffect = 0;
        }

        private void ResetEffect2_Click(object sender, EventArgs e) {
            MediaEffect2.controls.currentPosition = 0;
            timeEffect2 = 0;
        }

        private void ResetEffect3_Click(object sender, EventArgs e) {
            MediaEffect3.controls.currentPosition = 0;
            timeEffect3 = 0;
        }

        private void ResetEffect4_Click(object sender, EventArgs e) {
            MediaEffect4.controls.currentPosition = 0;
            timeEffect4 = 0;
        }

        private void ResetEffect5_Click(object sender, EventArgs e) {
            MediaEffect5.controls.currentPosition = 0;
            timeEffect5 = 0;
        }

        private void ResetEffect6_Click(object sender, EventArgs e) {
            MediaEffect6.controls.currentPosition = 0;
            timeEffect6 = 0;
        }

        private void ResetEffect7_Click(object sender, EventArgs e) {
            MediaEffect7.controls.currentPosition = 0;
            timeEffect7 = 0;
        }

        private void ResetEffect8_Click(object sender, EventArgs e) {
            MediaEffect8.controls.currentPosition = 0;
            timeEffect8 = 0;
        }

        private void ResetEffect9_Click(object sender, EventArgs e) {
            MediaEffect9.controls.currentPosition = 0;
            timeEffect9 = 0;
        }

        private void ResetEffect10_Click(object sender, EventArgs e) {
            MediaEffect10.controls.currentPosition = 0;
            timeEffect10 = 0;
        }

        private void ResetEffect11_Click(object sender, EventArgs e) {
            MediaEffect11.controls.currentPosition = 0;
            timeEffect11 = 0;
        }

        private void ResetEffect19_Click(object sender, EventArgs e) {
            MediaEffect19.controls.currentPosition = 0;
            timeEffect19 = 0;
        }

        private void ResetEffect13_Click(object sender, EventArgs e) {
            MediaEffect13.controls.currentPosition = 0;
            timeEffect13 = 0;
        }

        private void ResetEffect14_Click(object sender, EventArgs e) {
            MediaEffect14.controls.currentPosition = 0;
            timeEffect14 = 0;
        }

        private void ResetEffect15_Click(object sender, EventArgs e) {
            MediaEffect15.controls.currentPosition = 0;
            timeEffect15 = 0;
        }

        private void ResetEffect16_Click(object sender, EventArgs e) {
            MediaEffect16.controls.currentPosition = 0;
            timeEffect16 = 0;
        }

        private void ResetEffect17_Click(object sender, EventArgs e) {
            MediaEffect17.controls.currentPosition = 0;
            timeEffect17 = 0;
        }

        private void ResetEffect18_Click(object sender, EventArgs e) {
            MediaEffect18.controls.currentPosition = 0;
            timeEffect18 = 0;
        }

        private void ResetEffect12_Click(object sender, EventArgs e) {
            MediaEffect12.controls.currentPosition = 0;
            timeEffect12 = 0;
        }

        private void ResetEffect20_Click(object sender, EventArgs e) {
            MediaEffect20.controls.currentPosition = 0;
            timeEffect20 = 0;
        }

        private void progressBarEffect_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect.Bounds.X);
                calcFactor = progressBarEffect.Width / (float)progressBarEffect.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect.Value = Convert.ToInt32(relativeMouse);
                MediaEffect.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect2_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect2.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect2.Bounds.X);
                calcFactor = progressBarEffect2.Width / (float)progressBarEffect2.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect2.Value = Convert.ToInt32(relativeMouse);
                MediaEffect2.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect3_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect3.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect3.Bounds.X);
                calcFactor = progressBarEffect3.Width / (float)progressBarEffect3.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect3.Value = Convert.ToInt32(relativeMouse);
                MediaEffect3.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect4_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect4.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect4.Bounds.X);
                calcFactor = progressBarEffect4.Width / (float)progressBarEffect4.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect4.Value = Convert.ToInt32(relativeMouse);
                MediaEffect4.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect5_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect5.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect5.Bounds.X);
                calcFactor = progressBarEffect5.Width / (float)progressBarEffect5.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect5.Value = Convert.ToInt32(relativeMouse);
                MediaEffect5.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect6_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect6.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect6.Bounds.X);
                calcFactor = progressBarEffect6.Width / (float)progressBarEffect6.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect6.Value = Convert.ToInt32(relativeMouse);
                MediaEffect6.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect7_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect7.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect7.Bounds.X);
                calcFactor = progressBarEffect7.Width / (float)progressBarEffect7.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect7.Value = Convert.ToInt32(relativeMouse);
                MediaEffect7.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect8_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect8.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect8.Bounds.X);
                calcFactor = progressBarEffect8.Width / (float)progressBarEffect8.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect8.Value = Convert.ToInt32(relativeMouse);
                MediaEffect8.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect9_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect9.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect9.Bounds.X);
                calcFactor = progressBarEffect9.Width / (float)progressBarEffect9.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect9.Value = Convert.ToInt32(relativeMouse);
                MediaEffect9.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect10_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect10.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect10.Bounds.X);
                calcFactor = progressBarEffect10.Width / (float)progressBarEffect10.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect10.Value = Convert.ToInt32(relativeMouse);
                MediaEffect10.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect11_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect11.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect11.Bounds.X);
                calcFactor = progressBarEffect11.Width / (float)progressBarEffect11.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect11.Value = Convert.ToInt32(relativeMouse);
                MediaEffect11.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect12_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect12.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect12.Bounds.X);
                calcFactor = progressBarEffect12.Width / (float)progressBarEffect12.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect12.Value = Convert.ToInt32(relativeMouse);
                MediaEffect12.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect13_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect13.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect13.Bounds.X);
                calcFactor = progressBarEffect13.Width / (float)progressBarEffect13.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect13.Value = Convert.ToInt32(relativeMouse);
                MediaEffect13.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect14_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect14.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect14.Bounds.X);
                calcFactor = progressBarEffect14.Width / (float)progressBarEffect14.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect14.Value = Convert.ToInt32(relativeMouse);
                MediaEffect14.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect15_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect15.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect15.Bounds.X);
                calcFactor = progressBarEffect15.Width / (float)progressBarEffect15.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect15.Value = Convert.ToInt32(relativeMouse);
                MediaEffect15.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect16_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect16.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect16.Bounds.X);
                calcFactor = progressBarEffect16.Width / (float)progressBarEffect16.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect16.Value = Convert.ToInt32(relativeMouse);
                MediaEffect16.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect17_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect17.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect17.Bounds.X);
                calcFactor = progressBarEffect17.Width / (float)progressBarEffect17.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect17.Value = Convert.ToInt32(relativeMouse);
                MediaEffect17.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect18_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect18.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect18.Bounds.X);
                calcFactor = progressBarEffect18.Width / (float)progressBarEffect18.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect18.Value = Convert.ToInt32(relativeMouse);
                MediaEffect18.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect19_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect19.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect19.Bounds.X);
                calcFactor = progressBarEffect19.Width / (float)progressBarEffect19.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect19.Value = Convert.ToInt32(relativeMouse);
                MediaEffect19.controls.currentPosition = relativeMouse;
            }
        }

        private void progressBarEffect20_Click(object sender, EventArgs e) {
            if (effectsApplication.BoxLineEffect20.Text != "") {
                absoluteMouse = (PointToClient(MousePosition).X - progressBarEffect20.Bounds.X);
                calcFactor = progressBarEffect20.Width / (float)progressBarEffect20.Maximum;
                relativeMouse = absoluteMouse / calcFactor;

                progressBarEffect20.Value = Convert.ToInt32(relativeMouse);
                MediaEffect20.controls.currentPosition = relativeMouse;
            }
        }
        #endregion Effect

        #region System
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (MainMusicIsInited)
                {
                    progressBarMainMusic.Maximum = Convert.ToInt32(MainMedia.currentMedia.duration);
                    progressBarMainMusic.Value = Convert.ToInt32(MainMedia.controls.currentPosition);

                    if (progressBarMainMusic.Value == progressBarMainMusic.Maximum-1 & WhileMain.Checked)
                        MainMedia.controls.currentPosition = 0.1;
                    if (progressBarMainMusic.Value == progressBarMainMusic.Maximum-1 & !WhileMain.Checked)
                    {
                        musicIsPlaying = false;
                        OffTime = 0;
                        time = 0;
                        MP3Music.ReHideWidgets(PlayButton, PauseButton);
                    }
                }
                if (SecondMusicIsInited)
                {
                    progressBarMainMusicSecond.Maximum = Convert.ToInt32(SecondMedia.currentMedia.duration);
                    progressBarMainMusicSecond.Value = Convert.ToInt32(SecondMedia.controls.currentPosition);

                    if (progressBarMainMusicSecond.Value == progressBarMainMusicSecond.Maximum - 1 & WhileSecond.Checked)
                        SecondMedia.controls.currentPosition = 0.1;
                    if (progressBarMainMusicSecond.Value == progressBarMainMusicSecond.Maximum - 1 & !WhileSecond.Checked)
                    {
                        musicIsPlaying = false;
                        OffTime = 0;
                        timeSecond = 0;
                        MP3Music.ReHideWidgets(PlayButtonSecond, PauseButtonSecond);
                    }
                }
                if (IsInitedEffect)
                {
                    progressBarEffect.Maximum = Convert.ToInt32(MediaEffect?.currentMedia.duration);
                    progressBarEffect.Value = Convert.ToInt32(MediaEffect?.controls.currentPosition);

                    if (progressBarEffect.Value == progressBarEffect.Maximum - 1)
                    {
                        timeEffect = 0;
                        MP3Music.ReHideWidgets(playEffect, pauseEffect);
                    }
                }
                if (IsInitedEffect2)
                {
                    progressBarEffect2.Maximum = Convert.ToInt32(MediaEffect2.currentMedia.duration);
                    progressBarEffect2.Value = Convert.ToInt32(MediaEffect2.controls.currentPosition);

                    if (progressBarEffect2.Value == progressBarEffect2.Maximum - 1)
                    {
                        timeEffect2 = 0;
                        MP3Music.ReHideWidgets(playEffect2, pauseEffect2);
                    }
                }
                if (IsInitedEffect3)
                {
                    progressBarEffect3.Maximum = Convert.ToInt32(MediaEffect3.currentMedia.duration);
                    progressBarEffect3.Value = Convert.ToInt32(MediaEffect3.controls.currentPosition);

                    if (progressBarEffect3.Value == progressBarEffect3.Maximum - 1)
                    {
                        timeEffect3 = 0;
                        MP3Music.ReHideWidgets(playEffect3, pauseEffect3);
                    }
                }
                if (IsInitedEffect4)
                {
                    progressBarEffect4.Maximum = Convert.ToInt32(MediaEffect4.currentMedia.duration);
                    progressBarEffect4.Value = Convert.ToInt32(MediaEffect4.controls.currentPosition);

                    if (progressBarEffect4.Value == progressBarEffect4.Maximum - 1)
                    {
                        timeEffect4 = 0;
                        MP3Music.ReHideWidgets(playEffect4, pauseEffect4);
                    }
                }
                if (IsInitedEffect5)
                {
                    progressBarEffect5.Maximum = Convert.ToInt32(MediaEffect5.currentMedia.duration);
                    progressBarEffect5.Value = Convert.ToInt32(MediaEffect5.controls.currentPosition);

                    if (progressBarEffect5.Value == progressBarEffect5.Maximum - 1)
                    {
                        timeEffect5 = 0;
                        MP3Music.ReHideWidgets(playEffect5, pauseEffect5);
                    }
                }
                if (IsInitedEffect6)
                {
                    progressBarEffect6.Maximum = Convert.ToInt32(MediaEffect6.currentMedia.duration);
                    progressBarEffect6.Value = Convert.ToInt32(MediaEffect6.controls.currentPosition);

                    if (progressBarEffect6.Value == progressBarEffect6.Maximum - 1)
                    {
                        timeEffect6 = 0;
                        MP3Music.ReHideWidgets(playEffect6, pauseEffect6);
                    }
                }
                if (IsInitedEffect7)
                {
                    progressBarEffect7.Maximum = Convert.ToInt32(MediaEffect7.currentMedia.duration);
                    progressBarEffect7.Value = Convert.ToInt32(MediaEffect7.controls.currentPosition);

                    if (progressBarEffect7.Value == progressBarEffect7.Maximum - 1)
                    {
                        timeEffect7 = 0;
                        MP3Music.ReHideWidgets(playEffect7, pauseEffect7);
                    }
                }
                if (IsInitedEffect8)
                {
                    progressBarEffect8.Maximum = Convert.ToInt32(MediaEffect8.currentMedia.duration);
                    progressBarEffect8.Value = Convert.ToInt32(MediaEffect8.controls.currentPosition);

                    if (progressBarEffect8.Value == progressBarEffect8.Maximum - 1)
                    {
                        timeEffect8 = 0;
                        MP3Music.ReHideWidgets(playEffect8, pauseEffect8);
                    }
                }
                if (IsInitedEffect9)
                {
                    progressBarEffect9.Maximum = Convert.ToInt32(MediaEffect9.currentMedia.duration);
                    progressBarEffect9.Value = Convert.ToInt32(MediaEffect9.controls.currentPosition);

                    if (progressBarEffect9.Value == progressBarEffect9.Maximum - 1)
                    {
                        timeEffect9 = 0;
                        MP3Music.ReHideWidgets(playEffect9, pauseEffect9);
                    }
                }
                if (IsInitedEffect10)
                {
                    progressBarEffect10.Maximum = Convert.ToInt32(MediaEffect10.currentMedia.duration);
                    progressBarEffect10.Value = Convert.ToInt32(MediaEffect10.controls.currentPosition);

                    if (progressBarEffect10.Value == progressBarEffect10.Maximum - 1)
                    {
                        timeEffect10 = 0;
                        MP3Music.ReHideWidgets(playEffect10, pauseEffect10);
                    }
                }
                if (IsInitedEffect11)
                {
                    progressBarEffect11.Maximum = Convert.ToInt32(MediaEffect11.currentMedia.duration);
                    progressBarEffect11.Value = Convert.ToInt32(MediaEffect11.controls.currentPosition);

                    if (progressBarEffect11.Value == progressBarEffect11.Maximum - 1)
                    {
                        timeEffect11 = 0;
                        MP3Music.ReHideWidgets(playEffect11, pauseEffect11);
                    }
                }
                if (IsInitedEffect12)
                {
                    progressBarEffect12.Maximum = Convert.ToInt32(MediaEffect12.currentMedia.duration);
                    progressBarEffect12.Value = Convert.ToInt32(MediaEffect12.controls.currentPosition);

                    if (progressBarEffect12.Value == progressBarEffect12.Maximum - 1)
                    {
                        timeEffect12 = 0;
                        MP3Music.ReHideWidgets(playEffect12, pauseEffect12);
                    }
                }
                if (IsInitedEffect13)
                {
                    progressBarEffect13.Maximum = Convert.ToInt32(MediaEffect13.currentMedia.duration);
                    progressBarEffect13.Value = Convert.ToInt32(MediaEffect13.controls.currentPosition);

                    if (progressBarEffect13.Value == progressBarEffect13.Maximum - 1)
                    {
                        timeEffect13 = 0;
                        MP3Music.ReHideWidgets(playEffect13, pauseEffect13);
                    }
                }
                if (IsInitedEffect14)
                {
                    progressBarEffect14.Maximum = Convert.ToInt32(MediaEffect14.currentMedia.duration);
                    progressBarEffect14.Value = Convert.ToInt32(MediaEffect14.controls.currentPosition);

                    if (progressBarEffect14.Value == progressBarEffect14.Maximum - 1)
                    {
                        timeEffect14 = 0;
                        MP3Music.ReHideWidgets(playEffect14, pauseEffect14);
                    }
                }
                if (IsInitedEffect15)
                {
                    progressBarEffect15.Maximum = Convert.ToInt32(MediaEffect15.currentMedia.duration);
                    progressBarEffect15.Value = Convert.ToInt32(MediaEffect15.controls.currentPosition);

                    if (progressBarEffect15.Value == progressBarEffect15.Maximum - 1)
                    {
                        timeEffect15 = 0;
                        MP3Music.ReHideWidgets(playEffect15, pauseEffect15);
                    }
                }
                if (IsInitedEffect16)
                {
                    progressBarEffect16.Maximum = Convert.ToInt32(MediaEffect16.currentMedia.duration);
                    progressBarEffect16.Value = Convert.ToInt32(MediaEffect16.controls.currentPosition);

                    if (progressBarEffect16.Value == progressBarEffect16.Maximum - 1)
                    {
                        timeEffect16 = 0;
                        MP3Music.ReHideWidgets(playEffect16, pauseEffect16);
                    }
                }
                if (IsInitedEffect17)
                {
                    progressBarEffect17.Maximum = Convert.ToInt32(MediaEffect17.currentMedia.duration);
                    progressBarEffect17.Value = Convert.ToInt32(MediaEffect17.controls.currentPosition);

                    if (progressBarEffect17.Value == progressBarEffect17.Maximum - 1)
                    {
                        timeEffect17 = 0;
                        MP3Music.ReHideWidgets(playEffect17, pauseEffect17);
                    }
                }
                if (IsInitedEffect18)
                {
                    progressBarEffect18.Maximum = Convert.ToInt32(MediaEffect18.currentMedia.duration);
                    progressBarEffect18.Value = Convert.ToInt32(MediaEffect18.controls.currentPosition);

                    if (progressBarEffect18.Value == progressBarEffect18.Maximum - 1)
                    {
                        timeEffect18 = 0;
                        MP3Music.ReHideWidgets(playEffect18, pauseEffect18);
                    }
                }
                if (IsInitedEffect19)
                {
                    progressBarEffect19.Maximum = Convert.ToInt32(MediaEffect19.currentMedia.duration);
                    progressBarEffect19.Value = Convert.ToInt32(MediaEffect19.controls.currentPosition);

                    if (progressBarEffect19.Value == progressBarEffect19.Maximum - 1)
                    {
                        timeEffect19 = 0;
                        MP3Music.ReHideWidgets(playEffect19, pauseEffect19);
                    }
                }
                if (IsInitedEffect20)
                {
                    progressBarEffect20.Maximum = Convert.ToInt32(MediaEffect20.currentMedia.duration);
                    progressBarEffect20.Value = Convert.ToInt32(MediaEffect20.controls.currentPosition);

                    if (progressBarEffect20.Value == progressBarEffect20.Maximum - 1)
                    {
                        timeEffect20 = 0;
                        MP3Music.ReHideWidgets(playEffect20, pauseEffect20);
                    }
                }
            } catch { }
        }
        private void button1_Click(object sender, EventArgs e) => Application.Exit();
        private void SettingsButton_Click(object sender, EventArgs e) => effectsApplication.Show();
        private void SettingsDJ_Click(object sender, EventArgs e) => settingsApp.Show();
        private void MinimizeWindow_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void DownClicedLabel(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_Down(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion System

        #region Volume
        private void VolumeMain_ValueChanged(object sender, EventArgs e)
        {
            MainMedia.settings.volume = VolumeMain.Value;
            SecondMedia.settings.volume = VolumeMain.Value;
            MainVolume = VolumeMain.Value;
        }

        private void VolumeEffects_ValueChanged(object sender, EventArgs e)
        {
            MediaEffect.settings.volume = VolumeEffects.Value;
            MediaEffect2.settings.volume = VolumeEffects.Value;
            MediaEffect3.settings.volume = VolumeEffects.Value;
            MediaEffect4.settings.volume = VolumeEffects.Value;
            MediaEffect5.settings.volume = VolumeEffects.Value;
            MediaEffect6.settings.volume = VolumeEffects.Value;
            MediaEffect7.settings.volume = VolumeEffects.Value;
            MediaEffect8.settings.volume = VolumeEffects.Value;
            MediaEffect9.settings.volume = VolumeEffects.Value;
            MediaEffect10.settings.volume = VolumeEffects.Value;
            MediaEffect11.settings.volume = VolumeEffects.Value;
            MediaEffect12.settings.volume = VolumeEffects.Value;
            MediaEffect13.settings.volume = VolumeEffects.Value;
            MediaEffect14.settings.volume = VolumeEffects.Value;
            MediaEffect15.settings.volume = VolumeEffects.Value;
            MediaEffect16.settings.volume = VolumeEffects.Value;
            MediaEffect17.settings.volume = VolumeEffects.Value;
            MediaEffect18.settings.volume = VolumeEffects.Value;
            MediaEffect19.settings.volume = VolumeEffects.Value;
            MediaEffect20.settings.volume = VolumeEffects.Value;
        }
        #endregion
    }

    public class MP3Music
    {
        public static async void smoothStart(WindowsMediaPlayer player) {
            int TakedVolume = player.settings.volume;
            player.settings.volume = 0;
            player.controls.play();

            for (int volume = 0; volume <= TakedVolume; volume+=2, await Task.Delay(DJ_SHARP.delayTransition / 2)) { player.settings.volume = volume; }

            player.settings.volume = TakedVolume;
        }
        public static async Task smoothStop(WindowsMediaPlayer player, Control Widget) {
            int vol = player.settings.volume;
            Widget.Enabled = false;

            for (int volume = vol; volume > 0; volume -= 2, await Task.Delay(DJ_SHARP.delayTransition / 2)) { player.settings.volume = volume; }

            player.controls.pause();
            await Task.Delay(2);
            player.settings.volume = vol;
            Widget.Enabled = true;
        }
        public static void treads(object pocket)
        {
            Thread ThreadTransition = new Thread(new ParameterizedThreadStart(Transition));
            ThreadTransition.Start(pocket);
        }
        public static void Transition(object args)
        {
            if (!DJ_SHARP.transisting)
            {
                DJ_SHARP.transisting = true;
                InteregetArgs settings = args as InteregetArgs;
                int volumeForTransition = DJ_SHARP.MainVolume;
                int VolumeOff = volumeForTransition;
                int VolumeOn = 0;

                settings.Off.settings.volume = VolumeOff;
                settings.On.settings.volume = VolumeOn;
                settings.On.controls.currentPosition = DJ_SHARP.OffTime;
                settings.On.controls.play();

                for (int i = 0; i < volumeForTransition; i += 2)
                {
                    int _VolumeOff = VolumeOff - i;

                    settings.Off.settings.volume = _VolumeOff;
                    settings.On.settings.volume = i;
                    Thread.Sleep(DJ_SHARP.delayTransition);
                }
                DJ_SHARP.OffTime = settings.Off.controls.currentPosition;
                settings.Off.controls.pause();
                DJ_SHARP.transisting = false;
            }
        }
        public static void ReHideWidgets(Control Show, Control Hide) { Show.Show(); Hide.Hide(); }
    }
    public class InteregetArgs
    {
        public WindowsMediaPlayer Off { get; set; }
        public WindowsMediaPlayer On { get; set; }
    }
}