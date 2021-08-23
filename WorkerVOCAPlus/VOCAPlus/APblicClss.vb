Imports System.IO
Imports System.Management
Imports System.Net
Imports Microsoft.Exchange.WebServices.Data
Imports VOCAPlus.Strc

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

        Public CompList As New List(Of String) 'list of tickets to get tickets updates
    End Class
    Public Class Func
        Public Function ConStrFn(worker As System.ComponentModel.BackgroundWorker) As String
            Dim state As New Defntion
            state.Errmsg = Nothing
            strConn = Nothing
            If ServerCD = "Eg Server" Then
                strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
                ServerNm = "VOCA Server"
            ElseIf ServerCD = "My Labtop" Then
                strConn = "Data Source=ASHRAF-PC\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
                ServerNm = "My Labtop"
            ElseIf ServerCD = "Test Database" Then
                strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlusDemo;Persist Security Info=True;User ID=vocaplus21;Password=@VocaPlus$21-4"
                ServerNm = "Test Database"
            ElseIf ServerCD = "OnLine" Then
                strConn = "Data Source=34.123.217.183;Initial Catalog=vocaplus;Persist Security Info=True;User ID=sqlserver;Password=Hemonad105046"
                ServerNm = "OnLine"
            End If
            Try
                'sqlCon = New SqlConnection
                sqlCon.ConnectionString = strConn
            Catch ex As Exception
                state.Errmsg = ex.Message
                AppLog("0000&H", ex.Message, "Conecting String")
            End Try
            worker.ReportProgress(0, state)
            Return strConn
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
                'sqlCon = New SqlConnection
                If sqlCon.State = ConnectionState.Closed Then
                    sqlCon.Open()
                End If
                'sqlComm = New SqlCommand("Select GetDate() as Now_", sqlCon)
                'sqlComm.CommandTimeout = 5
                'sqlComm.Connection = sqlCon
                'SQLGetAdptr.SelectCommand = sqlComm
                'sqlComm.CommandType = CommandType.Text
                'SQLGetAdptr.Fill(TimeTble)

                state.BolString = True
                worker.ReportProgress(0, state)
            Catch ex As Exception
                state.StatStr = "Error"
                state.BolString = False
                worker.ReportProgress(0, state)
                AppLog("0000&H", ex.Message, "Select GetDate() as Now_")
            End Try
            'sqlCon.Close()
            'sqlCon.Dispose()
            'SqlConnection.ClearPool(sqlCon)
            Bol = state.BolString
            sqlComm.CommandTimeout = 30
        End Sub
        Public Function GetTbl(SSqlStr As String, SqlTbl As DataTable, ErrHndl As String, worker As System.ComponentModel.BackgroundWorker) As String
            Dim state As New Defntion
            state.StatStr = Nothing
            Dim StW As New Stopwatch
            StW.Start()
            Try
                If sqlCon.State = ConnectionState.Closed Or sqlCon.State = ConnectionState.Broken Then
                    sqlCon.Open()
                End If
                Dim sqlCommW As New SqlCommand
                sqlCommW = New SqlCommand(SSqlStr, sqlCon)
                Dim reader As SqlDataReader = sqlCommW.ExecuteReader
                SqlTbl.Load(reader)
                StW.Stop()
                Dim TimSpn As TimeSpan = (StW.Elapsed)
                ElapsedTimeSpan = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds / 10)
            Catch ex As Exception
                If ex.Message.Contains("The connection is broken and recovery is not possible") Then
                    sqlCon.Close()
                    SqlConnection.ClearPool(sqlCon)
                End If
                state.StatStr = ex.Message
                worker.ReportProgress(0, state)
                AppLog(ErrHndl, ex.Message, SSqlStr)
            End Try
            SqlTbl.Dispose()
            Return state.StatStr
        End Function
        Public Function InsUpd(SSqlStr As String, ErrHndl As String, worker As System.ComponentModel.BackgroundWorker) As String
            Errmsg = Nothing
            'sqlCon = New SqlConnection(strConn)
            sqlComm = New SqlCommand(SSqlStr, sqlCon)
            sqlComm.Connection = sqlCon
            sqlComm.CommandType = CommandType.Text
            Try
                If sqlCon.State = ConnectionState.Closed Then
                    sqlCon.Open()
                End If
                sqlComm.ExecuteNonQuery()
            Catch ex As Exception
                Errmsg = ex.Message
                AppLog(ErrHndl, ex.Message, SSqlStr)
            End Try
            'sqlCon.Close()
            'SqlConnection.ClearPool(sqlCon)
            Return Errmsg
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
                    Fn.InsUpd("insert into SdHardCollc (IpId, IpLocation, IpProsseccor, IpRam, IpNetwork, IpSerialNo, IpCollect) values ('" & Fn.OsIP() & "','" & "Location" & "','" & Fn.HrdCol.HProcc & "','" & Fn.HrdCol.HRam & "','" & Fn.HrdCol.HNetwrk & "','" & Fn.HrdCol.HSerNo & "','" & True & "');", "1000&H", worker) 'Append access Record
                    Def.StatStr = "Inserted"
                    worker.ReportProgress(0, Def)
                ElseIf Math.Abs(DateTime.Parse(Today).Subtract(DateTime.Parse(HardTable.Rows(0).Item(1))).TotalDays) > 30 Then
                    Fn.HrdCol()
                    Fn.InsUpd("UPDATE SdHardCollc SET IpProsseccor ='" & Fn.HrdCol.HProcc & "', IpRam ='" & Fn.HrdCol.HRam & "', IpNetwork ='" & Fn.HrdCol.HNetwrk & "', IpSerialNo ='" & Fn.HrdCol.HSerNo & "', IpStime ='" & Format(Fn.ServrTime(worker), "yyyy-MM-dd") & "' where IpId='" & Fn.OsIP() & "';", "1000&H", worker)
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

            If (Fn.GetTbl("SELECT SwNm, SwSer, SwID, SwObjNew,SwObjNm, SwObjImg, SwType FROM ASwitchboard ORDER BY SwID", SwichTabTable, "1002&H", worker)) = Nothing Then
                Def.Str = " Building Main Menu ..."
                worker.ReportProgress(0, Def)
                SwichButTable = SwichTabTable.Copy
                SwichTabTable.DefaultView.RowFilter = "(SwType = 'Tab') AND (SwNm <> 'NA')"
                For Cnt_ = 0 To SwichTabTable.DefaultView.Count - 1
                    Dim NewTab As New ToolStripMenuItem(SwichTabTable.DefaultView(Cnt_).Item("SwNm").ToString)
                    Dim NewTabCx As New ToolStripMenuItem(SwichTabTable.DefaultView(Cnt_).Item("SwNm").ToString)  'YYYYYYYYYYY

                    If Mid(Usr.PUsrLvl, SwichTabTable.DefaultView(Cnt_).Item("SwID").ToString, 1) = "A" Or
                        Mid(Usr.PUsrLvl, SwichTabTable.DefaultView(Cnt_).Item("SwID").ToString, 1) = "H" Then
                        Menu_.Items.Add(NewTab)
                        CntxMenu.Items.Add(NewTabCx)                     'YYYYYYYYYYY

                        Def.Str = " Adding Menu " & NewTab.Text
                        worker.ReportProgress(0, Def)
                        Def.Str = " Building Menu " & NewTab.Text
                        worker.ReportProgress(0, Def)
                        Dim Filtr_ As String = SwichTabTable.DefaultView(Cnt_).Item("SwSer").ToString
                        SwichButTable.DefaultView.RowFilter = "(([SwType] <> '" & "Tab" & "') AND ([SwNm] <> '" & "NA" & "') AND ([SwSer] ='" & Filtr_ & "'))"
                        For Cnt_1 = 0 To SwichButTable.DefaultView.Count - 1
                            Dim subItem As New ToolStripMenuItem(SwichButTable.DefaultView(Cnt_1).Item("SwNm").ToString)
                            Dim subItemCx As New ToolStripMenuItem(SwichButTable.DefaultView(Cnt_1).Item("SwNm").ToString)  'YYYYYYYYYYY
                            If Mid(Usr.PUsrLvl, SwichButTable.DefaultView(Cnt_1).Item("SwID").ToString, 1) = "A" Or
                                   Mid(Usr.PUsrLvl, SwichButTable.DefaultView(Cnt_1).Item("SwID").ToString, 1) = "H" Then

                                Def.Str = " Adding Button " & NewTab.Text
                                worker.ReportProgress(0, Def)
                                subItem.Tag = SwichButTable.DefaultView(Cnt_1).Item("SwObjNm").ToString
                                If Mid(Usr.PUsrLvl, SwichButTable.DefaultView(Cnt_1).Item("SwID").ToString, 1) = "H" Then
                                    subItem.AccessibleName = "True"
                                    subItemCx.AccessibleName = "True"
                                End If
                                If DBNull.Value.Equals(SwichButTable.DefaultView(Cnt_1).Item("SwObjImg")) = False Then
                                    Dim imglst As New ImageList
                                    Dim Cnt_ = imglst.Images(SwichButTable.DefaultView(Cnt_1).Item("SwObjImg"))
                                    Dim dd = My.Resources.ResourceManager.GetObject(SwichButTable.DefaultView(Cnt_1).Item("SwObjImg"))
                                    NewTab.Image = Cnt_
                                End If
                                subItemCx.Tag = SwichButTable.DefaultView(Cnt_1).Item("SwObjNm").ToString  'YYYYYYYYYYY
                                NewTab.DropDownItems.Add(subItem)
                                NewTabCx.DropDownItems.Add(subItemCx)    'YYYYYYYYYYY
                            End If
                            If Mid(Usr.PUsrLvl, SwichTabTable.DefaultView(Cnt_).Item(2).ToString, 1) = "H" Then
                                NewTab.AccessibleName = "True"
                                NewTabCx.AccessibleName = "True"
                            End If
                        Next Cnt_1
                    End If
                    NewTab = Nothing
                Next Cnt_
                PrciTblCnt = 0
                SwichTabTable.Dispose()
                SwichButTable.Dispose()
                Def.Str = " Menu has been builded  "
                worker.ReportProgress(0, Def)
                Def.Str = "جاري تحميل البيانات ..."
                worker.ReportProgress(0, Def)
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
                    worker.ReportProgress(0, Def)
                    If (Fn.GetTbl("SELECT OffArea FROM PostOff GROUP BY OffArea ORDER BY OffArea;", AreaTable, "1012&H", worker)) = Nothing Then
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أسماء المناطق "
                        worker.ReportProgress(0, Def)
                    End If

                    Def.Str = "جاري تحميل أسماء المكاتب ..."
                    worker.ReportProgress(0, Def)

                    If (Fn.GetTbl("select OffNm1, OffFinCd, OffArea from PostOff ORDER BY OffNm1;", OfficeTable, "1012&H", worker)) = Nothing Then
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أسماء المكاتب  "
                        worker.ReportProgress(0, Def)
                    End If

                    Dim SrcStr As String = ""
                    If Usr.PUsrUCatLvl = 7 Then
                        SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd = 1"
                    Else
                        SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd > 1 ORDER BY SrcNm"
                    End If
                    Def.Str = "جاري تحميل مصادر الشكوى ..."
                    worker.ReportProgress(0, Def)

                    If (Fn.GetTbl(SrcStr, CompSurceTable, "1012&H", worker)) = Nothing Then
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  مصادر الشكوى  "
                        worker.ReportProgress(0, Def)
                    End If


                    Def.Str = "جاري تحميل أسماء الدول ..."
                    worker.ReportProgress(0, Def)

                    If (Fn.GetTbl("select CounCd,CounNm from CDCountry order by CounNm", CountryTable, "1012&H", worker)) = Nothing Then
                        primaryKey(0) = CountryTable.Columns("CounCd")
                        CountryTable.PrimaryKey = primaryKey
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أسماء الدول  "
                        worker.ReportProgress(0, Def)
                    End If


                    Def.Str = "جاري تحميل أنواع الخدمات ..."
                    worker.ReportProgress(0, Def)

                    If (Fn.GetTbl("select ProdKCd, ProdKNm, ProdKClr from CDProdK where ProdKSusp = 0 order by ProdKCd", ProdKTable, "1012&H", worker)) = Nothing Then
                        primaryKey(0) = ProdKTable.Columns("ProdKNm")
                        ProdKTable.PrimaryKey = primaryKey
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أنواع الخدمات "
                        worker.ReportProgress(0, Def)
                    End If


                    Def.Str = "جاري تحميل أنواع المنتجات ..."
                    worker.ReportProgress(0, Def)

                    If (Fn.GetTbl("SELECT FnSQL, PrdKind, FnProdCd, PrdNm, FnCompCd, CompNm, FnMend, PrdRef, FnMngr, Prd3, FnSusp,CompHlp FROM VwFnProd where FnSusp = 0 ORDER BY PrdKind, PrdNm, CompNm", ProdCompTable, "1012&H", worker)) = Nothing Then
                        primaryKey(0) = ProdCompTable.Columns("FnSQL")
                        ProdCompTable.PrimaryKey = primaryKey
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل أنواع المنتجات  "
                        worker.ReportProgress(0, Def)
                    End If

                    Def.Str = "جاري تحميل أنواع التحديثات ..."
                    worker.ReportProgress(0, Def)
                    If Usr.PUsrUCatLvl >= 3 And Usr.PUsrUCatLvl <= 5 Then
                        If (Fn.GetTbl("SELECT EvId, EvNm FROM CDEvent where EvSusp = 0 and EvBkOfic = 1 ORDER BY EvNm", UpdateKTable, "1012&H", worker)) = Nothing Then
                            PrciTblCnt += 1
                        Else
                            Def.Str = "لم يتم تحميل  أنواع التحديثات "
                            worker.ReportProgress(0, Def)
                        End If
                    Else
                        If (Fn.GetTbl("SELECT EvId, EvNm FROM CDEvent where EvSusp = 0 and EvBkOfic = 0 ORDER BY EvNm", UpdateKTable, "1012&H", worker)) = Nothing Then
                            PrciTblCnt += 1
                        Else
                            Def.Str = " أنواع التحديثات / "
                            worker.ReportProgress(0, Def)
                        End If
                    End If
                End If

                'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            Else
                worker.ReportProgress(0, Def)
                Fn.MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf)
            End If
        End Sub
        Public Sub SwitchBoardXXXXXXXXXXXXXXXXXXXX(worker As System.ComponentModel.BackgroundWorker)
            Dim SwichTabTable As DataTable = New DataTable
            Dim SwichButTable As DataTable = New DataTable
            Dim Def As New APblicClss.Defntion
            Dim Fn As New APblicClss.Func

            Menu_ = New MenuStrip
            CntxMenu = New ContextMenuStrip

            If (Fn.GetTbl("SELECT SwNm, SwSer, SwID, SwObjNew FROM ASwitchboard WHERE (SwType = N'Tab') AND (SwNm <> N'NA') ORDER BY SwID", SwichTabTable, "1002&H", worker)) = Nothing Then
                Def.Str = " Building Main Menu ..."
                worker.ReportProgress(0, Def)
                For Cnt_ = 0 To SwichTabTable.Rows.Count - 1
                    Dim NewTab As New ToolStripMenuItem(SwichTabTable.Rows(Cnt_).Item(0).ToString)
                    Dim NewTabCx As New ToolStripMenuItem(SwichTabTable.Rows(Cnt_).Item(0).ToString)  'YYYYYYYYYYY

                    If Mid(Usr.PUsrLvl, SwichTabTable.Rows(Cnt_).Item(2).ToString, 1) = "A" Or
                        Mid(Usr.PUsrLvl, SwichTabTable.Rows(Cnt_).Item(2).ToString, 1) = "H" Then
                        Menu_.Items.Add(NewTab)
                        CntxMenu.Items.Add(NewTabCx)                     'YYYYYYYYYYY

                        Def.Str = " Adding Menu " & NewTab.Text
                        worker.ReportProgress(0, Def)
                        SwichButTable.Rows.Clear()
                        If (Fn.GetTbl("SELECT SwNm, SwSer, SwID, SwObjNm, SwObjImg, SwObjNew FROM ASwitchboard WHERE (SwType <> N'Tab') AND (SwNm <> N'NA') AND (SwSer ='" & SwichTabTable.Rows(Cnt_).Item(1).ToString & "') ORDER BY SwID;", SwichButTable, "1002&H", worker)) = Nothing Then
                            Def.Str = " Building Menu " & NewTab.Text
                            worker.ReportProgress(0, Def)
                            For Cnt_1 = 0 To SwichButTable.Rows.Count - 1
                                Dim subItem As New ToolStripMenuItem(SwichButTable.Rows(Cnt_1).Item(0).ToString)
                                Dim subItemCx As New ToolStripMenuItem(SwichButTable.Rows(Cnt_1).Item(0).ToString)  'YYYYYYYYYYY
                                If Mid(Usr.PUsrLvl, SwichButTable.Rows(Cnt_1).Item(2).ToString, 1) = "A" Or
                                   Mid(Usr.PUsrLvl, SwichButTable.Rows(Cnt_1).Item(2).ToString, 1) = "H" Then

                                    Def.Str = " Adding Button " & NewTab.Text
                                    worker.ReportProgress(0, Def)
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
                            MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain)
                        End If
                    End If
                    NewTab = Nothing
                Next Cnt_
                PrciTblCnt = 0
                SwichTabTable.Dispose()
                SwichButTable.Dispose()
                Def.Str = " Menu has been builded  "
                worker.ReportProgress(0, Def)
                Def.Str = "جاري تحميل البيانات ..."
                worker.ReportProgress(0, Def)
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
                    worker.ReportProgress(0, Def)
                    If (Fn.GetTbl("SELECT OffArea FROM PostOff GROUP BY OffArea ORDER BY OffArea;", AreaTable, "1012&H", worker)) = Nothing Then
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أسماء المناطق "
                        worker.ReportProgress(0, Def)
                    End If

                    Def.Str = "جاري تحميل أسماء المكاتب ..."
                    worker.ReportProgress(0, Def)

                    If (Fn.GetTbl("select OffNm1, OffFinCd, OffArea from PostOff ORDER BY OffNm1;", OfficeTable, "1012&H", worker)) = Nothing Then
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أسماء المكاتب  "
                        worker.ReportProgress(0, Def)
                    End If

                    Dim SrcStr As String = ""
                    If Usr.PUsrUCatLvl = 7 Then
                        SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd = 1"
                    Else
                        SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd > 1 ORDER BY SrcNm"
                    End If
                    Def.Str = "جاري تحميل مصادر الشكوى ..."
                    worker.ReportProgress(0, Def)

                    If (Fn.GetTbl(SrcStr, CompSurceTable, "1012&H", worker)) = Nothing Then
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  مصادر الشكوى  "
                        worker.ReportProgress(0, Def)
                    End If


                    Def.Str = "جاري تحميل أسماء الدول ..."
                    worker.ReportProgress(0, Def)

                    If (Fn.GetTbl("select CounCd,CounNm from CDCountry order by CounNm", CountryTable, "1012&H", worker)) = Nothing Then
                        primaryKey(0) = CountryTable.Columns("CounCd")
                        CountryTable.PrimaryKey = primaryKey
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أسماء الدول  "
                        worker.ReportProgress(0, Def)
                    End If


                    Def.Str = "جاري تحميل أنواع الخدمات ..."
                    worker.ReportProgress(0, Def)

                    If (Fn.GetTbl("select ProdKCd, ProdKNm, ProdKClr from CDProdK where ProdKSusp = 0 order by ProdKCd", ProdKTable, "1012&H", worker)) = Nothing Then
                        primaryKey(0) = ProdKTable.Columns("ProdKNm")
                        ProdKTable.PrimaryKey = primaryKey
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل  أنواع الخدمات "
                        worker.ReportProgress(0, Def)
                    End If


                    Def.Str = "جاري تحميل أنواع المنتجات ..."
                    worker.ReportProgress(0, Def)

                    If (Fn.GetTbl("SELECT FnSQL, PrdKind, FnProdCd, PrdNm, FnCompCd, CompNm, FnMend, PrdRef, FnMngr, Prd3, FnSusp,CompHlp FROM VwFnProd where FnSusp = 0 ORDER BY PrdKind, PrdNm, CompNm", ProdCompTable, "1012&H", worker)) = Nothing Then
                        primaryKey(0) = ProdCompTable.Columns("FnSQL")
                        ProdCompTable.PrimaryKey = primaryKey
                        PrciTblCnt += 1
                    Else
                        Def.Str = "لم يتم تحميل أنواع المنتجات  "
                        worker.ReportProgress(0, Def)
                    End If

                    Def.Str = "جاري تحميل أنواع التحديثات ..."
                    worker.ReportProgress(0, Def)
                    If Usr.PUsrUCatLvl >= 3 And Usr.PUsrUCatLvl <= 5 Then
                        If (Fn.GetTbl("SELECT EvId, EvNm FROM CDEvent where EvSusp = 0 and EvBkOfic = 1 ORDER BY EvNm", UpdateKTable, "1012&H", worker)) = Nothing Then
                            PrciTblCnt += 1
                        Else
                            Def.Str = "لم يتم تحميل  أنواع التحديثات "
                            worker.ReportProgress(0, Def)
                        End If
                    Else
                        If (Fn.GetTbl("SELECT EvId, EvNm FROM CDEvent where EvSusp = 0 and EvBkOfic = 0 ORDER BY EvNm", UpdateKTable, "1012&H", worker)) = Nothing Then
                            PrciTblCnt += 1
                        Else
                            Def.Str = " أنواع التحديثات / "
                            worker.ReportProgress(0, Def)
                        End If
                    End If
                End If

                'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            Else
                worker.ReportProgress(0, Def)
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
        Public Sub TikCntrSub(worker As System.ComponentModel.BackgroundWorker)
            Dim state As New APblicClss.Defntion
            Dim Fn As New APblicClss.Func
            'Ckeck User Tickets Count And Update It in Int_User Table If Different
            state.Nw = ServrTime(worker)
            TicTable = New DataTable
            If Fn.GetTbl("select UsrClsN, UsrFlN, UsrReOpY, UsrUnRead, UsrEvDy, UsrClsYDy, UsrReadYDy, UsrRecevDy, UsrClsUpdtd, UsrLastSeen, UsrTikFlowDy, UsrActive,UsrLogSnd from Int_user where UsrId = " & Usr.PUsrID & ";", TicTable, "1005&H", worker) = Nothing Then
                If TicTable.Rows.Count > 0 Then
                    If TicTable.Rows(0).Item("UsrActive") = False Then
                        'Login.ExitBtn.Enabled = False
                        Login.TxtUsrNm.Text = Usr.PUsrNm
                        'Login.ExitBtn.Enabled = False
                        Login.TxtUsrNm.Enabled = False
                        Dim frmCollection = Application.OpenForms
                        If frmCollection.OfType(Of Login).Any Then
                            Login.TxtUsrPass.Focus()
                        Else
                            WelcomeScreen.CntxtMnuStrp.Enabled = False
                            WelcomeScreen.CntxtMnuStrp.Enabled = False
                            Login.ShowDialog()
                            WelcomeScreen.TimerTikCoun.Stop()
                            WelcomeScreen.CntxtMnuStrp.Enabled = True
                            WelcomeScreen.CntxtMnuStrp.Enabled = True
                        End If
                    End If
                    'If Math.Abs(DateTime.Parse(Nw).Subtract(DateTime.Parse(TicTable.Rows(0).Item("UsrLastSeen"))).TotalMinutes) > 30 Then
                    'End If

