using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using OnlineStore.Domain.Abstract;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "896212375@qq.com";
        public string MailFromAddress = "516093398@qq.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "hocete.win";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"d:\online_store_emails";
    }
    public class EmailOrderProcessor:IOderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }
        public void ProcessOrder(Cart cart,ShippingDetails shippingDetails)
        {
            using (var smtpClient=new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder().AppendLine("新的订单被提交").AppendLine("---").AppendLine("商品：");
                foreach(var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0}X{1} (总计{2:c})", line.Quantity, line.Product.Name, subtotal);
                }
                body.AppendFormat("总价值:{0:c}", cart.ComputeTotalValue())
                .AppendLine("---")
                .AppendLine("地址：")
                .AppendLine(shippingDetails.Name)
                .AppendLine(shippingDetails.Country)
                .AppendLine(shippingDetails.Zip)
                .AppendLine(shippingDetails.State)
                .AppendLine(shippingDetails.City)
                .AppendLine(shippingDetails.Line1)
                .AppendLine(shippingDetails.Line2 ?? "")
                .AppendLine(shippingDetails.Line3 ?? "")
                .AppendLine("---")
                .AppendFormat("是否包装：{0}",shippingDetails.GiftWrap?"是":"否");
                MailMessage mailMessage = new MailMessage(emailSettings.MailFromAddress, emailSettings.MailToAddress, "New order submitted!", body.ToString());
                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }
                try
                {
                    smtpClient.Send(mailMessage);
                }
                catch
                {

                }
                

            }
        }
    }
}
