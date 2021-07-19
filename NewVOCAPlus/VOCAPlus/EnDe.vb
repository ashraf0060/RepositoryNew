Imports System.Security.Cryptography
Public NotInheritable Class Simple3Des
    Private TripleDes As New TripleDESCryptoServiceProvider
    Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
        Dim sha1 As New SHA256CryptoServiceProvider
        Dim keyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key) ' Hash the key.
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)
        ReDim Preserve hash(length - 1) ' Truncate or pad the hash.
        Return hash
    End Function
    Sub New(ByVal key As String)
        ' Initialize the crypto provider.
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub
    Public Function EncryptData(ByVal plaintext As String) As String
        Dim plaintextBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(plaintext) ' Convert the plaintext string to a byte array.
        Dim ms As New System.IO.MemoryStream        ' Create the stream.
        Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write) ' Create the encoder to write to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length) ' Use the crypto stream to write the byte array to the stream.
        encStream.FlushFinalBlock()
        Return Convert.ToBase64String(ms.ToArray)        ' Convert the encrypted stream to a printable string.
    End Function
    Public Function DecryptData(ByVal encryptedtext As String) As String
        Try
            Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext) ' Convert the encrypted text string to a byte array.
            Dim ms As New System.IO.MemoryStream ' Create the stream.
            Dim decStream As New CryptoStream(ms, TripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)  ' Create the decoder to write to the stream.
            decStream.Write(encryptedBytes, 0, encryptedBytes.Length) ' Use the crypto stream to write the byte array to the stream.
            decStream.FlushFinalBlock()
            Return System.Text.Encoding.Unicode.GetString(ms.ToArray) ' Convert the plaintext stream to a string.
        Catch
            Return Nothing
        End Try
    End Function

End Class

