using Microsoft.Playwright;

namespace OrganicShopTrainingProjectPlaywrightTests.Pages;

public class HomePage
{
    public readonly IPage Page;
    
    public readonly ILocator BreadLink;
    public readonly ILocator DairyLink;
    public HomePage(IPage page)
    {
        Page = page;
        BreadLink = Page.GetByRole(AriaRole.Link, new() { Name = "Bread" });
        DairyLink = Page.GetByRole(AriaRole.Link, new() { Name = "Dairy" });  
    }

    public async Task ClickBreadLinkAsync()
    {
        await BreadLink.ClickAsync();
    }

    public async Task ClickDairyLinkAsync()
    {
        await DairyLink.ClickAsync();
    }
}