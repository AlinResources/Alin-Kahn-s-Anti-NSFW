Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace DeviroAV.My.Resources
	' Token: 0x02000005 RID: 5
	<GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")>
	<DebuggerNonUserCode()>
	<CompilerGenerated()>
	<HideModuleName()>
	Friend NotInheritable Module Resources
		' Token: 0x17000006 RID: 6
		' (get) Token: 0x0600000C RID: 12 RVA: 0x0000226C File Offset: 0x0000046C
		<EditorBrowsable(EditorBrowsableState.Advanced)>
		Friend ReadOnly Property ResourceManager As ResourceManager
			Get
				Dim flag As Boolean = Object.ReferenceEquals(Resources.resourceMan, Nothing)
				If flag Then
					Dim resourceManager As ResourceManager = New ResourceManager("DeviroAV.Resources", GetType(Resources).Assembly)
					Resources.resourceMan = resourceManager
				End If
				Return Resources.resourceMan
			End Get
		End Property

		' Token: 0x17000007 RID: 7
		' (get) Token: 0x0600000D RID: 13 RVA: 0x000022B4 File Offset: 0x000004B4
		' (set) Token: 0x0600000E RID: 14 RVA: 0x000022CB File Offset: 0x000004CB
		<EditorBrowsable(EditorBrowsableState.Advanced)>
		Friend Property Culture As CultureInfo
			Get
				Return Resources.resourceCulture
			End Get
			Set(value As CultureInfo)
				Resources.resourceCulture = value
			End Set
		End Property

		' Token: 0x17000008 RID: 8
		' (get) Token: 0x0600000F RID: 15 RVA: 0x000022D4 File Offset: 0x000004D4
		Friend ReadOnly Property Checkmark_28px As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Checkmark_28px", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x17000009 RID: 9
		' (get) Token: 0x06000010 RID: 16 RVA: 0x00002308 File Offset: 0x00000508
		Friend ReadOnly Property close As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("close", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700000A RID: 10
		' (get) Token: 0x06000011 RID: 17 RVA: 0x0000233C File Offset: 0x0000053C
		Friend ReadOnly Property Error_28px As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Error_28px", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700000B RID: 11
		' (get) Token: 0x06000012 RID: 18 RVA: 0x00002370 File Offset: 0x00000570
		Friend ReadOnly Property Info_28px As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Info_28px", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x1700000C RID: 12
		' (get) Token: 0x06000013 RID: 19 RVA: 0x000023A4 File Offset: 0x000005A4
		Friend ReadOnly Property Warning_28px As Bitmap
			Get
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Warning_28px", Resources.resourceCulture))
				Return CType(objectValue, Bitmap)
			End Get
		End Property

		' Token: 0x04000006 RID: 6
		Private resourceMan As ResourceManager

		' Token: 0x04000007 RID: 7
		Private resourceCulture As CultureInfo
	End Module
End Namespace
