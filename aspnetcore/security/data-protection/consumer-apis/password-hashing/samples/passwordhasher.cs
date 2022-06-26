using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
#nullable disable

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a password: ");
        string password = Console.ReadLine();

        // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
        byte[] salt = new byte[128 / 8];
        RandomNumberGenerator.Create().GetNonZeroBytes(salt);
        Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

        // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
        Console.WriteLine($"Hashed: {hashed}");
    }
}

/*
 * SAMPLE OUTPUT
 *
 * Enter a password: Xtw9NMgx
 * Salt: SqSBFnfUBCRpH/yd9soRDQ==
 * Hashed: rWc4HTeqV7SA5eGWUEx7t4n5N8gyHgB4sVLTxtpsZNc=
 */