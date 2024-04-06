namespace YourPet.ApiHost.Infrastructure.Logging
{
    public class FileLogOptions
    {
        public bool Enabled { get; set; }

        public string Path { get; set; }

        public string OutputTemplate { get; set; }

        public string RollingInterval { get; set; }
    }
}
