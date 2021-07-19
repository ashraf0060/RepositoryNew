<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomSearch.aspx.vb" Inherits="VOCAPlus.CustomSearch" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <title>VOCA+ - Custom Search</title>

        <script type="text/javascript">

            

           function ClearWaterMark(defaultText, textBoxControl) {
               if (textBoxControl.value == defaultText)
               {
                   textBoxControl.value = "";
                   textBoxControl.style.color = "black";
               }
           }
           function CreateWaterMark(defaultText, textBoxControl) {
               if (textBoxControl.value.length == 0)
               {
                   textBoxControl.value = defaultText;
                   textBoxControl.style.color = "gray";

               }
           }
        </script>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
     <style type="text/css">

	   .Blink-me{

           direction:ltr;
           text-align:right;
            color:red;
		   animation-name: blinker;
		   animation-duration:4s;
		   animation-timing-function:linear;
		   animation-iteration-count:infinite;
	   }
        .Blink-me1{

           direction:ltr;
           text-align:center;
            color:red;
		   animation-name: blinker;
		   animation-duration:2s;
		   animation-timing-function:linear;
		   animation-iteration-count:infinite;
	   }
	   @keyframes blinker
	   {
		   0%{opacity: 1.0}
		   50%{opacity: 0.0}
		   100%{opacity: 1.0}
	   }
	  </style>
    <!--<link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">-->

    <link rel="stylesheet" href="css/animate.css">

    <link rel="stylesheet" href="css/owl.carousel.min.css">
    <link rel="stylesheet" href="css/owl.theme.default.min.css">
    <link rel="stylesheet" href="css/magnific-popup.css">

    <link rel="stylesheet" href="css/flaticon.css">
    <link rel="stylesheet" href="css/style.css">
</head>
<body>
    <div class="wrap">
        <div class="container">
            <div class="row justify-content-between">
                <div class="col">
                    <p class="mb-0 phone"><span class="fa fa-phone"></span> <a href="">+2 010-288-33-428 </a></p>
                </div>
                <div class="col d-flex justify-content-end">
                    <div class="social-media">
                        <p class="mb-0 d-flex">
                            <a href="" class="d-flex align-items-center justify-content-center"><span class="fa fa-facebook"><i class="sr-only">Facebook</i></span></a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <nav class="navbar navbar-expand-lg navbar-dark ftco_navbar bg-dark ftco-navbar-light" id="ftco-navbar">
        <div class="container">
            <a class="navbar-brand" href="">VOCA<span>+</span></a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#ftco-nav" aria-controls="ftco-nav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="fa fa-bars"></span> Menu
            </button>
            <div class="collapse navbar-collapse" id="ftco-nav">
                <ul class="navbar-nav m-auto">
                    <li class="nav-item"><a href="VOCAPlus.aspx" class="nav-link">Home</a></li>
                    <li class="nav-item"><a href="about.html" class="nav-link">About</a></li>
                    <li class="nav-item active"><a href="CustomSearch.aspx" class="nav-link">Custom Search</a></li>
                    <li class="nav-item"><a href="History.html" class="nav-link">History</a></li>
                    <li class="nav-item"><a href="Stories.html" class="nav-link">Stories</a></li>
                    <li class="nav-item"><a href="ContactUS.aspx" class="nav-link">Contact US</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <!-- END nav -->

                     

    <section >
               <form id="form1" runat="server"> 
                   <div style="margin-top:5px;width:60%;margin-left:20%;margin-right:20%">
                                <asp:Image ID="Image2" runat="server"  ImageUrl="~/images/VocaA.jpg" Width="800" Height="150" />
                   </div>

            <asp:Table ID="ChoseTabl" runat="server" HorizontalAlign="Right" Width="95%" Height="20px">

                   <asp:TableRow VerticalAlign="Bottom" Height="50">
                        <asp:TableCell HorizontalAlign="left" Width="20%">
                          <h8>Last Update: 08:00 PM Thursday, Apr. 30, 2020</h8> 
                            <br />
      <%--                      <img src="images/new-gif-blinking.gif" alt="gif image" />--%>
                             <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/images/Ramadan.jpeg" Width="250" Height="150" />--%>
                </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center" VerticalAlign="Bottom" Width="10%" Wrap="false" Font-Size="X-Large">
                    <asp:RadioButton ID="RadPrison" runat="server" AutoPostBack="True" Text="أمانات السجون" ForeColor="Black" TextAlign="Left" />
                </asp:TableCell>
                       <asp:TableCell HorizontalAlign="Center"  VerticalAlign="Bottom"  Width="10%" Wrap="false" Font-Size="X-Large">
                    <asp:RadioButton ID="RadATM" runat="server" AutoPostBack="True" Text="ماكينات الصراف الآلي" ForeColor="Black" TextAlign="Left" ViewStateMode="Enabled" />
                </asp:TableCell>
                       <asp:TableCell HorizontalAlign="Center"  VerticalAlign="Bottom"  Width="10%" Wrap="false" Font-Size="X-Large" >
                    <asp:RadioButton ID="RadOff" runat="server" AutoPostBack="True" Text="مكاتب البريد"  ForeColor="Black" TextAlign="Left" /> 
                </asp:TableCell>
                   </asp:TableRow>
             </asp:Table>
        <asp:Table ID="OffTabl" runat="server" HorizontalAlign="Center" Width="95%" Height="201px">
             <asp:TableRow VerticalAlign="Top" HorizontalAlign="Right">
                        <asp:TableCell HorizontalAlign="right" VerticalAlign="Top" Width="20%">
                            
                            <%--<asp:Image ID="Img50" runat="server" ImageUrl="~/images/50.jpg" Height="350" ImageAlign="Right" Width="250" />--%>
                            <asp:Image ID="Img1" runat="server" ImageUrl="~/images/50-52.jpg" Width="250" Height="350" />
                         </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center" VerticalAlign="Top" Width="80%">
                             <h1 style="direction:ltr;text-align:right;color:black">مواعيد عمل مكاتب البريد خلال الأزمة الحالية</h1>
