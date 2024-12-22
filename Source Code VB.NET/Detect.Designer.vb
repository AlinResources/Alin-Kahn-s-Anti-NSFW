<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Detect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Detect))
        Me.OpenFileDialog3 = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Labellastreal = New System.Windows.Forms.Label()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog3
        '
        Me.OpenFileDialog3.FileName = "OpenFileDialog3"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AlinKahnsAntiNSFW.My.Resources.Resources.BackgroundImage3
        Me.PictureBox1.Location = New System.Drawing.Point(0, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(569, 430)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Brown
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(205, 246)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Firebrick
        Me.TextBox1.Location = New System.Drawing.Point(271, 243)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(240, 20)
        Me.TextBox1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(271, 317)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(219, 43)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Remove Detected Item"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(377, 363)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Label2"
        '
        'Labellastreal
        '
        Me.Labellastreal.AutoSize = True
        Me.Labellastreal.BackColor = System.Drawing.Color.DarkRed
        Me.Labellastreal.Location = New System.Drawing.Point(144, 135)
        Me.Labellastreal.Name = "Labellastreal"
        Me.Labellastreal.Size = New System.Drawing.Size(164, 13)
        Me.Labellastreal.TabIndex = 6
        Me.Labellastreal.Text = "Recommandation : Delete the file"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "Found some bad file."
        Me.NotifyIcon1.Visible = True
        '
        'Detect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 381)
        Me.Controls.Add(Me.Labellastreal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(539, 420)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(539, 420)
        Me.Name = "Detect"
        Me.Text = "Form2"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog3 As OpenFileDialog
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Labellastreal As Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
End Class
