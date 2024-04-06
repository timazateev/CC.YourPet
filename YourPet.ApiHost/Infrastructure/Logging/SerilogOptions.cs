namespace YourPet.ApiHost.Infrastructure.Logging
{
    public class SerilogOptions
    {
        public bool SelfLogEnabled { get; set; }
        public bool ConsoleEnabled { get; set; }
        public FileLogOptions FileLog { get; set; }
        public string Level { get; set; }
        public string MicrosoftLevel { get; set; }
    }
}
