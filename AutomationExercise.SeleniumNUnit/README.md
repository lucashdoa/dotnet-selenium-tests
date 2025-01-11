# TAF with Selenium (C#) and NUnit

- Page Objects Model (POM)
- Driver Factory
- HTML report (ExtentReport)

## Filter test execution

For running a single test (e.g. TC001)
```bash
dotnet test --filter "Category=TC01"
```

Filtering with OR
```bash
dotnet test --filter "Category=Smoke || Category=Regression"
```

Filtering with AND

```bash
dotnet test --filter "Category=Smoke && Category=Regression"
```