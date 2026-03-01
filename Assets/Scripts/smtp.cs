using System;
using System.Net;
using System.Net.Mail;
using UnityEngine;

public class SimpleEmailSender
{

    public void SendEmail()
    {
        string fromEmail = "ingmultimediausbbog@gmail.com";
        string password = "fsjq ioqf zsxs jrzf";
        string toEmail = GameManager.Instance.playerEmail;

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(fromEmail);
        mail.To.Add(toEmail);
        mail.Subject = "Subject";
        mail.Body = "Body";

        SmtpClient smtp = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromEmail, password),
            EnableSsl = true
        };

        try
        {
            smtp.Send(mail);
            Debug.Log("Email sended succesfuly");
        }
        catch (Exception ex)
        {
            Debug.Log("Error: " + ex.Message);
        }
    }
}