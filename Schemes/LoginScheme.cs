using System.Text.Json.Serialization;

namespace nago_reforged_api.Schemes;

public class LoginScheme
{
   [JsonPropertyName("email")]
   public string Email { get; set; }
   [JsonPropertyName("password")]
   public string Password { get; set; }


    public override string ToString()
    {
        return $"Email: {Email}, Password: {Password}";
    }
}