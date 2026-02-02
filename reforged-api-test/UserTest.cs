using System.Net.Mime;
using System.Text.Json;

namespace reforged_api_test;


public class UserTest
{
    [Theory]
    [InlineData("desarrollo@tercol.com.co","lapsDev1308",200)]
    [InlineData("desarrollo@tercol.com","lapsDev1308",401)]
    [InlineData("desarrollo@gmail.com.co","lapsDev1308",401)]
    [InlineData("laps1308@gmail.com","lapsDev1308",401)]
    public async void Login(string email,string password,int success)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5181/");
        StringContent content = new StringContent(JsonSerializer.Serialize(new {email=email,password=password}));
        content.Headers.ContentType =new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        var response = await client.PostAsync("api/auth/signin",content);

        Assert.Equal<int>(success,(int) response.StatusCode);

    }
}
