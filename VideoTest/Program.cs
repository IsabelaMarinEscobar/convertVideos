
using NReco.VideoConverter;
using System.Text;

namespace MyVideosConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().GetAwaiter().GetResult();
        }

         public static async Task Run()
        {
            var result = new FFMpegConverter();
            Console.WriteLine("Set de configuraciones del video... ");

            //Settings
            ConcatSettings set = new ConcatSettings();
            set.SetVideoFrameSize(640, 480);
            set.ConcatAudioStream = false;
            set.ConcatVideoStream = true;
            set.VideoCodec = "h264";
            set.VideoFrameRate = 30;

            Console.WriteLine("Tamaño 640 x 780, Frames 30 ");
            Console.WriteLine("Setting video "+ set);

            //Videos
            string output = @"C:\videos\final-test.mp4";
            string video1 = @"C:\videos\video1.mp4";
            string video2 = @"C:\videos\video2.mp4";

            string[] files = new string[]
            {
                video1, video2
            };
            Console.WriteLine("Esto puedo tomas un tiempo... ");
            try
            {
                //Union de Videos
                Console.WriteLine("Empezando ...");
				result.ConcatMedia(files, output, NReco.VideoConverter.Format.mp4, set);
                Console.WriteLine("FINALIZADO");
            } catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

	}
}
