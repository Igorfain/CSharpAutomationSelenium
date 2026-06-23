using System.Net;

namespace Infra.Utils
{
    // Makes an HTTP login request (no browser) and returns session cookies
    // that can be injected into Selenium WebDriver to skip UI login flow
    public static class ApiLoginHelper
    {
        public static List<Cookie> GetSessionCookies(string loginUrl, string email, string password)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer,
                AllowAutoRedirect = true
            };

            using var httpClient = new HttpClient(handler);

            // Step 1: GET login page to grab CSRF token embedded in the HTML form
            var getResponse = httpClient.GetAsync(loginUrl).GetAwaiter().GetResult();
            var htmlContent = getResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var csrfToken = ExtractCsrfToken(htmlContent);

            // Step 2: POST credentials + CSRF token as a standard HTML form submission
            var loginFormFields = new List<KeyValuePair<string, string>>();
            loginFormFields.Add(new KeyValuePair<string, string>("email", email));
            loginFormFields.Add(new KeyValuePair<string, string>("password", password));
            loginFormFields.Add(new KeyValuePair<string, string>("csrfmiddlewaretoken", csrfToken));

            var formContent = new FormUrlEncodedContent(loginFormFields);
            httpClient.DefaultRequestHeaders.Add("Referer", loginUrl);
            httpClient.PostAsync(loginUrl, formContent).GetAwaiter().GetResult();

            // Step 3: Collect cookies from the root domain (session cookie lives here)
            var loginUri = new Uri(loginUrl);
            var rootUri = new Uri($"{loginUri.Scheme}://{loginUri.Host}");
            var siteCookies = cookieContainer.GetCookies(rootUri);

            var cookieList = new List<Cookie>();
            foreach (Cookie cookie in siteCookies)
            {
                cookieList.Add(cookie);
            }

            return cookieList;
        }

        // Extracts csrfmiddlewaretoken value from the hidden input in the login page HTML
        private static string ExtractCsrfToken(string htmlContent)
        {
            const string searchPattern = "name=\"csrfmiddlewaretoken\" value=\"";
            var tokenStartIndex = htmlContent.IndexOf(searchPattern, StringComparison.OrdinalIgnoreCase);

            if (tokenStartIndex < 0)
                return string.Empty;

            tokenStartIndex += searchPattern.Length;
            var tokenEndIndex = htmlContent.IndexOf("\"", tokenStartIndex, StringComparison.OrdinalIgnoreCase);

            if (tokenEndIndex < 0)
                return string.Empty;

            return htmlContent.Substring(tokenStartIndex, tokenEndIndex - tokenStartIndex);
        }
    }
}
