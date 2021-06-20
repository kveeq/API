using System;
using Telegram.Bot;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            TelegramBotClient bot = new TelegramBotClient("1709867716:AAFwIFr0N0pHlBPMLvE2cwJoucj_ifK88rM");
            string f = "Напишите IP адрес вида: 44.12.42.55";
            bot.OnMessage += (s, arg) =>
            {
                Console.WriteLine($"{arg.Message.Chat.FirstName}: {arg.Message.Text}");
                try
                {
                    f = API.GetInfo(arg.Message.Text);
                }
                catch { }
                bot.SendTextMessageAsync(arg.Message.Chat.Id, $"Город по IP: {f}");
            };
            f = "Напишите IP адрес вида: 44.12.42.55";

            bot.StartReceiving();

            Console.ReadKey();
        }
    }
}