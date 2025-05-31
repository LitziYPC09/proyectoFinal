
using MimeKit;
using MailKit.Net.Smtp;

namespace alertasUrgentes.clases
{
    

    public class EmailHelper
    {
        //private readonly string smtpHost = "smtp.gmail.com";
        //private readonly int smtpPort = 587;
        //private readonly string correoOrigen = "cermenolitzi009@gmail.com";          // Cambia por tu correo
        //private readonly string passwordCorreo = "09051523624cermenoLitzi";    // Cambia por tu contraseña o password de aplicación

        public void EnviarEmail(string destinatario, string asunto, string cuerpo)
        {
            var mensaje = new MimeMessage();
            mensaje.From.Add(new MailboxAddress("Urgencias Altas", "perezporra3@gmail.com"));
            mensaje.To.Add(new MailboxAddress("", destinatario));
            mensaje.Subject = asunto;

            mensaje.Body = new TextPart("plain")
            {
                Text = cuerpo
            };

            using (var cliente = new SmtpClient())
            {
                cliente.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                cliente.Authenticate("cermenolitzi009@gmail.com", "wjvc gdhz mvoh asts");
                //cliente.Authenticate("tucorreo@gmail.com", "abcd efgh ijkl mnop");
                cliente.Send(mensaje);
                cliente.Disconnect(true);
            }
        }
    }


}
