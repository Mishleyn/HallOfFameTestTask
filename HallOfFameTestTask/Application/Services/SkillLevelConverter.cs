using System.Text.Json.Serialization;
using System.Text.Json;

namespace HallOfFameTestTask.Application.Services;

public class SkillLevelConverter : JsonConverter<byte>
{
    public override byte Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            var value = reader.GetInt32();
            if (value < 1 || value > 10)
            {
                return 11;
            }
            return (byte)value;
        }

        //Возврат числа, которое не входит в диапазон для зажигания ошибки
        return 11;
    }

    public override void Write(Utf8JsonWriter writer, byte value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}
