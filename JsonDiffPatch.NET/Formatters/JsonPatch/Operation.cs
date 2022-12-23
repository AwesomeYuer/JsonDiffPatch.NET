namespace Microshaoft.Json.Formatters.JsonPatch
{
	using Newtonsoft.Json;
	public class Operation
	{
		public Operation() { }

		public Operation(string op, string path, string from)
		{
			Op = op;
			Path = path;
			From = from;
		}

		public Operation(string op, string path, string from, object value)
		{
			Op = op;
			Path = path;
			From = from;
			Value = value;
		}

		[JsonProperty("path")]
		public string Path { get; set; } = string.Empty;

		[JsonProperty("op")]
		public string Op { get; set; } = string.Empty;

		[JsonProperty("from")]
		public string From { get; set; } = string.Empty;

		[JsonProperty("value")]
		public object Value { get; set; } = null!;
	}
}
