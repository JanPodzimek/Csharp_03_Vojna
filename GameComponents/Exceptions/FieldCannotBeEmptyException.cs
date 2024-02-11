namespace Vojna
{
	public class FieldCannotBeEmptyException : Exception 
	{
		public FieldCannotBeEmptyException() {}
		public FieldCannotBeEmptyException(string message)
			: base(message) {}
	}
}