Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices

Public Class Scan
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
                '  Dim read As String = My.Computer.FileSystem.ReadAllText(System.IO.Path.GetPathRoot(Environment.SystemDirectory) & "aiotk.aiotk")
                Dim read As String = My.Computer.FileSystem.ReadAllText("main.db").ToString
                ProgressBar1.Increment(1)
                lblVirus.Text = Conversions.ToString(ListBox2.Items.Count)
                lblTotal.Text = Conversions.ToString(ProgressBar1.Value)
                scanbox.Text = read.ToString
                Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
                Dim f As FileStream = New FileStream(ListBox1.SelectedItem, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
                f = New FileStream(ListBox1.SelectedItem, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
                md5.ComputeHash(f)
                Dim hash As Byte() = md5.Hash
                Dim buff As StringBuilder = New StringBuilder
                Dim hashByte As Byte
                For Each hashByte In hash
                    buff.Append(String.Format("{0:X2}", hashByte))
                Next

                If scanbox.Text.Contains(buff.ToString) Then
                    ListBox2.Items.Add(ListBox1.SelectedItem)
                End If
            Catch ex As Exception
            End Try
        Else
            ListBox1.Enabled = True
            Timer1.Stop()
            If ListBox2.Items.Count > 0 Then
                MsgBox("Scanning has been completed. There was " & vbCrLf & ListBox2.Items.Count & " nsfw/questionable/explicit files and references detected. Please review the list and choose an action immediatly.", MsgBoxStyle.Critical)
                Button1.Visible = False
                Button2.Visible = True
                Button3.Visible = True
                Exit Sub
            End If
            MsgBox("Scanning has been completed." & vbCrLf & "No NSFW Files found.", MsgBoxStyle.Information)
            ProgressBar1.Value = 0
        End If
    End Sub

    Private Sub Scan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Are you sure you want to abort the scan?", MsgBoxStyle.YesNo, "Woah there, fella!") = MsgBoxResult.Yes Then
            Timer1.Stop()
            If ListBox2.Items.Count > 0 Then
                MsgBox("Scanning has been completed. There was" & vbCrLf & ListBox2.Items.Count & " viruses detected. Please review the list and choose an action.", MsgBoxStyle.Critical)
                Timer1.Stop()
                ProgressBar1.Value = 0
                Button1.Visible = False
                Button2.Visible = True
                Button3.Visible = True
            Else
                MsgBox("Scanning has been completed." & vbCrLf & "No viruses found.", MsgBoxStyle.Information)
                Timer1.Stop()
                ProgressBar1.Value = 0
                Button1.Visible = False
            End If
        Else
            
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Are you sure you want to ignore ALL items?", MsgBoxStyle.YesNo, "Woah there, fella!") = MsgBoxResult.Yes Then
            ProgressBar1.Value = 0
            Button1.Visible = False
            Button2.Visible = False
            Button3.Visible = False
        Else
            
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox2.Enabled = False
        ListBox2.SelectedIndex = -1
        If ListBox2.Items.Count = 0 Then
            MsgBox("Error", MsgBoxStyle.Critical)
            Exit Sub
        End If


        While ListBox2.Items.Count - 1 = ListBox1.SelectedIndex = False
            ListBox2.SelectedIndex += 1
            System.IO.File.Delete(ListBox2.SelectedItem)
            If ListBox2.Items.Count = ListBox2.SelectedIndex + 1 Then
                ListBox2.Items.Clear()
                ListBox2.Enabled = True
                MsgBox("All viruses have been removed. Your computer is now secured.", MsgBoxStyle.Information)
                ProgressBar1.Value = 0
                Button1.Visible = False
                Button2.Visible = False
                Button3.Visible = False
                Exit Sub
            End If
        End While
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

    End Sub
End Class
