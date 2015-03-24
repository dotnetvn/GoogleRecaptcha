namespace GoogleRecaptcha
{
	using System;
	using System.IO;
	using System.Net;
	using System.Text;
	using System.Runtime.Serialization.Json;

	public class RecaptchaV2 : IRecaptcha<RecaptchaV2Result>
	{
		private readonly RecaptchaV2Data _recaptchaV2Data;

		public RecaptchaV2(RecaptchaV2Data recaptchaV2Data)
		{
			if (recaptchaV2Data == null)
			{
				throw new ArgumentNullException("recaptchaV2Data");
			}
			_recaptchaV2Data = recaptchaV2Data;
		}

		public RecaptchaV2Result Verify()
		{
			var postData = String.Format("secret={0}&response={1}&remoteip={2}", _recaptchaV2Data.Secret, _recaptchaV2Data.Response, _recaptchaV2Data.RemoteIp);

			using (var webClient = new WebClient())
			{
				webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
				var jsonResult = webClient.UploadString(RecaptchaOptions.VerifyUrl, postData);
				var dataContractJsonSerializer = new DataContractJsonSerializer(typeof(RecaptchaV2Result));
				var ms = new MemoryStream(Encoding.ASCII.GetBytes(jsonResult));
				return dataContractJsonSerializer.ReadObject(ms) as RecaptchaV2Result;
			}
		}
	}
}
