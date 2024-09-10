namespace EasyUrl.Services;

/// <summary>
/// Service to generate random code based on the url and required length.
/// </summary>
public interface ICodeService
{
    /// <summary>
    /// Generates HASH code from the url for the given length.
    /// </summary>
    /// <param name="url">Original url to generate the code.</param>
    /// <param name="length">Length of the code to be generated.</param>
    /// <returns>A <see cref="Task{T}" /> with the HASH code generated from the url.</returns>
    Task<string> GenerateHashCodeAsync(string url, int length);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="includeLowerChars"></param>
    /// <param name="includeUpperChars"></param>
    /// <param name="includeNumerics"></param>
    /// <param name="url"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    Task<string> GenerateHashCodeAsync(
        bool includeLowerChars,
        bool includeUpperChars,
        bool includeNumerics,
        string url,
        int length);

    /// <summary>
    /// Generates RANDOM code from the url for the given length.
    /// </summary>
    /// <param name="url">Original url to generate the code.</param>
    /// <param name="length">Length of the code to be generated.</param>
    /// <returns>A <see cref="Task{T}" /> with the RANDOM code generated from the url.</returns>
    Task<string> GenerateRandomCodeAsync(string url, int length);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="includeLowerChars"></param>
    /// <param name="includeUpperChars"></param>
    /// <param name="includeNumerics"></param>
    /// <param name="url"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    Task<string> GenerateRandomCodeAsync(
        bool includeLowerChars,
        bool includeUpperChars,
        bool includeNumerics,
        string url,
        int length);
}