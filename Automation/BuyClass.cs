using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace Automation
{
    class BuyClass
    {
        IWebDriver driver;
        int pageTimer = 3000;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void ShoppingTest()
        {
            driver.Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";

            Thread.Sleep(pageTimer);
            IWebElement loginForm = driver.FindElement(By.Id("email"));

            Actions loginActions = new Actions(driver);
            loginActions.Click(loginForm)
                .SendKeys("1234qwerty54321@gmail.com" + Keys.Tab)
                .SendKeys("Passwordcorrecta.1" + Keys.Tab + Keys.Tab)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();

            PurchaseTest();

        }
        public void PurchaseTest()
        {
            Thread.Sleep(pageTimer);
            Actions builder = new Actions(driver);
            IWebElement shopBtn = driver.FindElement(By.XPath("(//a[contains(text(),'T-shirts')])[2]"));
            shopBtn.Click();


            Thread.Sleep(pageTimer);
            Thread.Sleep(pageTimer);
            driver.FindElement(By.XPath("//img[@alt='Faded Short Sleeve T-shirts']")).Click();
            Thread.Sleep(pageTimer);
            Thread.Sleep(pageTimer);
            driver.FindElement(By.XPath("//p[@id='add_to_cart']/button/span")).Click();
            Thread.Sleep(pageTimer);
            driver.FindElement(By.XPath("//div[@id='layer_cart']/div/div[2]/div[4]/a/span")).Click();
            Thread.Sleep(pageTimer);
            driver.FindElement(By.XPath("//div[@id='center_column']/p[2]/a/span")).Click();
            Thread.Sleep(pageTimer);
            driver.FindElement(By.XPath("//div[@id='center_column']/form/p/button/span")).Click();
            Thread.Sleep(pageTimer);
            driver.FindElement(By.XPath("//p[2]/div/span/input")).Click();
            Thread.Sleep(pageTimer);
            driver.FindElement(By.XPath("//form[@id='form']/p/button/span")).Click();
            Thread.Sleep(pageTimer);
            driver.FindElement(By.XPath("//div[@id='HOOK_PAYMENT']/div[2]/div/p/a/span")).Click();
            Thread.Sleep(pageTimer);
            driver.FindElement(By.XPath("//p[@id='cart_navigation']/button/span")).Click();


            Thread.Sleep(pageTimer);
        }

        [TearDown]
        public void closeBrowser()
        {
            Thread.Sleep(pageTimer);
            driver.Close();
        }
    }
}
