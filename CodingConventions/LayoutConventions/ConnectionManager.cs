using CodingConventions.NamingConventions;

namespace CodingConventions.LayoutConventions
{
    public class ConnectionManager
    {
        // One declaration per line
        private string _connectionString;
        private string _provider;

        // Format your code
        public void Open()
        {
            // One statement per line
            _connectionString = @"connection string";
            _provider = @"provider name";

            // Comment in a separate line
            _connectionString = string.Empty;

            /* Use var keyword only when the assigned value 
             * type is known
             */
            var fileReader = new FileReader();

            // Do not use var when the type is not explicit
            var fileLength = fileReader.Length;

            // Use string interpolation to concat strings
            _connectionString = $"Provider = {_provider}";

            // Use object initializer when necessary
            fileReader = new FileReader
            {
                Length = 640
            };

            // Use « is » before « as »
            if (fileReader is IFileReader)
            {
                var newFileReader = fileReader as IFileReader;
            }

            // Use Coalescing operator to check null
            IFileReader textReader = fileReader ?? new FileReader();
        }

        // Use Body Expression in single line methods
        public string GetConnectionString() => _connectionString;

        // Leave a blank line between methods & properties
        public bool IsConnected { get; set; }
    }
}