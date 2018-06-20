using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TelegramTwitchBot
{
    class TimerClass
    {
        static TwitchClass tw;
        static TelegramBot tg;
        static int k;
        public TimerClass()
        {
            tw = new TwitchClass();
            tg = new TelegramBot();
            k = 0;
        }
        public void timer()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 60 * 5000; //you can change time
            aTimer.Enabled = true;

            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private static async void OnTimedEvent(object source, ElapsedEventArgs e)
        {

            string jsonTwitch = await tw.getResponse();
            if (jsonTwitch.Contains("live"))
            {
                if (k == 0)
                {
                    Console.WriteLine("Send message to telegram channel");
                    await tg.TestApiAsync();
                    k++;
                }
                Console.WriteLine("Stream is online");
            }
            else
            {
                Console.WriteLine("Stream is offline");
                k = 0;
            }


        }
    }
}
