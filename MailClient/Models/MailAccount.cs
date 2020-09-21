using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.Models
{
    class MailAccount
    {
        private string      _name;
        private string      _id;
        private string      _pw;
        private string      _pop3Host;
        private int         _pop3Port;
        private string      _smtpHost;
        private int         _smtpPort;
        private bool        _useSsl;
        public string Name 
        { 
            get => _name; 
            set => _name = value; 
        }
        public string Id 
        { 
            get => _id; 
            set => _id = value; 
        }
        public string Pw 
        { 
            get => _pw; 
            set => _pw = value; 
        }
        public string Pop3Host 
        { 
            get => _pop3Host; 
            set => _pop3Host = value; 
        }
        public int Pop3Port
        {
            get => _pop3Port;
            set => _pop3Port = value;
        }
        public string SmtpHost
        { 
            get => _smtpHost; 
            set => _smtpHost = value; 
        }
        public int SmtpPort
        {
            get => _smtpPort;
            set => _smtpPort = value;
        }
        public bool UseSsl
        {
            get => _useSsl;
            set => _useSsl = value;
        }

        public object Clone()
        {
            return new MailAccount
            {
                Name = Name,
                Id = Id,
                Pw = Pw,
                Pop3Host = Pop3Host,
                Pop3Port = Pop3Port,
                SmtpHost = SmtpHost,
                SmtpPort = SmtpPort,
                UseSsl = UseSsl
            };
        }
    }
}
