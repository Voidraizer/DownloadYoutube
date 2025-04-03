using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace DownloadYoutube
{
    public partial class FormParent : Form
    {
        private Form overlayForm;

        public FormParent()
        {
            InitializeComponent();
            InitializeOverlayForm();
            AcceptButton = step5GoButton;
        }

        //private void InitializeOverlayPanel()
        //{
        //    overlayPanel = new Panel
        //    {
        //        Dock = DockStyle.Fill,
        //        BackColor = Color.FromArgb( 128, 255, 255, 255 ), // Semi-transparent white
        //        Visible = false
        //    };
        //    Controls.Add( overlayPanel );
        //    overlayPanel.BringToFront();
        //}

        private void InitializeOverlayForm()
        {
            overlayForm = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                ShowInTaskbar = false,
                BackColor = Color.Black,
                Opacity = 0.5, // Adjust for desired fade effect
                Size = ClientSize,
                Location = Location
            };
        }

        private void step1YoutubeLink_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            // Set the link as visited
            step1YoutubeLink.LinkVisited = true;

            // Open the link in the default web browser
            System.Diagnostics.Process.Start( new ProcessStartInfo
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
            }
        }

        private void mediaTypeAudioVideo_CheckedChanged( object sender, EventArgs e )
        {
            if( mediaTypeAudioVideo.Checked )
            {
                mediaTypeAudioOnly.Checked = false;
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
                var youtube = new YoutubeClient();
                var videoId = YoutubeExplode.Videos.VideoId.Parse( url );
                var video = await youtube.Videos.GetAsync( videoId );
                Debug.Print( $"Video ID: {videoId}" );
                Debug.Print( $"Video Title: {video.Title}" );
                //var outputFilePath = Path.Combine( Environment.CurrentDirectory, $"{videoId}.mp3" );

                var streamManifest = await youtube.Videos.Streams.GetManifestAsync( videoId );
                Debug.Print( $"Stream Manifest: {streamManifest}" );

                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                Debug.Print( $"Stream Info: {streamInfo}" );

                overlayForm.Owner = this;
                //overlayForm.Bounds = Bounds;
                overlayForm.Size = ClientSize;
                overlayForm.Location = PointToScreen( Point.Empty );
                overlayForm.Show();

                using( NameInputDialog nameInputDialog = new NameInputDialog( video.Title ) )
                {
                    nameInputDialog.ShowDialog( this );
                }

                overlayForm.Hide();

                //await youtube.Videos.Streams.DownloadAsync( streamInfo, outputFilePath );

                //// statusLabel.Text = "Downloading...";
                //await youtube.Videos.DownloadAsync( url, outputFilePath, o => o.SetContainer( "mp3" ) );
                //// statusLabel.Text = $"Download complete: {outputFilePath}";
            }
            catch( Exception ex )
            {
                Debug.Print( $"Error: {ex.Message}" );
                // statusLabel.Text = $"Error: {ex.Message}";
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
