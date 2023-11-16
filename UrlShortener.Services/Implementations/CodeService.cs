using System.Security.Cryptography;
using System.Text;

namespace UrlShortener.Services
{
    /// <summary>
    /// Implementation of <see cref="ICodeService" />.
    /// </summary>
    public sealed class CodeService : ICodeService
    {
        // define characters allowed in passcode.  set length so divisible into 256
        private const string AllowedCharacters = "0123456789aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
        

        public async Task<string> GenerateHashCodeAsync(string url, int length)
        {
            const string HashKey = "urlshortenerapi";

            string code;

            try
            {
                byte[] hash;
                using (HMACSHA1 hmacsha = new HMACSHA1(Encoding.ASCII.GetBytes(HashKey)))
                {
                    hash = hmacsha.ComputeHash(Encoding.UTF8.GetBytes(url));
                }

                int startingPosition = hash[hash.Length - 1] % (hash.Length - length);
                StringBuilder shortCodeBuilder = new StringBuilder();
                for (int i = startingPosition; i < startingPosition + length; i++)
                {
                    shortCodeBuilder.Append(AllowedCharacters[hash[i] % AllowedCharacters.Length]);
                }

                code = shortCodeBuilder.ToString();
            }
            catch
            {
                throw;
            }

            return await Task.FromResult(code).ConfigureAwait(false);
        }

        public async Task<string> GenerateRandomCodeAsync(string url, int length)
        {
            string code;

            try
            {
                Random random = new Random();
                List<int> randomNumbersList = new List<int>();

                for (int i = 0; i < length; i++)
                {
                    randomNumbersList.Add(random.Next(AllowedCharacters.Length));
                }

                code = randomNumbersList.Aggregate(string.Empty, (current, num) => current + AllowedCharacters.Substring(num, 1));
            }
            catch
            {
                throw;
            }

            return await Task.FromResult(code).ConfigureAwait(false);
        }
    }
}
