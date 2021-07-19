<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SmSActivation.aspx.vb" Inherits="VOCAPlus.SmSActivation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VOCA+ - Card Activation Via SmS</title>
        <style type="text/css">
        .auto-style1 {
            width: 390px;
            height: 112px;
        }
    </style>
     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

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
    <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
              <contenttemplate>

     <div style="text-align:center;margin-top:30px; width: 100%;direction:ltr">
         <asp:Table ID="ChoseTabl" runat="server" VerticalAlign="top" HorizontalAlign="center"  Width="95%" >
             <asp:TableRow VerticalAlign="top" width="100%">
                    <asp:TableCell HorizontalAlign="LEFT" Width="50%">
                        <img alt="" class="auto-style1" src="images/Post2.png" />
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" VerticalAlign="top" Width="50%" Wrap="false" >
                        <img alt="" src="images/VocaIcon2.ico" height="100" width="150" />
             </asp:TableCell>

         </asp:TableRow>
            <asp:TableRow VerticalAlign="top" HorizontalAlign="center" width="100%">
                     <asp:TableCell HorizontalAlign="Center" VerticalAlign="Top" Width="100%" Wrap="false" Font-Size="X-Large" columnspan="3" >
                 <h1 style="text-align:center;font-family:'Times New Roman';font-size:xx-large">SmS Card Activation Issues Collector</h1>
                    </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow ID="Crdentials0" VerticalAlign="top" HorizontalAlign="center" width="100%">
                  <asp:TableCell HorizontalAlign="center" VerticalAlign="Top" Width="50%" Wrap="false" Font-Size="X-Large" columnspan="3" >
 Your Email Address :<asp:TextBox ID="TxtMail" runat="server" TextMode="SingleLine" Width="166px"  Font-Size="12pt"></asp:TextBox><asp:Label ID="Label2" runat="server" Text="@egyptpost.org" ForeColor="#000099" Font-Size="12pt" ></asp:Label>  <br />                                  
                  </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="Crdentials" VerticalAlign="top" width="100%">
               <asp:TableCell HorizontalAlign="center" VerticalAlign="Top" Width="50%" Wrap="false" Font-Size="X-Large" columnspan="3" >
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
Password :<asp:TextBox ID="TxtPass" runat="server" TextMode="Password"  Width="166px"  Font-Size="12pt"  Font-Names="Tahoma"></asp:TextBox><br />  <asp:Button ID="Button1" runat="server" Text="Connect"  />
                </asp:PlaceHolder>
               </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="Colct" VerticalAlign="top" Visible="false" HorizontalAlign="Center" width="100%">

            <asp:TableCell HorizontalAlign="right" VerticalAlign="Top" Width="50%" Wrap="false" Font-Size="Large" >
Customer Name:<asp:TextBox ID="TxtClientName" runat="server" TextMode="SingleLine" Width="166px"  Font-Size="12pt"  Font-Names="Tahoma"></asp:TextBox><br />
Mobile:<asp:TextBox ID="TxtMobile" runat="server" TextMode="SingleLine" Width="166px"  Font-Size="12pt"  Font-Names="Tahoma"></asp:TextBox><br />
Card Number:<asp:TextBox ID="TxtCardNo" runat="server" TextMode="SingleLine" Width="166px"  Font-Size="12pt"  Font-Names="Tahoma"></asp:TextBox><br />
Card Number:<asp:TextBox ID="TxtNationalID" runat="server" TextMode="SingleLine" Width="166px"  Font-Size="12pt"  Font-Names="Tahoma"></asp:TextBox><br />
National:<asp:TextBox ID="Txt" runat="server" TextMode="SingleLine" Width="166px"  Font-Size="12pt"  Font-Names="Tahoma"></asp:TextBox><br />
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Vodafone</asp:ListItem>
                    <asp:ListItem>Orange</asp:ListItem>
                    <asp:ListItem>We</asp:ListItem>
                </asp:DropDownList>
                           <br /> <asp:Button ID="Button2"  runat="server" Text="Submit" />
            </asp:TableCell>
                                         <asp:TableCell HorizontalAlign="right" VerticalAlign="Top" Width="50%" Wrap="false" Font-Size="Large" >
                      <asp:Label runat="server" ID="LblUsr" Text="Usr" Font-Size="14pt"  ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ID="LblStat" Text="Status" Font-Size="14pt"  ForeColor="Black"></asp:Label>
                     </asp:TableCell>
                </asp:TableRow>
                </asp:Table>

     <asp:Label ID="Lbl" runat="server"></asp:Label><asp:Literal ID="Literal1" runat="server"></asp:Literal>
<script type="text/javascript">
    document.getElementById("TxtCardNo").value.length;
</script>

    
</div>

                          </contenttemplate>
                            <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="CLICK"/>
                      <asp:AsyncPostBackTrigger ControlID="Button2" EventName="CLICK"/>

                </Triggers>
                   </asp:UpdatePanel>
    </form>
</body>
</html>
