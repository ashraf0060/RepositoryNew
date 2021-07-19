<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VocaReportingService.aspx.vb" Inherits="VOCAPlus.VocaReportingService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
     <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>VOCA Reporting Service</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css" />
      <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
      <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
      $(function () {
          $("#datepickerFrom").datepicker({
            dateFormat: "yy/mm/dd",
          });

      });
      $(function () {
          $("#datepickerTo").datepicker({
              dateFormat: "yy/mm/dd",
          });

      });
  </script>




    <style type="text/css">
        </style>

</head>
<body>
    <form id="form1" runat="server">
        <div  >
             <br />
            <div dir="rtl">
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="3"  RepeatDirection="Horizontal" Width="700px" TextAlign="right">
  
            </asp:CheckBoxList>
                </div>
            <p>Date From: <input type="text" id="datepickerFrom" runat="server"  /></p>  <p>Date TO: <input type="text" id="datepickerTo" runat="server" /></p>
            <br />

  <asp:Button ID="BtnPrv" runat="server" Text="Button" />  <asp:Button ID="Button1" runat="server" Text="Export" />
            <br />
            <asp:Label ID="Lbl" Font-Size="X-Large" runat="server"></asp:Label><asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
        
    </form>
</body>
</html>
