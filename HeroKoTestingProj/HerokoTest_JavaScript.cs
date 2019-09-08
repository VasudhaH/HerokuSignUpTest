using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

/* 
 * FOR YOUR KIND INFORMATION ---
 I HAVE DONE THIS JUST FOR DEMO PURPOSE AND TIME BEING
 COVERED VERY BASIC VALIDATION Assumed that the  current page is Working fine with no issues.
 THIS CODE WILL BE REFRACTORED AND ORGANISED 
 IN REALTIME I WRITE THE TEST CASES VERY FORMAL WAY USING FRAME WORK AND CLASS HIERARCHY TO AVOID THE DUPLICATION AND USE OOPS CONCEPTS
 FOR DEMO PURPOSE I HAVE PASSED HARD CODED TEST VALUES
 I HAD VERY LIMITED PLATFORM FOR JAVASCRIPT SO USED SELENIUM, C# WITH JAVASCRIPT
 //Scope of testing
 As per the requirement not tested CAPTCHA at this moment.
 
 THANK YOU - VASUDHA
 */

namespace HeroKoTestingProj
{
    [TestClass]
    public class HerokoTest_JavaScript
    {
        IWebDriver chromeDriver;
        IJavaScriptExecutor js;
        
        [TestInitialize]
        public void TestInitialise()
        {
            chromeDriver = new ChromeDriver();
              chromeDriver.Navigate().GoToUrl("https://signup.heroku.com/");
                //Set the Script Timeout to 60 seconds		
                chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);

                //
                js = ((IJavaScriptExecutor)chromeDriver);
                //Ready State
                string readyStateScript = " return document.readyState";

                var state = js.ExecuteScript(readyStateScript);

