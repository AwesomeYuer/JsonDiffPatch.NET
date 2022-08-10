namespace Microshaoft.Formatters
{
	public interface IFormatContext<out TResult>
	{
		TResult Result();
	}
}
