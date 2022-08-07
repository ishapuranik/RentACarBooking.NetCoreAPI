using NLog;
using NLog.Web;

namespace Bookings.Shared.Log
{
    public class NLogWrapper : ILogWrapper
    {
        private readonly ILogger _logger;

        public NLogWrapper(string connectionString)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            _logger = NLogBuilder.ConfigureNLog(
                Path.Combine(Directory.GetCurrentDirectory(), "Log/nlog.config")).GetCurrentClassLogger();

            GlobalDiagnosticsContext.Set("connectionString", connectionString);
        }

        /// <summary>
        /// Logs to database depending on connection passed in.
        /// Please see nlog.config database configuration for table structure. (OrderDB is an example.)
        /// </summary>
        /// <param name="ex"></param>
        public void Error(Exception ex)
        {
            _logger.Error(ex, ex.Message);
        }

        /// <summary>
        /// Logs to database depending on connection passed in.
        /// Please see nlog.config database configuration for table structure. (OrderDB is an example.)
        /// </summary>
        /// <param name="ex"></param>
        public void Error(string message, Exception ex)
        {
            Error(new Exception(message, ex));
        }
        public void Info(string info)
        {
            _logger.Info(info);
        }

        public void Fatal(Exception ex)
        {
            _logger.Fatal(ex, ex.Message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }
    }
}
