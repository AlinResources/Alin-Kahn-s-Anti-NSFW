Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CompilerServices

Namespace DeviroAV.My
	' Token: 0x02000002 RID: 2
	<GeneratedCode("MyTemplate", "11.0.0.0")>
	<EditorBrowsable(EditorBrowsableState.Never)>
	Friend Class MyApplication
		Inherits WindowsFormsApplicationBase

		' Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		<STAThread()>
		<DebuggerHidden()>
		<EditorBrowsable(EditorBrowsableState.Advanced)>
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Friend Shared Sub Main(Args As String())
			Try
				Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering)
			Finally
			End Try
			MyProject.Application.Run(Args)
		End Sub

		' Token: 0x06000002 RID: 2 RVA: 0x0000208C File Offset: 0x0000028C
		Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
			Dim num As Integer
			Dim num3 As Integer
			Dim obj As Object
			Try
				Dim num2 As Integer
				Dim num4 As Integer
				While True
					IL_02:
					ProjectData.ClearProjectError()
					num = -2
					While True
						IL_0B:
						num2 = 2
						Interaction.MsgBox("Deviro Antivirus has encountered an error and will close immediately. Either the database or other required files are missing, or you are not the system administrator." & vbCrLf & "Please ensure that you are the system administrator and try again." & vbCrLf & " If the problem persists, reinstall the application or contact Support. ", MsgBoxStyle.OkOnly, Nothing)
						While True
							num2 = 3
							ProjectData.ClearProjectError()
							If num3 = 0 Then
								GoTo Block_2
							End If
							num4 = num3
							IL_3A:
							num3 = 0
							Select Case num4
								Case Else
									GoTo IL_55
								Case 1
									GoTo IL_02
								Case 2
									GoTo IL_0B
								Case 3
								Case 4
									GoTo IL_32
							End Select
						End While
					End While
				End While
				Block_2:
				Throw ProjectData.CreateProjectError(-2146828268)
				IL_32:
				GoTo IL_9C
				IL_55:
				GoTo IL_91
				IL_37:
				num4 = num3 + 1
				GoTo IL_3A
				IL_57:
				num3 = num2
				switch(ICSharpCode.Decompiler.ILAst.ILLabel[], If((num > -2), num, 1))
				IL_6F:
			Catch obj2 When endfilter(TypeOf obj Is Exception And num <> 0 And num3 = 0)
				Dim ex As Exception = CType(obj2, Exception)
				GoTo IL_57
			End Try
			IL_91:
			Throw ProjectData.CreateProjectError(-2146828237)
			IL_9C:
			If num3 <> 0 Then
				ProjectData.ClearProjectError()
			End If
		End Sub

		' Token: 0x06000003 RID: 3 RVA: 0x00002150 File Offset: 0x00000350
		<DebuggerStepThrough()>
		Public Sub New()
			MyBase.New(AuthenticationMode.Windows)
			AddHandler MyBase.UnhandledException, AddressOf Me.MyApplication_UnhandledException
			MyBase.IsSingleInstance = True
			MyBase.EnableVisualStyles = True
			MyBase.SaveMySettingsOnExit = True
			MyBase.ShutdownStyle = ShutdownMode.AfterMainFormCloses
		End Sub

		' Token: 0x06000004 RID: 4 RVA: 0x0000218E File Offset: 0x0000038E
		<DebuggerStepThrough()>
		Protected Overrides Sub OnCreateMainForm()
			MyBase.MainForm = MyProject.Forms.Form1
		End Sub
	End Class
End Namespace