#Region "Send Log File If UsrLogSnd is True"
                    If TicTable.Rows(0).Item("UsrLogSnd") = True Then
                        'TimerColctLog.Interval = 5000
                        tempTable = New DataTable
                        Fn.GetTbl("Select Mlxx from Alib", tempTable, "0000&H", worker)
                        Dim exchange As ExchangeService
                        exchange = New ExchangeService(ExchangeVersion.Exchange2007_SP1)
                        exchange.Credentials = New WebCredentials("egyptpost\voca-support", tempTable.Rows(0).Item(0).ToString)
                        exchange.Url() = New Uri("https://mail.egyptpost.org/ews/exchange.asmx")
                        Dim message As New EmailMessage(exchange)
                        'message.ToRecipients.Add("voca-support@egyptpost.org")
                        message.CcRecipients.Add("a.farag@egyptpost.org")
                        message.Subject = "VOCA Log Of " & Usr.PUsrRlNm & "," & Usr.PUsrID & "," & OsIP()
                        message.Body = "VOCA Log File"
                        Dim fileAttachment As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & "VOCALog" & Format(Now, "yyyyMM") & ".Vlg"
                        message.Attachments.AddFileAttachment(fileAttachment)
                        message.Attachments(0).ContentId = "VOCALog" & Format(Now, "yyyyMM")
                        message.Importance = 1
                        Try
                            message.SendAndSaveCopy()
                            If Fn.InsUpd("UPDATE Int_user SET UsrLogSnd = 0  WHERE (UsrId = " & Usr.PUsrID & ");", "1006&H", worker) = Nothing Then
                            End If
                        Catch ex As Exception
                            MsgInf(ex.Message)
                        End Try
                    End If

