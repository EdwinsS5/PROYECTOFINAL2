using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiagnosticoEnfermedades
{
    public class DiagnosticoOpenAI
    {
       // private static readonly string apiKey = "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"; // Reemplaza por tu API Key real de OpenAI
        private static readonly string apiUrl = "https://api.openai.com/v1/chat/completions";

        public static async Task<string> Diagnosticar(string sintomas, string fechaInicio)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var mensajes = new[]
                {
                    new { role = "system", content = "Eres un asistente médico. Da un diagnóstico probable según los síntomas y recomienda consultar a un médico real en caso de gravedad." },
                    new { role = "user", content = $"Estos son mis síntomas: {sintomas}. Comenzaron el {fechaInicio}. ¿Cuál podría ser el diagnóstico?" }
                };

                var data = new
                {
                    model = "gpt-3.5-turbo",
                    messages = mensajes,
                    max_tokens = 200,
                    temperature = 0.7
                };

                string json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();

                string respuestaJson = await response.Content.ReadAsStringAsync();
                dynamic datos = JsonConvert.DeserializeObject(respuestaJson);
                return datos.choices[0].message.content;
            }
        }
    }
}