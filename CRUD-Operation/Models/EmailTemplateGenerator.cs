namespace CRUD_Operation.Models
{
    public class EmailTemplateGenerator
    {
        public static (string plainText, string html) GenerateSuccessfulLoginEmailBody(string userName , string email)
        {
            var plainText = $@"
                Hello {userName},

                We are pleased to inform you that you have successfully logged into [Your Application Name].

                If you have any questions or concerns, please don't hesitate to contact our support team.

                Thank you for using [Your Application Name]!

                Best regards,
                [Feild Groovc]
            ";

            var html = $@"
                <!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Successful Login</title>
                </head>
                <body style=""font-family: Arial, sans-serif;"">
                    <div style=""max-width: 600px; margin: 20px auto; padding: 20px; border: 1px solid #ddd; border-radius: 5px; box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);"">
                        <h2 style=""color: #4CAF50;"">Successful Login</h2>
                        <p>Hello {userName},</p>
                        <p>We are pleased to inform you that you have successfully logged into [{userName}].</p>
                        <p>If you have any questions or concerns, please don't hesitate to contact our support team.</p>
                        <p>Thank you for using [{userName}]!</p>
                        <p>Best regards,<br>[Feild Groovc]</p>

                       <p>Activate your account: <a href=""https://localhost:44367/api/Users/activate?email={email}"" target=""_blank"">Click here</a></p>
                    </div>
                </body>
                </html>
            ";

            return (plainText, html);
        }

    }
}
