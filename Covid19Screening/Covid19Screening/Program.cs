using Covid19Screening.Core.Contracts;
using Covid19Screening.Core.Services;
using Microsoft.Extensions.Configuration;
using System;

namespace Covid19Screening
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<TwilioSmsService>()
                .AddEnvironmentVariables()
                .Build();

            ISmsService smsService = new TwilioSmsService(configuration["Twilio:AccountSid"], configuration["Twilio:AuthToken"]);

            string body = "Hello from Twilio SMS Service";
            string to = ""; // Insert Phone Number here

            smsService.SendSms(to, body);
        }
    }
}
