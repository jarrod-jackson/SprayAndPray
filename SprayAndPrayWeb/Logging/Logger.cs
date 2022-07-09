using log4net;

namespace SprayAndPrayWeb.Logging
{
    public class Logger : ILogger
    {
        private readonly ILog _logger;
        public Logger(string name)
        {
            _logger = LogManager.GetLogger(name);
        }

        public void Info(string message)
        {
            _logger.Info(string.Format("INFO: {0}", message));
        }

        public void InfoFormat(string message, params object[] args)
        {
            Info(string.Format(message, args));
        }

        public void Warn(string message)
        {
            _logger.Warn(string.Format("WARN: {0}", message));
        }

        public void Debug(string message)
        {
            _logger.Debug(string.Format("DEBUG: {0}", message));
        }

        public void Error(string message)
        {
            _logger.Error(string.Format("ERROR: {0}", message));
        }

        public void Error(Exception ex)
        {
            Error(ex.ToString());
        }

        public void Error(string message, Exception ex)
        {
            _logger.Error($"Message: {message}, Exception: {ex}");
        }
    }
}
