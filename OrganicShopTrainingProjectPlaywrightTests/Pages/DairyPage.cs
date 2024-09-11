using Microsoft.Playwright;

namespace OrganicShopTrainingProjectPlaywrightTests.Pages;

public class DairyPage
{
    public readonly IPage Page;
    
    public readonly ILocator AddCheeseToCartButton;
    public readonly ILocator CheesePlusButton;
    public DairyPage(IPage page)
    {
        Page = page;
        AddCheeseToCartButton = Page.Locator("product-card")
            .Filter(new() { HasText = "Cheese" })
            .GetByRole(AriaRole.Button);
        CheesePlusButton = Page.Locator("product-card")
            .Filter(new() { HasText = "Cheese" })
            .GetByRole(AriaRole.Button, new() { Name = "+"});  
    }

    public async Task ClickAddCheeseToCartAsync()
    {
        await AddCheeseToCartButton.ClickAsync();
    }

    public async Task ClickCheesePlusButtonAsync()
    {
        await CheesePlusButton.ClickAsync();
    }
}