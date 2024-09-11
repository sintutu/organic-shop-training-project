using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using OrganicShopTrainingProjectPlaywrightTests.Pages;

namespace OrganicShopTrainingProjectPlaywrightTests;

public abstract class TestBase
{
    // Declare tab in browser as IPage
    protected IPage Page;

    // Declare and instantiate a PlaywrightTest object to make Expect assertions available
    protected PlaywrightTest PlaywrightTest = new ();

    // Declare Common Locators
    protected ILocator ShoppingCartLink => Page.GetByRole(AriaRole.Link, new() { Name = "Shopping Cart" });
    protected ILocator LoginLink => Page.GetByRole(AriaRole.Link, new() { Name = "Login" });

    // Declare PageObjects
    protected HomePage HomePage => new(Page);
    protected BreadPage BreadPage => new(Page);
    protected DairyPage DairyPage => new(Page);
    protected ShoppingCartPage ShoppingCartPage => new(Page);

    // Declare BaseUri
    protected const string BaseUri = "https://agular-test-shop-cb70d.firebaseapp.com";

    // Create IPage instance via a Browser instance via Playwright instance
    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium
            .LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Timeout = 60000 // Increase timeout to 60 seconds
            });
        var context = await browser.NewContextAsync();
        Page = await context.NewPageAsync();
    }

    protected async Task ClickShoppingCartLinkAsync()
    {
        await ShoppingCartLink.ClickAsync();
    }

    protected async Task ClickLoginLinkAsync()
    {
        await LoginLink.ClickAsync();
    }
}