# CLAUDE Instructions

## Project Guidelines
You are an expert C# test automation engineer working with NUnit, Selenium WebDriver, and Allure reporting.

PROJECT CONTEXT:
- Framework: NUnit + Selenium WebDriver
- Language: C# 12.0, .NET 8
- Architecture: Page Object Model (POM) + Steps Pattern
- Reporting: Allure NUnit

STRICT CONVENTIONS (NON-NEGOTIABLE):

1. PRIVATE VARIABLES & FIELDS:
   - All private fields MUST use underscore prefix: _fieldName
   - Example: _driver, _wait, _bot, _landingPage, _navItems
   - ActionBot MUST be used for all Selenium interactions in POM (e.g., _bot.Click(_button), _bot.TypeText(_field, text))

2. NO LAMBDAS OR LINQ:
   - FORBIDDEN: .Select(), .Where(), .Any(), .ToArray() with lambdas
   - REQUIRED: Use explicit foreach loops for all iterations
   - Example:
     var navigationBarItemTexts = new List<string>();
     foreach (var navigationBarElement in navigationBarElements)
     {
         navigationBarItemTexts.Add(navigationBarElement.Text.Trim());
     }
     return navigationBarItemTexts;

3. PAGE OBJECT MODEL (POM) - Location: Infra\Pages\
   - Class naming: DescriptivePageName (e.g., LandingPage, LoginPage)
   - Constructor: public [ClassName](IWebDriver driver, WebDriverWait wait)
   - Private fields: _bot, _driver, _wait, and element locators (_elementName)
   - Methods: Verb-noun pattern (GetNavigationItems, FillEmailField, ClickLoginButton)
   - NO ASSERTIONS in POM - only interactions and data retrieval
   - Always include ActionBot initialization

4. STEPS CLASSES - Location: Infra\Steps\
   - Class naming: [PageName]Steps (e.g., LandingPageSteps, LoginSteps)
   - Constructor: Accept IWebDriver and WebDriverWait, instantiate POM
   - Private field: private readonly [POMClass] _[pomInstance];
   - Method naming: Verify*, Perform*, Execute* (e.g., VerifyNavigationContainsItems)
   - MUST return 'this' for fluent chaining
   - REQUIRED: LoggerUtils.LogStep() before and after each action
   - REQUIRED: [AllureStep("description")] attribute on all public methods
   - Explicit error messages in assertions with actual vs expected values

5. TEST DATA HELPER - Location: Infra\Utils\
   - Class naming: [Scenario]Data or [PageName]NavigationData
   - MUST be static class with public static methods
   - Return type: List<T>, IEnumerable<T>, or similar collections
   - Example: public static List<string> GetLandingPageNavItems() { ... }

6. TEST CLASS - Location: CSharpAutomationSeleniumTests\Tests\UITests\
   - Class naming: [Scenario]Test (e.g., LandingPageNavBarTest, LoginTest)
   - MUST inherit from BaseTest
   - Private field: private [StepsClass] _[stepsInstance] = null!;
   - [SetUp]: Initialize steps with driver and wait
   - override bool DoDefaultLogin => false; (if test is unauthenticated)
   - Test methods: [MethodName]Test naming convention
   - REQUIRED: [AllureTag("tag")] and [AllureSuite("suite")]
   - NO business logic - only call steps

7. CODE STYLE:
   - Private fields: _fieldName
   - Local variables: variableName
   - Method parameters: parameterName
   - Classes/methods: PascalCase
   - Assertions: Assert.That(actual, Is.EqualTo(expected), "Descriptive message with context");
   
8. VARIABLE NAMING STANDARDS:

   A. LOCAL VARIABLES & COLLECTIONS:
      - Descriptive + purpose: variableName (camelCase)
      - Never use single letters (i, j, x, y, e, a, etc.)
      - Collections should indicate content type
      
      Examples:
      ✅ var navigationBarItemTexts = new List<string>();
      ✅ var expectedNavigationBarItems = new List<string>();
      ✅ var actualNavigationBarItems = element.GetNavigationBarItems();
      ❌ var items = new List<string>();
      ❌ var list = new List<string>();
      ❌ var x = element.GetNavigationBarItems();

   B. LOOP VARIABLES:
      - Use full descriptive names, not single letters
      - Use plural for collection, singular for element
      
      Examples:
      ✅ foreach (var navigationBarElement in _driver.FindElements(_navigationBarItems))
      ✅ foreach (var expectedNavigationBarItem in expectedItems)
      ✅ foreach (var actualNavigationBarItem in actualNavigationBarItems)
      ❌ foreach (var e in elements)
      ❌ foreach (var item in items)
      ❌ for (int i = 0; i < items.Count; i++)

   C. BOOLEAN VARIABLES:
      - Use "is", "has", "found", "contains" prefixes
      - Full descriptive name, not single "found"
      
      Examples:
      ✅ bool navigationBarItemFound = false;
      ✅ bool isNavigationBarVisible = true;
      ✅ bool hasNavigationBarItems = elements.Count > 0;
      ❌ bool found = false;
      ❌ bool f = false;
      ❌ bool result = false;

   D. FOR-LOOP COUNTERS (if absolutely necessary):
      - Use descriptive alternative to 'i', 'j'
      - Better: use foreach instead
      
      Examples:
      ✅ foreach (var item in collection) { ... }  // PREFERRED
      ✅ for (int itemIndex = 0; itemIndex < items.Count; itemIndex++) { ... }
      ❌ for (int i = 0; i < items.Count; i++) { ... }

   E. PRIVATE FIELD NAMING:
      - Underscore prefix + descriptive name
      - Indicate element type or purpose
      
      Examples:
      ✅ private readonly By _navigationBarItems = By.CssSelector("...");
      ✅ private readonly IWebDriver _driver;
      ✅ private readonly WebDriverWait _wait;
      ✅ private readonly ActionBot _bot;
      ✅ private readonly LandingPage _landingPage;
      ❌ private readonly By _nav;
      ❌ private readonly IWebDriver _d;

   F. FEATURE-SPECIFIC NAMING:
      - Always specify feature/page context in variable names
      - Bad: "items", "elements", "data"
      - Good: "navigationBarItems", "loginFormFields", "productListElements"
      
      Examples:
      ✅ var navigationBarItemTexts = ...
      ✅ var loginFormInputFields = ...
      ✅ var productListElements = ...
      ✅ var expectedNavigationBarItems = ...
      ❌ var itemTexts = ...
      ❌ var inputFields = ...
      ❌ var elements = ...

   G. METHOD RETURN VARIABLES:
      - Name should reflect what the method returns
      - Clear intent on what to do next
      - NO generic names like "result" or "data"
      
      Examples:
      ✅ var navigationBarItems = _landingPage.GetNavigationBarItems();
      ✅ var loginErrorMessage = _loginPage.GetErrorMessage();
      ✅ var currentUser = _userPage.GetLoggedInUsername();
      ❌ var result = _landingPage.GetNavigationBarItems();
      ❌ var data = _loginPage.GetErrorMessage();

   H. TEST DATA VARIABLES:
      - Prefix with 'expected' or 'actual'
      - Always include feature context
      
      Examples:
      ✅ var expectedNavigationBarItems = LandingPageNavigationData.GetLandingPageNavigationBarItems();
      ✅ var actualNavigationBarItems = _landingPage.GetNavigationBarItems();
      ✅ var expectedErrorMessage = "Invalid credentials";
      ❌ var items = [...];
      ❌ var data = [...];
      ❌ var expected = [...];