#End Region

                End If
            End If
            If Usr.PUsrUCatLvl >= 3 And Usr.PUsrUCatLvl <= 5 Then
                Dim Notif As String = ""
                WelcomeScreen.GrpCounters.Text = "ملخص أرقامي حتى : " & Now
                'If Now.Subtract(TicTable.Rows(0).Item("UsrLastSeen")) Then
                If TicTable.Rows.Count > 0 Then
                    Notif = "جديد :"
                    Dim ss As Integer = TicTable.Rows(0).Item("UsrClsN")
                    If Usr.PUsrClsN < TicTable.Rows(0).Item("UsrClsN") Then
                        Notif &= vbCrLf & "شكاوى مفتوحه : " & TicTable.Rows(0).Item("UsrClsN") - Usr.PUsrClsN
                        Usr.PUsrClsN = TicTable.Rows(0).Item("UsrClsN")
                        WelcomeScreen.LblClsN.Text = Usr.PUsrClsN
                    End If
                    If Usr.PUsrFlN < TicTable.Rows(0).Item("UsrFlN") Then
                        Notif &= vbCrLf & "لم يتم التعامل : " & TicTable.Rows(0).Item("UsrFlN") - Usr.PUsrFlN
                        Usr.PUsrFlN = TicTable.Rows(0).Item("UsrFlN")
                        WelcomeScreen.LblFlN.Text = Usr.PUsrFlN
                    End If
                    If Usr.PUsrReOpY < TicTable.Rows(0).Item("UsrReOpY") Then
                        Notif &= vbCrLf & "معاد فتحها اليوم : " & TicTable.Rows(0).Item("UsrReOpY") - Usr.PUsrReOpY
                        Usr.PUsrReOpY = TicTable.Rows(0).Item("UsrReOpY")
                        WelcomeScreen.LblReOpY.Text = Usr.PUsrReOpY
                    End If
                    If Usr.PUsrUnRead < TicTable.Rows(0).Item("UsrUnRead") Then
                        Notif &= vbCrLf & "تحديثات غير مقروءه : " & TicTable.Rows(0).Item("UsrUnRead")
                        Usr.PUsrUnRead = TicTable.Rows(0).Item("UsrUnRead")
                        WelcomeScreen.LblUnRead.Text = Usr.PUsrUnRead
                    End If
                    If Usr.PUsrEvDy < TicTable.Rows(0).Item("UsrEvDy") Then
                        Notif &= vbCrLf & "عدد تحديثات اليوم : " & TicTable.Rows(0).Item("UsrEvDy")
                        Usr.PUsrEvDy = TicTable.Rows(0).Item("UsrEvDy")
                        WelcomeScreen.LblEvDy.Text = Usr.PUsrEvDy
                    End If
                    If Usr.PUsrClsYDy < TicTable.Rows(0).Item("UsrClsYDy") Then
                        Notif &= vbCrLf & "تم إغلاقها اليوم : " & TicTable.Rows(0).Item("UsrClsYDy")
                        Usr.PUsrClsYDy = TicTable.Rows(0).Item("UsrClsYDy")
                        WelcomeScreen.LblClsYDy.Text = Usr.PUsrClsYDy
                    End If
                    If Usr.PUsrReadYDy < TicTable.Rows(0).Item("UsrReadYDy") Then
                        Notif &= vbCrLf & "تحديثات مقروءه اليوم : " & TicTable.Rows(0).Item("UsrReadYDy") - Usr.PUsrReadYDy
                        Usr.PUsrReadYDy = TicTable.Rows(0).Item("UsrReadYDy")
                        WelcomeScreen.LblReadYDy.Text = Usr.PUsrReadYDy
                    End If
                    If Usr.PUsrRecvDy < TicTable.Rows(0).Item("UsrRecevDy") Then
                        Notif &= vbCrLf & "استلام اليوم : " & TicTable.Rows(0).Item("UsrRecevDy") - Usr.PUsrRecvDy
                        Usr.PUsrRecvDy = TicTable.Rows(0).Item("UsrRecevDy")
                        WelcomeScreen.LblRecivDy.Text = Usr.PUsrRecvDy
                    End If
                    If Usr.PUsrClsUpdtd < TicTable.Rows(0).Item("UsrClsUpdtd") Then
                        Notif &= vbCrLf & "تحديثات شكاوى مغلقة : " & TicTable.Rows(0).Item("UsrClsUpdtd") - Usr.PUsrRecvDy
                        Usr.PUsrClsUpdtd = TicTable.Rows(0).Item("UsrClsUpdtd")
                        WelcomeScreen.LblClsUpdted.Text = Usr.PUsrClsUpdtd
                    End If
                    If Usr.PUsrFolwDay < TicTable.Rows(0).Item("UsrTikFlowDy") Then
                        Notif &= vbCrLf & "تم التعامل اليوم : " & TicTable.Rows(0).Item("UsrTikFlowDy") - Usr.PUsrFolwDay
                        Usr.PUsrFolwDay = TicTable.Rows(0).Item("UsrTikFlowDy")
                        WelcomeScreen.LblFolwDy.Text = Usr.PUsrFolwDay
                    End If
                    If Notif.Length > 6 Then
                        WelcomeScreen.NotifyIcon1.ShowBalloonTip(0, "", Notif, ToolTipIcon.Info)
                    End If
                End If
            End If
        End Sub
