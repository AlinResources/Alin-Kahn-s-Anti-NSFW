Imports System
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CompilerServices

Namespace DeviroAV.My
	' Token: 0x02000004 RID: 4
	<HideModuleName()>
	<GeneratedCode("MyTemplate", "11.0.0.0")>
	Friend NotInheritable Module MyProject
		' Token: 0x17000001 RID: 1
		' (get) Token: 0x06000007 RID: 7 RVA: 0x000021E0 File Offset: 0x000003E0
		<HelpKeyword("My.Computer")>
		Friend ReadOnly Property Computer As MyComputer
			<DebuggerHidden()>
			Get
				Return MyProject.m_ComputerObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x17000002 RID: 2
		' (get) Token: 0x06000008 RID: 8 RVA: 0x000021FC File Offset: 0x000003FC
		<HelpKeyword("My.Application")>
		Friend ReadOnly Property Application As MyApplication
			<DebuggerHidden()>
			Get
				Return MyProject.m_AppObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x17000003 RID: 3
		' (get) Token: 0x06000009 RID: 9 RVA: 0x00002218 File Offset: 0x00000418
		<HelpKeyword("My.User")>
		Friend ReadOnly Property User As User
			<DebuggerHidden()>
			Get
				Return MyProject.m_UserObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x17000004 RID: 4
		' (get) Token: 0x0600000A RID: 10 RVA: 0x00002234 File Offset: 0x00000434
		<HelpKeyword("My.Forms")>
		Friend ReadOnly Property Forms As MyProject.MyForms
			<DebuggerHidden()>
			Get
				Return MyProject.m_MyFormsObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x17000005 RID: 5
		' (get) Token: 0x0600000B RID: 11 RVA: 0x00002250 File Offset: 0x00000450
		<HelpKeyword("My.WebServices")>
		Friend ReadOnly Property WebServices As MyProject.MyWebServices
			<DebuggerHidden()>
			Get
				Return MyProject.m_MyWebServicesObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x04000001 RID: 1
		Private m_ComputerObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyComputer) = New MyProject.ThreadSafeObjectProvider(Of MyComputer)()

		' Token: 0x04000002 RID: 2
		Private m_AppObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyApplication) = New MyProject.ThreadSafeObjectProvider(Of MyApplication)()

		' Token: 0x04000003 RID: 3
		Private m_UserObjectProvider As MyProject.ThreadSafeObjectProvider(Of User) = New MyProject.ThreadSafeObjectProvider(Of User)()

		' Token: 0x04000004 RID: 4
		Private m_MyFormsObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyProject.MyForms) = New MyProject.ThreadSafeObjectProvider(Of MyProject.MyForms)()

		' Token: 0x04000005 RID: 5
		Private m_MyWebServicesObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyProject.MyWebServices) = New MyProject.ThreadSafeObjectProvider(Of MyProject.MyWebServices)()

		' Token: 0x02000010 RID: 16
		<EditorBrowsable(EditorBrowsableState.Never)>
		<MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")>
		Friend NotInheritable Class MyForms
			' Token: 0x06000333 RID: 819 RVA: 0x00019784 File Offset: 0x00017984
			<DebuggerHidden()>
			Private Shared Function Create__Instance__(Of T As{Form, New})(Instance As T) As T
				Dim flag As Boolean = Instance Is Nothing OrElse Instance.IsDisposed
				If flag Then
					Dim flag2 As Boolean = MyProject.MyForms.m_FormBeingCreated IsNot Nothing
					If flag2 Then
						Dim flag3 As Boolean = MyProject.MyForms.m_FormBeingCreated.ContainsKey(GetType(T))
						If flag3 Then
							Throw New InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", New String(-1) {}))
						End If
					Else
						MyProject.MyForms.m_FormBeingCreated = New Hashtable()
					End If
					MyProject.MyForms.m_FormBeingCreated.Add(GetType(T), Nothing)
					Try
						Return Activator.CreateInstance(Of T)()
					Catch ex As TargetInvocationException When ex.InnerException IsNot Nothing
						Dim resourceString As String = Utils.GetResourceString("WinForms_SeeInnerException", New String() { ex.InnerException.Message })
						Throw New InvalidOperationException(resourceString, ex.InnerException)
					Finally
						MyProject.MyForms.m_FormBeingCreated.Remove(GetType(T))
					End Try
				End If
				Return Instance
			End Function

			' Token: 0x06000334 RID: 820 RVA: 0x000198AC File Offset: 0x00017AAC
			<DebuggerHidden()>
			Private Sub Dispose__Instance__(Of T As Form)(ByRef instance As T)
				instance.Dispose()
				instance = Nothing
			End Sub

			' Token: 0x06000335 RID: 821 RVA: 0x000198C3 File Offset: 0x00017AC3
			<DebuggerHidden()>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Sub New()
			End Sub

			' Token: 0x06000336 RID: 822 RVA: 0x000198D0 File Offset: 0x00017AD0
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function Equals(o As Object) As Boolean
				Return MyBase.Equals(RuntimeHelpers.GetObjectValue(o))
			End Function

			' Token: 0x06000337 RID: 823 RVA: 0x000198F0 File Offset: 0x00017AF0
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function GetHashCode() As Integer
				Return MyBase.GetHashCode()
			End Function

			' Token: 0x06000338 RID: 824 RVA: 0x00019908 File Offset: 0x00017B08
			<EditorBrowsable(EditorBrowsableState.Never)>
			Friend Function [GetType]() As Type
				Return GetType(MyProject.MyForms)
			End Function

			' Token: 0x06000339 RID: 825 RVA: 0x00019924 File Offset: 0x00017B24
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function ToString() As String
				Return MyBase.ToString()
			End Function

			' Token: 0x17000130 RID: 304
			' (get) Token: 0x0600033A RID: 826 RVA: 0x0001993C File Offset: 0x00017B3C
			' (set) Token: 0x06000341 RID: 833 RVA: 0x000199F9 File Offset: 0x00017BF9
			Public Property Form1 As Form1
				<DebuggerHidden()>
				Get
					Me.m_Form1 = MyProject.MyForms.Create__Instance__(Of Form1)(Me.m_Form1)
					Return Me.m_Form1
				End Get
				<DebuggerHidden()>
				Set(value As Form1)
					If value IsNot Me.m_Form1 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Form1)(Me.m_Form1)
					End If
				End Set
			End Property

			' Token: 0x17000131 RID: 305
			' (get) Token: 0x0600033B RID: 827 RVA: 0x00019957 File Offset: 0x00017B57
			' (set) Token: 0x06000342 RID: 834 RVA: 0x00019A25 File Offset: 0x00017C25
			Public Property Form2 As Form2
				<DebuggerHidden()>
				Get
					Me.m_Form2 = MyProject.MyForms.Create__Instance__(Of Form2)(Me.m_Form2)
					Return Me.m_Form2
				End Get
				<DebuggerHidden()>
				Set(value As Form2)
					If value IsNot Me.m_Form2 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Form2)(Me.m_Form2)
					End If
				End Set
			End Property

			' Token: 0x17000132 RID: 306
			' (get) Token: 0x0600033C RID: 828 RVA: 0x00019972 File Offset: 0x00017B72
			' (set) Token: 0x06000343 RID: 835 RVA: 0x00019A51 File Offset: 0x00017C51
			Public Property Form3 As Form3
				<DebuggerHidden()>
				Get
					Me.m_Form3 = MyProject.MyForms.Create__Instance__(Of Form3)(Me.m_Form3)
					Return Me.m_Form3
				End Get
				<DebuggerHidden()>
				Set(value As Form3)
					If value IsNot Me.m_Form3 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Form3)(Me.m_Form3)
					End If
				End Set
			End Property

			' Token: 0x17000133 RID: 307
			' (get) Token: 0x0600033D RID: 829 RVA: 0x0001998D File Offset: 0x00017B8D
			' (set) Token: 0x06000344 RID: 836 RVA: 0x00019A7D File Offset: 0x00017C7D
			Public Property Form5 As Form5
				<DebuggerHidden()>
				Get
					Me.m_Form5 = MyProject.MyForms.Create__Instance__(Of Form5)(Me.m_Form5)
					Return Me.m_Form5
				End Get
				<DebuggerHidden()>
				Set(value As Form5)
					If value IsNot Me.m_Form5 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Form5)(Me.m_Form5)
					End If
				End Set
			End Property

			' Token: 0x17000134 RID: 308
			' (get) Token: 0x0600033E RID: 830 RVA: 0x000199A8 File Offset: 0x00017BA8
			' (set) Token: 0x06000345 RID: 837 RVA: 0x00019AA9 File Offset: 0x00017CA9
			Public Property Form6 As Form6
				<DebuggerHidden()>
				Get
					Me.m_Form6 = MyProject.MyForms.Create__Instance__(Of Form6)(Me.m_Form6)
					Return Me.m_Form6
				End Get
				<DebuggerHidden()>
				Set(value As Form6)
					If value IsNot Me.m_Form6 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Form6)(Me.m_Form6)
					End If
				End Set
			End Property

			' Token: 0x17000135 RID: 309
			' (get) Token: 0x0600033F RID: 831 RVA: 0x000199C3 File Offset: 0x00017BC3
			' (set) Token: 0x06000346 RID: 838 RVA: 0x00019AD5 File Offset: 0x00017CD5
			Public Property Form8 As Form8
				<DebuggerHidden()>
				Get
					Me.m_Form8 = MyProject.MyForms.Create__Instance__(Of Form8)(Me.m_Form8)
					Return Me.m_Form8
				End Get
				<DebuggerHidden()>
				Set(value As Form8)
					If value IsNot Me.m_Form8 Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Form8)(Me.m_Form8)
					End If
				End Set
			End Property

			' Token: 0x17000136 RID: 310
			' (get) Token: 0x06000340 RID: 832 RVA: 0x000199DE File Offset: 0x00017BDE
			' (set) Token: 0x06000347 RID: 839 RVA: 0x00019B01 File Offset: 0x00017D01
			Public Property frmAlert As frmAlert
				<DebuggerHidden()>
				Get
					Me.m_frmAlert = MyProject.MyForms.Create__Instance__(Of frmAlert)(Me.m_frmAlert)
					Return Me.m_frmAlert
				End Get
				<DebuggerHidden()>
				Set(value As frmAlert)
					If value IsNot Me.m_frmAlert Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmAlert)(Me.m_frmAlert)
					End If
				End Set
			End Property

			' Token: 0x0400015A RID: 346
			<ThreadStatic()>
			Private Shared m_FormBeingCreated As Hashtable

			' Token: 0x0400015B RID: 347
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Form1 As Form1

			' Token: 0x0400015C RID: 348
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Form2 As Form2

			' Token: 0x0400015D RID: 349
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Form3 As Form3

			' Token: 0x0400015E RID: 350
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Form5 As Form5

			' Token: 0x0400015F RID: 351
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Form6 As Form6

			' Token: 0x04000160 RID: 352
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Form8 As Form8

			' Token: 0x04000161 RID: 353
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmAlert As frmAlert
		End Class

		' Token: 0x02000011 RID: 17
		<EditorBrowsable(EditorBrowsableState.Never)>
		<MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")>
		Friend NotInheritable Class MyWebServices
			' Token: 0x06000348 RID: 840 RVA: 0x00019B30 File Offset: 0x00017D30
			<EditorBrowsable(EditorBrowsableState.Never)>
			<DebuggerHidden()>
			Public Overrides Function Equals(o As Object) As Boolean
				Return MyBase.Equals(RuntimeHelpers.GetObjectValue(o))
			End Function

			' Token: 0x06000349 RID: 841 RVA: 0x00019B50 File Offset: 0x00017D50
			<EditorBrowsable(EditorBrowsableState.Never)>
			<DebuggerHidden()>
			Public Overrides Function GetHashCode() As Integer
				Return MyBase.GetHashCode()
			End Function

			' Token: 0x0600034A RID: 842 RVA: 0x00019B68 File Offset: 0x00017D68
			<EditorBrowsable(EditorBrowsableState.Never)>
			<DebuggerHidden()>
			Friend Function [GetType]() As Type
				Return GetType(MyProject.MyWebServices)
			End Function

			' Token: 0x0600034B RID: 843 RVA: 0x00019B84 File Offset: 0x00017D84
			<EditorBrowsable(EditorBrowsableState.Never)>
			<DebuggerHidden()>
			Public Overrides Function ToString() As String
				Return MyBase.ToString()
			End Function

			' Token: 0x0600034C RID: 844 RVA: 0x00019B9C File Offset: 0x00017D9C
			<DebuggerHidden()>
			Private Shared Function Create__Instance__(Of T As New)(instance As T) As T
				Dim flag As Boolean = instance Is Nothing
				Dim result As T
				If flag Then
					result = Activator.CreateInstance(Of T)()
				Else
					result = instance
				End If
				Return result
			End Function

			' Token: 0x0600034D RID: 845 RVA: 0x00019BC5 File Offset: 0x00017DC5
			<DebuggerHidden()>
			Private Sub Dispose__Instance__(Of T)(ByRef instance As T)
				instance = Nothing
			End Sub

			' Token: 0x0600034E RID: 846 RVA: 0x00019BCF File Offset: 0x00017DCF
			<DebuggerHidden()>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Sub New()
			End Sub
		End Class

		' Token: 0x02000012 RID: 18
		<EditorBrowsable(EditorBrowsableState.Never)>
		<ComVisible(False)>
		Friend NotInheritable Class ThreadSafeObjectProvider(Of T As New)
			' Token: 0x17000137 RID: 311
			' (get) Token: 0x0600034F RID: 847 RVA: 0x00019BDC File Offset: 0x00017DDC
			Friend ReadOnly Property GetInstance As T
				<DebuggerHidden()>
				Get
					Dim flag As Boolean = MyProject.ThreadSafeObjectProvider(Of T).m_ThreadStaticValue Is Nothing
					If flag Then
						MyProject.ThreadSafeObjectProvider(Of T).m_ThreadStaticValue = Activator.CreateInstance(Of T)()
					End If
					Return MyProject.ThreadSafeObjectProvider(Of T).m_ThreadStaticValue
				End Get
			End Property

			' Token: 0x06000350 RID: 848 RVA: 0x00019C0E File Offset: 0x00017E0E
			<DebuggerHidden()>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Sub New()
			End Sub

			' Token: 0x04000162 RID: 354
			<CompilerGenerated()>
			<ThreadStatic()>
			Private Shared m_ThreadStaticValue As T
		End Class
	End Module
End Namespace
