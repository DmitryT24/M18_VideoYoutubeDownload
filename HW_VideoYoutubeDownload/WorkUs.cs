using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_VideoYoutubeDownload
{
    internal class WorkUs
    {
        ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public async Task RunCommand()
        {
           await _command.RunAsync();
        }
    }
}
