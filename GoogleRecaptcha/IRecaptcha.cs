namespace GoogleRecaptcha
{
	/// <summary>
	/// This inteface defines the verification for Google Recaptcha
	/// </summary>
	/// <typeparam name="T">any class</typeparam>
	public interface IRecaptcha<out T> where T: class
	{
		/// <summary>
		/// Verify the Google recaptcha.
		/// </summary>
		/// <returns>Returns the verification result</returns>
		T Verify();
	}
}