#Region "Tik"
        Public Sub GetUpdtEvnt_(worker As System.ComponentModel.BackgroundWorker)
            Dim Fn As New APblicClss.Func
            UpdtCurrTbl = New DataTable
            '                                 0        1         2         3         4        5        6         7         8         9
            If Fn.GetTbl("SELECT TkupSTime, TkupTxt, UsrRealNm,TkupReDt, TkupUser,TkupSQL,TkupTkSql,TkupEvtId, EvSusp, UCatLvl,TkupUnread FROM TkEvent INNER JOIN Int_user ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId Where ( " & CompIds & ") ORDER BY TkupTkSql,TkupSQL DESC", UpdtCurrTbl, "1019&H", worker) = Nothing Then
                UpdtCurrTbl.Columns.Add("File")        ' Add files Columns 
            Else
                MsgErr(My.Resources.ConnErr & vbCrLf & My.Resources.TryAgain & vbCrLf & Errmsg)
            End If
        End Sub
        Public Function CompGrdTikFill(GrdTick As DataGridView, Tbl As DataTable, ProgBar As ProgressBar, worker As System.ComponentModel.BackgroundWorker) As String
            Dim Def As New APblicClss.Defntion
            Dim Fn As New APblicClss.Func
            Def.Errmsg = Nothing
            worker.ReportProgress(0, Def)
            Try
                GrdTick.DataSource = Tbl.DefaultView
                Def.CompList = New List(Of String)
                ProgBar.Visible = True
                ProgBar.Maximum = Tbl.Columns.Count
                For HH = 0 To Tbl.Columns.Count - 1
                    ProgBar.Value = HH + 1
                    ProgBar.Refresh()
                    If Tbl.Columns(HH).ColumnName = "TkDtStart" Then
                        GrdTick.Columns(HH).HeaderText = "تاريخ الشكوى"
                    ElseIf Tbl.Columns(HH).ColumnName = "TkID" Then
                        GrdTick.Columns(HH).HeaderText = "رقم الشكوى"
                    ElseIf Tbl.Columns(HH).ColumnName = "SrcNm" Then
                        GrdTick.Columns(HH).HeaderText = "مصدر الشكوى"
                    ElseIf Tbl.Columns(HH).ColumnName = "TkClNm" Then
                        GrdTick.Columns(HH).HeaderText = "اسم العميل"
                    ElseIf Tbl.Columns(HH).ColumnName = "TkClPh" Then
                        GrdTick.Columns(HH).HeaderText = "تليفون العميل1"
                    ElseIf Tbl.Columns(HH).ColumnName = "TkClPh1" Then
                        GrdTick.Columns(HH).HeaderText = "تليفون العميل2"
                    ElseIf Tbl.Columns(HH).ColumnName = "PrdNm" Then
                        GrdTick.Columns(HH).HeaderText = "اسم المنتج"
                    ElseIf Tbl.Columns(HH).ColumnName = "CompNm" Then
                        GrdTick.Columns(HH).HeaderText = "نوع الشكوى"
                    ElseIf Tbl.Columns(HH).ColumnName = "UsrRealNm" Then
                        GrdTick.Columns(HH).HeaderText = "متابع الشكوى"
                    Else
                        GrdTick.Columns(HH).HeaderText = "unknown"
                        GrdTick.Columns(HH).Visible = False
                    End If
                Next
                ProgBar.Maximum = GrdTick.Rows.Count
                For GG = 0 To GrdTick.Rows.Count - 1
                    ProgBar.Value = GG + 1
                    ProgBar.Refresh()
                    Def.CompList.Add("TkupTkSql = " & GrdTick.Rows(GG).Cells("TkSQL").Value)
                Next
                CompIds = String.Join(" OR ", Def.CompList)
                Tbl.Columns.Add("تاريخ آخر تحديث")
                Tbl.Columns.Add("نص آخر تحديث")
                Tbl.Columns.Add("محرر آخر تحديث")
                Tbl.Columns.Add("TkupReDt")
                Tbl.Columns.Add("TkupUser")
                Tbl.Columns.Add("LastUpdateID")
                Tbl.Columns.Add("EvSusp")
                Tbl.Columns.Add("UCatLvl")
                Tbl.Columns.Add("TkupUnread")

            Catch ex As Exception
                Def.Errmsg = ex.Message
                worker.ReportProgress(0, Def)
            End Try
            ProgBar.Visible = False
            Return Errmsg
        End Function
        Public Function TikFormat(TblTicket As DataTable, TblUpdt As DataTable, ProgBar As ProgressBar, worker As System.ComponentModel.BackgroundWorker) As TickInfo ' Function to Adjust Ticket Gridview
            GridCuntRtrn = New TickInfo
            ProgBar.Visible = True
            For Rws = 0 To TblTicket.Rows.Count - 1
                GridCuntRtrn.TickCount += 1                                          'Grid record count
                ProgBar.Maximum = TblTicket.Rows.Count
                ProgBar.Value = GridCuntRtrn.TickCount
                ProgBar.Refresh()
                Try
                    TblUpdt.DefaultView.RowFilter = "[TkupTkSql]" & " = " & TblTicket.Rows(Rws).Item("TkSQL")
                    TblTicket.Rows(Rws).Item("تاريخ آخر تحديث") = TblUpdt.DefaultView(0).Item("TkupSTime")
                    TblTicket.Rows(Rws).Item("نص آخر تحديث") = TblUpdt.DefaultView(0).Item("TkupTxt")
                    TblTicket.Rows(Rws).Item("محرر آخر تحديث") = TblUpdt.DefaultView(0).Item("UsrRealNm")
                    TblTicket.Rows(Rws).Item("TkupReDt") = TblUpdt.DefaultView(0).Item("TkupReDt")
                    TblTicket.Rows(Rws).Item("TkupUser") = TblUpdt.DefaultView(0).Item("TkupUser")
                    TblTicket.Rows(Rws).Item("LastUpdateID") = TblUpdt.DefaultView(0).Item("TkupEvtId")
                    TblTicket.Rows(Rws).Item("EvSusp") = TblUpdt.DefaultView(0).Item("EvSusp")
                    TblTicket.Rows(Rws).Item("UCatLvl") = TblUpdt.DefaultView(0).Item("UCatLvl")
                    TblTicket.Rows(Rws).Item("TkupUnread") = TblUpdt.DefaultView(0).Item("TkupUnread")

                    StruGrdTk.LstUpDt = TblUpdt.DefaultView(0).Item("TkupSTime")
                    StruGrdTk.LstUpTxt = TblUpdt.DefaultView(0).Item("TkupTxt")
                    StruGrdTk.LstUpUsrNm = TblUpdt.DefaultView(0).Item("UsrRealNm")
                    StruGrdTk.LstUpEvId = TblUpdt.DefaultView(0).Item("TkupEvtId")
                Catch ex As Exception
                    TblTicket.Rows(Rws).Delete()
                End Try
            Next Rws
            GridCuntRtrn.CompCount = Convert.ToInt32(TblTicket.Compute("count(TkSQL)", String.Empty))
            GridCuntRtrn.NoFlwCount = Convert.ToInt32(TblTicket.Compute("count(TkFolw)", "TkFolw = 'False'"))
            GridCuntRtrn.Recved = Convert.ToInt32(TblTicket.Compute("count(TkRecieveDt)", "TkRecieveDt = '" & Format(Nw, "yyyy/MM/dd").ToString & "'"))
            GridCuntRtrn.ClsCount = Convert.ToInt32(TblTicket.Compute("count(TkClsStatus)", "TkClsStatus = 'True' And TkKind = 'True'"))
            GridCuntRtrn.UpdtFollow = Convert.ToInt32(TblTicket.Compute("count(UsrRealNm)", "[محرر آخر تحديث] = UsrRealNm"))
            GridCuntRtrn.UpdtColleg = Convert.ToInt32(TblTicket.Compute("count(UsrRealNm)", "[محرر آخر تحديث] <> UsrRealNm AND UCatLvl >= 3 And UCatLvl <= 5"))
            GridCuntRtrn.UpdtOthrs = Convert.ToInt32(TblTicket.Compute("count(UsrRealNm)", "[محرر آخر تحديث] <> UsrRealNm AND UCatLvl < 3 And UCatLvl > 5"))
            GridCuntRtrn.UnReadCount = Convert.ToInt32(TblTicket.Compute("count(TkupUnread)", "TkupUnread = 'False'"))
            GridCuntRtrn.Esc1 = Convert.ToInt32(TblTicket.Compute("count(LastUpdateID)", "LastUpdateID = 902"))
            GridCuntRtrn.Esc2 = Convert.ToInt32(TblTicket.Compute("count(LastUpdateID)", "LastUpdateID = 903"))
            GridCuntRtrn.Esc3 = Convert.ToInt32(TblTicket.Compute("count(LastUpdateID)", "LastUpdateID = 904"))
            ProgBar.Visible = False
            Return GridCuntRtrn 'Return Counters Structure
        End Function
#End Region

    End Class
End Class
