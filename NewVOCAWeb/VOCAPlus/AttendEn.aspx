<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AttendEn.aspx.vb" Inherits="VOCAPlus.AttendEn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VOCA+ - Attendance System</title>
        <style type="text/css">
        .auto-style1 {
            width: 390px;
            height: 112px;
        }
    </style>
     <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!--<link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">-->

    <link rel="stylesheet" href="css/animate.css">

    <link rel="stylesheet" href="css/owl.carousel.min.css"/>
    <link rel="stylesheet" href="css/owl.theme.default.min.css"/>
    <link rel="stylesheet" href="css/magnific-popup.css"/>

    <link rel="stylesheet" href="css/flaticon.css"/>
    <link rel="stylesheet" href="css/style.css"/>
</head>
<body>
    <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate >
     <div style="text-align:center;margin-top:30px; width: 100%;direction:ltr">
         <asp:Table ID="ChoseTabl" runat="server" VerticalAlign="top" HorizontalAlign="center"  Width="95%" >

             <asp:TableRow VerticalAlign="top" width="100%">
                    <asp:TableCell HorizontalAlign="LEFT" Width="50%">
                        <img alt="" class="auto-style1" src="images/Post2.png" />
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="right" VerticalAlign="top" Width="50%" Wrap="false" >
                        <img alt="" src="images/VocaIcon2.ico" height="100" width="150" />
                      <ul class="navbar-nav m-auto">
                    <li class="nav-item"><a href="http://10.10.26.4:8000/attendance.aspx" class="nav-link" style="color:red;font-size:large;margin-top:30px; font-family: 'Lucida Handwriting'; font-weight: 900; text-decoration: underline overline blink;">اللغة العربية</a></li>
                          </ul>
             </asp:TableCell>

         </asp:TableRow>
            <asp:TableRow VerticalAlign="top" HorizontalAlign="center" width="100%">
                     <asp:TableCell HorizontalAlign="Center" VerticalAlign="Top" Width="100%" Wrap="false" Font-Size="X-Large" columnspan="3">
                 <h1 style="text-align:center;font-family:'Times New Roman';font-size:xx-large">Customer Service Sector 's Attendance System</h1>
                       <asp:Label ID="Label5" runat="server" ViewStateMode="Enabled" Width="457px" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" ForeColor="#006600"></asp:Label>
            <br />
                       <asp:Label ID="Label1" runat="server" ViewStateMode="Enabled" Width="262px" Font-Bold="True" Font-Names="Bookman Old Style" ForeColor="#000066" Font-Size="X-Large"></asp:Label>
            <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="27px" Width="271px" BorderStyle="None" OnTextChanged="TextBox1_TextChanged" AutoPostBack="True" BorderColor="Black" ForeColor="Black" onpaste="return false" TextMode="Password" style="text-align: center" ></asp:TextBox>  
           <br />
            <asp:Label ID="Label2" runat="server" Width="750px" style="" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" ></asp:Label>  <br />
                <asp:Label ID="Label3" runat="server" Width="400px"  style="text-align: center;direction:rtl" Font-Size="X-Large"></asp:Label> <br />
              <asp:Label ID="Label4" runat="server"  Width="400px" style="text-align:center ;direction:rtl" Font-Size="X-Large"></asp:Label>
                    </asp:TableCell>

            </asp:TableRow>
                </asp:Table>
</div>



<%--/XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/--%>



      

 <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
 <asp:Timer ID="Timer2" runat="server" Interval="5000" Enabled="False" OnTick="Timer2_Tick"></asp:Timer>

            
            <br />
                      </ContentTemplate>
             
         </asp:UpdatePanel>




    </form>
</body>
</html>
