Imports System.IO
Imports System.Management
Imports System.Net

Public Class APblicClss

    Public Class Defntion
        Public Str As String
        Public StatStr As String
        Public Errmsg As String
        Public RwCnt As Integer
        '"Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
        '"Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
        Public ElapsedTimeSpan As String
        Public sqlComm As New SqlCommand                    'SQL Command
        Public sqlComminsert_1 As New SqlCommand            'SQL Command
        Public sqlComminsert_2 As New SqlCommand            'SQL Command
        Public sqlComminsert_3 As New SqlCommand            'SQL Command
        Public sqlComminsert_4 As New SqlCommand            'SQL Command
        Public Tran As SqlTransaction
        Public cntXXX As Integer
        Public Nw As DateTime


        Public BolString As Boolean
        Public Admn As Boolean
    End Class
    Public Class Func
        Public Function ConStrFn(worker As System.ComponentModel.BackgroundWorker) As List(Of String)
            Dim ConData As New List(Of String)
            Dim state As New Defntion
            state.Errmsg = Nothing
            If ServerCD = "Eg Server" Then
                strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
                ServerNm = "VOCA Server"
            ElseIf ServerCD = "My Labtop" Then
                strConn = "Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
                ServerNm = "My Labtop"
            ElseIf ServerCD = "Test Database" Then
                strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlusDemo;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
                ServerNm = "Test Database"
            End If
            Try
                sqlCon = New SqlConnection
                sqlCon.ConnectionString = strConn
            Catch ex As Exception
                state.Errmsg = ex.Message
                AppLog("0000&H", ex.Message, "Conecting String")
            End Try
            ConData.Add(Errmsg)
            ConData.Add(strConn)
            ConData.Add(ServerNm)
            worker.ReportProgress(0, state)
            Return ConData
        End Function
        Public Sub MacTblSub(worker As System.ComponentModel.BackgroundWorker)
            Dim Def As New APblicClss.Defntion
            Dim Fn As New APblicClss.Func
            MacTable = New DataTable
            If (Fn.GetTbl("select Mac, Admin from AMac where Mac ='" & GetMACAddressNew() & "'", MacTable, "8888&H", worker)) = Nothing Then
                Def.RwCnt = MacTable.Rows.Count
                worker.ReportProgress(0, Def)
                If MacTable.Rows.Count > 0 Then
                    If DBNull.Value.Equals(MacTable.Rows(0).Item("Admin")) = True Then
                        Def.Admn = False
                        worker.ReportProgress(0, Def)
                    ElseIf MacTable.Rows(0).Item("Admin") = False Or MacTable.Rows(0).Item("Admin") = True Then
                        Def.Admn = True
                        worker.ReportProgress(0, Def)
                    End If
                End If
            Else
                Def.StatStr = "Error"
            End If
            worker.ReportProgress(0, Def)
            LodngFrm.Close()
        End Sub
        Public Sub Conoff(worker As System.ComponentModel.BackgroundWorker)
            Dim state As New Defntion
            Dim TimeTble As New DataTable
            Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
            Try
                state.StatStr = " ..."
                worker.ReportProgress(0, state)
                sqlCon = New SqlConnection
                sqlCon.ConnectionString = strConn
                sqlComm.CommandTimeout = 5
                sqlComm.Connection = sqlCon
                SQLGetAdptr.SelectCommand = sqlComm
                sqlComm.CommandType = CommandType.Text
                sqlComm.CommandText = "Select GetDate() as Now_"
                SQLGetAdptr.Fill(TimeTble)
                state.BolString = True
                'sqlCon.Close()
                'SqlConnection.ClearPool(sqlCon)
            Catch ex As Exception
                state.StatStr = "Error"
                worker.ReportProgress(0, state)
                state.BolString = False
                AppLog("0000&H", ex.Message, "Select GetDate() as Now_")
            End Try
            Bol = state.BolString
            sqlComm.CommandTimeout = 30
        End Sub
        Public Function GetTbl(SSqlStr As String, SqlTbl As DataTable, ErrHndl As String, worker As System.ComponentModel.BackgroundWorker) As String
            Dim state As New Defntion
            state.StatStr = Nothing
            worker.ReportProgress(0, state)
            Dim StW As New Stopwatch
            StW.Start()
            Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
            Dim sqlCommW As New SqlCommand
            Try
                sqlCon = New SqlConnection
                sqlCon.ConnectionString = strConn
                If sqlCon.State = ConnectionState.Closed Then
                    sqlCon.Open()
                End If
                SQLGetAdptr = New SqlDataAdapter            'SQL Table Adapter
                sqlCommW = New SqlCommand(SSqlStr, sqlCon)
                SQLGetAdptr.SelectCommand = sqlCommW
                SQLGetAdptr.Fill(SqlTbl)
                StW.Stop()
                Dim TimSpn As TimeSpan = (StW.Elapsed)
            Catch ex As Exception
                state.StatStr = state.StatStr
                state.StatStr = ex.Message
                AppLog(ErrHndl, ex.Message, SSqlStr)
                worker.ReportProgress(0, state)
            End Try
            SqlTbl.Dispose()
            SQLGetAdptr.Dispose()
            sqlCommW.Dispose()
            sqlCon.Close()
            SqlConnection.ClearPool(sqlCon)

            Return state.StatStr
        End Function
        Public Function InsUpd(SSqlStr As String, ErrHndl As String) As String
            Dim Def As New APblicClss.Defntion
            Def.StatStr = Nothing
            Def.sqlComm.Connection = sqlCon
            Def.sqlComm.CommandType = CommandType.Text
            Def.sqlComm.CommandText = SSqlStr
            Try
                If sqlCon.State = ConnectionState.Closed Then
                    sqlCon.Open()
                End If
                Def.sqlComm.ExecuteNonQuery()
            Catch ex As Exception
                Dim frmCollection = Application.OpenForms
                If frmCollection.OfType(Of WelcomeScreen).Any Then
                    WelcomeScreen.TimerCon.Start()
                    WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
                End If
                Def.StatStr = ex.Message
                AppLog(ErrHndl, ex.Message, SSqlStr)
            End Try
            'sqlCon.Close()
            'SqlConnection.ClearPool(sqlCon)
            Return Def.StatStr
        End Function
        Public Function InsTrans(TranStr1 As String, TranStr2 As String, ErrHndl As String) As String
            Dim Def As New APblicClss.Defntion
            Def.StatStr = Nothing
            Try
                If sqlCon.State = ConnectionState.Closed Then
                    sqlCon.Open()
                End If
                Def.sqlComminsert_1.Connection = sqlCon
                Def.sqlComminsert_2.Connection = sqlCon
                Def.sqlComminsert_1.CommandType = CommandType.Text
                Def.sqlComminsert_2.CommandType = CommandType.Text
                Def.sqlComminsert_1.CommandText = TranStr1
                Def.sqlComminsert_2.CommandText = TranStr2
                Def.Tran = sqlCon.BeginTransaction()
                Def.sqlComminsert_1.Transaction = Tran
                Def.sqlComminsert_2.Transaction = Tran
                Def.sqlComminsert_1.ExecuteNonQuery()
                Def.sqlComminsert_2.ExecuteNonQuery()
                Def.Tran.Commit()
            Catch ex As Exception
                Def.Tran.Rollback()

                Dim frmCollection = Application.OpenForms
                If frmCollection.OfType(Of WelcomeScreen).Any Then
                    WelcomeScreen.TimerCon.Start()
                    WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
                End If
                AppLog(ErrHndl, ex.Message, TranStr1 & "_" & TranStr2)
            End Try
            'sqlCon.Close()
            'SqlConnection.ClearPool(sqlCon)
            Return Def.StatStr
        End Function
        Public Sub AppLog(ErrHndls As String, LogMsg As String, SSqlStrs As String)
            On Error Resume Next
            My.Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) _
          & "\VOCALog" & Format(Now, "yyyyMM") & ".Vlg", Format(Now, "yyyyMMdd HH:mm:ss") & " ," & ErrHndls & LogMsg & " &H" & PassEncoding(SSqlStrs, GenSaltKey) & vbCrLf, True)
        End Sub
        Function OsIP() As String              'Returns the Ip address 
