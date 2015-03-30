namespace GoogleRecaptchaWebForms
{
	using System;
	using System.ComponentModel;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using GoogleRecaptcha;

	/// <summary>
	/// This class implements the custom server control for Google Recaptcha Version 2 of asp.net web forms.
	/// </summary>
	[ToolboxData("<{0}:RecaptchaV2Control runat=server></{0}:RecaptchaV2Control>")]
	public class RecaptchaV2Control : WebControl, IValidator
	{
		#region Properties

		/// <summary>
		/// Gets or sets the SiteKey property. This property indicates that
		/// this is site/public key of Google Recaptcha Version 2.
		/// </summary>
		[Bindable(true), Category("Keys"), Description("This is site/public key of Google Recaptcha Version 2.")]
		public string SiteKey { get; set; }

		/// <summary>
		/// Gets or sets the SecretKey property. This property indicates that
		/// this is secret/private key of Google Recaptcha Version 2.
		/// </summary>
		[Bindable(true), Category("Keys"), Description("This is secret/private key of Google Recaptcha Version 2.")]
		public string SecretKey { get; set; }

		/// <summary>
		/// Gets or sets the ErrorMessage property. This property indicates that
		/// this is error message returned from Google Recaptcha server.
		/// </summary>
		[Bindable(true), Category("Validations"), Description("This is error message returned from Google Recaptcha server.")]
		public string ErrorMessage { get; set; }

		/// <summary>
		/// Gets or sets the IsValid property. This property indicates that
		/// this is a flag used to check the valid captcha.
		/// </summary>
		[Bindable(true), Category("Validations"), Description("This is a flag used to check the valid captcha.")]
		public bool IsValid { get; set; }

		#endregion Properties

		#region Events

		/// <summary>
		/// Init the custom validator for Google Recaptcha version 2.
		/// </summary>
		/// <param name="e">event data</param>
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
			writer.AddAttribute(HtmlTextWriterAttribute.Class, "g-recaptcha");
			writer.AddAttribute("data-sitekey", SiteKey);
			writer.RenderBeginTag(HtmlTextWriterTag.Div);
			writer.RenderEndTag();
		}

		/// <summary>
		/// Renders the Google Recaptcha Version 2 server control to the specified HTML writer.
		/// </summary>
		/// <param name="writer">writer output</param>
		protected override void Render(HtmlTextWriter writer)
		{
			RenderContents(writer);
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
			IsValid = result.Success;
			if(!IsValid && result.ErrorCodes.Length > 0)
			{
				ErrorMessage = result.ErrorCodes[0];
			}
		}
	}
}
