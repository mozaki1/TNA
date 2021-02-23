namespace TNAChallange.Core.Interfaces
{
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IDiscoveryService" />.
    /// Holds the logic for the Document.
    /// </summary>
    public interface IDiscoveryService
    {
        /// <summary>
        /// The GetDocumentById.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="JToken"/>.</returns>
        Task<JToken> GetDocumentById(string id);

        /// <summary>
        /// The Display, displays the result based on agreed business rules , check the unit tests for
        /// further details
        /// </summary>
        /// <param name="token">The token<see cref="JToken"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        string Display(JToken token);

       
    }
}
