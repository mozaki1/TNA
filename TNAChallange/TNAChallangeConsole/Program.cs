namespace TNAChallangeConsole
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;
    using TNAChallange.Core.Interfaces;
    using TNAChallange.Core.Services;
    using TNAChallange.Infrastructure.Services;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// Console application ,searching for a document, expecting the user input for a  
    /// document id
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the loggerFactory.
        /// </summary>
        private readonly static ILoggerFactory loggerFactory = new LoggerFactory();

        /// <summary>
        /// Defines the discoveryservice.
        /// </summary>
        private static IDiscoveryService discoveryservice;

        /// <summary>
        /// Defines the repository.
        /// </summary>
        private static IRepository repository;

        /// <summary>
        /// Defines the logger.
        /// </summary>
        private static ILogger logger;

        /// <summary>
        /// The Main.
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        internal async static Task Main(string[] args)
        {
            try
            {
              
                // Create logger
                logger = loggerFactory.CreateLogger<Program>();
                // Create the repository
                repository = new Repository(logger);
                // Create the Discovery service
                discoveryservice = new DiscoveryService(repository, logger);
               
                do
                {
                    try
                    {
                        
                        
                        Console.WriteLine("Enter a valid document id:");
                        // Read user input
                        var documentid = Console.ReadLine();
                        // Get the document using the Id
                        var document = await discoveryservice.GetDocumentById(documentid);
                        // Get the display
                        var display = discoveryservice.Display(document);
                        Console.WriteLine("Dispaly: {0}", display);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                    Console.WriteLine("Press any key to continue or Escape to exit");

                }
                while(Console.ReadKey().Key != ConsoleKey.Escape);
                

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
           
               

            }
        }
    }
}
