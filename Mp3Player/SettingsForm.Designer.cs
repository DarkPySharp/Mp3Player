
namespace Mp3Player
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.LabelTag = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.delayTransition = new System.Windows.Forms.TextBox();
            this.delayForTransition = new System.Windows.Forms.Label();
            this.delayUpdateProgressLabel = new System.Windows.Forms.Label();
            this.delayUpdateProgress = new System.Windows.Forms.TextBox();
            this.StandartVolumeLabel = new System.Windows.Forms.Label();
            this.StandartVolume = new System.Windows.Forms.TextBox();
            this.SaveInFile = new System.Windows.Forms.Button();
            this.MultiMusicRadio = new System.Windows.Forms.CheckBox();
            this.SmoothStartStopCheck = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Controls.Add(this.LabelTag);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 26);
            this.panel1.TabIndex = 4;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Red;
            this.closeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeButton.BackgroundImage")));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(277, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(20, 20);
            this.closeButton.TabIndex = 4;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // LabelTag
            // 
            this.LabelTag.AutoSize = true;
            this.LabelTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.LabelTag.ForeColor = System.Drawing.Color.White;
            this.LabelTag.Location = new System.Drawing.Point(120, 7);
            this.LabelTag.Name = "LabelTag";
            this.LabelTag.Size = new System.Drawing.Size(53, 13);
            this.LabelTag.TabIndex = 3;
            this.LabelTag.Text = "Settings";
            this.LabelTag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelTag_MouseDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(779, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // delayTransition
            // 
            this.delayTransition.Location = new System.Drawing.Point(3, 33);
            this.delayTransition.Name = "delayTransition";
            this.delayTransition.Size = new System.Drawing.Size(46, 20);
            this.delayTransition.TabIndex = 5;
            this.delayTransition.Text = "200";
            this.delayTransition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.delayTransition.TextChanged += new System.EventHandler(this.delayTransition_TextChanged);
            // 
            // delayForTransition
            // 
            this.delayForTransition.AutoSize = true;
            this.delayForTransition.Location = new System.Drawing.Point(51, 36);
            this.delayForTransition.Name = "delayForTransition";
            this.delayForTransition.Size = new System.Drawing.Size(130, 13);
            this.delayForTransition.TabIndex = 6;
            this.delayForTransition.Text = "Задержка перехода (ms)";
            // 
            // delayUpdateProgressLabel
            // 
            this.delayUpdateProgressLabel.AutoSize = true;
            this.delayUpdateProgressLabel.Location = new System.Drawing.Point(51, 58);
            this.delayUpdateProgressLabel.Name = "delayUpdateProgressLabel";
            this.delayUpdateProgressLabel.Size = new System.Drawing.Size(201, 13);
            this.delayUpdateProgressLabel.TabIndex = 8;
            this.delayUpdateProgressLabel.Text = "Задержка обновления progressbar (ms)";
            // 
            // delayUpdateProgress
            // 
            this.delayUpdateProgress.Location = new System.Drawing.Point(3, 55);
            this.delayUpdateProgress.Name = "delayUpdateProgress";
            this.delayUpdateProgress.Size = new System.Drawing.Size(46, 20);
            this.delayUpdateProgress.TabIndex = 7;
            this.delayUpdateProgress.Text = "120";
            this.delayUpdateProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.delayUpdateProgress.TextChanged += new System.EventHandler(this.delayUpdateProgress_TextChanged);
            // 
            // StandartVolumeLabel
            // 
            this.StandartVolumeLabel.AutoSize = true;
            this.StandartVolumeLabel.Location = new System.Drawing.Point(51, 80);
            this.StandartVolumeLabel.Name = "StandartVolumeLabel";
            this.StandartVolumeLabel.Size = new System.Drawing.Size(146, 13);
            this.StandartVolumeLabel.TabIndex = 10;
            this.StandartVolumeLabel.Text = "Стандартная громкость (%)";
            // 
            // StandartVolume
            // 
            this.StandartVolume.Location = new System.Drawing.Point(3, 77);
            this.StandartVolume.Name = "StandartVolume";
            this.StandartVolume.Size = new System.Drawing.Size(46, 20);
            this.StandartVolume.TabIndex = 9;
            this.StandartVolume.Text = "50";
            this.StandartVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SaveInFile
            // 
            this.SaveInFile.Location = new System.Drawing.Point(229, 119);
            this.SaveInFile.Name = "SaveInFile";
            this.SaveInFile.Size = new System.Drawing.Size(68, 23);
            this.SaveInFile.TabIndex = 11;
            this.SaveInFile.Text = "Сохранить";
            this.SaveInFile.UseVisualStyleBackColor = true;
            this.SaveInFile.Click += new System.EventHandler(this.SaveInFile_Click);
            // 
            // MultiMusicRadio
            // 
            this.MultiMusicRadio.AutoSize = true;
            this.MultiMusicRadio.Location = new System.Drawing.Point(3, 99);
            this.MultiMusicRadio.Name = "MultiMusicRadio";
            this.MultiMusicRadio.Size = new System.Drawing.Size(287, 17);
            this.MultiMusicRadio.TabIndex = 12;
            this.MultiMusicRadio.Text = "Использовать несколько эффектов одновременно";
            this.MultiMusicRadio.UseVisualStyleBackColor = true;
            // 
            // SmoothStartStopCheck
            // 
            this.SmoothStartStopCheck.AutoSize = true;
            this.SmoothStartStopCheck.Location = new System.Drawing.Point(3, 115);
            this.SmoothStartStopCheck.Name = "SmoothStartStopCheck";
            this.SmoothStartStopCheck.Size = new System.Drawing.Size(134, 17);
            this.SmoothStartStopCheck.TabIndex = 13;
            this.SmoothStartStopCheck.Text = "Плавный старт | стоп";
            this.SmoothStartStopCheck.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 145);
            this.Controls.Add(this.SmoothStartStopCheck);
            this.Controls.Add(this.MultiMusicRadio);
            this.Controls.Add(this.SaveInFile);
            this.Controls.Add(this.StandartVolumeLabel);
            this.Controls.Add(this.StandartVolume);
            this.Controls.Add(this.delayUpdateProgressLabel);
            this.Controls.Add(this.delayUpdateProgress);
            this.Controls.Add(this.delayForTransition);
            this.Controls.Add(this.delayTransition);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelTag;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox delayTransition;
        private System.Windows.Forms.Label delayForTransition;
        private System.Windows.Forms.Label delayUpdateProgressLabel;
        private System.Windows.Forms.TextBox delayUpdateProgress;
        private System.Windows.Forms.Label StandartVolumeLabel;
        private System.Windows.Forms.TextBox StandartVolume;
        private System.Windows.Forms.Button SaveInFile;
        public System.Windows.Forms.CheckBox MultiMusicRadio;
        public System.Windows.Forms.CheckBox SmoothStartStopCheck;
    }
}