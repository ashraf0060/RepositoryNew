Public Class TikFrmRep
    Dim myAdapter As New SqlDataAdapter()
    Dim dataSet_ As New vocaplusDataSet
    Dim dataSet_1 As New vocaplusDataSet1
    Dim suppliersCommand As New SqlCommand
    Dim suppliersAdapter As New SqlDataAdapter
    Dim Users As New DataTable
    Dim Users1 As New DataTable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        'TikIDRep_ = 307226
        Me.Text = "شكوى رقم " & TikIDRep_
        Dim datasource As ReportDataSource
        Dim datasource1 As ReportDataSource
        With ReportViewer1.LocalReport
            .ReportEmbeddedResource = "VOCAPlus.TikRep.rdlc"
            .DataSources.Clear()
        End With
        dataSet_.Tables(0).Rows.Clear()
        dataSet_1.Tables(0).Rows.Clear()
        '        GetTbl("SELECT TkKind, TkID, TkDtStart, TkDtClose , TkDuration, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TkTransDate, ProdKNm, PrdNm, CompNm, case when CounNmSender is null then '' else CounNmSender end As CounNmSender, case when CounNmConsign is null then '' else CounNmConsign end As CounNmConsign, 
        '                         OffNm1, OffArea, TkDetails, TkClsStatus , TkFolw, TikCreat, TikCreatTeam, UsrRealNm, UCatNm, TkReOp , TkRecieveDt  
        'FROM  TicketsAll WHERE (TkID = 307226)", Users, "")

        suppliersCommand.Connection = sqlCon
        suppliersCommand.CommandText = "SELECT        TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkClNtID, TkShpNo, TkGBNo, TkCardNo, TkAmount, TkTransDate, PrdKind, ProdKNm, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, 
                         OffArea, TkDetails, TkClsStatus, TkFolw, UsrRealNm, TkReOp, TikCreat, TikCreatTeam, TkRecieveDt, TkDtClose, TkDuration
FROM            TicketsAll WHERE (TkID = " & TikIDRep_ & ")"
        suppliersCommand.CommandType = CommandType.Text
        suppliersAdapter.SelectCommand = suppliersCommand
        suppliersAdapter.Fill(dataSet_, "TicketsAll")

        datasource = New ReportDataSource("vocaplusDataSet", dataSet_.Tables(0))

        suppliersCommand.CommandText = "SELECT  TkEvent.TkupTkSql, TkEvent.TkupSTime, TkEvent.TkupTxt, Int_user.UsrRealNm, TkEvent.TkupSQL, IntUserCat.UCatLvl, CDEvent.EvSusp FROM TkEvent INNER JOIN Int_user ON TkEvent.TkupUser = Int_user.UsrId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId INNER JOIN CDEvent ON TkEvent.TkupEvtId = CDEvent.EvId
WHERE (TkupTkSql =" & TikIDRep_ & ") ORDER BY TkupSQL DESC"
        suppliersAdapter.Fill(dataSet_1, "ExportView2")

        datasource1 = New ReportDataSource("vocaplusDataSet1", dataSet_1.Tables(0))

        ReportViewer1.LocalReport.DataSources.Clear()

        Me.ReportViewer1.LocalReport.DataSources.Add(datasource)
        Me.ReportViewer1.LocalReport.DataSources.Add(datasource1)


        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.FullPage

        'Dim lpar As New ReportParameter("ReportParameter1", "Usr.PUsrRlNm", True)
        ''Dim lpar1(0) As ReportParameter
        ''lpar1(0) = lpar
        'ReportViewer1.LocalReport.SetParameters(lpar)
        Me.ReportViewer1.RefreshReport()
        sqlCon.Close()
        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    End Sub
End Class
