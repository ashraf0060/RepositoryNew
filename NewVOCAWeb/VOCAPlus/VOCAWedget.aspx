<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VOCAWedget.aspx.vb" Inherits="VOCAPlus.VOCAWedget" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VOCA Wedget</title>
  <link rel="icon" type="image/x-icon" href="images/graph.jpg" />
</head>
<body>
    <form id="form1" runat="server">
           <div style="text-align:center;margin-top:30px; width: 100%;direction:ltr">
               <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <contenttemplate>
                  <asp:TextBox ID="TextBox1" runat="server" Width="49px" Visible="False"></asp:TextBox>
                  <asp:Button ID="BtnPrv" runat="server" OnClick="BtnPrv_Click" style="height: 26px" Text="&lt;&lt; Previous" />
                  <asp:Button ID="BtnNxt" runat="server" OnClick="BtnNxt_Click" Text="Next &gt;&gt;" />
                  <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" />
              <asp:Table ID="ChoseTabl" runat="server" VerticalAlign="top" HorizontalAlign="center"  Width="95%" >
                           <asp:TableRow VerticalAlign="top" HorizontalAlign="Center" width="100%">
                            <asp:TableCell HorizontalAlign="center" columnspan="3">
      <asp:Label ID="Label1"  runat="server" style="text-align:center" Text=""  ViewStateMode="Enabled" Width="457px" Font-Bold="True" Font-Names="Times New Roman" Font-Size="XX-Large" ForeColor="#006600"></asp:Label>
                            </asp:TableCell>
                    </asp:TableRow>
         <asp:TableRow VerticalAlign="top" Height="400" width="100%">
             <asp:TableCell ID="TopPerformer1" VerticalAlign="Top" HorizontalAlign="center" width="67%"  ColumnSpan="3">
Chart Type : <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList> Refresh Rate: <asp:DropDownList ID="DropDownList2" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" runat="server"></asp:DropDownList><br />              
                 <asp:Chart ID="Chart1" runat="server" Height="300px" Width="500px" RightToLeft="Yes" >       
                <series>
                    <asp:Series Name="Series1" ChartArea="ChartArea1" ChartType="Pie" IsValueShownAsLabel="true">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                     <Area3DStyle Enable3D="true"  WallWidth="6"  />
                          <AxisX Title="Department"></AxisX>
                        <AxisY Title="Total Complaints"></AxisY>
                    </asp:ChartArea>
                </chartareas>
                     <Legends>
                    <asp:Legend Alignment="Center" Docking="Right" Name="LegendClass" Font="Microsoft Sans Serif, 12pt"></asp:Legend>
                </Legends>
            </asp:Chart>
                            </asp:TableCell>
                    </asp:TableRow>
 <%--XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX--%>

              </asp:Table>
 <%--<asp:Timer ID="Timer1" runat="server" Interval="180000" OnTick="Timer1_Tick"></asp:Timer>--%>
                <asp:Timer ID="Timer2" runat="server" Interval="15000" OnTick="Timer2_Tick"></asp:Timer>

</contenttemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick"/>
                <asp:AsyncPostBackTrigger ControlID="BtnPrv" EventName="Click"/>
                    <asp:AsyncPostBackTrigger ControlID="BtnNxt" EventName="Click"/>
                    <%--<asp:AsyncPostBackTrigger ControlID="DropDownList4" EventName="SelectedIndexChanged"/>--%>

                </Triggers>
      </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
