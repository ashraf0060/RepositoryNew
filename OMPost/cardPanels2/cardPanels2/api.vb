Public Class api

    Public Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" _
    (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByRef lParam As IntPtr) As IntPtr

    Public Const HT_CAPTION As Integer = &H2
    Public Const WM_NCLBUTTONDOWN As Integer = &HA1

End Class
