using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace API1.Converters
{
	/// <summary>
	/// https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/Converters/Value/DateTimeConverter.cs
	/// </summary>
	public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var dateString = reader.GetString();
			if (string.IsNullOrEmpty(dateString) ||
				!Regex.IsMatch(dateString, "^[0-9]{4}-[0-9]{2}-[0-9]{2}$", RegexOptions.IgnoreCase))
            {
				throw new JsonException("Please use date format yyyy-MM-dd.");
			}
			
			return reader.GetDateTime();
		}

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value);
		}

		public override DateTime ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			//var result = reader.GetDateTimeNoValidation();
			return DateTime.Now;
		}

		//public override DateTime ReadAsPropertyNameCore(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		//{
		//	return reader.GetDateTimeNoValidation();
		//}

		public virtual void WriteAsPropertyName(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
            //writer.WritePropertyName(value);
        }
    }
}
