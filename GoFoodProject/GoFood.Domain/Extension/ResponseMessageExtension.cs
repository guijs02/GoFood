using GoFood.Domain.Exceptions;
using System.Text.Json;

namespace GoFood.Domain.Extension
{
    public static class ResponseMessageExtension
    {
        private static JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
        public async static Task<T> ReadJsonAsObject<T>(this HttpResponseMessage httpResponseMessage)
        {
            try
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();

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
