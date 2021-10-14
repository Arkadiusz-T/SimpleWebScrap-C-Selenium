using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver chromDriver = new ChromeDriver();
            String urlToVisit = "https://www.google.pl/";
            chromDriver.Navigate().GoToUrl(urlToVisit);
            
            
            //Agree to user policy
            IWebElement butBlockingWebsite = chromDriver.FindElement(By.XPath("//*[@id=\"L2AGLb\"]/div"));
            butBlockingWebsite.Click();

            //Search for selenium tutorials in google
            IWebElement textBox = chromDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"));
            String textToSearch = "Selenium tutorials";
            textBox.SendKeys(textToSearch);

            //Scrap titles and links then print them to the console
            IWebElement searchButton = chromDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]"));
            searchButton.Click();
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> links = chromDriver.FindElements(By.ClassName("yuRUbf"));
            Console.WriteLine("Hej działam, pobrano elementy ze strony:");
            foreach (IWebElement link in links){
                String linkSrc = link.FindElement(By.TagName("a")).GetAttribute("href");
                String title = link.FindElement(By.TagName("a")).FindElement(By.TagName("h3")).Text;
                Console.WriteLine( title + "-> " + linkSrc);
            }
            Console.WriteLine("Hej koniec programu");
        }
    }
}
