using FluentValidation;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;
using System.Net.Mail;
using System.Net;
namespace Yipa.Business.Concrete
{
    public class ContactManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Contact> _validator;

        public ContactManager(IUnitOfWork unitOfWork, IValidator<Contact> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task SendEmailAsync(Contact contact)
        {
          
            string fromAddress = "gonderici@ornek.com";
            string fromPassword = "gonderici_sifresi";

            string smtpHost = "smtp.office365.com";
            int smtpPort = 587; 

           
            MailMessage mailMessage = new MailMessage(fromAddress, contact.Mail!, contact.Subject, contact.Message);
            mailMessage.IsBodyHtml = true; 

            using (SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtpClient.EnableSsl = true; 

                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                    
                }
                catch (Exception)
                {
                    throw new Exception("E-posta gönderme hatası.");
                }
            }
        }




    }
}
