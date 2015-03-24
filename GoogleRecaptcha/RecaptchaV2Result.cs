namespace GoogleRecaptcha
{
	using System.Runtime.Serialization;

	[DataContract]
	public class RecaptchaV2Result
	{
		[DataMember(Name = "success")]
		public bool Success { get; set; }

		[DataMember(Name = "error-codes")]
		public string[] ErrorCodes { get; set; }
	}
}
