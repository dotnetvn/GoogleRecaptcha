namespace GoogleRecaptcha
{
	using System.Runtime.Serialization;

	/// <summary>
	/// This class contains the result returned from the server.
	/// </summary>
	[DataContract]
	public class RecaptchaV2Result
	{
		/// <summary>
		/// Gets or sets the Success property. This property indicates whether the verification process is success or not.
		/// </summary>
		[DataMember(Name = "success")]
		public bool Success { get; set; }

		/// <summary>
		/// Gets or sets the ErrorCodes property. This property contains the error codes in case of failing to verify.
		/// </summary>
		[DataMember(Name = "error-codes")]
		public string[] ErrorCodes { get; set; }
	}
}
