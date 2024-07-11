using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HW_VideoYoutubeDownload
{
    internal class DownloadVideoCommand : ICommand
    {
        ILoadin _download;

        public DownloadVideoCommand(ILoadin download)
        {
            _download = download;
        }

        public async Task RunAsync()
        {
            await _download.Operation();
        }
    }
}
