using Microsoft.Playwright;

namespace OrganicShopTrainingProjectPlaywrightTests.Pages;

public class ShoppingCartPage
{
    public readonly IPage Page;
    
    public ILocator MinusButton;
    public readonly ILocator CheckOutButton;
    public ShoppingCartPage(IPage page)
    {
        Page = page;

        // Defaulting MinusButton to first item in the list
        MinusButton = Page.GetByRole(AriaRole.Link, new() { Name = "-" }).First;
        CheckOutButton = Page.GetByRole(AriaRole.Link, new() { Name = "Check Out" });  
    }

    public async Task ClickMinusButtonAsync(string elementText)
    {
        var table = Page.GetByRole(AriaRole.Table);
        var product = table.GetByRole(AriaRole.Row, new () { Name = elementText });
        MinusButton = product.GetByRole(AriaRole.Button, new () { Name = "-" });
        await MinusButton.ClickAsync();
    }

    public async Task ClickCheckOutButtonAsync()
    {
        await CheckOutButton.ClickAsync();
    }
}