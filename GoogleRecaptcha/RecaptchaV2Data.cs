namespace GoogleRecaptcha
{
	using System.Web;

	/// <summary>
	/// This class contains the input data for the Google Recaptcha version 2.
	/// </summary>
	public class RecaptchaV2Data
	{
		/// <summary>
		/// Gets or sets the _response field. This field indicates that this is the private response returned from the server.
		/// </summary>
		private string _response;

		/// <summary>
		/// Gets or sets the _remoteIp field. This field indicates that this is the this is private remote ip address from the client.
		/// </summary>
		private string _remoteIp;

		/// <summary>
		/// Gets or sets the Secret property. This property indicates that this is the secret key to be set up on the Google Recaptcha server.
		/// </summary>
		public string Secret { get; set; }

		/// <summary>
		/// Gets the Response property. This property indicates that this is the response returned from the server.
		/// </summary>
		public string Response
		{
			get 
			{
				if (_response == null)
				{
					return HttpContext.Current.Request.Form["g-recaptcha-response"];
				}
				return _response;
			}
			set
			{
				_response = value;
			}
		}

		/// <summary>
		/// Gets the RemoteIp property. This property indicates that this is remote ip address from the client.
		/// </summary>
		public string RemoteIp
		{
			get 
			{
				if (_remoteIp == null)
				{
					return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
				}
				return _remoteIp;
			}
			set
			{
				_remoteIp = value;
			}
		}
	}
}
