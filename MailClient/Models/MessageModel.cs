using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.Models
{
    public class MessageModel
    {
        public string MessageID;
        public string FromID;
        public string FromName;
        public string Subject;
        public string Body;
        public string Html;
        public string FileName;
        public List<MessagePart> Attachment;

        public static MessageModel GetEmailContent(int messageNumber, ref Pop3Client objPOP3Client)
        {
            MessageModel message = new MessageModel();

            MessagePart plainTextPart = null, HTMLTextPart = null;

            Message objMessage = objPOP3Client.GetMessage(messageNumber);

            message.MessageID = objMessage.Headers.MessageId == null ? "" : objMessage.Headers.MessageId.Trim();

            message.FromID = objMessage.Headers.From.Address.Trim();
            message.FromName = objMessage.Headers.From.DisplayName.Trim();
            message.Subject = objMessage.Headers.Subject.Trim();

            plainTextPart = objMessage.FindFirstPlainTextVersion();
            message.Body = (plainTextPart == null ? "" : plainTextPart.GetBodyAsText().Trim());

            HTMLTextPart = objMessage.FindFirstHtmlVersion();
            message.Html = (HTMLTextPart == null ? "" : HTMLTextPart.GetBodyAsText().Trim());

            List<MessagePart> attachment = objMessage.FindAllAttachments();
            if (attachment.Count > 0)
            {

                message.FileName = attachment[0].FileName.Trim();
                message.Attachment = attachment;

            }

            return message;
        }
    }
}
