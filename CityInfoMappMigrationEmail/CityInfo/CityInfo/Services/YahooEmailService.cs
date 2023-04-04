using CityInfo.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CityInfo.Services
{
    public class YahooEmailService : IMailService
    {
        private readonly ILogger<YahooEmailService> _logger;
        private object _mailFrom;
        private object _mailTo;

        public YahooEmailService(ILogger<YahooEmailService> logger)
        {
            _logger = logger;
        }

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with YahooMailService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
