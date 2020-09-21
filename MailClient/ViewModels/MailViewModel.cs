using MailClient.Models;
using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.ViewModels
{
    class MailViewModel
    {
        List<MessageModel> _mails;
        MailAccount _account;

        public MailViewModel()
        {
            _account = new MailAccount
            {
                Name = "박훈",
                Id = "dev-game@naver.com",
                Pw = "qpzmal1592!",
                Pop3Host = "pop.naver.com",
                Pop3Port = 995,
                SmtpHost = "smtp.naver.com",
                SmtpPort = 465,
                UseSsl = true
            };
        }

        public void downloadFile(MessageModel message)
        {
            List<MessagePart> attachment = message.Attachment;

            try
            {
                if (attachment[0] != null)
                {
                    byte[] content = attachment[0].Body;
                    if (!Directory.Exists("./Attachment"))
                        Directory.CreateDirectory("./Attachment");
                    //[1] Save file to server path  
                    File.WriteAllBytes(Path.Combine("./Attachment/") + message.FileName, attachment[0].Body);

                    //[2] Download file  
                    string[] stringParts = message.FileName.Split(new char[] { '.' });
                    string strType = stringParts[1];


                }
            }
            catch (Exception ex)
            {
            }
        }

        public List<MessageModel> FetchAllMessages(string hostname, int port, bool useSsl, string username, string password, Pop3Client client)
        {
            // The client disconnects from the server when being disposed
            //using (Pop3Client client = new Pop3Client())
            //{
            // Connect to the server
            //client.Connect(hostname, port, useSsl);

            // Authenticate ourselves towards the server
            //client.Authenticate(username, password);

            // Get the number of messages in the inbox
            int messageCount = client.GetMessageCount();

            // We want to download all messages
            List<MessageModel> allMessages = new List<MessageModel>(messageCount);

            // Messages are numbered in the interval: [1, messageCount]
            // Ergo: message numbers are 1-based.
            // Most servers give the latest message the highest number
            for (int i = messageCount; i > 0; i--)
            {
                allMessages.Add(MessageModel.GetEmailContent(messageCount, ref client));
            }

            //client.Disconnect();

            // Now return the fetched messages
            return allMessages;
            //}
        }
    }
}
