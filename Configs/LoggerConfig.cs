namespace LoggerAsync.Configs
{
    public class LoggerConfig
    {
        public string LogsDir { get; set; }
        public string FileExtension { get; set; }
        public string DayTimeFormat { get; set; }
        public string BackupPath { get; set; }
        public string BackupPeriod { get; set; }
    }
}
