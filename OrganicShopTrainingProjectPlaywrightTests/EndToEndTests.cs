using System.Text.RegularExpressions;

namespace OrganicShopTrainingProjectPlaywrightTests;

public class EndToEndTests : TestBase
{
    [Test]
    public async Task EndToEndTest()
    {
        // Go to home page
        await Page.GotoAsync($"{BaseUri}/");
        await PlaywrightTest.Expect(Page).ToHaveURLAsync($"{BaseUri}/");

        // 1. Select the Bread Category
        await HomePage.ClickBreadLinkAsync();

        // 2. Assert that the URL has changed
        await PlaywrightTest.Expect(Page).ToHaveURLAsync($"{BaseUri}/?category=bread");

        // 3. Add a French Baguette
        await BreadPage.ClickAddFrenchBaguetteToCartAsync();

        // 4. Select the Dairy Category
        await HomePage.ClickDairyLinkAsync();

        // 5. Assert that the URL has changed
        await PlaywrightTest.Expect(Page).ToHaveURLAsync($"{BaseUri}/?category=dairy");

        // 6. Add 2 blocks of cheese
        await DairyPage.ClickAddCheeseToCartAsync();
        await DairyPage.ClickCheesePlusButtonAsync();

        // 7. Open the cart
        await ClickShoppingCartLinkAsync();

        // 8. Assert that the URL has changed
        await PlaywrightTest.Expect(Page).ToHaveURLAsync($"{BaseUri}/shopping-cart");

        // Check number of items in cart before removing the block of cheese
        await PlaywrightTest.Expect(Page.GetByText(new Regex("You have .+"))).ToContainTextAsync("You have 3 items in your shopping cart");

        // 9. Remove 1 block of cheese
        await ShoppingCartPage.ClickMinusButtonAsync("Cheese");

        // Check number of items in cart after removing the block of cheese
        await PlaywrightTest.Expect(Page.GetByText(new Regex("You have .+"))).ToContainTextAsync("You have 2 items in your shopping cart");

        // 10. Click checkout
        await ShoppingCartPage.ClickCheckOutButtonAsync();
        await PlaywrightTest.Expect(Page).ToHaveURLAsync($"{BaseUri}/login?returnUrl=check-out");

        // 11. Click Login
        await ClickLoginLinkAsync();
    }
}