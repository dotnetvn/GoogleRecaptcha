namespace GoogleRecaptcha
{
	using System.Web;

	/// <summary>
	/// This class contains the input data for the Google Recaptcha version 2.
	/// </summary>
	public class RecaptchaV2Data
	{
		/// <summary>
		/// Gets or sets the Secret property. This property indicates that this is the secret key to be set up on the Google Recaptcha server.
		/// </summary>
		public string Secret { get; set; }

		/// <summary>
		/// Gets or sets the Response property. This property indicates that this is the response returned from the server.
		/// </summary>
		public string Response
		{
			get { return HttpContext.Current.Request.Form["g-recaptcha-response"]; }
		}

		/// <summary>
		/// Gets or sets the RemoteIp property. This property indicates that this is remote ip address from the client.
		/// </summary>
		public string RemoteIp
		{
			get { return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; }
		}
	}
}
