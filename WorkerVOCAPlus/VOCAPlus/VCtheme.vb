Module VCtheme
    Public Sub NonEditableTxT(VCTxt As TextBox)
        VCTxt.BackColor = Color.FromArgb(192, 255, 192)
        VCTxt.ForeColor = Color.FromArgb(0, 0, 200)
        VCTxt.Cursor = Cursors.No
        VCTxt.ReadOnly = True
        VCTxt.TabStop = False
        VCTxt.BorderStyle = BorderStyle.FixedSingle
        VCTxt.Font = New Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Point)
        VCTxt.Tag += "Not Editable"
    End Sub
    Public Sub NonEditableLbl(VCTxt As Label)
        VCTxt.BackColor = Color.Transparent
        VCTxt.ForeColor = Color.FromArgb(0, 0, 250)
        VCTxt.BorderStyle = BorderStyle.None
        VCTxt.Font = New Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Point)
    End Sub
    Public Sub BtnCtrl(VCBtn As Button)
        VCBtn.BackColor = Color.Transparent
        VCBtn.BackgroundImageLayout = ImageLayout.Stretch
        If Split(VCBtn.Text, " ").Count > 1 Then
            VCBtn.Font = New Font("Times New Roman", VCBtn.Width / 14, FontStyle.Regular, GraphicsUnit.Point)
        Else
            VCBtn.Font = New Font("Times New Roman", VCBtn.Width / 8, FontStyle.Regular, GraphicsUnit.Point)
        End If

        VCBtn.TextAlign = ContentAlignment.MiddleCenter
        VCBtn.FlatStyle = FlatStyle.Flat
        VCBtn.FlatAppearance.BorderSize = 0
        VCBtn.BringToFront()
        'If BttonCtrl.Name.Contains("Submit") Then       'Format all button if contains Name
        'End If
    End Sub
    Public Sub BtnIncrease(VCBtn As Button)
        VCBtn.Width += 10
        VCBtn.Height += 10
        VCBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128)
        VCBtn.FlatAppearance.MouseOverBackColor = Color.Transparent
        VCBtn.Location = New Point(VCBtn.Location.X - 5, VCBtn.Location.Y - 5)
        VCBtn.Font = New Font(VCBtn.Font.Name, VCBtn.Font.Size + 2, FontStyle.Bold, VCBtn.Font.Unit)
        VCBtn.Padding = New Padding(VCBtn.Padding.Left, -2, VCBtn.Padding.Right, -2)
    End Sub
    Public Sub BtnDecrease(VCBtn As Button)
        VCBtn.Width -= 10
        VCBtn.Height -= 10
        VCBtn.Location = New Point(VCBtn.Location.X + 5, VCBtn.Location.Y + 5)
        VCBtn.Font = New Font(VCBtn.Font.Name, VCBtn.Font.Size - 2, FontStyle.Regular, VCBtn.Font.Unit)
        VCBtn.Padding = New Padding(VCBtn.Padding.Left, 0, VCBtn.Padding.Right, 0)
    End Sub
End Module
