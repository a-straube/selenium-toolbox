using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumSandbox
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            // IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            IWebElement webElement = driver.FindElement(By.Name("q"));
            webElement.SendKeys("selenium");
            webElement.SendKeys(Keys.Return);
        }

        [Test]
        public void EAWebSiteTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");

            //IWebElement loginLink = driver.FindElement(By.Id("loginLink"));
            //loginLink.Click();
            SeleniumCustomMethods.Click(driver, By.Id("loginLink"));

            //IWebElement txtUserName = driver.FindElement(By.Name("UserName"));
            //txtUserName.SendKeys("admin");
            SeleniumCustomMethods.EnterText(driver, By.Name("UserName"), "admin");

            IWebElement txtPassword = driver.FindElement(By.Id("Password"));
            txtPassword.SendKeys("password");
            IWebElement btnLogin = driver.FindElement(By.ClassName("btn"));
            btnLogin.Submit();
        }

        [Test]
        public void WorkingWithAdvancedControls()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://seleniumbase.io/demo_page");

            SelectElement selectElemnt = new SelectElement(driver.FindElement(By.Id("mySelect")));
            selectElemnt.SelectByText("Set to 50%");
            IList<IWebElement> selectedOption = selectElemnt.AllSelectedOptions;

            foreach (IWebElement option in selectedOption)
            {
                Console.WriteLine(option.Text);
            }
        }
    }
}