namespace GoogleRecaptchaMvc
{
	using System;
	using System.Web;
	using System.Web.Mvc;

	/// <summary>
	/// This static class contains the extension methods to create the html controls for asp.net mvc.
	/// </summary>
    public static class RecaptchaMvcExtensions
    {
		/// <summary>
		/// Create a html control with the specified site key.
		/// </summary>
		/// <param name="helper">Html Helper</param>
		/// <param name="siteKey">site key to be set up on the Google Recaptcha server</param>
		/// <returns>Return the html control as html string</returns>
		public static IHtmlString RecaptchaV2(this HtmlHelper helper, string siteKey)
		{
			var htmlString = String.Format("<div class='g-recaptcha' data-sitekey='{0}'></div>", siteKey);
			return new HtmlString(htmlString);
		}

		/// <summary>
		/// Create a html control with both the specified class name and site key.
		/// </summary>
		/// <param name="helper">Html Helper</param>
		/// <param name="className">css class name</param>
		/// <param name="siteKey">site key to be set up on the Google Recaptcha server</param>
		/// <returns>Return the html control as html string</returns>
		public static IHtmlString RecaptchaV2(this HtmlHelper helper, string className, string siteKey)
		{
			var htmlString = String.Format("<div class='{0}' data-sitekey='{1}'></div>", className, siteKey);
			return new HtmlString(htmlString);
		}
    }
}
