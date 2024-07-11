


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using static System.Net.WebRequestMethods;

namespace HW_VideoYoutubeDownload
{
    internal class GetVideo : ILoadin
    {
        string _urlVideo;

        public GetVideo(string urlVideo)
        {
            _urlVideo = urlVideo;
        }
        public async Task Operation()
        {

            var path = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            Console.WriteLine("Скачивание...!");

            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(_urlVideo);

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);

            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            if (streamInfo != null)
            {
                var fileName = $"{video.Title}.{streamInfo.Container}";
                var filePath = Path.Combine(path, fileName);

                await youtube.Videos.Streams.DownloadAsync(streamInfo, filePath);

                Console.WriteLine("Скачивание завершено!");
                Console.WriteLine($" Файл сохранен в каталоге: \n{filePath}!");
            }
            else
            {
                throw new Exception("Упс! что то пошло не так!\nНе удалось скачать видео!\n Попробуйте снова!");
            }
        }
    }
}
