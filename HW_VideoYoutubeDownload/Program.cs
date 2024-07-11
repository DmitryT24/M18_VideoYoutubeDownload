using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HW_VideoYoutubeDownload
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var urlUserConst = "https://www.youtube.com/watch?v=GkMdejyiYjQ&ab_channel=SamJones23";

            Console.WriteLine($"Введите URL вашего видеоролика - затем Enter\n или нажмите Enter для скачивания по ссылке - \n{urlUserConst}");
            
            try
            {
                string url = Console.ReadLine();

                if (url.Length <= 1)
                {
                    url = urlUserConst;
                }
                WorkUs workUs = new WorkUs();

                ILoadin getInfoVideo = new GetInfoVideo(url);
                workUs.SetCommand(new GetInfoCommand(getInfoVideo));
                await workUs.RunCommand();

                ILoadin downloadVideo = new GetVideo(url);
                workUs.SetCommand(new DownloadVideoCommand(downloadVideo));
                await workUs.RunCommand();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Чтобы закрыть программу нажмите Enter!");
            Console.ReadKey();
        }
    }
}
