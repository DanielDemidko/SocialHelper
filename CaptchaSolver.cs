using System;
using System.Diagnostics;
using VkNet.Utils.AntiCaptcha;

class CaptchaSolver : ICaptchaSolver
{
    public void CaptchaIsFalse()
    {
        Console.WriteLine("Капча не подходит!");
    }

    public string Solve(String url)
    {
        Console.Write("Необходимо ввести капчу из браузера: ");
        Process.Start(url);
        return Console.ReadLine();
    }
}