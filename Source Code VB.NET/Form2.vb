Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports AlinKahnsAntiNSFW.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Public Class Form2
    Private Sub Form3_Load(sender As Object, e As Global.System.EventArgs)
        TextBox1.SelectedText = ""
        Me.TextBox1.Size = New Global.System.Drawing.Size(340, 26)
        Me.TextBox1.TabIndex = 38
        Me.TextBox2.Font = New Global.System.Drawing.Font("Segoe UI", 9.0F)
        Me.TextBox2.PasswordChar = vbNullChar
        Me.TextBox2.SelectedText = ""
        Me.TextBox2.Size = New Global.System.Drawing.Size(340, 26)
        Me.TextBox2.TabIndex = 42
    End Sub

    Public Declare Ansi Function MoveFileEx Lib "kernel32" Alias "MoveFileExA" (<Global.System.Runtime.InteropServices.MarshalAs(Global.System.Runtime.InteropServices.UnmanagedType.VBByRefStr)> ByRef lpExistingFileName As String, <Global.System.Runtime.InteropServices.MarshalAs(Global.System.Runtime.InteropServices.UnmanagedType.VBByRefStr)> ByRef lpNewFileName As String, dwFlags As Long) As Long

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.OpenFileDialog1.ShowDialog()
        Me.TextBox1.Text = Me.OpenFileDialog1.FileName
        Me.TextBox2.Text = Global.System.IO.Path.GetFileName(Me.OpenFileDialog1.FileName)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim flag As Boolean = Global.AlinKahnsAntiNSFW.My.MyProject.Computer.FileSystem.FileExists(Me.TextBox1.Text)
            If flag Then
                Global.AlinKahnsAntiNSFW.My.MyProject.Computer.FileSystem.DeleteFile(Me.TextBox1.Text)
                Global.Microsoft.VisualBasic.Interaction.MsgBox("The file has been deleted successfully. No further action is required.", Global.Microsoft.VisualBasic.MsgBoxStyle.Information, Nothing)
                Me.TextBox1.Clear()
                Me.TextBox2.Clear()
                MyBase.Hide()
            Else
                Dim flag2 As Boolean = Not Global.AlinKahnsAntiNSFW.My.MyProject.Computer.FileSystem.FileExists(Me.TextBox1.Text)
                If flag2 Then
                    Global.Microsoft.VisualBasic.Interaction.MsgBox("An error occured during the process. Either you didn't choose a file to be deleted or the selected file do not seem to exist anymore on your PC.", Global.Microsoft.VisualBasic.MsgBoxStyle.Critical, Nothing)
                    MyBase.Hide()
                    Me.TextBox1.Clear()
                    Me.TextBox2.Clear()
                End If
            End If
        Catch ex As Global.System.UnauthorizedAccessException
            Dim textBox As TextBox = Me.TextBox1
            Dim text As String = textBox.Text
            Dim text2 As String = Nothing
            Global.AlinKahnsAntiNSFW.Form2.MoveFileEx(text, text2, 4L)
            textBox.Text = text
            Dim flag3 As Boolean = Global.Microsoft.VisualBasic.Interaction.MsgBox("The selected file appeared to be locked in an active process." & vbCrLf & "Our tool will successfully delete the selected file on next system restart." & vbCrLf & "Please click YES to restart now or NO to restart later. Please note that the file will not be deleted until you restart.", Global.Microsoft.VisualBasic.MsgBoxStyle.YesNo Or Global.Microsoft.VisualBasic.MsgBoxStyle.Critical Or Global.Microsoft.VisualBasic.MsgBoxStyle.Question, "Action confirmation") = Global.Microsoft.VisualBasic.MsgBoxResult.Yes
            If flag3 Then
                Me.TextBox1.Clear()
                Me.TextBox2.Clear()
                Global.Microsoft.VisualBasic.Interaction.Shell("Shutdown -r -t 1", Global.Microsoft.VisualBasic.AppWinStyle.MinimizedFocus, False, -1)
            Else
                Global.Microsoft.VisualBasic.Interaction.MsgBox("You have chosen to postpone the restart of your PC to complete the file removal process. The file may still be present on your PC until you reboot.", Global.Microsoft.VisualBasic.MsgBoxStyle.OkOnly, Nothing)
                Me.TextBox1.Clear()
                Me.TextBox2.Clear()
                MyBase.Hide()
            End If
        Catch ex2 As Global.System.Exception
        End Try
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub
End Class