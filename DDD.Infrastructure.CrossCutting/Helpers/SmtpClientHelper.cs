using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.CrossCutting.Helpers
{
    public static class SmtpClientHelper
    {
        public static void Send(string host, string username, string password, int port, MailMessage message)
        {
            using (SmtpClient client = new SmtpClient(host, port))
            {
                client.Credentials = new NetworkCredential(username, password);
                client.EnableSsl = true;

                client.Send(message);
            }
        }
    }
}
