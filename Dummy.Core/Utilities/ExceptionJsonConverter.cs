using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dummy.Core.Utilities;

public class ExceptionJsonConverter : JsonConverter<Exception>
{
    public override Exception Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Exception value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("Message", value.Message);

        writer.WritePropertyName("StackTrace");
        writer.WriteStartArray();
        foreach (var line in value.StackTrace.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
        {
            writer.WriteStringValue(line);
        }
        writer.WriteEndArray();

        if (value.InnerException != null)
        {
            writer.WritePropertyName("InnerException");
            JsonSerializer.Serialize(writer, value.InnerException, options);
        }
        writer.WriteEndObject();
    }
}