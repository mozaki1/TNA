namespace TNAChallange.Core.Interfaces
{
    using Newtonsoft.Json.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IRepository" />.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// The GetById, process document request given a document Id
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="JToken"/>.</returns>
        Task<string> GetById(string id);

       
    }
}
