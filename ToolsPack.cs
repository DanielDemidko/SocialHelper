using System;
using System.Threading;
using VkNet;
using VkNet.Model.RequestParams;


class ToolsPack
{
    private readonly VkApi Api = ApiFactory.CreateApi();

    public void StartSpam(MessagesSendParams message, Int32 size, Func<Int32, String> updater = null)
    {
        for (Int32 i = 1; i <= size; ++i)
        {
            if (updater != null)
            {
                message.Message = updater(i);
            }
            Console.WriteLine($"Выстрел №{i}...");
            Api.Messages.Send(message);
            Console.WriteLine($"Выстрел успешно достиг цели!");
            if (i % 20 == 0)
            {
                Console.WriteLine("Дислоцируем пушку, потребуется минута");
                for (Int32 j = 0; j < 6; ++j)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    Console.Write('.');
                }
                Console.WriteLine();
            }
        }
    }

    public void PrintDialogs()
    {
        Console.WriteLine("Вывод всех диалогов...");
        foreach (var i in Api.Messages.SearchDialogs("7").Chats)
        {
            Console.WriteLine($"{i.Title}: {i.Id}");
        }

    }
}
