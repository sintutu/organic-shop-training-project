# Notes

## Add introductory docs

1. Create the .gitignore by copying from https://github.com/github/gitignore/blob/main/VisualStudio.gitignore at repo root.
2. Create ./docs/notes.md at repo root to keep notes on what I'm doing.
3. Create README.md explaining the project.

## Add solution and project

Add the solution with 

```pwsh
dotnet new sln --name OrganicShopTrainingProject
```

Add the test project to a new directory ./OrganicShopTrainingProjectPlaywrightTests with 

```pwsh
dotnet new nunit --name OrganicShopTrainingProjectPlaywrightTests --output OrganicShopTrainingProjectPlaywrightTests
```

Add the test project to the solution with 

```pwsh
dotnet sln .\OrganicShopTrainingProject.sln add .\OrganicShopTrainingProjectPlaywrightTests\OrganicShopTrainingProjectPlaywrightTests.csproj
```

Test that the solution builds and tests pass with:

```pwsh
dotnet build
dotnet test
```

## Add Playwright

It's a good idea to follow the [Playwright dotnet docs](https://playwright.dev/dotnet/docs/intro "It's a good idea to read the docs :)")

The latest Playwright for NUNit version available on nuget is [1.46.0](https://www.nuget.org/packages/Microsoft.Playwright.NUnit/1.46.0#supportedframeworks-body-tab (Latest available .NET 8 compatible Playwright.NUnit nuget package from nuget.org))

Install this to the test project with 

```pwsh
dotnet add .\OrganicShopTrainingProjectPlaywrightTests\OrganicShopTrainingProjectPlaywrightTests.csproj package Microsoft.Playwright.nunit --version 1.46.0
```

To actually use Playwright, I need to build the project first so that the powershell script that installs browsers is available.

```pwsh
dotnet build
```

The powershell script is available now. So run it with

```pwsh
pwsh .\OrganicShopTrainingProjectPlaywrightTests\bin\Debug\net8.0\playwright.ps1 install
```

The command has the below installed:

* Chromium 128.0.6613.18 (playwright build v1129) from https://playwright.azureedge.net/builds/chromium/1129/chromium-win64.zip
* Firefox 128.0 (playwright build v1458) from https://playwright.azureedge.net/builds/firefox/1458/firefox-win64.zip
* Webkit 18.0 (playwright build v2051) from https://playwright.azureedge.net/builds/webkit/2051/webkit-win64.zip

Check that the build is still fine with `dotnet test`

