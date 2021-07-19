Imports System.Globalization
Imports System.Text.RegularExpressions

Public NotInheritable Class IntUtly

    Public Shared Sub ValdtInt(ByVal e As KeyPressEventArgs) ' numeric only integer
        If Not Char.IsControl(e.KeyChar) AndAlso (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub
    ' ***************************************
    Public Shared Sub ValdtNumber(sender As Object, e As KeyPressEventArgs) ' numeric decmal
        Dim TempNum As TextBox = sender
        If (Not e.KeyChar = ChrW(Keys.Back) And ("0123456789.").IndexOf(e.KeyChar) = -1) Or (e.KeyChar = "." And TempNum.Text.ToCharArray().Count(Function(c) c = ".") > 0) Then
            e.Handled = True
        End If
    End Sub
    Public Shared Sub ValdtIntLetter(ByVal e As KeyPressEventArgs) ' numeric & Letters & White Space & Backspace
        If Not Char.IsControl(e.KeyChar) AndAlso (Char.IsDigit(e.KeyChar)) OrElse (Char.IsLetter(e.KeyChar)) OrElse (Char.IsWhiteSpace(e.KeyChar)) OrElse (e.KeyChar = ChrW(Keys.Back)) OrElse (e.KeyChar = ChrW(Keys.ShiftKey)) AndAlso (Char.IsLetter(e.KeyChar)) Then
        Else
            e.Handled = True
        End If
    End Sub
    Public Shared Sub ValdtLetter(ByVal e As KeyPressEventArgs) ' numeric & Letters & White Space & Backspace
        If Not Char.IsControl(e.KeyChar) AndAlso (Char.IsLetter(e.KeyChar)) OrElse (Char.IsWhiteSpace(e.KeyChar)) OrElse (e.KeyChar = ChrW(Keys.Back)) OrElse (e.KeyChar = ChrW(Keys.ShiftKey)) AndAlso (Char.IsLetter(e.KeyChar)) Then
        Else
            e.Handled = True
        End If
    End Sub
    Public Shared Sub ValdtNotNull(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim No As TextBox = sender
        If No.Text.Trim = "" Then
            MsgBox("This field Must be filled!")
            No.Focus()
        End If
    End Sub
    '********************************************************
    Public Shared Function IsValidEmail(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False
        Try ' Use IdnMapping class to convert Unicode domain names.
            ' Examines the domain part of the email and normalizes it.
            Dim DomainMapper =
                Function(match As Match) As String
                    Dim idn = New IdnMapping '                                      Use IdnMapping class to convert Unicode domain names.
                    Dim domainName As String = idn.GetAscii(match.Groups(2).Value) 'Pull out and process domain name (throws ArgumentException on invalid)
                    Return match.Groups(1).Value & domainName
                End Function
            email = Regex.Replace(email, "(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200)) 'Normalize the domain
        Catch e As RegexMatchTimeoutException
            Return False
        Catch e As ArgumentException
            Return False

        End Try
        Try
            Return Regex.IsMatch(email,
                                 "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                 "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                                 RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))
        Catch e As RegexMatchTimeoutException
            Return False
        End Try
    End Function
End Class