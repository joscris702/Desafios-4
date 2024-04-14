using System;

public interface INotificable
{
    void Notificar(string mensaje);
}

public class NotificacionEmail : INotificable
{
    public string DireccionCorreo { get; set; }

    public NotificacionEmail(string direccionCorreo)
    {
        DireccionCorreo = direccionCorreo;
    }

    public void Notificar(string mensaje)
    {
        Console.WriteLine($"Enviando correo electrónico a {DireccionCorreo}: {mensaje}");
    }
}

public class NotificacionWhatsapp : INotificable
{
    public string NumeroTelefono { get; set; }

    public NotificacionWhatsapp(string numeroTelefono)
    {
        NumeroTelefono = numeroTelefono;
    }

    public void Notificar(string mensaje)
    {
        Console.WriteLine($"Enviando mensaje por WhatsApp al número {NumeroTelefono}: {mensaje}");
    }
}

public class NotificacionSMS : INotificable
{
    public string NumeroTelefono { get; set; }

    public NotificacionSMS(string numeroTelefono)
    {
        NumeroTelefono = numeroTelefono;
    }

    public void Notificar(string mensaje)
    {
        Console.WriteLine($"Enviando SMS al número {NumeroTelefono}: {mensaje}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Seleccione el tipo de notificación:");
        Console.WriteLine("1. Correo electrónico");
        Console.WriteLine("2. WhatsApp");
        Console.WriteLine("3. SMS");

        string opcion = Console.ReadLine();

        INotificable notificacion;

        switch (opcion)
        {
            case "1":
                Console.WriteLine("Ingrese la dirección de correo electrónico:");
                string correo = Console.ReadLine();
                notificacion = new NotificacionEmail(correo);
                break;
            case "2":
                Console.WriteLine("Ingrese el número de teléfono de WhatsApp:");
                string whatsapp = Console.ReadLine();
                notificacion = new NotificacionWhatsapp(whatsapp);
                break;
            case "3":
                Console.WriteLine("Ingrese el número de teléfono para SMS:");
                string sms = Console.ReadLine();
                notificacion = new NotificacionSMS(sms);
                break;
            default:
                Console.WriteLine("Opción no válida.");
                return;
        }

        Console.WriteLine("Ingrese el mensaje a enviar:");
        string mensaje = Console.ReadLine();

        notificacion.Notificar(mensaje);
    }
}

