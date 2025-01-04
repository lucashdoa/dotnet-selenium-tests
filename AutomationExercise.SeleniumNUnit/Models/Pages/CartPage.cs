using OpenQA.Selenium;
using AutomationExercise.SeleniumNUnit.Models.Products;

namespace AutomationExercise.SeleniumNUnit.Pages;

public class CartPage(IWebDriver driver) : BasePage(driver)
{
    private readonly IWebDriver driver = driver;
    private readonly By emptyCartText = By.Id("empty_cart");

    private IWebElement GetProductRemoveButton(string productId)
    {
        return driver.FindElement(By.CssSelector($"td.cart_delete a[data-product-id='{productId}']"));
    }

    public void DeleteProductFromCart(string product)
    {
        string tableRowId = driver.FindElement(By.XPath($"//*[text()='{product}']/ancestor::tr")).GetDomAttribute("id");
        string productId = tableRowId.Substring(tableRowId.Length - 1);
        IWebElement deleteButton = GetProductRemoveButton(productId);

        deleteButton.Click();
    }

    public int GetNumberOfItemsInCart()
    {
        var cartItems = driver.FindElements(By.CssSelector("tbody tr"));
        int numberOfItems = cartItems.Count;

        return numberOfItems;
    }

    public string GetProductDataById(ProductData data, int id)
    {
        string productDataSelector = data switch
        {
            ProductData.quantity => $"#product-{id} td.cart_{data} button",
            _ => $"#product-{id} td.cart_{data} p",
        };
        string productData = driver.FindElement(By.CssSelector(productDataSelector)).Text;

        return productData;
    }

    public bool IsCartEmpty()
    {
        bool isCartEmpty = WaitForElementToBeVisible(emptyCartText,5);

        return isCartEmpty;
    }
}