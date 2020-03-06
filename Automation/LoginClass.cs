using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Automation
{
    class LoginClass
    {
        IWebDriver driver;
        int pageTimer = 5000;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void LoginTest()
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

            AddAddress();

        }

        public void AddAddress()
        {
            
            driver.FindElement(By.XPath("//div[@id='center_column']/div/div/ul/li[3]/a/span")).Click();
            Thread.Sleep(pageTimer);
            driver.FindElement(By.XPath("//div[@id='center_column']/div[2]/a/span")).Click();
            Thread.Sleep(pageTimer);

            Thread.Sleep(pageTimer);
            driver.FindElement(By.Id("address1")).SendKeys("Calle Vasco de Quiroga #7");
            driver.FindElement(By.Id("address2")).SendKeys("Calle Vasco de Quiroga #8");
            driver.FindElement(By.Id("city")).SendKeys("Álvaro Obregón");
            driver.FindElement(By.Id("postcode")).SendKeys("58920");
            driver.FindElement(By.Id("other")).SendKeys("Cerca de la iglesia");
            driver.FindElement(By.Id("phone")).SendKeys("2315647657");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("4433279677");
            driver.FindElement(By.Id("alias")).SendKeys("My real address 2");

            Thread.Sleep(pageTimer);
            IWebElement state = driver.FindElement(By.XPath("//option[@value='1']"));
            state.Click();

            driver.FindElement(By.XPath("//button[@id='submitAddress']/span/i")).Click();

        }


        [TearDown]
        public void closeBrowser()
        {
            Thread.Sleep(pageTimer);
            driver.Close();
        }

    }
}
