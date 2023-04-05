using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumPrac
{
    internal class Locators
    {
        IWebDriver driver;

        [SetUp]
        public void StartUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            
        }

        [Test]
        public void LocationIdentification()
        {
            driver.Url = "http://122.170.14.195:8080/uth/gadgetsgallery/catalog/";
            driver.FindElement(By.LinkText("log yourself in")).Click();
            driver.FindElement(By.Name("email_address")).SendKeys("anu@gmail.com");
            driver.FindElement(By.Name("password")).SendKeys("ancds");
            //driver.FindElement(By.Id("tdb1")).Click();
            //driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            driver.FindElement(By.XPath("//button[@id='tdb1']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(driver.FindElement(By.ClassName("messageStackError")), "No match for E-Mail Address and/or Password."));
            //Thread.Sleep(1000);
            
            String errMessage = driver.FindElement(By.ClassName("messageStackError")).Text;
            TestContext.Progress.WriteLine(errMessage);
            IWebElement link =driver.FindElement(By.LinkText("Mobile Phones"));
            String hrefAttr=link.GetAttribute("href");
            TestContext.Progress.WriteLine(hrefAttr);
            String expctURL = "http://122.170.14.195:8080/uth/gadgetsgallery/catalog/index.php?cPath=22";
         //   Assert.AreEqual(expctURL, hrefAttr);
            Assert.That(expctURL, Is.EqualTo(hrefAttr));
        }
    }
}
