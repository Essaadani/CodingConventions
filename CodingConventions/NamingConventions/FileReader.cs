namespace CodingConventions.NamingConventions
{
    public class FileReader : IFileReader
    {
        // Avoid meaningless names (ex: fName)
        private string _fileName;

        // Avoid excessively short names (ex: MxSz)
        private const double MaxSize = 1024;

        /* preferably start boolean with meaningful prefix 
         * like Is and Has (ex: IsDone, HasLock,…)
         */
        protected bool isLocked;

        public FileReader()
        {

        }

        /* Do not repeat the class name in its members 
         * (ex: FileReaderLength)
         */
        public double Length { get; set; }

        public void Read(string fileName)
        {
            _fileName = fileName;
        }
    }

    // Start interface name with I
    public interface IFileReader
    {
        void Read(string fileName);
    }
}
