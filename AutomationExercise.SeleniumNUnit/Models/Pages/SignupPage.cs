using AutomationExericse.SeleniumNUnit.Models.Users;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise.SeleniumNUnit.Pages;

public class SignupPage(IWebDriver driver)
{
    private readonly By signupLoginButton = By.CssSelector("a[href*=login]");
    private readonly By signupNameInput = By.CssSelector("[data-qa=signup-name]");
    private readonly By signupEmailInput = By.CssSelector("[data-qa=signup-email]");
    private readonly By signupButton = By.CssSelector("[data-qa=signup-button]");
    private readonly By genderMaleRadio = By.CssSelector("#id_gender1");
    private readonly By genderFemaleRadio = By.CssSelector("#id_gender2");
    private readonly By passwordInput = By.CssSelector("#password");
    private readonly By birthDaySelect = By.CssSelector("#days");
    private readonly By birthMonthSelect = By.CssSelector("[data-qa='months']");
    private readonly By birthYearSelect = By.CssSelector("#years");
    private readonly By newsletterSelect = By.CssSelector("#newsletter");
    private readonly By offersSelect = By.CssSelector("#optin");
    private readonly By firstNameInput = By.CssSelector("#first_name");
    private readonly By lastNameInput = By.CssSelector("#last_name");
    private readonly By addressInput = By.CssSelector("#address1");
    private readonly By countrySelect = By.CssSelector("#country");
    private readonly By stateInput = By.CssSelector("#state");
    private readonly By cityInput = By.CssSelector("#city");
    private readonly By zipcodeInput = By.CssSelector("#zipcode");
    private readonly By mobileNumberInput = By.CssSelector("#mobile_number");
    private readonly By createAccountButton = By.CssSelector("[data-qa='create-account']");

    public void GoTo()
    {
        driver.Navigate().GoToUrl("https://automationexercise.com/");
    }

    public void SignupUserWithEmail(string user, string email)
    {
        driver.FindElement(signupLoginButton).Click();
        driver.FindElement(signupNameInput).SendKeys(user);
        driver.FindElement(signupEmailInput).SendKeys(email);
        driver.FindElement(signupButton).Click();
    }

    public void EnterAccountInformation(User user)
    {
        if (user.isMale)
        {
            driver.FindElement(genderMaleRadio).Click();
        }
        else
        {
            driver.FindElement(genderFemaleRadio).Click();
        }

        driver.FindElement(passwordInput).SendKeys(user.password);

        new SelectElement(driver.FindElement(birthDaySelect)).SelectByValue(user.birthDay);
        new SelectElement(driver.FindElement(birthMonthSelect)).SelectByValue(user.birthMonth);
        new SelectElement(driver.FindElement(birthYearSelect)).SelectByValue(user.birthYear);

        if (user.isSubscribedNewsletter)
        {
            driver.FindElement(newsletterSelect).Click();
        }

        if (user.isSubscribedSpecialOffers)
        {
            driver.FindElement(offersSelect).Click();
        }

        driver.FindElement(firstNameInput).SendKeys(user.address.firstName);
        driver.FindElement(lastNameInput).SendKeys(user.address.firstName);
        driver.FindElement(addressInput).SendKeys(user.address.fullAddress);
        driver.FindElement(countrySelect).SendKeys(user.address.country);
        driver.FindElement(stateInput).SendKeys(user.address.state);
        driver.FindElement(cityInput).SendKeys(user.address.city);
        driver.FindElement(zipcodeInput).SendKeys(user.address.zipcode);
        driver.FindElement(mobileNumberInput).SendKeys(user.address.phone);

        driver.FindElement(createAccountButton).Click();
    }
}