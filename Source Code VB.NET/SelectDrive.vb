Imports System.IO

Public Class SelectDrive
    Private Sub SelectDrive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For Each drive In Environment.GetLogicalDrives
                Dim InfoDrive As DriveInfo = New DriveInfo(drive)
                If InfoDrive.DriveType = DriveType.Removable Or InfoDrive.DriveType = DriveType.Fixed Then
                    ComboBox1.Items.Add(drive)
                End If
            Next
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("BAD", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.ListBox2.Items.Clear()
        Form1.ListBox1.Items.Clear()
        Form1.FolderBrowserDialog1.SelectedPath = ComboBox1.Text
        Form1.ProgressBar1.Value = 0
        Form1.lblVirus.Text = "0"

        On Error Resume Next
        For Each strDir As String In System.IO.Directory.GetDirectories(Form1.FolderBrowserDialog1.SelectedPath, "*.*", SearchOption.TopDirectoryOnly)
            For Each strFile As String In System.IO.Directory.GetFiles(strDir, "*.*", SearchOption.AllDirectories)
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\scanstarted.wav")
                Form1.ListBox1.Items.Add(strFile)
            Next

        Next

        Form1.Button4.Visible = True
        Form1.Button2.Visible = False
        Form1.Button3.Visible = False
        Form1.Show()
        Form1.ListBox1.Enabled = False
        Form1.Timer1.Start()
        Me.Hide()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub
End Class