Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Configuration
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CompilerServices

Namespace AlinKahnsAntiNSFW.My
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase

        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()), MySettings)

        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                Return defaultInstance
            End Get
        End Property


        Public Property StartWindows As Boolean
            Get
                Return Global.Microsoft.VisualBasic.CompilerServices.Conversions.ToBoolean(Me("StartWindows"))
            End Get
            Set(value As Boolean)
                Me("StartWindows") = value
            End Set

        End Property

        Public Property AutoUpdate() As Boolean
            Get
                Return CType(Me("AutoUpdate"), Boolean)
            End Get
            Set
                Me("AutoUpdate") = Value
            End Set
        End Property

        Public Property RunMinimized() As Boolean
            Get
                Return CType(Me("RunMinimized"), Boolean)
            End Get
            Set
                Me("RunMinimized") = Value
            End Set
        End Property
    End Class
End Namespace