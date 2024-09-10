using System.Security.Cryptography;
using System.Text;

namespace UrlShortener.Services;

/// <summary>
/// Implementation of <see cref="ICodeService" />.
/// </summary>
public sealed class CodeService : ICodeService
{
    // define characters allowed in passcode.  set length so divisible into 256
    private const string AllowedUpperCaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string AllowedLowerCaseCharacters = "abcdefghijklmnopqrstuvwxyz";
    private const string AllowedNumericCharacters = "0123456789";
    private const string AllowedCharacters = "0123456789aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
        

    /// <inheritdoc />
    public async Task<string> GenerateHashCodeAsync(string url, int length)
    {
        const string hashKey = "urlshortenerapi";

        byte[] hash;
        using (HMACSHA1 hmacsha = new(Encoding.ASCII.GetBytes(hashKey)))
        {
            hash = hmacsha.ComputeHash(Encoding.UTF8.GetBytes(url));
        }

        var startingPosition = hash[^1] % (hash.Length - length);
        StringBuilder shortCodeBuilder = new();
        for (var i = startingPosition; i < startingPosition + length; i++)
        {
            shortCodeBuilder.Append(AllowedCharacters[hash[i] % AllowedCharacters.Length]);
        }

        return await Task.FromResult(shortCodeBuilder.ToString()).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<string> GenerateHashCodeAsync(
        bool includeLowerChars,
        bool includeUpperChars,
        bool includeNumerics,
        string url,
        int length)
    {
        const string hashKey = "urlshortenerapi";

        string shortCodeBuildingCharacters =
            $"{(includeLowerChars ? AllowedLowerCaseCharacters : string.Empty)}" +
            $"{(includeUpperChars ? AllowedUpperCaseCharacters : string.Empty)}" +
            $"{(includeNumerics ? AllowedNumericCharacters : string.Empty)}";

        byte[] hash;
        using (HMACSHA1 hmacsha = new(Encoding.ASCII.GetBytes(hashKey)))
        {
            hash = hmacsha.ComputeHash(Encoding.UTF8.GetBytes(url));
        }

        var startingPosition = hash[^1] % (hash.Length - length);
        StringBuilder shortCodeBuilder = new();
        for (var i = startingPosition; i < startingPosition + length; i++)
        {
            shortCodeBuilder.Append(shortCodeBuildingCharacters[hash[i] % shortCodeBuildingCharacters.Length]);
        }

        return await Task.FromResult(shortCodeBuilder.ToString()).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<string> GenerateRandomCodeAsync(string url, int length)
    {
        string code;

        try
        {
            Random random = new();
            List<int> randomNumbersList = [];

            for (var i = 0; i < length; i++)
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

    /// <inheritdoc />
    public async Task<string> GenerateRandomCodeAsync(
        bool includeLowerChars,
        bool includeUpperChars,
        bool includeNumerics,
        string url,
        int length)
    {
        string code;

        string codeBuildingCharacters =
            $"{(includeLowerChars ? AllowedLowerCaseCharacters : string.Empty)}" +
            $"{(includeUpperChars ? AllowedUpperCaseCharacters : string.Empty)}" +
            $"{(includeNumerics ? AllowedNumericCharacters : string.Empty)}";

        try
        {
            Random random = new();
            List<int> randomNumbersList = [];

            for (var i = 0; i < length; i++)
            {
                randomNumbersList.Add(random.Next(codeBuildingCharacters.Length));
            }

            code = randomNumbersList.Aggregate(string.Empty, (current, num) => current + codeBuildingCharacters.Substring(num, 1));
        }
        catch
        {
            throw;
        }

        return await Task.FromResult(code).ConfigureAwait(false);
    }
}