﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("MRS.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;br&gt;&lt;br&gt; &lt;font size=2;font color=red&gt;&lt;b&gt;&lt;U&gt;Confidential:&lt;/b&gt;&lt;/U&gt;&lt;/font&gt;&lt;br&gt; &lt;font size=2&gt;The content of this email is confidential and intended for the recipient specified in message only. It is strictly forbidden to share any part of this message with any third party, without a written consent of &lt;/font&gt;&lt;font size=2; font color=green&gt;Egypt Post&lt;/font&gt;&lt;font size=2&gt;. If you received this message by mistake, please reply to this message and follow with its deletion, so that we can ensure such a mistake does n [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property MsgConfed() As String
            Get
                Return ResourceManager.GetString("MsgConfed", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;br&gt;&lt;br&gt; &lt;font size=2&gt; Best Regards&lt;/font&gt;
        ''' &lt;br&gt; &lt;font size=2&gt; MRS Team&lt;/font&gt;
        '''&lt;br&gt; &lt;br&gt;&lt;font size=2&gt; This is an auto mail Service, Please don&apos;t reply.&lt;/font&gt;
        ''' &lt;br&gt; &lt;font size=2&gt; For more information please contact us at&lt;/font&gt;
        ''' &lt;br&gt; &lt;font size=2; font color=blue&gt;&lt;U&gt; http://10.10.26.14:8000/contactus.aspx &lt;/U&gt;&lt;/font&gt;
        ''' &lt;br&gt; &lt;font size=2&gt; ---------------------------------------------------------------------------&lt;/font&gt;&lt;br&gt;&lt;br&gt;&lt;font size=2; font color=red&gt;&lt;b&gt;&lt;U&gt;Notice&lt;/U&gt;&lt;/b&gt;&lt;/font&gt;&lt;font size=2&gt;: Any ema [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property MsgSign() As String
            Get
                Return ResourceManager.GetString("MsgSign", resourceCulture)
            End Get
        End Property
    End Module
End Namespace