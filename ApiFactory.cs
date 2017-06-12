#define TEST
using System;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Exception;


static class ApiFactory
{
    private static ApiAuthParams ReadParams()
    {
        var userParams = new ApiAuthParams()
        {
            ApplicationId = ТВОЙИД,
            Settings = Settings.All
        };
        Console.Write("E-mail или номер телефона: ");
        userParams.Login = Console.ReadLine();
        Console.Write("Пароль: ");
        userParams.Login = Console.ReadLine();
        return userParams;
    }

    public static VkApi CreateApi()
    {
        var result = new VkApi(new CaptchaSolver());
        while (!result.IsAuthorized)
        {
            try
            {
                var data = ReadParams();
                Console.WriteLine("Попытка авторизации...");
                result.Authorize(data);
                Console.WriteLine("Авторизация успешно получена!");
            }
            catch (VkApiAuthorizationException error)
            {
                Console.WriteLine($"Ошибка авторизации: {error.Message}\n");
            }
        }
        return result;
    }
}
