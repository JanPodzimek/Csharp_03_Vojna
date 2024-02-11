namespace Vojna
{
	public class NamesMustBeDifferentException : Exception 
	{
		public NamesMustBeDifferentException() {}
		public NamesMustBeDifferentException(string message)
			: base(message) {}
	}
}