using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TelegramTwitchBot
{
    class TwitchClass
    {
        private static string _nicknameOnTwitch = "LipaTree";
        private static string _tokenTwitch = "yvy8mf472go0rblnra4rcjytgn499p";
        private static string _url = "https://api.twitch.tv/helix/streams";

        async Task<string> GetAsync(string uri)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers["Client-ID"] = _tokenTwitch;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task<string> getResponse()
        {
            string uri = _url + "?user_login=" + _nicknameOnTwitch;
            string jsonResponseString = await GetAsync(uri);

            Console.WriteLine(jsonResponseString);
            return jsonResponseString;
        }

    }
}
