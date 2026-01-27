namespace nago_reforged_api.Security;
using System.Security.Cryptography;
using System.Text;
public static class Hash{
    public static string make(string password){
        byte[] pwd = Encoding.UTF8.GetBytes(password);
        byte[] hash = SHA256.HashData(pwd);
        return Convert.ToHexString(hash);
    }

    public static bool check(string password, string hash){
        var auxhash = Hash.make(password);
        Console.WriteLine($"Hash {auxhash} == {hash}");
        return auxhash == hash;
    }
}