namespace SprayAndPrayWeb.Logging
{
    public interface ILogger
    {
        public void Info(string message);
        public void InfoFormat(string message, params object[] args);
        public void Warn(string message);
        public void Debug(string message);
        public void Error(string message);
        public void Error(Exception ex);
        public void Error(string message, Exception ex);
    }
}
