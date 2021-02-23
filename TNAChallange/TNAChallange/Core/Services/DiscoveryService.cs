namespace TNAChallange.Core.Services
{
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TNAChallange.Core.Interfaces;

    /// <summary>
    /// Defines the <see cref="DiscoveryService" />.
    /// </summary>
    public class DiscoveryService : IDiscoveryService
    {
        /// <summary>
        /// Defines the NOIFORMATION.
        /// </summary>
        private const string NOIFORMATION = "not sufficient information";

        /// <summary>
        /// Defines the NORECORDFOUND.
        /// </summary>
        private const string NORECORDFOUND = "no record found";

        /// <summary>
        /// Defines the _respository.
        /// </summary>
        private readonly IRepository _respository;

        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoveryService"/> class...
        /// </summary>
        private readonly string _api = "http://discovery.nationalarchives.gov.uk/API/records/v1/details/";

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoveryService"/> class.
        /// </summary>
        /// <param name="respository">The respository<see cref="IRepository"/>.</param>
        /// <param name="logger">The logger<see cref="ILogger"/>.</param>
        public DiscoveryService(IRepository respository, ILogger logger)
        {
            this._respository = respository;
            this._logger = logger;
        }

        /// <summary>
        /// The Display, reads the document and display the result based 
        /// on agreed business rules , check the unit tests for further details
        /// </summary>
        /// <param name="token">The token<see cref="JToken"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string Display(JToken token)
        {
            try
            {
                if((string)token["title"] == null &&
                    (string)token["scopeContent"]["description"] == null &&
                    (string)token["citableReference"] == null)
                    return NOIFORMATION;
                if((string)token["title"] != null)
                    return (string)token["title"];
                else if((string)token["scopeContent"]["description"] != null)
                    return (string)token["scopeContent"]["description"];
                else if((string)token["citableReference"] != null)
                    return (string)token["citableReference"];
               
                return NORECORDFOUND;
            }
            catch(Exception ex)
            {

                this._logger.LogError("Error:{0}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The GetDocumentById, process the request given a document id
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="JToken"/>.</returns>
        public async Task<JToken> GetDocumentById(string id)
        {
            try
            {
                if(string.IsNullOrEmpty(id))
                    throw new ArgumentNullException();
                var json = await _respository.GetById(_api + id);
                if(string.IsNullOrEmpty(json))
                    throw new Exception(NORECORDFOUND);
                return Parse(json);
            }
            catch(Exception ex)
            {

                this._logger.LogError("Error:{0}", ex.Message);
                throw;
            }
        }

      

        /// <summary>
        /// The Parse.
        /// </summary>
        /// <param name="Json">The Json<see cref="string"/>.</param>
        /// <returns>The <see cref="JToken"/>.</returns>
        private JToken Parse(string Json)
        {
            return JToken.Parse(Json);
        }
    }
}
