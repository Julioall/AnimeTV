using System.Security.Cryptography;

namespace AnimeTV.Helpers
{
    public class PasswordHasher
    {
        private static readonly int SaltSize = 16;
        private static readonly int HashSize = 16;
        private static readonly int Iterations = 1000;

        public static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize); // gera o salt usando o método estático GetBytes
            var key = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = key.GetBytes(HashSize);
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            var base64Hash = BitConverter.ToString(hashBytes).Replace("-", ""); // converte o hash em uma string hexadecimal usando o método BitConverter.ToString
            return base64Hash;

        }

        public static bool VerificarPassword(string password, string basa64Hash)
        {
            var hashBytes = Convert.FromBase64String(basa64Hash); // converte a string hexadecimal em um array de bytes usando o método BitConverter.GetBytes
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var key = new Rfc2898DeriveBytes(password, salt, Iterations);

            byte[] hash = key.GetBytes(HashSize);

            return String.Equals(BitConverter.ToString(hashBytes, SaltSize), BitConverter.ToString(hash)); // compara as strings do hash usando o método String.Equals
        }
    }
}
