using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace TelegramTwitchBot
{
    class TelegramBot
    {
        private static TelegramBotClient Bot;
        static string _token = "588146438:AAE_GOVto-Vaj9oxNQ3dmaM1NQB4TCT0rZU";
        static string _channelName = "@lipatree";
        public TelegramBot()
        {
            Bot = new TelegramBotClient(_token);
        }

        private TelegramBot(int i)
        {

        }



        public async Task TestApiAsync()
        {
            await Bot.SendTextMessageAsync(_channelName, "Стримчайский начался! [Тык](https://www.twitch.tv/lipatree)", parseMode: ParseMode.Markdown);
            var me = await Bot.GetMeAsync();


        }


    }

}