<%--                         <h5 class="Blink-me" >ملحوظة : عدد المكاتب المدرج أسمائها 3838 مكتب على مستوى الجمهورية</h5> --%>
                             <br />
                <div style="margin-left:5%;margin-right:5%;text-align:center;direction:ltr">
            <div style="float:right;padding-right:20px">
                 <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" Text="فلتر" Font-Size="Medium" ForeColor="Black" TextAlign="Left" />
            </div>
            <div style="float:right;padding-right:20px">
                        <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" Text="بحث بالاسم" Font-Size="Medium" ForeColor="Black" TextAlign="Left" />
            </div>
            <div style="float:right;padding-right:20px">
                <asp:TextBox ID="TextBox10" runat="server"  dir="rtl" height="30px"  Width="235px" ForeColor="gray" onblur="CreateWaterMark('البحث باسم المكتب / المنطقة',this);" onfocus="ClearWaterMark('البحث باسم المكتب / المنطقة',this);" ViewStateMode="Enabled">البحث باسم المكتب / المنطقة</asp:TextBox> 
            </div>
            <div style="float:right;padding-right:20px">
         <asp:Button ID="Button1" runat="server" Text="بحث" height="30px" Width="61px" AutoPostBack="true"  />
                </div>

        <br />
             <div style="float:right;padding-right:20px">
        <asp:ListBox ID="AreaList" runat="server" AutoPostBack="True" Height="150px" Width="150px" dir="rtl" forecolor="White" BackColor="#2E3842" Font-Bold="True" Font-Size="12pt" Font-Names="Times New Roman" DataTextField="offArea"></asp:ListBox>
                </div>
            <div style="float:right;padding-right:20px">
        <asp:ListBox ID="TimeList" runat="server" DataSourceID="WTimeDataSource" DataTextField="WorkingTime" AutoPostBack="True" Height="150px" Width="150px" dir="rtl"  forecolor="White" BackColor="#2E3842" Font-Bold="True" Font-Size="12pt" Font-Names="Times New Roman"></asp:ListBox>
                </div>
         <div style="float:right;padding-right:20px;text-align:right">
        <asp:ListBox ID="WeekEndList" runat="server" DataSourceID="WekEndDataSource" DataTextField="WeekEnd" AutoPostBack="True" Height="150px" Width="150px" dir="rtl"  forecolor="White" BackColor="#2E3842" Font-Bold="True" Font-Size="12pt" Font-Names="Times New Roman"></asp:ListBox>
             </div>

        <asp:SqlDataSource ID="AreaOffGridSource0" runat="server" ConnectionString="<%$ ConnectionStrings:PostOfficesConnectionString %>" SelectCommand="SELECT OffArea, OffNm1, WorkingTime, WeekEnd, WorkingDays FROM PostOff WHERE (OffArea Like N'%' + @p1 + N'%') OR (OffNm1 LIKE N'%' + @P2 + N'%') ORDER BY OffArea, OffNm1"><SelectParameters><asp:ControlParameter ControlID="TextBox10" Name="p1" PropertyName="Text" /><asp:ControlParameter ControlID="TextBox10" Name="P2" PropertyName="Text" /></SelectParameters></asp:SqlDataSource>

        <asp:SqlDataSource ID="WTimeDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:PostOfficesConnectionString %>" SelectCommand="SELECT WorkingTime FROM PostOff WHERE (OffArea = @Area) GROUP BY WorkingTime ORDER BY WorkingTime"><SelectParameters><asp:ControlParameter ControlID="AreaList" Name="Area" PropertyName="SelectedValue" DbType="String" /></SelectParameters></asp:SqlDataSource>

        
        <asp:SqlDataSource ID="AreaOffDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:PostOfficesConnectionString %>" SelectCommand="SELECT OffArea FROM PostOff GROUP BY OffArea ORDER BY OffArea"></asp:SqlDataSource>

        <asp:SqlDataSource ID="WekEndDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:PostOfficesConnectionString %>" SelectCommand="SELECT WeekEnd, WorkingTime FROM PostOff WHERE (OffArea = @Area) GROUP BY WeekEnd, WorkingTime HAVING (WorkingTime = @Time) ORDER BY WeekEnd"><SelectParameters><asp:ControlParameter ControlID="AreaList" Name="Area" PropertyName="SelectedValue" DbType="String" /><asp:ControlParameter ControlID="TimeList" Name="Time" PropertyName="SelectedValue" /></SelectParameters></asp:SqlDataSource>        
        
        <asp:SqlDataSource ID="AreaOffGridSource" runat="server" ConnectionString="<%$ ConnectionStrings:PostOfficesConnectionString %>" SelectCommand="SELECT OffArea, OffNm1, WorkingTime, WeekEnd, WorkingDays FROM PostOff WHERE (OffArea = @p1)"><SelectParameters><asp:ControlParameter ControlID="AreaList" Name="p1" PropertyName="SelectedValue" /></SelectParameters></asp:SqlDataSource>
        
        <asp:SqlDataSource ID="AreaOffGridSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PostOfficesConnectionString %>" SelectCommand="SELECT OffArea, OffNm1, WorkingTime, WeekEnd, WorkingDays FROM PostOff WHERE (OffArea = @p1) AND (WorkingTime = @p2)"><SelectParameters><asp:ControlParameter ControlID="AreaList" Name="p1" PropertyName="SelectedValue" /><asp:ControlParameter ControlID="TimeList" Name="p2" PropertyName="SelectedValue" /></SelectParameters></asp:SqlDataSource>
        <asp:SqlDataSource ID="AreaOffGridSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PostOfficesConnectionString %>" SelectCommand="SELECT OffArea, OffNm1, WorkingTime, WeekEnd, WorkingDays FROM PostOff WHERE (OffArea = @p1) AND (WorkingTime = @p2) AND (WeekEnd = @p3)"><SelectParameters><asp:ControlParameter ControlID="AreaList" Name="p1" PropertyName="SelectedValue" /><asp:ControlParameter ControlID="TimeList" Name="p2" PropertyName="SelectedValue" /><asp:ControlParameter ControlID="WeekEndList" Name="p3" PropertyName="SelectedValue" /></SelectParameters></asp:SqlDataSource>
