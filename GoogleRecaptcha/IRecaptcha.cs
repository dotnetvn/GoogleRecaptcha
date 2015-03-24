namespace GoogleRecaptcha
{
	public interface IRecaptcha<out T> where T: class
	{
		T Verify();
	}
}
