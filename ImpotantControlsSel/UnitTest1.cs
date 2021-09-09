using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ImpotantControlsSel
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        //Select from complex date picker
        [TestMethod]
        public void SelectValueFromDate()
        {
            IWebDriver driver = new ChromeDriver();
            //I want to select date and month as below
            string month = "December 2021";
            string date = "25";            

            driver.Navigate().GoToUrl("https://www.phptravels.net/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//input[@id='checkin']")).Click();            

            while (true)
            {
                string currentDateandMonth = driver.FindElement(By.XPath("//div[@class='datepicker-days']//table[@class=' table-condensed']//thead//tr//th[@class='switch']")).Text;
                if (currentDateandMonth.Equals(month))
                {
                    break;
                }
                else
                {
                    //driver.FindElement(By.XPath("//div[@class='datepicker-days']//table[@class=' table-condensed']//thead//tr//th[@class='next']")).Click();
                    driver.FindElement(By.XPath("/html/body/div[9]/div[1]/table/thead/tr[1]/th[3]/i")).Click();
                }
                //table[@class=' table-condensed']//tbody//tr//td
                driver.FindElement(By.XPath("//div[9]//div[1]//table[1]//tbody[1]//tr//td[contains(text(),'25')]")).Click();
            }

            driver.Dispose();

        }

        [TestMethod]
        public void SelectDateByJS()
        {
            string dateVal  = "20-09-2021";
           
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.phptravels.net/");
            driver.Manage().Window.Maximize();
            //IWebElement date = driver.FindElement(By.XPath("//div[@class='css-76zvg2 css-bfa6kz r-1862ga2 r-1gkfh8e' and text()='Departure Date']"));
            
            IWebElement date = driver.FindElement(By.XPath("//input[@id='checkin']"));
            SelectDateJS (driver, date, dateVal);

            driver.Dispose();


        }
        public static void SelectDateJS(IWebDriver driver, IWebElement element, string dateValue)
        {
            
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('value','" + dateValue + "');", element);

        }
    }
}
