using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    /// <summary>
    /// Your class with constructor and singletone instance.
    /// </summary>
    public class Client
    {
        private static readonly Lazy<Client> defaultInstance = new Lazy<Client>(() => new Client());

        /// <summary>
        /// Initializes a new instance of the <see cref="MyLibrary.Client"/> class.
        /// </summary>
        /// <remarks>
        /// Make it private in case you don't need other instances of <see cref="MyLibrary.Client"/>.
        /// </remarks>
        public Client()
        {
        }

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static Client Instance
        {
            get { return defaultInstance.Value; }
        }

        /// <summary>
        /// Writes config parameter to the console.
        /// </summary>
        public void DeployContract(Config configuration)
        {
            Console.WriteLine($"DeployContract was called with config: \n\tAddress: {configuration.Address}\n\tPath: {configuration.Path}");
        }
    }
}
