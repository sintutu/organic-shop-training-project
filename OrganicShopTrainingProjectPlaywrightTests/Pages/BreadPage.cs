using Microsoft.Playwright;

namespace OrganicShopTrainingProjectPlaywrightTests.Pages;

public class BreadPage
{
    public readonly IPage Page;
    
    public readonly ILocator FrenchBaguetteButton;
    public BreadPage(IPage page)
    {
        Page = page;
        FrenchBaguetteButton = Page.Locator("product-card")
            .Filter(new() { HasText = "French Baguette" })
            .GetByRole(AriaRole.Button);
    }

    public async Task ClickAddFrenchBaguetteToCartAsync()
    {
        await FrenchBaguetteButton.ClickAsync();
    }
}