using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Automation
{
    class RegistrationClass
    {
        IWebDriver driver;
        int pageTimer = 5000;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();

        }

        [Test]
        public void AutoLogin()
        {
            driver.Url = "http://automationpractice.com/index.php";

            Thread.Sleep(pageTimer);

            IWebElement loginBtn = driver.FindElement(By.ClassName("login"));
            loginBtn.Click();

            Thread.Sleep(pageTimer);
            IWebElement emailAdd = driver.FindElement(By.Id("email_create"));
            Actions emailActions = new Actions(driver);
            emailActions.Click(emailAdd)
                .SendKeys("1234qwerty54321@gmail.com" + Keys.Tab)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();

            Thread.Sleep(pageTimer);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Felipe");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Ayala");
            driver.FindElement(By.Id("passwd")).SendKeys("Passwordcorrecta.1");
            driver.FindElement(By.Id("company")).SendKeys("Company");
            driver.FindElement(By.Id("address1")).SendKeys("Mercado #5");
            driver.FindElement(By.Id("address2")).SendKeys("Apartamento 3b");
            driver.FindElement(By.Id("city")).SendKeys("Morelia");
            driver.FindElement(By.Id("postcode")).SendKeys("58920");
            driver.FindElement(By.Id("other")).SendKeys("Cerca de donde venden elotes");
            driver.FindElement(By.Id("phone")).SendKeys("2315647657");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("4433279677");
            driver.FindElement(By.Id("alias")).SendKeys("My real address");

            Thread.Sleep(pageTimer);
            IWebElement day = driver.FindElement(By.XPath("//option[6]"));
            day.Click();
            IWebElement month = driver.FindElement(By.XPath("(//option[@value='4'])[2]"));
            month.Click();
            IWebElement year = driver.FindElement(By.XPath("//option[@value='1997']"));
            year.Click();

            Thread.Sleep(pageTimer);
            IWebElement state = driver.FindElement(By.XPath("(//option[@value='5'])[3]"));
            state.Click();

            Thread.Sleep(pageTimer);
            IWebElement sendButton = driver.FindElement(By.Id("submitAccount"));
            sendButton.Click();


        }

        [TearDown]
        public void closeBrowser()
        {
            Thread.Sleep(pageTimer);
            driver.Close();
        }

    }
}
