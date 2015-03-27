namespace GoogleRecaptcha
{
	using System;
	using System.IO;
	using System.Net;
	using System.Text;
	using System.Runtime.Serialization.Json;

	/// <summary>
	/// This class implements verifying the Google Recaptcha version 2.
	/// </summary>
	public class RecaptchaV2 : IRecaptcha<RecaptchaV2Result>
	{
		/// <summary>
		/// Gets or sets the _recaptchaV2Data field. This field indicates that this is the input data for Google Recaptcha version 2.
		/// </summary>
		private readonly RecaptchaV2Data _recaptchaV2Data;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:GoogleRecaptcha.RecaptchaV2"/> class with the specified input data.
		/// </summary>
		/// <param name="recaptchaV2Data">the input data for Google Recaptcha version 2</param>
		public RecaptchaV2(RecaptchaV2Data recaptchaV2Data)
		{
			// Oops! Not be able to accept null for the input data
			if (recaptchaV2Data == null)
			{
				throw new ArgumentNullException("recaptchaV2Data");
			}
			_recaptchaV2Data = recaptchaV2Data;
		}

		/// <summary>
		/// Verify the recaptcha version 2.
		/// </summary>
		/// <returns>Returns the verification result as RecaptchaV2Result type</returns>
		public RecaptchaV2Result Verify()
		{
			// Prepares the data to implement the POST request
			var postData = String.Format("secret={0}&response={1}&remoteip={2}", _recaptchaV2Data.Secret, _recaptchaV2Data.Response, _recaptchaV2Data.RemoteIp);

			using (var webClient = new WebClient())
			{
				webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

				// Sends a POST request to verify the recaptcha.
				var jsonResult = webClient.UploadString(RecaptchaOptions.VerifyUrl, postData);

				// Init the json serializer
				var dataContractJsonSerializer = new DataContractJsonSerializer(typeof(RecaptchaV2Result));

				// Deserialize the result from the server into the strongly-type object
				using (var ms = new MemoryStream(Encoding.ASCII.GetBytes(jsonResult)))
				{
					return dataContractJsonSerializer.ReadObject(ms) as RecaptchaV2Result;
				}
			}
		}
	}
}
