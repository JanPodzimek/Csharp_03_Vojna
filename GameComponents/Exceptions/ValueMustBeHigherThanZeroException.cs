namespace Vojna
{
	public class ValueMustBeHigherThanZeroException : Exception 
	{
		public ValueMustBeHigherThanZeroException() {}
		public ValueMustBeHigherThanZeroException(string message)
			: base(message) {}
	}
}