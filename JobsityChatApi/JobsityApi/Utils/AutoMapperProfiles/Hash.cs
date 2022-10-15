using System.Security.Cryptography;
using System.Text;

namespace JobsityApi.Utils.AutoMapperProfiles;

public class Hash
{
    private HashAlgorithm Algorithm;

    public Hash(HashAlgorithm algorithm)
    {
        Algorithm = algorithm;
    }
    public string PasswordHash(string password)
    {

        var encodedValue = Encoding.UTF8.GetBytes(password);
        var encryptedPassword = Algorithm.ComputeHash(encodedValue);

        var sb = new StringBuilder();
        foreach (var character in encryptedPassword)
        {
            sb.Append(character.ToString("X2"));
        }

        return sb.ToString();
    }
}