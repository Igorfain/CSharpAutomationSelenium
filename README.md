# CSharpAutomationSelenium

Modern C# Selenium automation framework with UI + API tests, POM architecture, Allure reporting and clean Infra/Test separation.

---

## 🔧 Technologies
- C# .NET 8  
- Selenium WebDriver  
- NUnit  
- Allure  
- RestSharp  
- Page Object Model  
- JSON Config (MainConfig.json)

---

## 🚀 Running Tests

### Run all tests
```bash
dotnet test
```

### Run UI only
```bash
dotnet test --filter "TestCategory=UI"
```

### Run API only
```bash
dotnet test --filter "TestCategory=API"
```

---

## 📊 Allure Report
```bash
allure generate allure-results --clean
allure open
```

---

## ⭐ Features
- Clear architecture  
- POM + Steps pattern  
- Full Allure integration  
- Unified UI & API approach  
- Config isolated in JSON  
- Easy to extend and maintain  
