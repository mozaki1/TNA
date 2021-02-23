namespace TNAChallange.Infrastructure.Services
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TNAChallange.Core.Interfaces;

    /// <summary>
    /// Defines the <see cref="Repository" />.
    /// </summary>
    public class Repository : IRepository
    {
        /// <summary>
        /// Defines the client.
        /// </summary>
        internal static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="logger">The logger<see cref="ILogger"/>.</param>
        public Repository(ILogger logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// The GetById.
        /// returns a result given an id
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{JToken}"/>.</returns>
        public async Task<string> GetById(string id)
        {
            try
            {

                return
                await ReadStringAsync(id);

            }
            catch(Exception ex)
            {
                this._logger.LogError("Error:{0}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The ReadStringAsync.
        /// Read from the api
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{string}"/>.</returns>
        private async Task<string> ReadStringAsync(string title)
        {
            HttpResponseMessage response = await client.GetAsync(title);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
