﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseBackup
{
    internal class Mailer
    {
        private static readonly Regex EmailRegex = new Regex(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private  bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email);
        }
        private readonly App_Data.MailerNode _mailerNode;

        public Mailer()
        {
            _mailerNode = new App_Data.MailerNode();
        }

        public async Task Send(string to, string ccList, string subject, string body, List<string> filePaths, bool isZip = false)
        {
            try
            {
                if (IsValidEmail(to))
                {
                    var from = _mailerNode.data(App_Data.MailerNode.node.Email);
                    var password = _mailerNode.data(App_Data.MailerNode.node.Password);

                    using (var mail = new MailMessage(from, to))
                    using (var client = new SmtpClient("smtp.gmail.com", 587))
                    {
                        client.Timeout = 100000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(from, password);
                        client.EnableSsl = true;

                        mail.BodyEncoding = System.Text.Encoding.UTF8;
                        mail.SubjectEncoding = System.Text.Encoding.UTF8;
                        mail.Subject = $"{subject} {DateTime.Now}";
                        mail.IsBodyHtml = true;
                        mail.Body = HTML(subject, body);

                        AddCcAddresses(mail, to, ccList);

                        if (isZip)
                        {
                            string zipFilePath = CreateZipFromFiles(filePaths);
                            if (zipFilePath != null)
                            {
                                mail.Attachments.Add(new Attachment(zipFilePath));
                            }
                        }
                        else
                        {
                            AddAttachments(mail, filePaths);
                        }

                        client.SendCompleted += (s, e) =>
                        {
                            mail.Dispose();
                            client.Dispose();
                            if (e.Error != null)
                            {
                                // Handle the error here
                                //MessageBox.Show($"Error sending email: {e.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        };

                        await client.SendMailAsync(mail);
                    }
                }      
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                //MessageBox.Show($"Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCcAddresses(MailMessage mail, string to, string ccList)
        {
            if (string.IsNullOrWhiteSpace(ccList)) return;

            var ccAddresses = ccList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(email => email.Trim())
                                    .Distinct()
                                    .Where(email => !string.Equals(email, to, StringComparison.OrdinalIgnoreCase))
                                    .ToList();

            foreach (var email in ccAddresses)
            {
                try
                {
                    mail.CC.Add(email);
                }
                catch (Exception ex)
                {
                    // Handle or log invalid email address exception
                    //MessageBox.Show($"Invalid CC email address: {email}. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddAttachments(MailMessage mail, List<string> filePaths)
        {
            try
            {
                foreach (var filePath in filePaths)
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        mail.Attachments.Add(new Attachment(filePath));
                    }
                    else
                    {
                        // Handle case where file does not exist
                        //MessageBox.Show($"File not found: {filePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log attachment exception
                //MessageBox.Show($"Attachment error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CreateZipFromFiles(List<string> filePaths)
        {
            try
            {
                string zipFilePath = Path.Combine(Path.GetTempPath(), $"Attachments_{DateTime.Now.Ticks}.zip");
                using (var zip = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
                {
                    foreach (var filePath in filePaths)
                    {
                        if (System.IO.File.Exists(filePath))
                        {
                            zip.CreateEntryFromFile(filePath, Path.GetFileName(filePath));
                        }
                        else
                        {
                            // Handle case where file does not exist
                            //MessageBox.Show($"File not found: {filePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                return zipFilePath;
            }
            catch (Exception ex)
            {
                // Handle or log zip creation exception
                //MessageBox.Show($"Error creating zip file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private string HTML(string subject, string body)
        {
            // Replace with actual HTML content generation logic
            return $"<html><body><h1>{subject}</h1><p>{body}</p></body></html>";
        }
    }
}
