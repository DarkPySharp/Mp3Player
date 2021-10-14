using System;
using System.Windows.Forms;

namespace Mp3Player
{
    class ActionsMain
    {
        public string TakeFile(string filter="music files|*.mp3; *.wav; *.aiff; *.ape; *.flac; *.ogg|all files|*.*")
        {
            OpenFileDialog takeFileN = new OpenFileDialog();
            takeFileN.Filter = filter;
            takeFileN.ShowDialog();
            string file = takeFileN.FileName;
            return file;
        }
        public string TakeDir()
        {
            FolderBrowserDialog takeDirectory = new FolderBrowserDialog();
            takeDirectory.ShowDialog();
            string directory = takeDirectory.SelectedPath;
            return directory;
        }
        public static void ResetColor(string color, string message)
        {
            ConsoleColor mode = ConsoleColor.Red;
            switch (color.ToLower())
            {
                case "green":
                    mode = ConsoleColor.Green;
                    break;
                case "gray":
                    mode = ConsoleColor.Gray;
                    break;
                case "yellow":
                    mode = ConsoleColor.Yellow;
                    break;
            }

            Console.ForegroundColor = mode;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
