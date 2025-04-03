namespace DownloadYoutube
{
    partial class FormParent
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainDescriptionLabel = new Label();
            step1Label = new Label();
            step2Label = new Label();
            step3Label = new Label();
            step1YoutubeLink = new LinkLabel();
            step2UrlBox = new TextBox();
            step5Label = new Label();
            mediaTypeAudioOnly = new RadioButton();
            mediaTypeAudioVideo = new RadioButton();
            step5GoButton = new Button();
            step4Label = new Label();
            step4DirTextBox = new TextBox();
            step4DirSelectButton = new Button();
            SuspendLayout();
            // 
            // MainDescriptionLabel
            // 
            MainDescriptionLabel.Font = new Font( "Outfit SemiBold", 30F );
            MainDescriptionLabel.ForeColor = Color.Indigo;
            MainDescriptionLabel.Location = new Point( 0, 0 );
            MainDescriptionLabel.Name = "MainDescriptionLabel";
            MainDescriptionLabel.Padding = new Padding( 30, 0, 30, 0 );
            MainDescriptionLabel.Size = new Size( 800, 102 );
            MainDescriptionLabel.TabIndex = 5;
            MainDescriptionLabel.Text = "Follow these steps to download\r\nwhatever you want from Youtube";
            MainDescriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // step1Label
            // 
            step1Label.AutoSize = true;
            step1Label.Font = new Font( "Outfit", 30F );
            step1Label.ForeColor = Color.Indigo;
            step1Label.Location = new Point( 12, 130 );
            step1Label.Name = "step1Label";
            step1Label.Size = new Size( 135, 50 );
            step1Label.TabIndex = 6;
            step1Label.Text = "Step 1:";
            // 
            // step2Label
            // 
            step2Label.AutoSize = true;
            step2Label.Font = new Font( "Outfit", 30F );
            step2Label.ForeColor = Color.Indigo;
            step2Label.Location = new Point( 12, 223 );
            step2Label.Name = "step2Label";
            step2Label.Size = new Size( 143, 50 );
            step2Label.TabIndex = 7;
            step2Label.Text = "Step 2:";
            // 
            // step3Label
            // 
            step3Label.AutoSize = true;
            step3Label.Font = new Font( "Outfit", 30F );
            step3Label.ForeColor = Color.Indigo;
            step3Label.Location = new Point( 12, 318 );
            step3Label.Name = "step3Label";
            step3Label.Size = new Size( 143, 50 );
            step3Label.TabIndex = 8;
            step3Label.Text = "Step 3:";
            // 
            // step1YoutubeLink
            // 
            step1YoutubeLink.AutoSize = true;
            step1YoutubeLink.Font = new Font( "Outfit SemiBold", 25F );
            step1YoutubeLink.LinkArea = new LinkArea( 6, 7 );
            step1YoutubeLink.LinkColor = Color.Red;
            step1YoutubeLink.Location = new Point( 168, 137 );
            step1YoutubeLink.Name = "step1YoutubeLink";
            step1YoutubeLink.Size = new Size( 233, 50 );
            step1YoutubeLink.TabIndex = 1;
            step1YoutubeLink.TabStop = true;
            step1YoutubeLink.Text = "Go To Youtube";
            step1YoutubeLink.UseCompatibleTextRendering = true;
            step1YoutubeLink.VisitedLinkColor = Color.Red;
            step1YoutubeLink.LinkClicked +=  step1YoutubeLink_LinkClicked ;
            // 
            // step2UrlBox
            // 
            step2UrlBox.Font = new Font( "Outfit", 15F );
            step2UrlBox.Location = new Point( 175, 234 );
            step2UrlBox.Name = "step2UrlBox";
            step2UrlBox.PlaceholderText = "Copy Paste Youtube URL Here";
            step2UrlBox.Size = new Size( 571, 33 );
            step2UrlBox.TabIndex = 2;
            // 
            // step5Label
            // 
            step5Label.AutoSize = true;
            step5Label.Font = new Font( "Outfit", 30F );
            step5Label.ForeColor = Color.Indigo;
            step5Label.Location = new Point( 12, 493 );
            step5Label.Name = "step5Label";
            step5Label.Size = new Size( 143, 50 );
            step5Label.TabIndex = 9;
            step5Label.Text = "Step 5:";
            // 
            // mediaTypeAudioOnly
            // 
            mediaTypeAudioOnly.Appearance = Appearance.Button;
            mediaTypeAudioOnly.AutoSize = true;
            mediaTypeAudioOnly.BackgroundImageLayout = ImageLayout.None;
            mediaTypeAudioOnly.Checked = true;
            mediaTypeAudioOnly.Cursor = Cursors.Hand;
            mediaTypeAudioOnly.FlatAppearance.BorderColor = Color.Indigo;
            mediaTypeAudioOnly.FlatAppearance.BorderSize = 3;
            mediaTypeAudioOnly.FlatAppearance.CheckedBackColor = Color.FromArgb( 192, 192, 255 );
            mediaTypeAudioOnly.FlatAppearance.MouseDownBackColor = Color.FromArgb( 160, 160, 255 );
            mediaTypeAudioOnly.FlatAppearance.MouseOverBackColor = Color.FromArgb( 210, 210, 255 );
            mediaTypeAudioOnly.FlatStyle = FlatStyle.Flat;
            mediaTypeAudioOnly.Font = new Font( "Outfit Medium", 20F );
            mediaTypeAudioOnly.Location = new Point( 175, 321 );
            mediaTypeAudioOnly.Name = "mediaTypeAudioOnly";
            mediaTypeAudioOnly.Size = new Size( 162, 50 );
            mediaTypeAudioOnly.TabIndex = 3;
            mediaTypeAudioOnly.TabStop = true;
            mediaTypeAudioOnly.Text = "Audio Only";
            mediaTypeAudioOnly.TextAlign = ContentAlignment.MiddleCenter;
            mediaTypeAudioOnly.UseVisualStyleBackColor = true;
            mediaTypeAudioOnly.CheckedChanged +=  mediaTypeAudioOnly_CheckedChanged ;
            // 
            // mediaTypeAudioVideo
            // 
            mediaTypeAudioVideo.Appearance = Appearance.Button;
            mediaTypeAudioVideo.AutoSize = true;
            mediaTypeAudioVideo.BackgroundImageLayout = ImageLayout.None;
            mediaTypeAudioVideo.Cursor = Cursors.Hand;
            mediaTypeAudioVideo.FlatAppearance.BorderColor = Color.Indigo;
            mediaTypeAudioVideo.FlatAppearance.BorderSize = 3;
            mediaTypeAudioVideo.FlatAppearance.CheckedBackColor = Color.FromArgb( 192, 192, 255 );
            mediaTypeAudioVideo.FlatAppearance.MouseDownBackColor = Color.FromArgb( 160, 160, 255 );
            mediaTypeAudioVideo.FlatAppearance.MouseOverBackColor = Color.FromArgb( 210, 210, 255 );
            mediaTypeAudioVideo.FlatStyle = FlatStyle.Flat;
            mediaTypeAudioVideo.Font = new Font( "Outfit Medium", 20F );
            mediaTypeAudioVideo.Location = new Point( 420, 321 );
            mediaTypeAudioVideo.Name = "mediaTypeAudioVideo";
            mediaTypeAudioVideo.Size = new Size( 196, 50 );
            mediaTypeAudioVideo.TabIndex = 4;
            mediaTypeAudioVideo.Text = "Audio + Video";
            mediaTypeAudioVideo.TextAlign = ContentAlignment.MiddleCenter;
            mediaTypeAudioVideo.UseVisualStyleBackColor = true;
            mediaTypeAudioVideo.CheckedChanged +=  mediaTypeAudioVideo_CheckedChanged ;
            // 
            // step5GoButton
            // 
            step5GoButton.Font = new Font( "Outfit SemiBold", 25F );
            step5GoButton.Location = new Point( 175, 493 );
            step5GoButton.Name = "step5GoButton";
            step5GoButton.Size = new Size( 571, 50 );
            step5GoButton.TabIndex = 0;
            step5GoButton.Text = "Start";
            step5GoButton.UseVisualStyleBackColor = true;
            step5GoButton.Click +=  step4GoButton_Click ;
            // 
            // step4Label
            // 
            step4Label.AutoSize = true;
            step4Label.Font = new Font( "Outfit", 30F );
            step4Label.ForeColor = Color.Indigo;
            step4Label.Location = new Point( 12, 406 );
            step4Label.Name = "step4Label";
            step4Label.Size = new Size( 145, 50 );
            step4Label.TabIndex = 10;
            step4Label.Text = "Step 4:";
            // 
            // step4DirTextBox
            // 
            step4DirTextBox.Font = new Font( "Outfit", 15F );
            step4DirTextBox.Location = new Point( 175, 419 );
            step4DirTextBox.Name = "step4DirTextBox";
            step4DirTextBox.PlaceholderText = "Directory To Save Files";
            step4DirTextBox.Size = new Size( 456, 33 );
            step4DirTextBox.TabIndex = 11;
            // 
            // step4DirSelectButton
            // 
            step4DirSelectButton.Font = new Font( "Outfit SemiBold", 15F );
            step4DirSelectButton.Location = new Point( 637, 419 );
            step4DirSelectButton.Name = "step4DirSelectButton";
            step4DirSelectButton.Size = new Size( 109, 33 );
            step4DirSelectButton.TabIndex = 12;
            step4DirSelectButton.Text = "Select";
            step4DirSelectButton.UseVisualStyleBackColor = true;
            step4DirSelectButton.Click +=  step4DirSelectButton_Click ;
            // 
            // FormParent
            // 
            AutoScaleDimensions = new SizeF( 7F, 15F );
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size( 800, 589 );
            Controls.Add( step4DirSelectButton );
            Controls.Add( step4DirTextBox );
            Controls.Add( step4Label );
            Controls.Add( step5GoButton );
            Controls.Add( mediaTypeAudioVideo );
            Controls.Add( mediaTypeAudioOnly );
            Controls.Add( step5Label );
            Controls.Add( step2UrlBox );
            Controls.Add( step1YoutubeLink );
            Controls.Add( step3Label );
            Controls.Add( step2Label );
            Controls.Add( step1Label );
            Controls.Add( MainDescriptionLabel );
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormParent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DownloadYoutube";
            ResumeLayout( false );
            PerformLayout();
        }

        #endregion

        private Label MainDescriptionLabel;
        private Label step1Label;
        private Label step2Label;
        private Label step3Label;
        private LinkLabel step1YoutubeLink;
        private TextBox step2UrlBox;
        private Label step5Label;
        private RadioButton mediaTypeAudioOnly;
        private RadioButton mediaTypeAudioVideo;
        private Button step5GoButton;
        private Label step4Label;
        private TextBox step4DirTextBox;
        private Button step4DirSelectButton;
    }
}