</div>
                    </asp:TableCell>
             </asp:TableRow>
            <asp:TableRow VerticalAlign="Bottom" HorizontalAlign="Right">
                <asp:TableCell>

                </asp:TableCell>
                <asp:TableCell>
                             <div >
    <asp:GridView runat="server" AutoGenerateColumns="False" ID="Result_" HorizontalAlign="Center" Font-Names="Times New Roman" ForeColor="Black" HeaderStyle-HorizontalAlign="Center" Font-Bold="True" Font-Size="12">
                                <Columns>
                    
                    <asp:BoundField DataField="WeekEnd" HeaderText="أيام الأجازة" />
                    
                    <asp:BoundField DataField="WorkingTime" HeaderText="مواعيد العمل" />
                    
                    <asp:BoundField DataField="WorkingDays" HeaderText="أيام العمل" SortExpression="WorkingTime" />
                    
                    <asp:BoundField DataField="OffNm1" HeaderText="اسم المكتب" SortExpression="OffNm1" />
                    
                    <asp:BoundField DataField="OffArea" HeaderText="اسم المنطقة" />                    
                </Columns>
                <RowStyle HorizontalAlign="Right" VerticalAlign="Middle" />
        </asp:GridView>
</div>
                </asp:TableCell>

                </asp:TableRow>
        </asp:Table>

        <asp:Table ID="ATMTabl" runat="server" HorizontalAlign="Center" Width="95%" Height="201px">
            <asp:TableRow>
                        <asp:TableCell HorizontalAlign="center" VerticalAlign="Top" Width="20%">
                    <asp:Image ID="Img5" runat="server" ImageUrl="~/images/ATM.jpg" Height="350" ImageAlign="Right" Width="250" />
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="center" dir="ltr"  VerticalAlign="Top">
                             <h5  >ملحوظة : ماكينات الصراف الآلي على مستوى الجمهورية تعمل على مدار الـ 24 ساعة</h5> 
                                         <h5 class="Blink-me1" >إبتداء من 1 مـــــايـــــو</h5> 
                            <h5 > صرف المعاشات متاح لجميع فئات أصحاب المعاشات على ماكينات الصراف الآلي </h5> 

                <asp:DropDownList ID="AreaDropATM"  runat="server" AutoPostBack="True" DataSourceID="AreaDataSource" DataTextField="OffArea" DataValueField="OffArea" Width="150px" ViewStateMode="Enabled" dir="rtl" Font-Size="14" Font-Bold="True"></asp:DropDownList>
        <asp:SqlDataSource ID="AreaDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:PostOfficesConnectionString %>" SelectCommand="SELECT OffArea FROM ATM GROUP BY OffArea"></asp:SqlDataSource>
                            <br />
                            <br />
                <%--     <div style="margin-left:5%;margin-right:5%;text-align:right">--%>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ATMDataSource1"  Font-Names="Times New Roman" ForeColor="Black" RowStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" Font-Bold="True" Font-Size="12">
            <Columns>
                <asp:BoundField DataField="Address" HeaderText="العنوان" SortExpression="Address" />
                <asp:BoundField DataField="WorkingTime" HeaderText="مواعيد عمل المكتب" SortExpression="WorkingTime" />
                <asp:BoundField DataField="OffNm1" HeaderText="اسم المكتب" SortExpression="OffNm1" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="ATMDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PostOfficesConnectionString %>" SelectCommand="SELECT OffNm1, WorkingTime, Address FROM ATM WHERE (OffArea = @p)">
            <SelectParameters>
                <asp:ControlParameter ControlID="AreaDropATM" Name="p" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
                                                <%--    </div>--%>
                        </asp:TableCell>
                            </asp:TableRow>
                        <asp:TableRow>
                                <asp:TableCell>
                                   </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="right" Width="80%">
                                           <%--<div style="margin-left:5%;margin-right:5%;text-align:center;direction:ltr">--%>
        
                                    <%--</div>--%>
                            </asp:TableCell>
               
                        </asp:TableRow>
          
        </asp:Table>
                
        <asp:Table ID="PrisonTabl" runat="server" HorizontalAlign="Center" Width="95%" Height="201px">
                       <asp:TableRow VerticalAlign="Top" HorizontalAlign="Right">
                           <asp:TableCell HorizontalAlign="right" VerticalAlign="Top" Width="20%">
                                <asp:Image ID="ImgPrison" runat="server" ImageUrl="~/images/Prison1.jpg" Height="350" ImageAlign="Right" Width="250" />
                           </asp:TableCell>
                           <asp:TableCell HorizontalAlign="right" VerticalAlign="Top" Width="100%">
                               <div style="margin-left:5%;margin-right:5%;direction:ltr">
                                   <div style="float:right;padding-right:20px">
                                            <asp:TextBox ID="PrisonTxBox" runat="server"  dir="rtl" height="30px"  Width="235px" ForeColor="gray" onblur="CreateWaterMark('البحث باسم السجن',this);" onfocus="ClearWaterMark('البحث باسم السجن',this);" ViewStateMode="Enabled">البحث باسم السجن</asp:TextBox> 
                                        </div>
                                        <div style="float:right;padding-right:20px">
                                     <asp:Button ID="Button2" runat="server" Text="بحث" height="30px" Width="61px" AutoPostBack="true"  />
                                            </div>
                                        
                               
                                    <div style="text-align:right;margin-left:5%;margin-right:5%;direction:ltr">
                                   <asp:GridView ID="PrisonGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Name" DataSourceID="PrisonDataSource" HorizontalAlign="Center" Font-Names="Times New Roman" Font-Size="12pt" ForeColor="Black" ViewStateMode="Enabled" Font-Bold="True">
                        <Columns>
                            <asp:BoundField DataField="AccNo" HeaderText="رقم الحساب" SortExpression="AccNo" />
                            <asp:BoundField DataField="Name" HeaderText="اسم السجن" ReadOnly="True" SortExpression="Name" />

                        </Columns>
                        <HeaderStyle Font-Names="Times New Roman" Font-Size="12pt" HorizontalAlign="Center" Wrap="False" />
                   </asp:GridView>
        <asp:SqlDataSource ID="PrisonDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:PostOfficesConnectionString %>" SelectCommand="SELECT Name, AccNo FROM Prisons WHERE (Name LIKE N'%' + @p + N'%')">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="PrisonTxBox" Name="p" PropertyName="Text" />
                        </SelectParameters>
                   </asp:SqlDataSource>
                                        </div>
                                        </div>
                 
                           </asp:TableCell>
                       </asp:TableRow>
                       <asp:TableRow VerticalAlign="Top" HorizontalAlign="Right">
                           <asp:TableCell HorizontalAlign="right" VerticalAlign="Top" Width="20%">
                                
                           </asp:TableCell>
                        <asp:TableCell HorizontalAlign="right" VerticalAlign="Top" Width="80%">
                        
                           </asp:TableCell>
                            </asp:TableRow>
                   </asp:Table>


                    <hr />
            </form>
    </section> <!-- .section -->
    <footer class="footer">
        <div class="container-fluid px-lg-5">
            <div class="row">
                <div class="col-md-9 py-5">
                    <div class="row">
                        <div class="col-md-4 mb-md-0 mb-4">
                            <h2 class="footer-heading">About us</h2>
                            <p>We will Not Lose a Single Customer Because We Didn’t Care.</p>
                            <ul class="ftco-footer-social p-0">

                                <li class="ftco-animate"><a href="" data-toggle="tooltip" data-placement="top" title="Facebook"><span class="fa fa-facebook"></span></a></li>

                            </ul>
                        </div>
                        <div style="margin-left:35%">
                            <div class="bio mr-5">
                                <%--<img src="images/voca256.ico" alt="Image placeholder" class="img-fluid mb-4">--%>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-md-5">
                        <div class="col-md-12">
                            <p class="copyright">
                                <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                                Copyright &copy;
                                <script>document.write(new Date().getFullYear());</script> Ashraf Farag
                                <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </footer>



    <!-- loader -->
    <div id="ftco-loader" class="show fullscreen"><svg class="circular" width="48px" height="48px"><circle class="path-bg" cx="24" cy="24" r="22" fill="none" stroke-width="4" stroke="#eeeeee" /><circle class="path" cx="24" cy="24" r="22" fill="none" stroke-width="4" stroke-miterlimit="10" stroke="#F96D00" /></svg></div>


    <script src="js/jquery.min.js"></script>
    <script src="js/jquery-migrate-3.0.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.easing.1.3.js"></script>
    <script src="js/jquery.waypoints.min.js"></script>
    <script src="js/jquery.stellar.min.js"></script>
    <script src="js/jquery.animateNumber.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/jquery.magnific-popup.min.js"></script>
    <script src="js/scrollax.min.js"></script>
    <script src=""></script>
<%--    <script src="js/google-map.js"></script>--%>
    <script src="js/main.js"></script>




</body>
</html>
