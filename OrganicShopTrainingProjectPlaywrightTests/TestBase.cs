using Microsoft.Extensions.Configuration;
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
    protected static IConfigurationRoot Configuration = null!;
    protected readonly string BaseUri;

    protected TestBase()
    {
        ReadAppSettings();
        BaseUri = Configuration["BaseUri"]!;
    }

    // Create IPage instance via a Browser instance via Playwright instance
    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium
            .LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
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

    private void ReadAppSettings()
    {
        // 1. json file must be set to copy always
        // 2. NuGet: Microsoft.Extensions.Configuration
        // 3. NuGet: Microsoft.Extensions.Configuration.Json
        Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }
}