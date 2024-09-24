Public Class Notepad
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        TextBox1.Clear()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
        Try
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
        Try
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        TextBox1.Undo()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        TextBox1.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        TextBox1.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        TextBox1.Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        TextBox1.SelectAll()
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        TextBox1.Clear()
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        Try
            Dim dlg As FontDialog = New FontDialog
            dlg.Font = TextBox1.Font
            If dlg.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                TextBox1.Font = dlg.Font
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Notepad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class