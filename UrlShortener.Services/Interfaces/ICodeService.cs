namespace UrlShortener.Services
{
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
        /// <returns>A <see cref="Task{string}" /> with the HASH code generated from the url.</returns>
        Task<string> GenerateHashCodeAsync(string url, int length);

        /// <summary>
        /// Generates RANDOM code from the url for the given length.
        /// </summary>
        /// <param name="url">Original url to generate the code.</param>
        /// <param name="length">Length of the code to be generated.</param>
        /// <returns>A <see cref="Task{string}" /> with the RANDOM code generated from the url.</returns>
        Task<string> GenerateRandomCodeAsync(string url, int length);
    }
}
