using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IA_AlertaDesaparecidos_MaterialSkin
{
    public class GroqClient
    {
        private readonly HttpClient _httpClient;

        public GroqClient(string apiKey)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri("https://api.groq.com/openai/");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);
        }

        public async Task<string> AnalizarAlerta(string alertaTexto)
        {
            var body = new
            {
                model = "llama3-70b-8192",
                messages = new[]
                {
                    
                    new { role = "system", content = "Eres un experto legal que analiza reportes de corrupción para clasificarlos." },
                new { role = "user", content = $"Analiza el siguiente reporte y responde con: tipo de corrupción, nivel de gravedad y acción sugerida:\n\n{alertaTexto}" }

                },
                temperature = 0.3
            };

            var jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("v1/chat/completions", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseString);
            return result.choices[0].message.content;
        }
    }
}
