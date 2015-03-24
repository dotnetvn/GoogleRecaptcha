namespace GoogleRecaptcha
{
	using System.Web;

	public class RecaptchaV2Data
	{
		public string Secret { get; set; }

		public string Response
		{
			get { return HttpContext.Current.Request.Form["g-recaptcha-response"]; }
		}

		public string RemoteIp
		{
			get { return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; }
		}
	}
}
