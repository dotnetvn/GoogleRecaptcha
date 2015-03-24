
namespace GoogleRecaptchaMvc
{
	using System;
	using System.Web;
	using System.Web.WebPages.Html;

    public static class RecaptchaMvcExtensions
    {
		public static IHtmlString RecaptchaV2(this HtmlHelper helper, string siteKey)
		{
			var htmlString = String.Format("<div class='g-recaptcha' data-sitekey='{0}'></div>", siteKey);
			return new HtmlString(htmlString);
		}

		public static IHtmlString RecaptchaV2(this HtmlHelper helper, string className, string siteKey)
		{
			var htmlString = String.Format("<div class='{0}' data-sitekey='{1}'></div>", className, siteKey);
			return new HtmlString(htmlString);
		}
    }
}
