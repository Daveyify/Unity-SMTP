using System;
using System.Net;
using System.Net.Mail;
using UnityEngine;

public class SimpleEmailSender
{

    public void SendEmail(string subject, string body)
    {
        string fromEmail = "davidesuancha1206@gmail.com";
        string password = "nkbe tlld wmcm dooj";
        string toEmail = GameManager.Instance.playerEmail;

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(fromEmail);
        mail.To.Add(toEmail);
        mail.Subject = subject;
        mail.Body = body;

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