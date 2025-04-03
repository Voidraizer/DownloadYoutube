using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace DownloadYoutube
{
    internal class YoutubeDownloader
    {
        private readonly YoutubeClient youtube = new();

        public async Task DownloadFile( IStreamInfo streamInfo, string outputFilePath, IProgress<double> progress )
        {
            try
            {
                await youtube.Videos.Streams.DownloadAsync( streamInfo, outputFilePath, progress );
                Debug.Print( "Download Complete!" );
            }
            catch( Exception ex )
            {
                Debug.Print( $"Error: {ex.Message}" );
                Debug.Print( $"Stack Trace: {ex.StackTrace}" );
            }
        }
    }
}
