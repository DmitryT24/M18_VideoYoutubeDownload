using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HW_VideoYoutubeDownload
{
    internal class GetInfoCommand : ICommand
    {
        ILoadin _getInfoVideo;
        public GetInfoCommand(ILoadin getInfoVideo)
        {
            _getInfoVideo = getInfoVideo;
        }

        public async Task RunAsync()
        {
            await _getInfoVideo.Operation();
        }
    }
}
