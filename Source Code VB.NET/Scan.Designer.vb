<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Scan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblVirus = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblLast = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Currently scanning your computer for threats"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Viruses detected:"
        '
        'lblVirus
        '
        Me.lblVirus.AutoSize = True
        Me.lblVirus.Location = New System.Drawing.Point(95, 222)
        Me.lblVirus.Name = "lblVirus"
        Me.lblVirus.Size = New System.Drawing.Size(13, 13)
        Me.lblVirus.TabIndex = 6
        Me.lblVirus.Text = "0"
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(12, 25)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(523, 134)
        Me.ListBox2.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(448, 238)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 22)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Abort"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(450, 193)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(10, 4)
        Me.ListBox1.TabIndex = 12
        Me.ListBox1.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Enabled = False
        Me.ProgressBar1.Location = New System.Drawing.Point(11, 238)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(431, 23)
        Me.ProgressBar1.TabIndex = 13
        Me.ProgressBar1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 165)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(186, 22)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Delete All Viruses (recommended)"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(349, 165)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(186, 22)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Ignore (NOT RECOMMENDED!)"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 206)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Files Scanned:"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(83, 206)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(13, 13)
        Me.lblTotal.TabIndex = 5
        Me.lblTotal.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Last file scanned:"
        '
        'lblLast
        '
        Me.lblLast.AutoSize = True
        Me.lblLast.Location = New System.Drawing.Point(95, 190)
        Me.lblLast.Name = "lblLast"
        Me.lblLast.Size = New System.Drawing.Size(22, 13)
        Me.lblLast.TabIndex = 11
        Me.lblLast.Text = "C:\"
        '
        'Scan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 270)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.lblLast)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblVirus)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(566, 309)
        Me.MinimumSize = New System.Drawing.Size(566, 309)
        Me.Name = "Scan"
        Me.Text = "Scan"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblVirus As Label
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblLast As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
