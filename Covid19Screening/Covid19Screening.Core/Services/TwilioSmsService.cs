using Covid19Screening.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Covid19Screening.Core.Services
{
    public class TwilioSmsService : ISmsService
    {
        private readonly string _accountSid;
        private readonly string _authToken;

        public TwilioSmsService(string accountSid, string authToken)
        {
            this._accountSid = accountSid;
            this._authToken = authToken;
        }

        public bool SendSms(string to, string message)
        {
            try
            {
                TwilioClient.Init(_accountSid, _authToken);

                var sms = MessageResource.Create(
                    body: message,
                    from: new Twilio.Types.PhoneNumber("+12028131793"),
                    to: new Twilio.Types.PhoneNumber(to)
                );
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
    }
}
