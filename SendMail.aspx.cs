
using System;

using System.Net;

using System.Net.Mail;
 
namespace YourProject

{

    public partial class SendMail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)

            {

                string name = Request.Form["name"];

                string email = Request.Form["email"];

                string subject = Request.Form["subject"];

                string message = Request.Form["message"];
 
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||

                    string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message))

                {

                    Response.Write("<script>alert('All fields are required');window.history.back();</script>");

                    return;

                }
 
                string body = $@"
                    <h3>New Contact Form Submission</h3>
                    <p><b>Name:</b> {name}</p>
                    <p><b>Email:</b> {email}</p>
                    <p><b>Subject:</b> {subject}</p>
                    <p><b>Message:</b><br>{message}</p>

                ";
 
                try

                {

                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress("yourEmail@gmail.com");

                    mail.To.Add("ownerEmail@gmail.com");

                    mail.Subject = "Contact Form: " + subject;

                    mail.Body = body;

                    mail.IsBodyHtml = true;
 
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                    smtp.Credentials = new NetworkCredential("yourEmail@gmail.com", "yourAppPassword");

                    smtp.EnableSsl = true;
 
                    smtp.Send(mail);
 
                    Response.Write("<script>alert('Message sent successfully!');window.location='index.html';</script>");

                }

                catch (Exception ex)

                {

                    Response.Write("<script>alert('Error: " + ex.Message + "');window.history.back();</script>");

                }

            }

        }

    }

}

 