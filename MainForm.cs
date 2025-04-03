using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace DownloadYoutube
{
    public partial class FormParent : Form
    {
        private Form overlayForm = new();
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTSYSMENU = 0x3;
        private Form pictureForm = new Form();

        public FormParent()
        {
            InitializeComponent();
            InitializeOverlayForm();
            AcceptButton = step5GoButton;
            MouseClick += FormParent_MouseClick;
        }

        private void InitializeOverlayForm()
        {
            overlayForm = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                ShowInTaskbar = false,
                BackColor = Color.Black,
                Opacity = 0.3, // Adjust for desired fade effect
                Size = ClientSize,
                Location = Location
            };
        }

        private void FormParent_MouseClick( object sender, MouseEventArgs e )
        {
            if( pictureForm != null && !pictureForm.IsDisposed )
            {
                pictureForm.Close();
            }
        }

        protected override void WndProc( ref Message m )
        {
            if( m.Msg == WM_NCLBUTTONDOWN && m.WParam.ToInt32() == HTSYSMENU )
            {
                ShowPicture();
                return;
            }

            base.WndProc( ref m );
        }

        private void ShowPicture()
        {
            if( pictureForm != null && !pictureForm.IsDisposed )
            {
                pictureForm.Close();
            }

            // Display the picture
            pictureForm = new Form();
            pictureForm.FormClosed += ( s, e ) => overlayForm.Hide();
            pictureForm.Text = "Zhonya & River Download Youtube";
            pictureForm.Size = new Size( 626, 626 );
            pictureForm.Icon = Icon;
            pictureForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            pictureForm.MinimizeBox = false;
            pictureForm.MaximizeBox = false;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Click += ( s, e ) => pictureForm.Close();
            pictureBox.Dock = DockStyle.Fill;

            // Load the image from embedded resources
            var assembly = Assembly.GetExecutingAssembly();
            using( var stream = assembly.GetManifestResourceStream( "DownloadYoutube.YoutubeDownloader_Full.png" ) )
            {
                if( stream == null )
                {
                    Debug.Print( "Stream is null" );
                    return;
                }

                pictureBox.Image = Image.FromStream( stream );
            }

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureForm.Controls.Add( pictureBox );

            // Center the picture form relative to the main form
            pictureForm.StartPosition = FormStartPosition.Manual;
            pictureForm.Location = new Point( Location.X + ( Width - pictureForm.Width ) / 2,
                                             Location.Y + ( Height - pictureForm.Height ) / 2 );

            // Close the popup when clicking on the parent form or pressing Escape
            pictureForm.Deactivate += ( s, e ) => pictureForm.Close();
            pictureForm.KeyDown += ( s, e ) => { if( e.KeyCode == Keys.Escape ) pictureForm.Close(); };
            pictureForm.KeyPreview = true; // Ensure the form receives key events

            overlayForm.Show();
            pictureForm.Show();
        }

        private void step1YoutubeLink_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            // Set the link as visited
            step1YoutubeLink.LinkVisited = true;

            // Open the link in the default web browser
            Process.Start( new ProcessStartInfo
            {
                FileName = "https://www.youtube.com",
                UseShellExecute = true
            } );
        }

        private void mediaTypeAudioOnly_CheckedChanged( object sender, EventArgs e )
        {
            if( mediaTypeAudioOnly.Checked )
            {
                mediaTypeAudioVideo.Checked = false;
                mediaTypeVideoOnly.Checked = false;
            }
        }

        private void mediaTypeAudioVideo_CheckedChanged( object sender, EventArgs e )
        {
            if( mediaTypeAudioVideo.Checked )
            {
                mediaTypeAudioOnly.Checked = false;
                mediaTypeVideoOnly.Checked = false;
            }
        }

        private void mediaTypeVideoOnly_CheckedChanged( object sender, EventArgs e )
        {
            if( mediaTypeAudioVideo.Checked )
            {
                mediaTypeAudioOnly.Checked = false;
                mediaTypeAudioVideo.Checked = false;
            }
        }

        private async void step4GoButton_Click( object sender, EventArgs e )
        {
            string url = step2UrlBox.Text;
            bool failed = false;

            if( string.IsNullOrWhiteSpace( url ) )
            {
                MessageBox.Show( $"Make sure you submit a www.youtube.com URL\n'{url}' is invalid", "URL doesn't look right", MessageBoxButtons.OK, MessageBoxIcon.Error );
                failed = true;
            }
            else if( url.Contains( ' ' ) || url.Contains( '\t' ) || url.Contains( '\n' ) )
            {
                MessageBox.Show( $"URL contains whitespace\n'{url}' is invalid", "URL doesn't look right", MessageBoxButtons.OK, MessageBoxIcon.Error );
                failed = true;
            }
            else if( !url.StartsWith( "www.youtube.com" ) && !url.StartsWith( "http://www.youtube.com" ) && !url.StartsWith( "https://www.youtube.com" ) && !url.StartsWith( "youtube.com" ) )
            {
                MessageBox.Show( $"Doesn't appear to be a youtube link\n'{url}' is invalid", "URL doesn't look right", MessageBoxButtons.OK, MessageBoxIcon.Error );
                failed = true;
            }

            if( failed )
            {
                return;
            }

            try
            {
                YoutubeClient youtube = new YoutubeClient();
                VideoId videoId = VideoId.Parse( url );
                Video video = await youtube.Videos.GetAsync( videoId );
                Debug.Print( $"Video ID: {videoId}" );

                // get the video title and if it contains "Official Music Video" or "Music Video", remove that from the string
                string title = video.Title;
                if( title.Contains( "Official Music Video" ) )
                {
                    title = title.Replace( "Official Music Video", "" );
                }
                else if( title.Contains( "Music Video" ) )
                {
                    title = title.Replace( "Music Video", "" );
                }

                if( title.Contains( "()" ) )
                {
                    title = title.Replace( "()", "" ).Trim();
                }

                Debug.Print( $"Video Title: {video.Title}" );

                var streamManifest = await youtube.Videos.Streams.GetManifestAsync( videoId );
                Debug.Print( $"Stream Manifest: {streamManifest}" );

                Debug.Print( $"{streamManifest.Streams.Count} streams available" );

                IStreamInfo? streamInfo = null;

                if( mediaTypeAudioOnly.Checked )
                {
                    streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                }
                else if( mediaTypeAudioVideo.Checked )
                {
                    streamInfo = streamManifest.GetMuxedStreams().GetWithHighestBitrate();
                }
                else if( mediaTypeVideoOnly.Checked )
                {
                    streamInfo = streamManifest.GetVideoOnlyStreams().GetWithHighestBitrate();
                }
                else
                {
                    Debug.Print( "Unknown Media Type" );
                }

                if( streamInfo == null )
                {
                    Debug.Print( "Stream Info is null" );
                    return;
                }
                Debug.Print( $"Stream Info: {streamInfo.Container.Name}" );

                string extension = streamInfo.Container.Name;
                Debug.Print( $"Extension: {extension}" );

                overlayForm.Owner = this;
                overlayForm.Size = ClientSize;
                overlayForm.Location = PointToScreen( Point.Empty );
                overlayForm.Show();

                string outputFilePath = string.Empty;

                bool cancelled = false;

                using( NameInputDialog nameInputDialog = new NameInputDialog( title, extension ) )
                {
                    if( nameInputDialog.ShowDialog( this ) == DialogResult.OK )
                    {
                        outputFilePath = Path.Combine( step4DirTextBox.Text, nameInputDialog.InputText );
                        Debug.Print( $"File Name = {nameInputDialog.InputText}" );
                    }
                    else
                    {
                        cancelled = true;
                    }
                }

                overlayForm.Hide();

                if( !cancelled )
                {
                    if( string.IsNullOrWhiteSpace( outputFilePath ) )
                    {
                        MessageBox.Show( $"Output file path is empty\n'{outputFilePath}' is invalid", "Output file path doesn't look right", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        return;
                    }

                    Debug.Print( $"Output File Path: {outputFilePath}" );
                    downloadProgressBar.Value = 0;
                    YoutubeDownloader downloader = new YoutubeDownloader();

                    IProgress<double> progress = new Progress<double>( percent =>
                    {
                        Debug.Print( $"Download Progress: {percent}%" );
                        downloadProgressBar.Value = (int)( percent * 100 );
                        downloadProgressBar.Value = Math.Max( 0, downloadProgressBar.Value - 1 ); // Force immediate update
                        downloadProgressBar.Value = (int)( percent * 100 );

                        if( percent >= 1 )
                        {
                            downloadProgressBar.Value = 0;
                        }
                    } );

                    await downloader.DownloadFile( streamInfo, outputFilePath, progress );
                }
            }
            catch( Exception ex )
            {
                Debug.Print( $"Error: {ex.Message}" );
            }
        }

        private void step4DirSelectButton_Click( object sender, EventArgs e )
        {
            // use folderBrowserDialog and open a folder browser dialog to select the output file path
            using( FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog() )
            {
                folderBrowserDialog.Description = "Select the output folder";
                folderBrowserDialog.ShowNewFolderButton = true;
                folderBrowserDialog.InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory );

                if( folderBrowserDialog.ShowDialog() == DialogResult.OK )
                {
                    // Put the chosen location in the textbox
                    step4DirTextBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        protected override void OnMove( EventArgs e )
        {
            base.OnMove( e );
            if( overlayForm != null )
            {
                overlayForm.Location = Location;
            }
        }

        protected override void OnResize( EventArgs e )
        {
            base.OnResize( e );
            if( overlayForm != null )
            {
                overlayForm.Size = ClientSize;
            }
        }
    }
}
