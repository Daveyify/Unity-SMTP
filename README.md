Sistema de notificación por correo 
Integración protocolo SMTP y Unity


El sistema envía notificaciones automáticas por correo electrónico cuando se cumplen las siguientes condiciones dentro del juego:

  - 10 Cubos recolectados
  - 10 Esferas recolectadas
  - Victoria (10 Cubos + 10 Esferas)

Cada evento se evalúa dentro del GameManager en el método CheckEmailEvents().


Cuando se alcanza una condición:

  - Se valida que el jugador haya ingresado un correo electrónico.
  - Se verifica que el evento no haya sido enviado previamente por medio de 3 variables booleanas.
  - Se llama al método SendEmail() del SimpleEmailSender.


El envío de correos utiliza el protocolo SMTP mediante la clase SmtpClient.


Flujo general:

1. El jugador ingresa su correo en un TMP_InputField.
2. El UIManager guarda ese correo en GameManager.playerEmail.

3. Cuando se cumple un evento:

```csharp
GameManager ejecuta SendEmail(subject, body);
```

4. SimpleEmailSender:

  - Crea un objeto MailMessage.
  - Configura:
  Remitente (fromEmail)
  Destinatario (toEmail)
  Asunto
  Cuerpo del mensaje
  - Configura el cliente SMTP

5. Se ejecuta
smtp.Send(mail).
7. Se hace envio del mail
