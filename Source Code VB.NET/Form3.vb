Imports System.IO
Public Class Form3

    Dim path As String
    Dim sw As StreamWriter

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        path = "C:\Windows\System32\drivers\etc\hosts"
        sw = New StreamWriter(path, True)
        Dim sitetoblock As String = (Environment.NewLine & "127.0.0.1 " & TextBox1.Text)
        sw.Write(sitetoblock)
        sw.Close()
        MessageBox.Show("NSFW Site has been blocked succefully.All incomings to the nsfw sites are blocked.Please wait until internet disallow access.", "NSFW Site blocked", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub
End Class