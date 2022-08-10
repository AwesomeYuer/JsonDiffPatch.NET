namespace Microshaoft.Json.Formatters
{
	public interface IFormatContext<out TResult>
	{
		TResult Result();
	}
}
