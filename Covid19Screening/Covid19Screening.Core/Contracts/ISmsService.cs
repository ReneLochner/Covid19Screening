using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Screening.Core.Contracts
{
    public interface ISmsService
    {  
        /// <summary>
        /// Sendet eine SMS
        /// </summary>
        /// <param name="to">Handynummer des Empfängers</param>
        /// <param name="message">Inhalt</param>
        /// <returns>Ob Nachricht erfolgreich gesendet wurde</returns>
        bool SendSms(string to, string message);
    }
}