                while (state.ToString() != "complete")
                {
                    System.Threading.Thread.Sleep(1000);
                }
                chromeDriver.Manage().Window.Maximize();
                Console.WriteLine(" Page Loaded");
            
        }
        [TestMethod]
        [TestCategory("Veirfy button submit Case")]
        [Priority(0)]
        public void ValidateSubmitButton()
        {

            // First Name   Field
            IWebElement elementFirstName = (IWebElement)js.ExecuteScript("return document.getElementById('first_name');");
            elementFirstName.SendKeys("TestFirstName");
            // Last Name   Field
            IWebElement elementlasttName = (IWebElement)js.ExecuteScript("return document.getElementById('last_name');");
            elementlasttName.SendKeys("TestLasttName");

            // Email  Field
            IWebElement elementEmail = (IWebElement)js.ExecuteScript("return document.getElementById('email');");
            elementEmail.SendKeys("TestEmail@abc.com");

            //Roles DropDown List
            IWebElement elementRoles = (IWebElement)js.ExecuteScript("return document.getElementById('role');");
            SelectElement selectRoles = new SelectElement(elementRoles);
            selectRoles.SelectByIndex(1);


            //Countries DropDown List
            IWebElement elementCountries = (IWebElement)js.ExecuteScript("return document.getElementById('self_declared_country');");
            SelectElement selectcountries = new SelectElement(elementCountries);
            selectcountries.SelectByIndex(1);

            //Primary Development language List
            IWebElement elementlanguage = (IWebElement)js.ExecuteScript("return document.getElementById('main_programming_language');");
            SelectElement selectlanguage = new SelectElement(elementlanguage);
            selectlanguage.SelectByIndex(1);

           

            //Button Element
            IWebElement btnSubmit = (IWebElement)(js.ExecuteScript("return document.getElementsByName('commit')[0];"));
            btnSubmit.Click();


            //List of validation on screen Errors
            string ErrorMessage = js.ExecuteScript(" return document.getElementsByClassName('alert alert-error')[0].innerText;").ToString();

            //Validate the Assertions
            String ActualMessage = "True";
            string ExpectedMessage = ErrorMessage.Contains("We could not verify you are not a robot. Please try the CAPTCHA again.").ToString();
            Assert.AreEqual(ExpectedMessage, ActualMessage);
            Console.WriteLine("Test case Validated for all positive inputs");

        }
        [TestMethod]
        [Priority(1)]
        public void ValidteForEmptyFields()
        {

            // First Name   Field
            IWebElement elementFirstName = (IWebElement)js.ExecuteScript("return document.getElementById('first_name');");
            elementFirstName.SendKeys("");
            // Last Name   Field
            IWebElement elementlasttName = (IWebElement)js.ExecuteScript("return document.getElementById('last_name');");
            elementlasttName.SendKeys("");

            // Email  Field
            IWebElement elementEmail = (IWebElement)js.ExecuteScript("return document.getElementById('email');");
            elementEmail.SendKeys("");

            //Roles DropDown List
            IWebElement elementRoles = (IWebElement)js.ExecuteScript("return document.getElementById('role');");
            SelectElement selectRoles = new SelectElement(elementRoles);
            selectRoles.SelectByIndex(0);


            //Countries DropDown List
            IWebElement elementCountries = (IWebElement)js.ExecuteScript("return document.getElementById('self_declared_country');");
            SelectElement selectcountries = new SelectElement(elementCountries);
            selectcountries.SelectByIndex(0);

            //Primary Development language List
            IWebElement elementlanguage = (IWebElement)js.ExecuteScript("return document.getElementById('main_programming_language');");
            SelectElement selectlanguage = new SelectElement(elementlanguage);
            selectlanguage.SelectByIndex(0);
            //
            //Button Element
            IWebElement btnSubmit = (IWebElement)(js.ExecuteScript("return document.getElementsByName('commit')[0];"));
            btnSubmit.Click();

         
            //List of validation on screen Errors
            string ErrorMessage = js.ExecuteScript(" return document.getElementsByClassName('alert alert-error')[0].innerText;").ToString();

            //Validate the Assertions
            String ActualMessage = "True";
            string ExpectedMessage = ErrorMessage.Contains("Please fill in all required field").ToString();
            Assert.AreEqual(ExpectedMessage, ActualMessage);
            Console.WriteLine("Test case Validated for Empty Fields");

        }
        [TestMethod]
        [Priority(3)]
        public void ValidteForNumbers()
        {

            // First Name   Field
            IWebElement elementFirstName = (IWebElement)js.ExecuteScript("return document.getElementById('first_name');");
            elementFirstName.SendKeys("12345");
            // Last Name   Field
            IWebElement elementlasttName = (IWebElement)js.ExecuteScript("return document.getElementById('last_name');");
            elementlasttName.SendKeys("5678");

            // Email  Field
            IWebElement elementEmail = (IWebElement)js.ExecuteScript("return document.getElementById('email');");
            elementEmail.SendKeys("abc@gmail.com");

            //Roles DropDown List
            IWebElement elementRoles = (IWebElement)js.ExecuteScript("return document.getElementById('role');");
            SelectElement selectRoles = new SelectElement(elementRoles);
            selectRoles.SelectByIndex(1);


            //Countries DropDown List
            IWebElement elementCountries = (IWebElement)js.ExecuteScript("return document.getElementById('self_declared_country');");
            SelectElement selectcountries = new SelectElement(elementCountries);
            selectcountries.SelectByIndex(2);

            //Primary Development language List
            IWebElement elementlanguage = (IWebElement)js.ExecuteScript("return document.getElementById('main_programming_language');");
            SelectElement selectlanguage = new SelectElement(elementlanguage);
            selectlanguage.SelectByIndex(3);
            //
            //Button Element
            IWebElement btnSubmit = (IWebElement)(js.ExecuteScript("return document.getElementsByName('commit')[0];"));
            btnSubmit.Click();

           

            //List of validation on screen Errors
            string ErrorMessage = js.ExecuteScript(" return document.getElementsByClassName('alert alert-error')[0].innerText;").ToString();

            //Validate the Assertions
            String ActualMessage = "True";
            string ExpectedMessage = ErrorMessage.Contains("contains invalid characters").ToString();
            Assert.AreEqual(ExpectedMessage, ActualMessage);
            Console.WriteLine("Test case Validated for Empty Fields");

        }


