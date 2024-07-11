using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace HW_VideoYoutubeDownload
{
    internal class GetInfoVideo : ILoadin
    {
        string _urlVideo;
        public GetInfoVideo(string url)
        {
            _urlVideo = url;
        }
        public async Task Operation()
        {
            var youtube = new YoutubeClient();
            var videoInfo =  youtube.Videos.GetAsync(_urlVideo).Result; 
            if(videoInfo != null) { 
            var title = videoInfo.Title; 
            var duration = videoInfo.Duration.ToString();
            var description = videoInfo.Description;

            Console.WriteLine(" Общая информация о видео:");
            Console.WriteLine($" Название - {title}, \n продолжительность - {duration} \n описание - {description}");
            Console.WriteLine();
            }
            else
            {
                throw new Exception("Упс! что то пошло не так!\nНе удалось получить информацию о видео!\n Попробуйте снова!");
            }
        }
    }
}
