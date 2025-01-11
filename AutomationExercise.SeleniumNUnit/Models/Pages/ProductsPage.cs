using AutomationExercise.SeleniumNUnit.Models.Users;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise.SeleniumNUnit.Pages;

public class ProductsPage(IWebDriver driver) : BasePage(driver)
{
    private readonly IWebDriver driver = driver;
    private readonly By searchProductInput = By.Id("search_product");
    private readonly By searchButton = By.Id("submit_search");
    private readonly By cartConfirmationModal = By.Id("cartModal");
    private readonly By continueShoppingButton = By.CssSelector("button[data-dismiss='modal']");

    public void SearchProduct(string product)
    {
        driver.FindElement(searchProductInput).SendKeys(product);
        driver.FindElement(searchButton).Click();
    }

    public void AddProductToCart(string product)
    {
        IWebElement productCard = driver.FindElement(By.XPath($"//div[@class='productinfo text-center']//*[text()='{product}']"));
        ScrollElementIntoView(productCard);
        HoverElement(productCard);

        IWebElement addProductButton = driver.FindElement(By.XPath($"//div[@class='product-overlay']//*[text()='{product}']/following-sibling::a"));
        addProductButton.Click();

        WaitForElementToBeVisible(cartConfirmationModal, 5);
        driver.FindElement(continueShoppingButton).Click();
    }

    public void AddProductToCartByPosition(int position)
    {
        By productCardDiv = By.XPath($"(//div[@class='single-products'])[{position}]");
        By addProductButton = By.XPath($"(//div[@class='product-overlay'])[{position}]//a");

        IWebElement productCard = driver.FindElement(productCardDiv);
        ScrollElementIntoView(productCard);
        HoverElement(productCard);

        IWebElement addProduct = driver.FindElement(addProductButton);
        WaitForElementToBeClickable(addProductButton, 5);
        addProduct.Click();

        WaitForElementToBeVisible(cartConfirmationModal, 5);
        driver.FindElement(continueShoppingButton).Click();
    }
}