namespace Store.Utils
{
    public static class ApplicationCrypt
    {
        public static string Encriptar(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool Desencriptar(string input, string password)
        {
            return BCrypt.Net.BCrypt.Verify(input, password);
        }
    }
}