#Disable Warning BC40000 ' Type or member is obsolete
            OsIP = System.Net.Dns.GetHostByName("").AddressList(0).ToString()
#Enable Warning BC40000 ' Type or member is obsolete
        End Function
        Public Function CalDate(StDt As Date, ByRef EnDt As Date, ErrHndl As String) As Integer    ' Returns the number of CalDate between StDt and EnDt Using the table CDHolDay
            Dim WdyCount As Integer = 0
            Dim SQLcalDtAdptr As New SqlDataAdapter
            Dim CaldtTbl As New DataTable
            Dim Def As New APblicClss.Defntion
            Try

                StDt = DateValue(StDt)     ' DateValue returns the date part only if U use stamptime as example.
                EnDt = DateValue(EnDt)
                Def.sqlComm.Connection = sqlCon ' Get ID & Date & UserID                        
                Def.sqlComm.CommandText = "SELECT Count(HDate) AS WDaysCount FROM CDHolDay WHERE (HDy = 1) AND (HDate BETWEEN CONVERT(DATETIME, '" & Format(StDt, "dd/MM/yyyy") & "', 103) AND CONVERT(DATETIME, '" & Format(EnDt, "dd/MM/yyyy") & "', 103));"
                Def.sqlComm.CommandType = CommandType.Text
                SQLcalDtAdptr.SelectCommand = Def.sqlComm
                'If sqlCon.State = ConnectionState.Closed Then
                '    sqlCon.Open()
                'End If
                SQLcalDtAdptr.Fill(CaldtTbl)
                WdyCount = CaldtTbl.Rows(0).Item("WDaysCount")
            Catch ex As Exception
                Def.StatStr = ex.Message
                WdyCount = 1
            End Try
            Return WdyCount
        End Function
        Function PassEncoding(password As String, FSaltKey As String) As String
            Dim Wrapper As New Simple3Des(FSaltKey)
            EncDecTxt = Wrapper.EncryptData(password)
            Return EncDecTxt
        End Function
        Function PassDecoding(password As String, FSaltKey As String) As String
            Dim wrapper As New Simple3Des(FSaltKey)
            Try '        DecryptData throws if the wrong password is used.
                EncDecTxt = wrapper.DecryptData(password)
            Catch ex As System.Security.Cryptography.CryptographicException
                EncDecTxt = "false"
            End Try
            Return EncDecTxt
        End Function
        Public Sub MsgInf(MsgBdy As String)
            MessageBox.Show(MsgBdy, "رسالة معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
        End Sub
        Public Sub MsgErr(MsgBdy As String)
            MessageBox.Show(MsgBdy, "رسالة خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
        End Sub
        Public Sub LoadFrm(worker As System.ComponentModel.BackgroundWorker)
            LodngFrm.Show()
            LodngFrm.Location = New Point((Screen.PrimaryScreen.Bounds.Width - LodngFrm.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - LodngFrm.Height) / 2)
        End Sub
        Public Function ServrTime(worker As System.ComponentModel.BackgroundWorker) As DateTime
            Dim Def As New APblicClss.Defntion
            Def.StatStr = Nothing
            worker.ReportProgress(0, Def)
            Dim TimeTble As New DataTable
            Dim SQLGetAdptr As New SqlDataAdapter            'SQL Table Adapter
            Try
                sqlComm.Connection = sqlCon
                SQLGetAdptr.SelectCommand = sqlComm
                sqlComm.CommandType = CommandType.Text
                sqlComm.CommandText = "Select GetDate() as Now_"
                SQLGetAdptr.Fill(TimeTble)
                Def.Nw = Format(TimeTble.Rows(0).Item(0), "yyyy/MMM/dd hh:mm:ss tt")

            Catch ex As Exception
                Def.StatStr = "X"
                worker.ReportProgress(0, Def)
                Dim frmCollection = Application.OpenForms
                If frmCollection.OfType(Of WelcomeScreen).Any Then
                    WelcomeScreen.TimerCon.Start()
                    WelcomeScreen.StatBrPnlEn.Icon = My.Resources.WSOff032
                End If
            End Try
            Return Def.Nw
            worker.ReportProgress(0, Def)
            SQLGetAdptr.Dispose()
        End Function

        Function HrdCol() As Strc.HrdColc
            Dim MyOBJ As Object
            Dim Items As New Strc.HrdColc
            MyOBJ = GetObject("WinMgmts:").instancesof("Win32_Processor") ' Proccessor Information
            For Each Device In MyOBJ
                Items.HProcc &= Device.Name.ToString + " " + Device.CurrentClockSpeed.ToString + " Mhz"
            Next
            MyOBJ = GetObject("WinMgmts:").instancesof("Win32_NetworkAdapter") ' Network Information
            For Each Device In MyOBJ
                Items.HNetwrk &= Device.Name.ToString & " & "
            Next

            MyOBJ = GetObject("WinMgmts:").instancesof("Win32_PhysicalMemory")  ' Ram Information
            For Each Device In MyOBJ
                Items.HRam &= " Ram Capacity : " & Device.Capacity / 1024 / 1024 / 1024 & " Giga " & "Manufacturer : " & Device.Manufacturer
            Next

            MyOBJ = GetObject("WinMgmts:").instancesof("Win32_bios")  ' Bios Information
            For Each Device In MyOBJ
                Items.HSerNo &= "Serial Number: " & Device.serialNumber & " Manufacturer : " & Device.Manufacturer
            Next
            Return Items
        End Function
        Public Sub HrdWre(worker As System.ComponentModel.BackgroundWorker)
            Dim Def As New APblicClss.Defntion
            Dim Fn As New APblicClss.Func
            On Error Resume Next
            HardTable = New DataTable
            Def.StatStr = "Not Updated"
            worker.ReportProgress(0, Def)
            If (Fn.GetTbl("select IpId, IpStime FROM SdHardCollc WHERE ((IpId= '" & OsIP() & "'));", HardTable, "1000&H", worker)) = Nothing Then
                If HardTable.Rows.Count = 0 Then 'insert new computer hardware information if not founded into Hardware Table
                    Fn.HrdCol()
                    Fn.InsUpd("insert into SdHardCollc (IpId, IpLocation, IpProsseccor, IpRam, IpNetwork, IpSerialNo, IpCollect) values ('" & Fn.OsIP() & "','" & "Location" & "','" & Fn.HrdCol.HProcc & "','" & Fn.HrdCol.HRam & "','" & Fn.HrdCol.HNetwrk & "','" & Fn.HrdCol.HSerNo & "','" & True & "');", "1000&H") 'Append access Record
                    Def.StatStr = "Inserted"
                    worker.ReportProgress(0, Def)
                ElseIf Math.Abs(DateTime.Parse(Today).Subtract(DateTime.Parse(HardTable.Rows(0).Item(1))).TotalDays) > 30 Then
                    Fn.HrdCol()
                    Fn.InsUpd("UPDATE SdHardCollc SET IpProsseccor ='" & Fn.HrdCol.HProcc & "', IpRam ='" & Fn.HrdCol.HRam & "', IpNetwork ='" & Fn.HrdCol.HNetwrk & "', IpSerialNo ='" & Fn.HrdCol.HSerNo & "', IpStime ='" & Format(Fn.ServrTime(worker), "yyyy-MM-dd") & "' where IpId='" & Fn.OsIP() & "';", "1000&H")
                    Def.StatStr = "Updated"
                    worker.ReportProgress(0, Def)
                End If
            End If
Sec2:
            HardTable.Dispose()
            GC.Collect()
        End Sub
        Public Sub SwitchBoard(worker As System.ComponentModel.BackgroundWorker)
            Dim SwichTabTable As DataTable = New DataTable
            Dim SwichButTable As DataTable = New DataTable
            Dim Def As New APblicClss.Defntion
            Dim Fn As New APblicClss.Func

            Menu_ = New MenuStrip
            CntxMenu = New ContextMenuStrip

            If (Fn.GetTbl("SELECT SwNm, SwSer, SwID, SwObjNew FROM ASwitchboard WHERE (SwType = N'Tab') AND (SwNm <> N'NA') ORDER BY SwID", SwichTabTable, "1002&H", worker)) = Nothing Then
                Def.Str = " Building Main Menu ..."
                If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                For Cnt_ = 0 To SwichTabTable.Rows.Count - 1
                    Dim NewTab As New ToolStripMenuItem(SwichTabTable.Rows(Cnt_).Item(0).ToString)
                    Dim NewTabCx As New ToolStripMenuItem(SwichTabTable.Rows(Cnt_).Item(0).ToString)  'YYYYYYYYYYY

                    If Mid(Usr.PUsrLvl, SwichTabTable.Rows(Cnt_).Item(2).ToString, 1) = "A" Or
                        Mid(Usr.PUsrLvl, SwichTabTable.Rows(Cnt_).Item(2).ToString, 1) = "H" Then
                        Menu_.Items.Add(NewTab)
                        CntxMenu.Items.Add(NewTabCx)                     'YYYYYYYYYYY

                        Def.Str = " Adding Menu " & NewTab.Text
                        If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                        SwichButTable.Rows.Clear()
                        If (Fn.GetTbl("SELECT SwNm, SwSer, SwID, SwObjNm, SwObjImg, SwObjNew FROM ASwitchboard WHERE (SwType <> N'Tab') AND (SwNm <> N'NA') AND (SwSer ='" & SwichTabTable.Rows(Cnt_).Item(1).ToString & "') ORDER BY SwID;", SwichButTable, "1002&H", worker)) = Nothing Then
                            Def.Str = " Building Menu " & NewTab.Text
                            If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                            For Cnt_1 = 0 To SwichButTable.Rows.Count - 1
                                Dim subItem As New ToolStripMenuItem(SwichButTable.Rows(Cnt_1).Item(0).ToString)
                                Dim subItemCx As New ToolStripMenuItem(SwichButTable.Rows(Cnt_1).Item(0).ToString)  'YYYYYYYYYYY
                                If Mid(Usr.PUsrLvl, SwichButTable.Rows(Cnt_1).Item(2).ToString, 1) = "A" Or
                                   Mid(Usr.PUsrLvl, SwichButTable.Rows(Cnt_1).Item(2).ToString, 1) = "H" Then

                                    Def.Str = " Adding Button " & NewTab.Text
                                    If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                                    subItem.Tag = SwichButTable.Rows(Cnt_1).Item(3).ToString
                                    If Mid(Usr.PUsrLvl, SwichButTable.Rows(Cnt_1).Item(2).ToString, 1) = "H" Then
                                        subItem.AccessibleName = "True"
                                        subItemCx.AccessibleName = "True"
                                    End If
                                    If DBNull.Value.Equals(SwichButTable.Rows(Cnt_1).Item("SwObjImg")) = False Then
                                        Dim imglst As New ImageList
                                        Dim Cnt_ = imglst.Images(SwichButTable.Rows(Cnt_1).Item("SwObjImg"))
                                        Dim dd = My.Resources.ResourceManager.GetObject(SwichButTable.Rows(Cnt_1).Item("SwObjImg"))
                                        NewTab.Image = Cnt_
                                    End If
                                    subItemCx.Tag = SwichButTable.Rows(Cnt_1).Item(3).ToString  'YYYYYYYYYYY
                                    NewTab.DropDownItems.Add(subItem)
                                    NewTabCx.DropDownItems.Add(subItemCx)    'YYYYYYYYYYY
                                End If
                                If Mid(Usr.PUsrLvl, SwichTabTable.Rows(Cnt_).Item(2).ToString, 1) = "H" Then
                                    NewTab.AccessibleName = "True"
                                    NewTabCx.AccessibleName = "True"
                                End If
                            Next Cnt_1
                        Else
                            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf & Def.StatStr.ToString)
                        End If
                    End If
                    NewTab = Nothing
                Next Cnt_
                PrciTblCnt = 0
                SwichTabTable.Dispose()
                SwichButTable.Dispose()
                Def.Str = " Menu has been builded  "
                If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                Def.Str = "جاري تحميل البيانات ..."
                If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                If Def.Str = "جاري تحميل البيانات ..." Then
                    Dim primaryKey(0) As DataColumn
                    AreaTable = New DataTable
                    OfficeTable = New DataTable
                    CompSurceTable = New DataTable
                    CountryTable = New DataTable
                    ProdKTable = New DataTable
                    ProdCompTable = New DataTable
                    UpdateKTable = New DataTable
                    Def.Str = "جاري تحميل أسماء المناطق ..."
                    If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                    If (Fn.GetTbl("SELECT OffArea FROM PostOff GROUP BY OffArea ORDER BY OffArea;", AreaTable, "1012&H", worker)) = Nothing Then
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أسماء المناطق "
                        If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                    End If

                    Def.Str = "جاري تحميل أسماء المكاتب ..."
                    If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)

                    If (Fn.GetTbl("select OffNm1, OffFinCd, OffArea from PostOff ORDER BY OffNm1;", OfficeTable, "1012&H", worker)) = Nothing Then
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أسماء المكاتب  "
                        If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                    End If

                    Dim SrcStr As String = ""
                    If Usr.PUsrUCatLvl = 7 Then
                        SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd = 1"
                    Else
                        SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd > 1 ORDER BY SrcNm"
                    End If
                    Def.Str = "جاري تحميل مصادر الشكوى ..."
                    If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)

                    If (Fn.GetTbl(SrcStr, CompSurceTable, "1012&H", worker)) = Nothing Then
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  مصادر الشكوى  "
                        If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                    End If


                    Def.Str = "جاري تحميل أسماء الدول ..."
                    If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)

                    If (Fn.GetTbl("select CounCd,CounNm from CDCountry order by CounNm", CountryTable, "1012&H", worker)) = Nothing Then
                        primaryKey(0) = CountryTable.Columns("CounCd")
                        CountryTable.PrimaryKey = primaryKey
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أسماء الدول  "
                        If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                    End If


                    Def.Str = "جاري تحميل أنواع الخدمات ..."
                    If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)

                    If (Fn.GetTbl("select ProdKCd, ProdKNm, ProdKClr from CDProdK where ProdKSusp = 0 order by ProdKCd", ProdKTable, "1012&H", worker)) = Nothing Then
                        primaryKey(0) = ProdKTable.Columns("ProdKNm")
                        ProdKTable.PrimaryKey = primaryKey
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أنواع الخدمات "
                        If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                    End If


                    Def.Str = "جاري تحميل أنواع المنتجات ..."
                    If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)

                    If (Fn.GetTbl("SELECT FnSQL, PrdKind, FnProdCd, PrdNm, FnCompCd, CompNm, FnMend, PrdRef, FnMngr, Prd3, FnSusp,CompHlp FROM VwFnProd where FnSusp = 0 ORDER BY PrdKind, PrdNm, CompNm", ProdCompTable, "1012&H", worker)) = Nothing Then
                        primaryKey(0) = ProdCompTable.Columns("FnSQL")
                        ProdCompTable.PrimaryKey = primaryKey
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل أنواع المنتجات  "
                        If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                    End If

                    Def.Str = "جاري تحميل أنواع التحديثات ..."
                    If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                    If Usr.PUsrUCatLvl >= 3 And Usr.PUsrUCatLvl <= 5 Then
                        If (Fn.GetTbl("SELECT EvId, EvNm FROM CDEvent where EvSusp = 0 and EvBkOfic = 1 ORDER BY EvNm", UpdateKTable, "1012&H", worker)) = Nothing Then
                            PrciTblCnt += 1
                        Else
                            Def.Str = "لم يتم تحميل  أنواع التحديثات "
                            If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                        End If
                    Else
                        If (Fn.GetTbl("SELECT EvId, EvNm FROM CDEvent where EvSusp = 0 and EvBkOfic = 0 ORDER BY EvNm", UpdateKTable, "1012&H", worker)) = Nothing Then
                            PrciTblCnt += 1
                        Else
                            Def.Str = " أنواع التحديثات / "
                            If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                        End If
                    End If
                End If

                'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            Else
                If Def.Str.Length > 0 Then worker.ReportProgress(0, Def)
                Fn.MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf)
            End If
        End Sub
        Public Sub LodUsrPic(worker As System.ComponentModel.BackgroundWorker)
            Dim Def As New APblicClss.Defntion
            Dim Fn As New APblicClss.Func
            Dim request As FtpWebRequest = WebRequest.Create("ftp://10.10.26.4/UserPic/" & Usr.PUsrID & " " & Usr.PUsrNm & ".jpg")
            request.Credentials = New NetworkCredential("administrator", "Hemonad105046")
            request.Method = WebRequestMethods.Ftp.DownloadFile
            request.Timeout = 10000
            Def.StatStr += vbCrLf & "جاري تحميل الصورة الشخصية .................."
            worker.ReportProgress(0, Def)
            Try
                Dim ftpStream As Stream = request.GetResponse().GetResponseStream()
                Dim buffer As Byte() = New Byte(10240 - 1) {}
                WelcomeScreen.PictureBox1.Image = Image.FromStream(ftpStream) 'Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile.MyDocuments) & "\" & Usr.PUsrID & ".jpg")
                WelcomeScreen.PictureBox1.Refresh()
                WelcomeScreen.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                WelcomeScreen.PictureBox1.BorderStyle = BorderStyle.None
                request.Abort()
                ftpStream.Close()
                ftpStream.Dispose()
                WelcomeScreen.StatBrPnlAr.Text = ""
                Def.StatStr += vbCrLf & "تم تحميل الصورة الشخصية .................."
                worker.ReportProgress(0, Def)
            Catch ex As Exception
                Def.StatStr += vbCrLf & "لم يتم تحميل الصورة الشخصية"
                worker.ReportProgress(0, Def)
                WelcomeScreen.PictureBox1.Image = My.Resources.UsrResm
                WelcomeScreen.PictureBox1.Refresh()
                WelcomeScreen.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                WelcomeScreen.PictureBox1.BorderStyle = BorderStyle.None
            End Try
        End Sub
    End Class
End Class
