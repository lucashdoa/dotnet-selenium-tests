using AutomationExercise.SeleniumNUnit.Constants;
using AutomationExercise.SeleniumNUnit.Utils;
using AutomationExercise.SeleniumNUnit.Models.Browsers;
using AutomationExercise.SeleniumNUnit.Pages;
using OpenQA.Selenium;
using AutomationExercise.SeleniumNUnit.Models.Products;

namespace AutomationExercise.SeleniumNUnit.Tests;

[TestFixture]
public class CartTests
{
    private IWebDriver driver;
    private ScreenshotHelper screenshotHelper;
    private HomePage homePage;
    private CartPage cartPage;
    private ProductsPage productsPage;

    [SetUp]
    public void Setup()
    {
        driver = DriverFactory.CreateDriver(BrowserType.CHROME);
        driver.Manage().Window.Maximize();

        screenshotHelper = new ScreenshotHelper(driver);

        homePage = new HomePage(driver);
        cartPage = new CartPage(driver);
        productsPage = new ProductsPage(driver);

        homePage.NavigateTo(Routes.home);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
    }

    [Test, Category("TC12"), Category("Regression")]
    public void ShouldAddProductsToCart()
    {
        try
        {
            ReportManager.StartTest("Test Case 12: Add Products in Cart", "Testing cart functionality");

            homePage.NavigateTo(Routes.products);
            productsPage.AddProductToCartByPosition(1);
            productsPage.AddProductToCartByPosition(2);

            productsPage.NavigateTo(Routes.cart);

            Assert.That(cartPage.GetNumberOfItemsInCart, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(cartPage.GetProductDataById(ProductData.price, 1), Is.EqualTo("Rs. 500"));
                Assert.That(cartPage.GetProductDataById(ProductData.quantity, 1), Is.EqualTo("1"));
                Assert.That(cartPage.GetProductDataById(ProductData.total, 1), Is.EqualTo("Rs. 500"));
            });
            Assert.Multiple(() =>
            {
                Assert.That(cartPage.GetProductDataById(ProductData.price, 2), Is.EqualTo("Rs. 400"));
                Assert.That(cartPage.GetProductDataById(ProductData.quantity, 2), Is.EqualTo("1"));
                Assert.That(cartPage.GetProductDataById(ProductData.total, 2), Is.EqualTo("Rs. 400"));
            });

            ReportManager.AttachScreenshot(screenshotHelper.CaptureScreenshot("products-added-to-cart-successfully"));
        }
        catch (Exception e)
        {
            ReportManager.AttachScreenshot(screenshotHelper.CaptureScreenshot("TC12_Failed"));
            ReportManager.FailTest($"Message: {e.Message} Stack trace: {e.StackTrace}");

            throw;
        }
    }

    [Test, Category("TC17"), Category("Regression")]
    public void ShouldRemoveProductsFromCart()
    {
        try
        {
            ReportManager.StartTest("Test Case 17: Remove Products From Cart", "Testing cart functionality");

            homePage.NavigateTo(Routes.products);
            productsPage.SearchProduct("Fancy Green Top");
            productsPage.AddProductToCart("Fancy Green Top");

            productsPage.NavigateTo(Routes.cart);
            cartPage.DeleteProductFromCart("Fancy Green Top");

            Assert.That(cartPage.IsCartEmpty(), Is.True);

            ReportManager.AttachScreenshot(screenshotHelper.CaptureScreenshot("removed-product-from-cart-successfully"));
        }
        catch (Exception e)
        {
            ReportManager.AttachScreenshot(screenshotHelper.CaptureScreenshot("TC17_Failed"));
            ReportManager.FailTest($"MeMessagessage: {e.Message} Stack trace: {e.StackTrace}");

            throw;
        }
    }
}