        [TestMethod]
        [Priority(2)]
        public void TestCaseForInvalidEmail()
        {

            // First Name   Field
            IWebElement elementFirstName = (IWebElement)js.ExecuteScript("return document.getElementById('first_name');");
            elementFirstName.SendKeys("TestFirstName");
            // Last Name   Field
            IWebElement elementlasttName = (IWebElement)js.ExecuteScript("return document.getElementById('last_name');");
            elementlasttName.SendKeys("TestLasttName");

            // Email  Field
            IWebElement elementEmail = (IWebElement)js.ExecuteScript("return document.getElementById('email');");
            elementEmail.SendKeys("TestEmail");

            //Roles DropDown List
            IWebElement elementRoles = (IWebElement)js.ExecuteScript("return document.getElementById('role');");
            SelectElement selectRoles = new SelectElement(elementRoles);
            selectRoles.SelectByIndex(1);


            //Countries DropDown List
            IWebElement elementCountries = (IWebElement)js.ExecuteScript("return document.getElementById('self_declared_country');");
            SelectElement selectcountries = new SelectElement(elementCountries);
            selectcountries.SelectByIndex(1);

            //Primary Development language List
            IWebElement elementlanguage = (IWebElement)js.ExecuteScript("return document.getElementById('main_programming_language');");
            SelectElement selectlanguage = new SelectElement(elementlanguage);
            selectlanguage.SelectByIndex(1);

           

            //Button Element
            IWebElement btnSubmit = (IWebElement)(js.ExecuteScript("return document.getElementsByName('commit')[0];"));
            btnSubmit.Click();


            //List of validation on screen Errors
            string ErrorMessage = js.ExecuteScript(" return document.getElementsByClassName('alert alert-error')[0].innerText;").ToString();

            //Validate the Assertions
            String ActualMessage = "True";
            string ExpectedMessage = ErrorMessage.Contains("").ToString();
            Assert.AreEqual(ExpectedMessage, ActualMessage);
            Console.WriteLine("Test case Validated for Invalid Email format");

        }

        [TestMethod]
        [Priority(4)]
        public void ValidateForFirstCharacterBlank()
        {

            // First Name   Field
            IWebElement elementFirstName = (IWebElement)js.ExecuteScript("return document.getElementById('first_name');");
            elementFirstName.SendKeys("  TestFirstName");
            // Last Name   Field
            IWebElement elementlasttName = (IWebElement)js.ExecuteScript("return document.getElementById('last_name');");
            elementlasttName.SendKeys(" TestLasttName");

            // Email  Field
            IWebElement elementEmail = (IWebElement)js.ExecuteScript("return document.getElementById('email');");
            elementEmail.SendKeys("TestEmail@abc.com");

            //Roles DropDown List
            IWebElement elementRoles = (IWebElement)js.ExecuteScript("return document.getElementById('role');");
            SelectElement selectRoles = new SelectElement(elementRoles);
            selectRoles.SelectByIndex(1);


            //Countries DropDown List
            IWebElement elementCountries = (IWebElement)js.ExecuteScript("return document.getElementById('self_declared_country');");
            SelectElement selectcountries = new SelectElement(elementCountries);
            selectcountries.SelectByIndex(1);

            //Primary Development language List
            IWebElement elementlanguage = (IWebElement)js.ExecuteScript("return document.getElementById('main_programming_language');");
            SelectElement selectlanguage = new SelectElement(elementlanguage);
            selectlanguage.SelectByIndex(1);

           

            //Button Element
            IWebElement btnSubmit = (IWebElement)(js.ExecuteScript("return document.getElementsByName('commit')[0];"));
            btnSubmit.Click();


            //List of validation on screen Errors
            string ErrorMessage = js.ExecuteScript(" return document.getElementsByClassName('alert alert-error')[0].innerText;").ToString();

            //Validate the Assertions
            String ActualMessage = "True";
            string ExpectedMessage = ErrorMessage.Contains("First Character should not be Blank Space.").ToString();
            Assert.AreNotEqual(ExpectedMessage, ActualMessage);
            Console.WriteLine("Test case Validated for all positive inputs");

        }



        [TestCleanup]
        public void TestCleanup()
        {
            chromeDriver.Close();
           chromeDriver.Quit();
        }

   
    }
}
