namespace GoogleRecaptchaWebForms
{
	using GoogleRecaptcha;
	using System;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	/// <summary>
	/// This class implements the custom server control for Google Recaptcha Version 2 of asp.net web forms.
	/// </summary>
	[ToolboxData("<{0}:RecaptchaV2Control runat=server></{0}:RecaptchaV2Control>")]
	public class RecaptchaV2Control : WebControl, IValidator
	{
		#region Fields

		/// <summary>
		/// Gets or sets the _siteKey field. This field indicates that
		/// this is site/public key of Google Recaptcha Version 2.
		/// </summary>
		private string _siteKey;

		/// <summary>
		/// Gets or sets the _secretKey field. This field indicates that
		/// this is secret/private key of Google Recaptcha Version 2.
		/// </summary>
		private string _secretKey;

		/// <summary>
		/// Gets or sets the _errorMessage field. This field indicates that
		/// this is error message returned from Google Recaptcha server.
		/// </summary>
		private string _errorMessage;

		/// <summary>
		/// Gets or sets the _isValid field. This field indicates that
		/// this is a flag used to check the valid captcha.
		/// </summary>
		private bool _isValid;

		#endregion Fields

		#region Properties

		/// <summary>
		/// Gets or sets the SiteKey property. This property indicates that
		/// this is site/public key of Google Recaptcha Version 2.
		/// </summary>
		public string SiteKey
		{
			get
			{
				return _siteKey;
			}
			set
			{
				_siteKey = value;
			}
		}

		/// <summary>
		/// Gets or sets the SecretKey property. This property indicates that
		/// this is secret/private key of Google Recaptcha Version 2.
		/// </summary>
		public string SecretKey
		{
			get
			{
				return _secretKey;
			}
			set
			{
				_secretKey = value;
			}
		}

		/// <summary>
		/// Gets or sets the ErrorMessage property. This property indicates that
		/// this is error message returned from Google Recaptcha server.
		/// </summary>
		public string ErrorMessage
		{
			get
			{
				return _errorMessage;
			}
			set
			{
				_errorMessage = value;
			}
		}

		/// <summary>
		/// Gets or sets the IsValid property. This property indicates that
		/// this is a flag used to check the valid captcha.
		/// </summary>
		public bool IsValid
		{
			get
			{
				return _isValid;
			}
			set
			{
				_isValid = value;
			}
		}

		#endregion Properties

		#region Events

		protected override void OnInit(EventArgs e)
		{
			Page.Validators.Add(this);
			base.OnInit(e);
		}

		/// <summary>
		/// Renders the contents of the Google Recaptcha Version 2 server control to the specified writer.
		/// </summary>
		/// <param name="writer">writer output</param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
			writer.WriteBeginTag("div");
			writer.AddAttribute("class", "g-recaptcha");
			writer.AddAttribute("data-sitekey", SiteKey);
			writer.WriteEndTag("div");
		}

		/// <summary>
		/// Renders the Google Recaptcha Version 2 server control to the specified HTML writer.
		/// </summary>
		/// <param name="writer">writer output</param>
		protected override void Render(HtmlTextWriter writer)
		{
			this.RenderContents(writer);
		}

		#endregion Events

		/// <summary>
		/// Validates the Google Recaptcha Version 2.
		/// </summary>
		public void Validate()
		{
			IRecaptcha<RecaptchaV2Result> recaptcha = new RecaptchaV2(
				new RecaptchaV2Data() { Secret = SecretKey });
			var result = recaptcha.Verify();
			this.IsValid = result.Success;
			if(!this.IsValid && result.ErrorCodes.Length > 0)
			{
				this.ErrorMessage = result.ErrorCodes[0];
			}
		}
	}
}
