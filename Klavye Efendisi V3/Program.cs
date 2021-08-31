using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;

namespace Klavye_Efendisi_V3
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenQA.Selenium.Chrome.ChromeDriver drv;
            Console.Title = "Klavye Efendisi V3";
            Console.ForegroundColor = ConsoleColor.Green;
        basadon:
            Console.Clear();
            Console.WriteLine("Website : kodzamani.weebly.com");
            Console.WriteLine("İnstagram : @kodzamani.tk");
            Console.Write("Yazma hızı (ms) :");
            int yazmahızı = 1;
            try
            {
                yazmahızı = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                goto basadon;
            }
            if (yazmahızı <= 0)
                yazmahızı = 1;

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            drv = new ChromeDriver(service);
            drv.Navigate().GoToUrl("https://duello.m5bilisim.com/");

            for (; ; )
            {
                if (drv.Url.Contains("/duello") == false)
                {
                    Console.WriteLine("Düello seçmeniz bekleniyor.");
                }
                else
                {
                    for (; ; )
                    {
                        try
                        {
                            if (drv.Url.Contains("/duello") == false)
                                break;
                            string zaman = drv.FindElement(By.XPath("//html/body/div[3]/div[1]/div[2]/div[2]/div[2]")).Text;
                            string kelime = drv.FindElement(By.XPath("//span[@class='golge']")).Text;
                            Thread.Sleep(yazmahızı);
                            drv.FindElement(By.XPath("//html/body/div[3]/div[1]/div[5]/input")).SendKeys(kelime + OpenQA.Selenium.Keys.Space);
                            Console.WriteLine("Kalan süre : " + zaman);
                            Console.WriteLine("Yazılan Kelime : " + kelime);
                            Console.WriteLine("--------------------------");
                        }
                        catch
                        {
                            if (drv.Url.Contains("/duello") == false)
                                break;
                            Console.WriteLine("Lobinin Başlaması bekleniyor.");
                        }
                    }
                }
            }
        }
    }
}
