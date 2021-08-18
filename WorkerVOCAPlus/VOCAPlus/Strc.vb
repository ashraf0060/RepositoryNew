Public Class Strc
    Structure HrdColc
        Public HProcc As String
        Public HNetwrk As String
        Public HRam As String
        Public HSerNo As String
    End Structure
    Structure CurrentUser   '                Current User
        Public PUsrID As Integer      'UsrId
        Public PUsrCat As Integer     'UsrCat
        Public PUsrNm As String       'UsrNm
        Public PUsrPWrd As String     'UsrPass
        Public PUsrLvl As String      'UsrLevel
        Public PUsrRlNm As String     'UsrRealNm
        Public PUsrMail As String     'UsrEmail
        Public PUsrSisco As String    'UsrSisco
        Public PUsrGsm As String      'UsrMobile
        Public PUsrGndr As String     'UsrGender
        Public PUsrActv As Boolean    'UsrActive(Yes/No)
        Public PUsrLstS As String     'UsrLastSeen
        Public PUsrSusp As String     'UsrSusp(Yes/No)
        Public PUsrTcCnt As Integer   'UsrTkCount
        Public PUsrSltKy As String    'SaltKey
        Public PUsrCatNm As String    'Catagory name
        Public PUsrCalCntr As Boolean 'Call Center
        Public PUsrUCatLvl As Integer 'Close Count
        Public PUsrFlN As Integer     'Follow Count
        Public PUsrClsN As Integer    'Open Count
        Public PUsrReOpY As Integer   'ReOpen Count
        Public PUsrUnRead As Integer  'Read Count
        Public PUsrEvDy As Integer    'Enent Count
        Public PUsrReadYDy As Integer 'Read Count
        Public PUsrClsYDy As Integer  'Close Count
        Public PUsrRecvDy As Integer  'Recieved Count
        Public PUsrClsUpdtd As Integer 'Closed updated Count
        Public PUsrFolwDay As Integer  'Followed Tickets Count
    End Structure
    Structure ExprXlsx
        Public RwsCnt As Integer
        Public ColCnt As Integer
        Public Distin As String
        Public NoDatas As Boolean
    End Structure
    Structure TickInfo
        Public TickCount As Integer
        Public CompCount As Integer
        Public NoFlwCount As Integer
        Public UnReadCount As Integer
        Public ClsCount As Integer
        Public Recved As Integer
        Public UpdtFollow As Integer
        Public UpdtColleg As Integer
        Public UpdtOthrs As Integer
        Public Esc1 As Integer
        Public Esc2 As Integer
        Public Esc3 As Integer
    End Structure
    Structure TickFld                                                    'Ticket Gridview Values
        Public Ser As Integer        'Columns(0)  "م"
        Public Sql As Integer        'Columns(1)  "SQL"
        Public Tick As Integer       'Columns(2)  "Ticket Kind"
        Public DtStrt As DateTime    'Columns(3)  "تاريخ الشكوى"
        Public TkId As String        'Columns(4)  "رقم الشكوى"
        Public Src As String         'Columns(5)  "مصدر الشكوى"
        Public ClNm As String        'Columns(6)  "اسم العميل"
        Public Ph1 As String         'Columns(7)  "تليفون العميل1"
        Public Ph2 As String         'Columns(8)  "تليفون العميل2"
        Public Email As String       'Columns(9)  "ايميل العميل"
        Public Adress As String         'Columns(10) "عنوان العميل"
        Public Card As String        'Columns(11) "رقم الكارت"
        Public Trck As String        'Columns(12) "رقم الشحنة"
        Public Gp As String          'Columns(13) "رقم أمر الدقع"
        Public NID As String         'Columns(14) "الرقم القومي"
        Public Amnt As Double        'Columns(15) "مبلغ العملية"
        Public TransDt As DateTime     'Columns(16) "تاريخ العملية"
        Public ProdK As String       'Columns(17) "نوع المنتج"
        Public ProdNm As String      'Columns(18) "نوع الخدمة"
        Public CompNm As String      'Columns(19) "نوع الشكوى"
        Public Orig As String        'Columns(20) "بلد الراسل"
        Public Dist As String        'Columns(21) "بلد المرسل إلية"
        Public Offic As String         'Columns(22) "اسم المكتب"
        Public Area As String        'Columns(23) "اسم المنطقة"
        Public Detls As String       'Columns(24) "تفاصيل الشكوى"
        Public ClsStat As Boolean    'Columns(25) "حالة الشكوى"
        Public FlwStat As Boolean    'Columns(26) "حالة المتابعة"
        Public UserId As Integer      'Columns(27) "كود متابع الشكوى"
        Public UsrNm As String       'Columns(28) "متابع الشكوى"
        Public RecvDt As DateTime     'Columns(16) "تاريخ استلام الشكوى"
        Public EscCnt As Integer     'Columns(36) عدد المتابعات
        Public LstUpSql As Integer   'Columns(29) "LstSqlEv"
        Public LstUpDt As DateTime   'Columns(30) "تاريخ آخر تحديث"
        Public LstUpTxt As String    'Columns(31) "نص آخر تحديث"
        Public LstUpUnRd As Boolean  'Columns(32) "TkupUnread"
        Public LstUpEvId As Integer  'Columns(33) "TkupEvtId"
        Public LstUpEnNm As String   'Columns(34) "EvNm"
        Public LstUpSys As Boolean   'Columns(35) "EvSusp"
        Public LstUpUsrNm As String 'Columns(36) "TkupUser"
        Public PrdKNm As String   'Columns(36) "نوع المنتج"
        Public Help_ As String   'Columns(36) "Help"
    End Structure
End Class
