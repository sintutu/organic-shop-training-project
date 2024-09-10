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

