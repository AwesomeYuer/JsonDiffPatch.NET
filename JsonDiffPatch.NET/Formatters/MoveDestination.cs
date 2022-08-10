namespace Microshaoft.Json.Formatters
{
	using Newtonsoft.Json.Linq;
	public class MoveDestination
	{
		public MoveDestination(string key, JToken value)
		{
			Key = key;
			Value = value;
		}

		public string Key { get; }

		public JToken Value { get; }
	}
}
