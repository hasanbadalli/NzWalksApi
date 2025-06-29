using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    private static readonly HttpClient client = new HttpClient();
    private const string ApiUrl = "https://api.deepseek.com/v1/chat/completions"; // API endpointini kontrol edin
    private static string apiKey = "sk-79a57782dd3d4707884c90f28583c0d5"; // Buraya API keyinizi girin

    static async Task Main(string[] args)
    {
        Console.WriteLine("DeepSeek Chat Uygulamasına Hoş Geldiniz!");
        Console.WriteLine("Çıkmak için 'exit' yazın.\n");

        while (true)
        {
            Console.Write("Kullanıcı: ");
            var userInput = Console.ReadLine();

            if (userInput.ToLower() == "exit")
                break;

            if (!string.IsNullOrWhiteSpace(userInput))
            {
                try
                {
                    var response = await GetChatResponse(userInput);
                    Console.WriteLine($"Asistan: {response}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata oluştu: {ex.Message}");
                }
            }
        }
    }

    private static async Task<string> GetChatResponse(string userPrompt)
    {
        string initialPrompt = "Sən BrainsBattle-ın təhsil yönümlü süni intellektisən və məqsədin Azərbaycanın təhsil proqramına uyğun şəkildə şagirdlərə mövzuları izah etmək və öyrətməkdir." +
            " Bir müəllim kimi anlaşılan, səbirli və ətraflı yanaşaraq şagirdlərə hər mövzuda rəhbərlik et və onları sadə, aydın izahlarla dəstəklə.";

        var combinedPrompt = initialPrompt + " " + userPrompt;

        var requestData = new
        {
            model = "deepseek-chat",
            messages = new[]
            {
            new { role = "user", content = combinedPrompt }
        }
        };

        var json = JsonConvert.SerializeObject(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        var response = await client.PostAsync(ApiUrl, content);
        var responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"API hatası: {response.StatusCode} - {responseString}");
        }

        dynamic responseData = JsonConvert.DeserializeObject(responseString);
        return responseData.choices[0].message.content;
    }

}