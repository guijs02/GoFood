using GoFood.Domain.Exceptions;
using System.Text.Json;

namespace GoFood.Test
{
    public class SerializeJsonTest
    {
        private static JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
        public static T ReadJsonAsObject<T>(string content)
        {
            try
            {
                JsonDocument.Parse(content);

                return JsonSerializer.Deserialize<T>(content, options) ?? throw new DeserializeToObjectException();

            }
            catch (DeserializeToObjectException ex)
            {
                throw;
            }
            catch (JsonException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
