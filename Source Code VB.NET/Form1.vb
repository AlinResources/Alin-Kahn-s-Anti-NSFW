﻿Imports System.Security.Cryptography
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Runtime.CompilerServices
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports AlinKahnsAntiNSFW.My

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button25.Enabled = False
        realtime.Text = "Real-Time Enabled"
        Me.Label27.Text = "Active"
        Me.ListBox2.ForeColor = Global.System.Drawing.Color.DarkRed
        Me.TabPage2.Controls.Add(Me.realtimelistbox)
        Me.GroupBox7.Controls.Add(Me.Labellastreal)
        Me.GroupBox7.Name = "labellastreal"
        Me.Labellastreal.AutoSize = True
        Me.Labellastreal.BackColor = Global.System.Drawing.Color.Transparent
        Me.Labellastreal.Font = New Global.System.Drawing.Font("Segoe UI", 9.0F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
        Me.Labellastreal.ForeColor = Global.System.Drawing.Color.Black
        Me.Labellastreal.Location = New Global.System.Drawing.Point(11, 20)
        Me.Labellastreal.MaximumSize = New Global.System.Drawing.Size(1550, 20)
        Me.Labellastreal.Name = "Labellastreal"
        Me.Labellastreal.Size = New Global.System.Drawing.Size(89, 14)
        Me.Labellastreal.TabIndex = 4
        Me.Labellastreal.Text = "No file scanned"
    End Sub
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MessageBox.Show("Do you want to close Alin Kahn's Anti-NSFW program?" & ControlChars.CrLf & "NOTE : If you exit you will also disable on exit the real time protection which means it cannot warns you and protect you when an explicit questionable compromissing material" & ControlChars.CrLf & "of fictional/anime/random image/file is able to be writted , and maybe downloaded , if you reopen the program don't forget to scan the downloads area and possible other folders, but if you attempt to keep those then what that would? If you exit the program , the anti-nsfw protection will not work unless the program is running." & ControlChars.CrLf & "BUT do you really want to exit?", "Exit AntiNSFW and its protection?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = False
            NotifyIcon1.Visible = True
            NotifyIcon1.Icon = NotifyIcon1.Icon
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            NotifyIcon1.BalloonTipTitle = "Don't worry , i am not going anywhere"
            NotifyIcon1.BalloonTipText = "The program is minimized in tray."
            NotifyIcon1.ShowBalloonTip(50000)
            ShowInTaskbar = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            ListBox1.Items.Clear()
            Button4.Visible = True
            SavelogButton.Visible = False
            Button3.Enabled = True
        Else
            Exit Sub
        End If

        On Error Resume Next

        For Each strFile As String In System.IO.Directory.GetFiles(FolderBrowserDialog1.SelectedPath, "*.*", IO.SearchOption.AllDirectories)
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\scanstarted.wav")
            ListBox1.Items.Add(strFile)
        Next
        Timer1.Start()
        TabControl1.SelectTab(1)
        NotifyIcon1.Visible = True
        NotifyIcon1.Icon = NotifyIcon1.Icon
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipTitle = "A scanner has been started"
        NotifyIcon1.BalloonTipText = "Anti-NSFW Scanner has been started , this will take a while then once the scanner has been finished , we will notify you soon."
        NotifyIcon1.ShowBalloonTip(50000)
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Maximum = Conversions.ToString(ListBox1.Items.Count)
        lblTotal.Text = Conversions.ToString(ListBox1.Items.Count)
        ListBox1.Enabled = False
        If Not ProgressBar1.Value = ProgressBar1.Maximum Then
            Try
                ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
                lblLast.Text = ListBox1.SelectedItem.ToString
            Catch ex As Exception
            End Try

            Try

                Dim scanbox As New TextBox
                Dim read As String = My.Computer.FileSystem.ReadAllText("antinsfwdatabase.db").ToString
                ProgressBar1.Increment(1)
                lblVirus.Text = Conversions.ToString(ListBox2.Items.Count)
                lblTotal.Text = Conversions.ToString(ProgressBar1.Value)
                scanbox.Text = read.ToString
                Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
                Dim f As FileStream = New FileStream(ListBox1.SelectedItem, FileMode.Open, FileAccess.Read, FileShare.Read, &H2000)
                f = New FileStream(ListBox1.SelectedItem, FileMode.Open, FileAccess.Read, FileShare.Read, &H2000)
                md5.ComputeHash(f)
                f.Close()
                Dim hash As Byte() = md5.Hash
                Dim buff As StringBuilder = New StringBuilder
                Dim hashByte As Byte
                For Each hashByte In hash
                    buff.Append(String.Format("{0:X2}", hashByte))
                Next

                If scanbox.Text.Contains(buff.ToString) Then
                    My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\badnsfwfilefoundalert.wav")
                    ListBox2.Items.Add(ListBox1.SelectedItem)
                    Me.BackColor = Global.System.Drawing.Color.Crimson
                End If
            Catch ex As Exception
            End Try
        Else
            ListBox1.Enabled = True
            Timer1.Stop()
            If ListBox2.Items.Count > 0 Then
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\scancompleted.wav")
                Show()
                MsgBox("Scanning has been completed. There was " & vbCrLf & ListBox2.Items.Count & " nsfw/questionable/explicit files and references detected. Please review the list and choose an action immediatly.", MsgBoxStyle.Critical)
                NotifyIcon1.Visible = True
                NotifyIcon1.Icon = SystemIcons.Exclamation
                NotifyIcon1.BalloonTipTitle = "NSFW Explicit/Questionable content detected"
                NotifyIcon1.BalloonTipText = "The scanner has been completed , please check the items and take an action."
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
                NotifyIcon1.ShowBalloonTip(30000)
                Button4.Visible = False
                Button2.Visible = True
                Button3.Visible = True
                SavelogButton.Visible = True
                Button21.Enabled = False
                Button20.Enabled = False
                Exit Sub
            End If
            MsgBox("Scanning has been completed." & vbCrLf & "No NSFW materials found.", MsgBoxStyle.Information)
            ProgressBar1.Value = 0
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox2.Enabled = False
        ListBox2.SelectedIndex = -1
        If ListBox2.Items.Count = 0 Then
            MsgBox("...the frick?", MsgBoxStyle.Critical)
            Exit Sub
        End If

        While ListBox2.Items.Count - 1 = ListBox1.SelectedIndex = False
            ListBox2.SelectedIndex += 1
            File.Delete(ListBox2.SelectedItem)
            If ListBox2.Items.Count = ListBox2.SelectedIndex + 1 Then
                ListBox2.Items.Clear()
                ListBox2.Enabled = True
                Me.BackColor = Global.System.Drawing.Color.Goldenrod
                MsgBox("All NSFW materials have been removed. Your folder/PC is now cleaned from NSFW files.", MsgBoxStyle.Information)
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\operationdone.wav")
                Me.Visible = True
                NotifyIcon1.Visible = True
                NotifyIcon1.Icon = SystemIcons.Asterisk
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                NotifyIcon1.BalloonTipTitle = "Alin Kahn's AntiNSFW : NSFW Files Deleted"
                NotifyIcon1.BalloonTipText = "The NSFW Materials has been removed succefully and now the task has been finished.The Scanner is now closing."
                NotifyIcon1.ShowBalloonTip(50000)
                ProgressBar1.Value = 0
                Button4.Visible = False
                Button2.Visible = False
                Button3.Visible = False
                SavelogButton.Visible = False
                Button21.Visible = False
                Button20.Visible = False
                Exit Sub
            End If
        End While
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Are you sure you want to ignore ALL items?It is easy to wish to keep them or something , but now is depending on reputation, do you want to keep them or delete them?", MsgBoxStyle.YesNo, "Woah there, dude!") = MsgBoxResult.Yes Then
            ListBox2.Items.Clear()
            ListBox2.Enabled = True
            ProgressBar1.Value = 0
            Button4.Visible = False
            Button2.Visible = False
            Button3.Visible = False
            SavelogButton.Visible = False
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\ignoredstuff.wav")
        Else
            MessageBox.Show("Maybe you wanna to go back to delete those gross stuff , then go ahead and destroy them.", "Maybe...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If MsgBox("Are you sure you want to abort the scan?", MsgBoxStyle.YesNo, "Woah, dude!") = MsgBoxResult.Yes Then
            Timer1.Stop()
            If ListBox2.Items.Count > 0 Then
                Show()
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\scancompleted.wav")
                NotifyIcon1.Visible = True
                NotifyIcon1.Icon = SystemIcons.Exclamation
                NotifyIcon1.BalloonTipTitle = "NSFW Explicit/Questionable content detected"
                NotifyIcon1.BalloonTipText = "The scanner has been completed , please check the items and take an action."
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
                NotifyIcon1.ShowBalloonTip(30000)
                MsgBox("Scanning has been completed. There was" & vbCrLf & ListBox2.Items.Count & " nsfw/questionable/explicit files and references detected. Please review the list and choose an action immediatly.", MsgBoxStyle.Critical)
                Timer1.Stop()
                ProgressBar1.Value = 0
                Button4.Visible = False
                Button2.Visible = True
                Button3.Visible = True
                Button20.Enabled = False
                Button21.Enabled = False
                SavelogButton.Visible = True
            Else
                MsgBox("Scanning has been completed." & vbCrLf & "No NSFW files found.", MsgBoxStyle.Information)
                Timer1.Stop()
                ProgressBar1.Value = 0
                Button4.Visible = False
            End If
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            ListBox1.Items.Add(OpenFileDialog1.FileName)
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SelectDrive.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Notepad.Show()
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        EmptyRecycleBin()
        MessageBox.Show("Done cleaning the recycle bin.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub EmptyRecycleBin()
        SHEmptyRecycleBin(Me.Handle.ToInt32, vbNullString, SHERB_NOCONFIRMATION)
        SHUpdateRecycleBinIcon()
    End Sub

    Private Declare Function SHEmptyRecycleBin Lib "shell32.dll" Alias "SHEmptyRecycleBinA" (ByVal hWnd As Int32, ByVal pszRootPath As String, ByVal dwFlags As Int32) As Int32
    Private Declare Function SHUpdateRecycleBinIcon Lib "shell32.dll" () As Int32

    Private Const SHERB_NOCONFIRMATION = &H1
    Private Const SHERB_NOPROGRESSUI = &H2

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Form2.Show()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Process.Start("taskmgr.exe")
    End Sub

    Private Sub Button16_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button16.Click
        If MessageBox.Show("Do You want to reset the wallpaper?" & ControlChars.CrLf & "This will not reset the wallpaper on the first Click or first instance" & ControlChars.CrLf & "BUT do you want to reset the wallpaper?", "Reset Wallpaper?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
        End If
        If MessageBox.Show("THIS IS THE LAST WARNING BEFORE TO PROCEED, Forcing changing wallpaper may cause unstable results or may result in other problems." & ControlChars.CrLf & "In some cases restart explorer or logoff to apply the wallpaper changes but anyways DO YOU WANT TO RESET THE WALLPAPER BY FORCE?", "Alin Kahn Anti-NSFW Kill Wallpaper : LAST WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            Dim fileName As String = "killwallpaper.cmd"
            Dim appDir As String = System.IO.Path.GetDirectoryName( _
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

            Process.Start(appDir & "\scripts\" & fileName)
            MessageBox.Show("The NSFW Wallpaper has been killed succefully." & ControlChars.CrLf & "DISCLAIMER : In case of gross wallpaper kill the wallpaper which it kill the wallpaper and set to a random solid color" & ControlChars.CrLf & "ATTENTION !!! : Sometimes it didn't change the wallpaper on the first click , try again until the wallpaper is a solid color / wallpaper killed.", "Kill NSFW Wallpaper waifu", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavelogButton.Click
        Dim sb As New System.Text.StringBuilder()
        Dim dateString = DateTime.Now.ToString("yyyyMMdd_HH_mm_ss")
        Dim filepath As String = dateString + ".txt"
        Dim flag As Boolean = Global.System.Windows.Forms.DialogResult.OK
        For Each o As Object In ListBox2.Items
            sb.AppendLine(o)
        Next
        If Not System.IO.File.Exists(filepath) Then
            System.IO.File.WriteAllText(Application.StartupPath & "\logs\DetectedNSFWLog_Reportlist_" & filepath, sb.ToString())
        End If

        MessageBox.Show("A log of all Not safe for work stuff found has been saved in the logs folder.", "Log Created", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick, NotifyIcon1.BalloonTipClicked
        Show()
        Me.WindowState = FormWindowState.Normal
        Me.Visible = True
        NotifyIcon1.Visible = False
    End Sub

    Private Sub FileSystemWatcher1_Changed(sender As Object, e As FileSystemEventArgs)
        Try
            Me.OpenFileDialog1.FileName = ""
            Dim textBox As TextBox = New TextBox()
            textBox.Text = MyProject.Computer.FileSystem.ReadAllText(Application.StartupPath + "\antinsfwdatabase.db").ToString()
            Dim md5CryptoServiceProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
            Dim fileStream As FileStream = New FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
            fileStream.Close()
            fileStream = New FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
            md5CryptoServiceProvider.ComputeHash(fileStream)
            Dim hash As Byte() = md5CryptoServiceProvider.Hash
            Dim stringBuilder As StringBuilder = New StringBuilder()
            For Each b As Byte In hash
                stringBuilder.Append(String.Format("{0:X2}", b))
            Next
            fileStream.Close()
            Dim flag As Boolean = textBox.Text.Contains(stringBuilder.ToString())
            If flag Then
                Me.Labellastreal1.Text = e.FullPath
                Me.realtimelistbox.Items.Add(Me.Labellastreal1.Text)
                Me.OpenFileDialog1.FileName = e.FullPath
                MyProject.Forms.Detect.ShowDialog()
            Else
                Me.Labellastreal1.Text = e.FullPath
                Me.realtimelistbox.Items.Add(Me.Labellastreal1.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FileSystemWatcher1_Renamed(sender As Object, e As RenamedEventArgs)
        Try
            Me.OpenFileDialog1.FileName = ""
            Dim textBox As TextBox = New TextBox()
            textBox.Text = MyProject.Computer.FileSystem.ReadAllText(Application.StartupPath + "\antinsfwdatabase.db").ToString()
            Dim md5CryptoServiceProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
            Dim fileStream As FileStream = New FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
            fileStream.Close()
            fileStream = New FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
            md5CryptoServiceProvider.ComputeHash(fileStream)
            Dim hash As Byte() = md5CryptoServiceProvider.Hash
            Dim stringBuilder As StringBuilder = New StringBuilder()
            For Each b As Byte In hash
                stringBuilder.Append(String.Format("{0:X2}", b))
            Next
            fileStream.Close()
            Dim flag As Boolean = textBox.Text.Contains(stringBuilder.ToString())
            If flag Then
                Me.Labellastreal1.Text = e.FullPath
                Me.realtimelistbox.Items.Add(Me.Labellastreal1.Text)
                Me.OpenFileDialog1.FileName = e.FullPath
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\nsfwitemthreatdetectedrealtime.wav")
                MyProject.Forms.Detect.ShowDialog()
            Else
                Me.Labellastreal1.Text = e.FullPath
                Me.realtimelistbox.Items.Add(Me.Labellastreal1.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub OpenFileDialog3_Disposed(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        FileSystemWatcher1.EnableRaisingEvents = True
        realtime.Text = "Real-Time Enabled"
        Me.BackColor = Global.System.Drawing.Color.ForestGreen
        Button25.Enabled = False
        Button19.Enabled = True
        realtime.ForeColor = Color.LimeGreen
        NotifyIcon1.Icon = SystemIcons.Shield
        NotifyIcon1.BalloonTipTitle = "Anti-NSFW Shield has been turned on"
        NotifyIcon1.BalloonTipText = "Real-time protection is turned on, now the Windows is protected from any compromissing fictional character who attempt to be accessed / downloaded."
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        Me.Label27.Text = "Active"
        NotifyIcon1.ShowBalloonTip(30000)
        My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\done.wav")

    End Sub

    Private Sub Button19_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button19.Click
        If MessageBox.Show("Do you want to turn off the real time protection? If you turn it off , you will no longer be notified about the detected and downloaded NSFW files on your personal windows , unless you turn the protection back on,do you want to turn it off?This will make your computer vulnerable to questionable stuff and explicit content.Proceed?", "Alin Kahn's Anti-NSFW Turn off Run-time protection?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            FileSystemWatcher1.EnableRaisingEvents = False
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\done.wav")
            realtime.Text = "Real-Time Disabled"
            Me.BackColor = Global.System.Drawing.Color.DarkRed
            NotifyIcon1.Icon = SystemIcons.Error
            NotifyIcon1.BalloonTipTitle = "Anti-NSFW Shield has been turned off"
            NotifyIcon1.BalloonTipText = "Real-time protection has been turned off,your computer will posses a high risk of anime/fictional/other NSFW compromissing content to be copied and transferred in this PC."
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
            Me.Label27.Text = "Inactive. Please check."
            NotifyIcon1.ShowBalloonTip(30000)
            realtime.ForeColor = Color.Red
            Button25.Enabled = True
            Button19.Enabled = False
        End If
    End Sub

    Private Sub realtime_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Timer1.Stop()
        Button20.Enabled = False
        Button21.Enabled = True
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Timer1.Start()
        Button20.Enabled = True
        Button21.Enabled = False
    End Sub

    Private Sub realtimelistbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles realtimelistbox.SelectedIndexChanged
        For Each strFile As String In System.IO.Directory.GetFiles(FolderBrowserDialog1.SelectedPath, "*.*", IO.SearchOption.AllDirectories)
            realtimelistbox.Items.Add(strFile)
        Next
        Me.realtimelistbox.FormattingEnabled = True
        Me.realtimelistbox.ItemHeight = 16
        Me.realtimelistbox.Location = New Point(870, 388)
        Me.realtimelistbox.Name = "realtimelistbox"
        Me.realtimelistbox.Size = New Size(41, 20)
        Me.realtimelistbox.TabIndex = 59
        Me.realtimelistbox.Visible = True
        Me.TabPage2.Controls.Add(Me.realtimelistbox)
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub Label19_Load(sender As Object, e As EventArgs) Handles Label19.TextChanged
        Label19.AutoSize = True
        Label19.BackColor = Color.Transparent
        Label19.Font = New Font("Segoe UI", 9.0F)
        Label19.ForeColor = Color.Black
        Label19.Name = "Label19"
        Label19.Size = New Size(97, 15)
        Label19.TabIndex = 32
        Label19.Text = "Misc Settings"
    End Sub

    Private Sub GroupBox5_Load(sender As Object, e As EventArgs) Handles GroupBox5.Enter
        GroupBox5.Controls.Add(Me.Label19)
        TabPage4.Controls.Add(Me.realtimelistbox)
    End Sub

    Private Sub Labellastreal1_Load(sender As Object, e As EventArgs) Handles Labellastreal1.TextChanged
        Labellastreal1.AutoSize = True
        Labellastreal1.BackColor = Color.Transparent
        Labellastreal1.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, 0)
        Labellastreal1.ForeColor = Color.Black
        Labellastreal1.Name = "Labellastreal1"
        Labellastreal1.Size = New Size(89, 14)
        Labellastreal1.Text = "The section with other settings is working in progress."
    End Sub

    Friend Overridable Property OpenFileDialog2 As OpenFileDialog



    Private Sub FileSystemWatcher1_Changed_1(sender As Object, e As FileSystemEventArgs) Handles FileSystemWatcher1.Changed
        Try
            Me.OpenFileDialog1.FileName = ""
            Dim detectedbadbloodydesire As Detect
            detectedbadbloodydesire = New Detect
            Dim textBox As Global.System.Windows.Forms.TextBox = New Global.System.Windows.Forms.TextBox()
            textBox.Text = Global.AlinKahnsAntiNSFW.My.MyProject.Computer.FileSystem.ReadAllText(Global.System.Windows.Forms.Application.StartupPath + "\antinsfwdatabase.db").ToString()
            Dim md5CryptoServiceProvider As Global.System.Security.Cryptography.MD5CryptoServiceProvider = New Global.System.Security.Cryptography.MD5CryptoServiceProvider()
            Dim fileStream As Global.System.IO.FileStream = New Global.System.IO.FileStream(e.FullPath, Global.System.IO.FileMode.Open, Global.System.IO.FileAccess.Read, Global.System.IO.FileShare.Read, 8192)
            fileStream.Close()
            fileStream = New Global.System.IO.FileStream(e.FullPath, Global.System.IO.FileMode.Open, Global.System.IO.FileAccess.Read, Global.System.IO.FileShare.Read, 8192)
            md5CryptoServiceProvider.ComputeHash(fileStream)
            Dim hash As Byte() = md5CryptoServiceProvider.Hash
            Dim stringBuilder As Global.System.Text.StringBuilder = New Global.System.Text.StringBuilder()
            For Each b As Byte In hash
                stringBuilder.Append(String.Format("{0:X2}", b))
            Next
            fileStream.Close()
            Dim flag As Boolean = textBox.Text.Contains(stringBuilder.ToString())
            If flag Then
                Me.Labellastreal.Text = e.FullPath
                Me.realtimelistbox.Items.Add(Me.Labellastreal.Text)
                Me.OpenFileDialog1.FileName = e.FullPath
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\nsfwitemthreatdetectedrealtime.wav")
                detectedbadbloodydesire.Show()
            Else
                Me.Labellastreal.Text = e.FullPath
                Me.realtimelistbox.Items.Add(Me.Labellastreal.Text)
            End If
        Catch ex As Global.System.Exception
        End Try
    End Sub
    Private Sub FileSystemWatcher1_Created_1(sender As Object, e As Global.System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Created
        Try
            Me.OpenFileDialog2.FileName = ""
            Dim detectedbadbloodydesire As Detect
            detectedbadbloodydesire = New Detect
            Dim textBox As Global.System.Windows.Forms.TextBox = New Global.System.Windows.Forms.TextBox()
            textBox.Text = Global.AlinKahnsAntiNSFW.My.MyProject.Computer.FileSystem.ReadAllText(Global.System.Windows.Forms.Application.StartupPath + "\antinsfwdatabase.db").ToString()
            Dim md5CryptoServiceProvider As Global.System.Security.Cryptography.MD5CryptoServiceProvider = New Global.System.Security.Cryptography.MD5CryptoServiceProvider()
            Dim fileStream As Global.System.IO.FileStream = New Global.System.IO.FileStream(e.FullPath, Global.System.IO.FileMode.Open, Global.System.IO.FileAccess.Read, Global.System.IO.FileShare.Read, 8192)
            fileStream.Close()
            fileStream = New Global.System.IO.FileStream(e.FullPath, Global.System.IO.FileMode.Open, Global.System.IO.FileAccess.Read, Global.System.IO.FileShare.Read, 8192)
            md5CryptoServiceProvider.ComputeHash(fileStream)
            Dim hash As Byte() = md5CryptoServiceProvider.Hash
            Dim stringBuilder As Global.System.Text.StringBuilder = New Global.System.Text.StringBuilder()
            For Each b As Byte In hash
                stringBuilder.Append(String.Format("{0:X2}", b))
            Next
            fileStream.Close()
            Dim flag As Boolean = textBox.Text.Contains(stringBuilder.ToString())
            If flag Then
                Me.Labellastreal.Text = e.FullPath
                Me.realtimelistbox.Items.Add(Me.Labellastreal.Text)
                Me.OpenFileDialog2.FileName = e.FullPath
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\nsfwitemthreatdetectedrealtime.wav")
                detectedbadbloodydesire.Show()
            Else
                Me.Labellastreal.Text = e.FullPath
                Me.realtimelistbox.Items.Add(Me.Labellastreal.Text)
            End If
        Catch ex As Global.System.Exception
        End Try
    End Sub

    Private Sub FileSystemWatcher1_Renamed_1(sender As Object, e As Global.System.IO.RenamedEventArgs) Handles FileSystemWatcher1.Renamed
        Try
            Me.OpenFileDialog2.FileName = ""
            Dim detectedbadbloodydesire As Detect
            detectedbadbloodydesire = New Detect
            Dim textBox As Global.System.Windows.Forms.TextBox = New Global.System.Windows.Forms.TextBox()
            textBox.Text = Global.AlinKahnsAntiNSFW.My.MyProject.Computer.FileSystem.ReadAllText(Global.System.Windows.Forms.Application.StartupPath + "\antinsfwdatabase.db").ToString()
            Dim md5CryptoServiceProvider As Global.System.Security.Cryptography.MD5CryptoServiceProvider = New Global.System.Security.Cryptography.MD5CryptoServiceProvider()
            Dim fileStream As Global.System.IO.FileStream = New Global.System.IO.FileStream(e.FullPath, Global.System.IO.FileMode.Open, Global.System.IO.FileAccess.Read, Global.System.IO.FileShare.Read, 8192)
            fileStream.Close()
            fileStream = New Global.System.IO.FileStream(e.FullPath, Global.System.IO.FileMode.Open, Global.System.IO.FileAccess.Read, Global.System.IO.FileShare.Read, 8192)
            md5CryptoServiceProvider.ComputeHash(fileStream)
            Dim hash As Byte() = md5CryptoServiceProvider.Hash
            Dim stringBuilder As Global.System.Text.StringBuilder = New Global.System.Text.StringBuilder()
            For Each b As Byte In hash
                stringBuilder.Append(String.Format("{0:X2}", b))
            Next
            fileStream.Close()
            Dim flag As Boolean = textBox.Text.Contains(stringBuilder.ToString())
            If flag Then
                Me.Labellastreal.Text = e.FullPath
                Me.realtimelistbox.Items.Add(Me.Labellastreal.Text)
                Me.OpenFileDialog2.FileName = e.FullPath
                My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\nsfwitemthreatdetectedrealtime.wav")
                detectedbadbloodydesire.Show()
            Else
                Me.Labellastreal.Text = e.FullPath
                Me.realtimelistbox.Items.Add(Me.Labellastreal.Text)
            End If
        Catch ex As Global.System.Exception
        End Try
    End Sub

    Private Sub Processor_Text(sender As Object, e As EventArgs) Handles Processor.TextChanged
        Dim text As String = Global.Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Global.AlinKahnsAntiNSFW.My.MyProject.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\SYSTEM\CentralProcessor\0", "ProcessorNameString", Nothing))
        Me.Processor.Text = text
    End Sub

    Private Sub Label22_Text(sender As Object, e As EventArgs) Handles Label22.TextChanged
        Label22.Text = Global.AlinKahnsAntiNSFW.My.MyProject.Computer.Info.OSFullName
    End Sub

    Private Sub Label24_Text(sender As Object, e As EventArgs) Handles Label24.TextChanged
        Me.Label24.Text = (Global.AlinKahnsAntiNSFW.My.MyProject.Computer.Info.TotalPhysicalMemory / 1024.0 / 1024.0 / 1024.0).ToString("##.# GB")
    End Sub

    Private Sub Label27_Text(sender As Object, e As EventArgs) Handles Label27.TextChanged
        Dim enableRaisingEvents As Boolean = Me.FileSystemWatcher1.EnableRaisingEvents
        If enableRaisingEvents Then
            Me.Label27.Text = "Active"
        Else
            Me.Label27.Text = "Inactive. Please check."
        End If
    End Sub

    Private Sub Label31_Text(sender As Object, e As EventArgs) Handles Label31.TextChanged
        Me.Label31.Text = Global.Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Global.System.IO.File.GetLastWriteTime("antinsfwdatabase.db"))
    End Sub

    Overridable Property httpclient As Global.System.Net.WebClient

    Private Sub Button18_Click_1(sender As Object, e As EventArgs) Handles update1.Click
        Dim flag As Boolean = Global.System.DateTime.Compare(Global.Microsoft.VisualBasic.CompilerServices.Conversions.ToDate(Global.System.IO.File.GetLastWriteTimeUtc(Global.System.AppDomain.CurrentDomain.BaseDirectory + "antinsfwdatabase.db").ToShortDateString()), Global.System.DateTime.Today) = 0
        If flag Then
            Global.Microsoft.VisualBasic.Interaction.MsgBox("You already have the latest anti-NSFW definitions. Update is not required at this time, please try to update later or in a few days.", Global.Microsoft.VisualBasic.MsgBoxStyle.Information, Nothing)
            Me.update1.Enabled = True
        Else
            Dim isAvailable As Boolean = My.Computer.Network.IsAvailable
            If isAvailable Then
                Try
                    ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
                    My.Computer.Network.Ping("alinresources.github.io")
                    Dim _WebClient As New System.Net.WebClient()
                    AddHandler _WebClient.DownloadFileCompleted, AddressOf _DownloadFileCompleted
                    AddHandler _WebClient.DownloadProgressChanged, AddressOf _DownloadProgressChanged
                    _WebClient.DownloadFileAsync(New Uri("https://alinresources.github.io/Alin-Kahn-s-Anti-NSFW/antinsfwdatabase.db"), "antinsfwdatabase.db")
                    Me.Label31.Text = "Update in progress"
                    Me.update1.Enabled = False
                    Me.Label32.Text = "Updating..."
                Catch ex As Global.System.Exception
                    Global.Microsoft.VisualBasic.Interaction.MsgBox("Update failed, unable to connect to server. Please check your Internet connection and try again later.", Global.Microsoft.VisualBasic.MsgBoxStyle.Critical, Nothing)
                    Me.Label32.Text = "Connection to server failed."
                    Me.update1.Enabled = True
                    Me.Label31.Text = Global.Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Global.System.IO.File.GetLastWriteTime("antinsfwdatabase.db"))
                End Try
            Else
                Global.Microsoft.VisualBasic.Interaction.MsgBox("Update failed, unable to connect to server. Please check your Internet connection and try again later.", Global.Microsoft.VisualBasic.MsgBoxStyle.Critical, Nothing)
                Me.Label32.Text = "Connection to server failed."
                Me.update1.Enabled = True
                Me.Label31.Text = Global.Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Global.System.IO.File.GetLastWriteTime("antinsfwdatabase.db"))
            End If
        End If
    End Sub
    Private Sub _DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)
        Me.Label32.Text = "Updating..."
        ProgressBar2.Value = e.ProgressPercentage
    End Sub

    Private Sub _DownloadFileCompleted()
        Me.Label32.Text = "Updated, now idle..."
        update1.Enabled = Enabled
        My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\databaseupdated.wav")
        NotifyIcon1.Visible = True
        NotifyIcon1.Icon = SystemIcons.Asterisk
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipTitle = "Alin Kahn's AntiNSFW : Database Upgraded"
        NotifyIcon1.BalloonTipText = "The Anti-NSFW database has been updated to the latest version."
        NotifyIcon1.ShowBalloonTip(50000)
        MessageBox.Show("Download completed.The Anti-NSFW database definitions has been updated successfully.", "Alin Kahn's Anti-NSFW Database Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        MessageBox.Show("Close all browsers and leave all VC's if you are in a chat with somebody on discord , save all of your online work / finish your uploads on youtube and other platform before to proceed to desexualize the pc.Once you done your stuff , press Ok to continue", "Desexualizer option", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        If MessageBox.Show("Launch the Desexualize console window to start with the process?Close all browers and then continue.Start now?", "Alin Kahn's Anti-NSFW Desexualizer Process", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            Dim fileName As String = "desexualizer.cmd"
            Dim appDir As String = System.IO.Path.GetDirectoryName( _
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

            Process.Start(appDir & "\scripts\" & fileName)
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Process.Start("cmd.exe")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        MessageBox.Show("This feature will be available in the next version.", "Custom Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button18_Click_2(sender As Object, e As EventArgs) Handles Button18.Click
        Form3.Show()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If MessageBox.Show("Do you want to clean the history from all browsers?This will kill the brower processes and killing the history , even if you have cheat game pages or other gross items the whole entire history needs to be cleared , do you want to continue with cleaning process? DISCLAIMER : Save all of your online works , leave the online meeting/VC and quit all browsers , browser processes may be killed during the process.", "Clean the History?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            Dim fileName As String = "clearhistory.cmd"
            Dim appDir As String = System.IO.Path.GetDirectoryName( _
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

            Process.Start(appDir & "\scripts\" & fileName)
            MessageBox.Show("The history from all browers has been cleanned succefully.", "History Cleaned", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://alinresources.github.io/Alin-Kahn-s-Anti-NSFW/")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("https://alinresources.github.io/Alin-Kahn-s-Anti-NSFW/faq.html")
    End Sub

    Private Sub Button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button7.Click
        Dim fileName As String = "clearrecentitems.cmd"
        Dim appDir As String = System.IO.Path.GetDirectoryName( _
        System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

        Process.Start(appDir & "\scripts\" & fileName)
        MessageBox.Show("Recent Items Cleaned Succefully.", "Clear Recent Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("https://github.com/AlinResources/Alin-Kahn-s-Anti-NSFW/issues")
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click

    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Process.Start("RUNDLL32.EXE", "user32.dll,UpdatePerUserSystemParameters")
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        If MessageBox.Show("Do you want to add ""Permanently delete"" to the context menu?", "Add Permanently delete to the context menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Dim fileName As String = "PermanentlyDeleteToTheContextMenu.exe"
            Dim appDir As String = System.IO.Path.GetDirectoryName( _
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

            Process.Start(appDir & "\scripts\" & fileName)
            MessageBox.Show("""Permanently delete"" has been added to the context menu succefully. How to use , Go to a file , click right click and then select Permanently Delete.", "Permanently delete added to the context menu", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        If MessageBox.Show("Do you want to remove the Permanently Delete Item from the context menu?", "Remove Permanently delete from the context menu", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            Dim fileName As String = "RemovePermanentlyDeleteToTheContextMenu.exe"
            Dim appDir As String = System.IO.Path.GetDirectoryName( _
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

            Process.Start(appDir & "\scripts\" & fileName)
            MessageBox.Show("""Permanently delete"" has been removed from the context menu.", "Permanently delete removed from the context menu", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        If MessageBox.Show("Do you want to Restart Explorer?", "Restart Explorer", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            Shell("cmd /c taskkill /f /im explorer.exe & explorer.exe")
        End If
    End Sub

    Private Sub ScanLocalDriveRemovableDriveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanLocalDriveRemovableDriveToolStripMenuItem.Click
        SelectDrive.Show()
    End Sub

    Private Sub DesexualizerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesexualizerToolStripMenuItem.Click
        MessageBox.Show("Close all browsers and leave all VC's if you are in a chat with somebody on discord , save all of your online work / finish your uploads on youtube and other platform before to proceed to desexualize the pc.Once you done your stuff , press Ok to continue", "Desexualizer option", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        If MessageBox.Show("Launch the Desexualize console window to start with the process?Close all browers and then continue.Start now?", "Alin Kahn's Anti-NSFW Desexualizer Process", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            Dim fileName As String = "desexualizer.cmd"
            Dim appDir As String = System.IO.Path.GetDirectoryName( _
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

            Process.Start(appDir & "\scripts\" & fileName)
        End If
    End Sub

    Private Sub BlockANSFWSiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlockANSFWSiteToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub FileEliminatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileEliminatorToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub CommandPromptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommandPromptToolStripMenuItem.Click
        Process.Start("cmd.exe")
    End Sub

    Private Sub TaskManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskManagerToolStripMenuItem.Click
        Process.Start("taskmgr.exe")
    End Sub

    Private Sub ScanFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanFolderToolStripMenuItem.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            ListBox1.Items.Clear()
            Button4.Visible = True
            SavelogButton.Visible = False
            Button3.Enabled = True
        Else
            Exit Sub
        End If

        On Error Resume Next

        For Each strFile As String In System.IO.Directory.GetFiles(FolderBrowserDialog1.SelectedPath, "*.*", IO.SearchOption.AllDirectories)
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "sounds\scanstarted.wav")
            ListBox1.Items.Add(strFile)
        Next
        Timer1.Start()
        TabControl1.SelectTab(1)
        Me.Visible = False
        NotifyIcon1.Visible = True
        NotifyIcon1.Icon = NotifyIcon1.Icon
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipTitle = "A scanner has been started"
        NotifyIcon1.BalloonTipText = "Anti-NSFW Scanner has been started , this will take a while then once the scanner has been finished , we will notify you soon."
        NotifyIcon1.ShowBalloonTip(50000)
    End Sub

    Private Sub EmptyTheRecycleBinToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmptyTheRecycleBinToolStripMenuItem.Click
        EmptyRecycleBin()
        MessageBox.Show("Done cleaning the recycle bin.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub DestroyTheWallpaperToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestroyTheWallpaperToolStripMenuItem.Click
        If MessageBox.Show("ATTENTION!, Forcing changing wallpaper may cause unstable results or may result in other problems." & ControlChars.CrLf & "In some cases restart explorer or logoff to apply the wallpaper changes but anyways DO YOU WANT TO RESET THE WALLPAPER BY FORCE?", "Alin Kahn Anti-NSFW Kill Wallpaper : Do you want to destroy the wallpaper?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            Dim fileName As String = "killwallpaper.cmd"
            Dim appDir As String = System.IO.Path.GetDirectoryName( _
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

            Process.Start(appDir & "\scripts\" & fileName)
            MessageBox.Show("The NSFW Wallpaper has been killed succefully." & ControlChars.CrLf & "DISCLAIMER : In case of gross wallpaper kill the wallpaper which it kill the wallpaper and set to a random solid color" & ControlChars.CrLf & "ATTENTION !!! : Sometimes it didn't change the wallpaper on the first click , try again until the wallpaper is a solid color / wallpaper killed.", "Kill NSFW Wallpaper waifu", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ClearRecentItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearRecentItemsToolStripMenuItem.Click
        Dim fileName As String = "clearrecentitems.cmd"
        Dim appDir As String = System.IO.Path.GetDirectoryName( _
        System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

        Process.Start(appDir & "\scripts\" & fileName)
        MessageBox.Show("Recent Items Cleaned Succefully.", "Clear Recent Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        TabControl1.SelectTab(3)
    End Sub

    Private Sub About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles About.Click
        TabControl1.SelectTab(4)
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        TabControl1.SelectTab(6)
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Me.Close()
    End Sub

    Private Sub UpdateCenterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateCenterToolStripMenuItem.Click
        TabControl1.SelectTab(5)
    End Sub

    Private Sub UpdateAntiNSFWDatabaseNowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateAntiNSFWDatabaseNowToolStripMenuItem.Click
        If MessageBox.Show("Do you want to update the Alin Kahn's Anti-NSFW database to the latest version? NOTE : Do not update while scanning for questionable threats,finish the scanner and then update", "Update the AntiNSFW Database?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Dim flag As Boolean = Global.System.DateTime.Compare(Global.Microsoft.VisualBasic.CompilerServices.Conversions.ToDate(Global.System.IO.File.GetLastWriteTimeUtc(Global.System.AppDomain.CurrentDomain.BaseDirectory + "antinsfwdatabase.db").ToShortDateString()), Global.System.DateTime.Today) = 0
            If flag Then
                Global.Microsoft.VisualBasic.Interaction.MsgBox("You already have the latest anti-NSFW definitions. Update is not required at this time, please try to update later or in a few days.", Global.Microsoft.VisualBasic.MsgBoxStyle.Information, Nothing)
                Me.update1.Enabled = True
            Else
                Dim isAvailable As Boolean = My.Computer.Network.IsAvailable
                If isAvailable Then
                    Try
                        ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
                        My.Computer.Network.Ping("alinresources.github.io")
                        Dim _WebClient As New System.Net.WebClient()
                        AddHandler _WebClient.DownloadFileCompleted, AddressOf _DownloadFileCompleted
                        AddHandler _WebClient.DownloadProgressChanged, AddressOf _DownloadProgressChanged
                        _WebClient.DownloadFileAsync(New Uri("https://raw.githubusercontent.com/AlinResources/Alin-Kahn-s-Anti-NSFW/refs/heads/main/antinsfwdatabase.db"), "antinsfwdatabase.db")
                        Me.Label31.Text = "Update in progress"
                        Me.update1.Enabled = False
                        Me.Label32.Text = "Updating..."
                    Catch ex As Global.System.Exception
                        Global.Microsoft.VisualBasic.Interaction.MsgBox("Update failed, unable to connect to server. Please check your Internet connection and try again later.", Global.Microsoft.VisualBasic.MsgBoxStyle.Critical, Nothing)
                        Me.Label32.Text = "Connection to server failed."
                        Me.update1.Enabled = True
                        Me.Label31.Text = Global.Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Global.System.IO.File.GetLastWriteTime("antinsfwdatabase.db"))
                    End Try
                Else
                    Global.Microsoft.VisualBasic.Interaction.MsgBox("Update failed, unable to connect to server. Please check your Internet connection and try again later.", Global.Microsoft.VisualBasic.MsgBoxStyle.Critical, Nothing)
                    Me.Label32.Text = "Connection to server failed."
                    Me.update1.Enabled = True
                    Me.Label31.Text = Global.Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Global.System.IO.File.GetLastWriteTime("antinsfwdatabase.db"))
                End If
            End If
        End If
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        MessageBox.Show("This feature is work in progress and will be available in the next version.", "DNS / Safe Internet Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        MessageBox.Show("This feature will be available in the next version.", "Computer Manager", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Process.Start("https://alinresources.github.io/Alin-Kahn-s-Anti-NSFW/antinsfwdatabase.db")
    End Sub
End Class
