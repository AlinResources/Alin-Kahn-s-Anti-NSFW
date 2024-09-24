Imports AlinKahnsAntiNSFW.My
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32



Public Class Detect
    Public Declare Ansi Function MoveFileEx Lib "kernel32" Alias "MoveFileExA" (<Global.System.Runtime.InteropServices.MarshalAs(Global.System.Runtime.InteropServices.UnmanagedType.VBByRefStr)> ByRef lpExistingFileName As String, <Global.System.Runtime.InteropServices.MarshalAs(Global.System.Runtime.InteropServices.UnmanagedType.VBByRefStr)> ByRef lpNewFileName As String, dwFlags As Long) As Long

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Detect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Text = Global.AlinKahnsAntiNSFW.My.MyProject.Forms.Form1.OpenFileDialog1.FileName
        Me.TextBox1.[ReadOnly] = True
        Me.TextBox1.Text = MyProject.Forms.Form1.OpenFileDialog1.FileName
        Me.TextBox1.Text = Global.AlinKahnsAntiNSFW.My.MyProject.Forms.Form1.OpenFileDialog1.FileName
        Me.Label1.Text = "Filename : "
        Me.Text = "Alin Kahn Anti-NSFW Alert"
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Text = Global.AlinKahnsAntiNSFW.My.MyProject.Forms.Form1.OpenFileDialog1.FileName
        Me.TextBox1.[ReadOnly] = True
    End Sub

    Private Sub OpenFileDialog3_FileOk(sender As Object, e As CancelEventArgs) Handles OpenFileDialog3.FileOk

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim flag As Boolean = Global.AlinKahnsAntiNSFW.My.MyProject.Computer.FileSystem.FileExists(Me.TextBox1.Text)
            If flag Then
                Global.AlinKahnsAntiNSFW.My.MyProject.Computer.FileSystem.DeleteFile(Me.TextBox1.Text)
                Global.Microsoft.VisualBasic.Interaction.MsgBox("The NSFW file successfully removed. No further action is required", Global.Microsoft.VisualBasic.MsgBoxStyle.Information, Nothing)
                MyBase.Hide()
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\removednsfwdetectedyougrossedme.wav")
            Else
                Dim flag2 As Boolean = Not Global.AlinKahnsAntiNSFW.My.MyProject.Computer.FileSystem.FileExists(Me.TextBox1.Text)
                If flag2 Then
                    Global.Microsoft.VisualBasic.Interaction.MsgBox("An error occured while deleting found file. The NSFW infected file do not seem to exist anymore on your PC, or maybe downloaded into the folder or has been moved , please run a scan to find the leftover of the files.", Global.Microsoft.VisualBasic.MsgBoxStyle.Critical, Nothing)
                    MyBase.Hide()
                End If
            End If
        Catch ex As Global.System.UnauthorizedAccessException
            Dim textBox As Global.System.Windows.Forms.TextBox = Me.TextBox1
            Dim text As String = textBox.Text
            Dim text2 As String = Nothing
            Global.AlinKahnsAntiNSFW.Detect.MoveFileEx(text, text2, 4L)
            textBox.Text = text
            Dim flag3 As Boolean = Global.Microsoft.VisualBasic.Interaction.MsgBox("Some of the NSFW Files require logging off/sign off to be erased completely." & vbCrLf & "Click YES to log off now or NO to log off later and remove manually. If you choose to sign off now, save your work before clicking YES button." & vbCrLf & "Please run Alin Kahn's anti NSFW scanner again after log off to locate and remove possible explicit subsequent traces.", Global.Microsoft.VisualBasic.MsgBoxStyle.YesNo Or Global.Microsoft.VisualBasic.MsgBoxStyle.Critical Or Global.Microsoft.VisualBasic.MsgBoxStyle.Question, "Action confirmation") = Global.Microsoft.VisualBasic.MsgBoxResult.Yes
            If flag3 Then
                Global.Microsoft.VisualBasic.Interaction.Shell("Shutdown -l -t 1", Global.Microsoft.VisualBasic.AppWinStyle.MinimizedFocus, False, -1)
                MyBase.Hide()
            Else
                Global.Microsoft.VisualBasic.Interaction.MsgBox("You have chosen to postpone the log off of your PC to complete the removal process. Active compromising NSFW files and some animes may still be present/downloaded on your PC until you sign out.", Global.Microsoft.VisualBasic.MsgBoxStyle.OkOnly, Nothing)
                MyBase.Hide()
            End If
        Catch ex2 As Global.System.Exception
        End Try
    End Sub

    Private Sub Label2_Load(sender As Object, e As EventArgs) Handles Label2.TextChanged
        Label2.AutoSize = True
        Label2.Text = "Ignore( Not recommended)"
    End Sub
End Class