<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="vocasupport.aspx.vb" Inherits="VOCAPlus.vocasupport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VOCA+ Support Center</title>
    <link rel="icon" type="image/x-icon" href="images/Tool.jpeg" />
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
              <contenttemplate>

     <div style="text-align:center;margin-top:30px; width: 100%;direction:ltr">
       
         <asp:Table ID="ChoseTabl" runat="server" VerticalAlign="top" HorizontalAlign="center"  Width="95%" >
            <asp:TableRow VerticalAlign="top" width="100%">
                    <asp:TableCell HorizontalAlign="left" Width="50%">
                        <img alt="" class="auto-style1" src="images/Post2.png" height="100" width="350" />
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="right" VerticalAlign="top" Width="50%" Wrap="false" >
                        <img alt="" src="images/VocaIcon2.ico" height="100" width="150" />
             </asp:TableCell>

         </asp:TableRow>
            <asp:TableRow VerticalAlign="top" HorizontalAlign="center" width="100%" >
                     <asp:TableCell HorizontalAlign="Center" VerticalAlign="Top" Width="100%" Wrap="false" Font-Size="X-Large" ColumnSpan="3">
                 <h1 style="text-align:center;font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;font-size:xx-large">VOCA Support Center</h1>
                         <br />
                    </asp:TableCell>
         </asp:TableRow> 
            <asp:TableRow ID="UsrData" Visible="false" VerticalAlign="top" HorizontalAlign="left" Height="150" width="100%" >
              <asp:TableCell>

              </asp:TableCell>
                  <asp:TableCell HorizontalAlign="left"  VerticalAlign="Top" Width="75%" Wrap="false" Font-Size="X-Large"  >
Welcome :<asp:Label ID="LblUsrRNm" runat="server" Text="" ForeColor="#000099" ></asp:Label>  <br />                                
Team    :<asp:Label ID="LblUsrLeader" runat="server" Text="" ForeColor="#000099"  ></asp:Label>  <br />                                  
Category :<asp:Label ID="LblUsrCat" runat="server" Text="" ForeColor="#000099"  ></asp:Label>    <br />                              
Location :<asp:Label ID="LblLction" runat="server" Text="" ForeColor="#000099"  ></asp:Label>  
<asp:Label ID="LblUrId" runat="server" Visible ="false"  ></asp:Label> 
<asp:Label ID="LblUsNm" runat="server" Visible ="false"  ></asp:Label> 
                  </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="Crdentials0" VerticalAlign="top" HorizontalAlign="right"  width="100%">
<asp:TableCell HorizontalAlign="right" VerticalAlign="Top" Width="50%" Wrap="false" Font-Size="X-Large"  >
User Name :<asp:TextBox ID="TxtMail" runat="server" TextMode="SingleLine" Width="166px"  Font-Size="12pt" AutoCompleteType="Disabled"></asp:TextBox><br />   
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
Password :<asp:TextBox ID="TxtPass" runat="server" TextMode="Password"  Width="166px"  Font-Size="12pt"  Font-Names="Tahoma"></asp:TextBox><br />  <asp:Button ID="LogInBtn" runat="server" Text="Connect"  />
</asp:PlaceHolder>
                  </asp:TableCell>
        <asp:TableCell HorizontalAlign="center" VerticalAlign="Top" Width="50%" Wrap="false" Font-Size="X-Large"  >

        </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="Row1" Visible="false" HorizontalAlign="center"  VerticalAlign="Bottom" Height="50" >
                   <asp:TableCell HorizontalAlign="center" VerticalAlign="Top" Width="100%" Font-Size="Large"  >
                 <div style="direction:ltr">
                            <div style="float:left;margin-left:80px;font-size:xx-large">
                                <asp:RadioButton ID="RdRequest" font-size="X-Large" Text="Request" runat="server" AutoPostBack="True" /> <asp:RadioButton ID="RdIssue"  font-size="X-Large" Text="Issue" runat="server" AutoPostBack="True" />    
                            </div>      
                       <div style="float:right;margin-right:20px">
                           <asp:Button ID="BtnNxt1" runat="server" Font-Size="Larger" Width="90" Height="30" Text="Next >>" />
                       </div>
                         <div style="float:right;margin-right:20px">
                            
                       </div>
                </div>
                   </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="Row2" Visible="false" HorizontalAlign="center"  VerticalAlign="Bottom" Height="50" >
                   <asp:TableCell HorizontalAlign="left" VerticalAlign="Top" Width="100%"   >
                       <div style="direction:ltr">
                           <div style="margin-left:30px">
                                <asp:RadioButton ID="RdSlow"   font-size="X-Large" Text="Slow Performance" runat="server" AutoPostBack="True" /> <asp:RadioButton ID="RdErr"  font-size="X-Large" Text="Error" runat="server" AutoPostBack="True" />    
                            </div>      
                           <div style="margin-left:30px">
<asp:Label ID="Label1" runat="server" Font-Size="x-Large" Text="Screen Name"></asp:Label>  <asp:DropDownList ID="DropDownList1"  font-size="X-Large" runat="server" AutoPostBack="True"></asp:DropDownList>   
                               </div>   
                          <%-- <div style="margin-left:30px">
                                <asp:RadioButton ID="RdAttYes" Text="Attached" runat="server" AutoPostBack="True" /> <asp:RadioButton ID="RdAttNo" Text="No Attachment" runat="server" AutoPostBack="True" />    
                            </div> 
            <div style="margin-left:30px">
  <asp:PlaceHolder ID="PlaceHolder2" runat="server">
 <asp:FileUpload ID="FileUpload1" runat="server"  Width="213px" Enabled="False" />         <asp:Button ID="BtnUpload" runat="server" Text="Upload" Enabled="False" /> 
</asp:PlaceHolder>
                </div>--%>
                       <div style="float:right;margin-right:30px">
                      <asp:Button ID="BtnNxt2" runat="server" Font-Size="Larger" Width="90" Height="30" Text="Next >>" />
                       </div>
                         <div style="float:right;margin-right:20px">
                         <asp:Button ID="BtnBck1" runat="server" Font-Size="Larger" Width="90" Height="30" Text="<< Back" />
                       </div>
                </div>
                   </asp:TableCell>
            </asp:TableRow>                         
            <asp:TableRow ID="Row3" Visible="false" HorizontalAlign="center"  VerticalAlign="Bottom" Height="50" >
                   <asp:TableCell HorizontalAlign="left" VerticalAlign="Top" Width="100%" Font-Size="XX-Large"  >
                       <div style="direction:ltr">
                           <div style="margin-left:30px">
                             User Name :  <asp:TextBox ID="TxtusrName" runat="server"></asp:TextBox>
                            </div>      
                           <div style="margin-left:30px">

                            </div>   
                          <%-- <div style="margin-left:30px">
                                <asp:RadioButton ID="RdAttYes" Text="Attached" runat="server" AutoPostBack="True" /> <asp:RadioButton ID="RdAttNo" Text="No Attachment" runat="server" AutoPostBack="True" />    
                            </div> 
            <div style="margin-left:30px">
  <asp:PlaceHolder ID="PlaceHolder2" runat="server">
 <asp:FileUpload ID="FileUpload1" runat="server"  Width="213px" Enabled="False" />         <asp:Button ID="BtnUpload" runat="server" Text="Upload" Enabled="False" /> 
</asp:PlaceHolder>
                </div>--%>
                       <div style="float:right;margin-right:30px;">
                      <asp:Button ID="Button1" runat="server" Font-Size="Larger" Width="90" Height="30" Text="Next >>" />
                       </div>
                         <div style="float:right;margin-right:20px">
                         <asp:Button ID="Button2" runat="server" Font-Size="Larger" Width="90" Height="30" Text="<< Back" />
                       </div>
                </div>
                   </asp:TableCell>
            </asp:TableRow>      
            <asp:TableRow ID="Finsh" Visible="false" HorizontalAlign="center"  VerticalAlign="Middle"  >
             <asp:TableCell HorizontalAlign="center" VerticalAlign="Top" Width="100%"   >
           <div style="direction:ltr">
<div style="float:right;margin-left:80px;font-size:x-large">
            <asp:Label ID="L1" runat="server" Text="Dear " ForeColor="Black"> </asp:Label>
            <asp:Label ID="L2" runat="server" Text="Label" ForeColor="Green"></asp:Label>
            <asp:Label ID="L3" runat="server" Text=" You Have Selected to Submit " ForeColor="Black">  </asp:Label>
            <asp:Label ID="L4" runat="server" Text="Label" ForeColor="Green"></asp:Label>
            <asp:Label ID="L5" runat="server" Text=" That Seem as " ForeColor="Black">  </asp:Label>
            <asp:Label ID="L6" runat="server" Text="Label" ForeColor="Green"></asp:Label>
            <asp:Label ID="L7" runat="server" Text=" In " ForeColor="Black"></asp:Label>
            <asp:Label ID="L8" runat="server" Text="Label" ForeColor="Green"></asp:Label>
            <asp:Label ID="L9" runat="server" Text=" Screen of your PC with IP Address : " ForeColor="Black">  </asp:Label>
            <asp:Label ID="L10" runat="server" Text="Label" ForeColor="Green"></asp:Label>
            <asp:Label ID="L11" runat="server" Text=" From " ForeColor="Black"></asp:Label>
            <asp:Label ID="L12" runat="server" Text="Label" ForeColor="Green"></asp:Label>   
            <asp:Label ID="L13" runat="server" Text=" Site " ForeColor="Black"></asp:Label>
        </div>   
               </div>
                         </asp:TableCell>

          </asp:TableRow>
            <asp:TableRow ID="Finsh1" Visible="false" HorizontalAlign="center"  VerticalAlign="Middle"  >
                   <asp:TableCell HorizontalAlign="center" VerticalAlign="Top" Width="100%"   >
                              <div style="direction:ltr">
 <div style="float:left;margin-left:5px;">
       <asp:Label runat="server" Font-Size="Larger" Width="90" Height="30">Details :</asp:Label>
                            </div>
 <div style="float:left;width:80%;margin-left:5px;">
     <asp:TextBox ID="TxtDetails" runat="server" TextMode="MultiLine" Wrap="true" Width="60%" Height="100px"  Font-Size="X-Large" AutoCompleteType="Disabled"></asp:TextBox>                      
 </div>

 <div style="float:right;margin-right:20px">
      <asp:Button ID="BtnFnsh"  runat="server"  Font-Size="Larger" Width="90" Height="30"  Text="Finish"  OnClientClick="this.disabled = true;" UseSubmitBehavior="False" />
  </div>

       <div style="float:right;margin-right:20px">
                         <asp:Button ID="BtnBck2" runat="server" Font-Size="Larger" Width="90" Height="30" Text="<< Back" />
                       </div>
                              </div>
                   </asp:TableCell>
            </asp:TableRow>     
            <asp:TableRow ID="Submt" Visible="false" HorizontalAlign="center"  VerticalAlign="Middle"  >
                   <asp:TableCell HorizontalAlign="center" VerticalAlign="Top" Width="100%"   >


 <div style="direction:ltr">
 <div style="float:right;margin-right:20px">
      <asp:Button ID="BtnSubmit"  runat="server" BackColor="Green"   Font-Size="Larger" Width="90" Height="30" ForeColor="Yellow" Text="Submit"  OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
  </div>
                </div>
                   </asp:TableCell>
            </asp:TableRow>    
            <asp:TableRow ID="Rsult" Visible="False" HorizontalAlign="center"  VerticalAlign="Middle" Height="50" >
 <asp:TableCell HorizontalAlign="center" VerticalAlign="Top" Width="100%" Font-Size="Large"  >
                    <div style="direction:ltr">
                           <div style="float:unset;margin-left:80px">
<asp:Label ID="LblRslt" runat="server" Font-Bold="true" Font-Size="X-Large" Font-Names="Times New Roman">ff</asp:Label>
                            </div>    
 <br /> 
                    </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

           <br /> <asp:Label ID="Lbl" Font-Size="X-Large" runat="server"></asp:Label> 
<script type="text/javascript">
    document.getElementById("BtnSubmit").enabled = false;
</script>
</div>
                           </contenttemplate>
                            <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="LogInBtn" EventName="CLICK"/>
                    <asp:AsyncPostBackTrigger ControlID="BtnNxt1" EventName="CLICK"/>
                    <asp:AsyncPostBackTrigger ControlID="BtnNxt2" EventName="CLICK"/>
                    <asp:AsyncPostBackTrigger ControlID="BtnBck1" EventName="CLICK"/>
                    <asp:AsyncPostBackTrigger ControlID="BtnNxt2" EventName="CLICK"/>
                    <asp:AsyncPostBackTrigger ControlID="BtnBck2" EventName="CLICK"/>
                    <asp:AsyncPostBackTrigger ControlID="BtnSubmit" EventName="CLICK"/>
                    <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged"/>
                      </Triggers>
                   </asp:UpdatePanel>
<div style="direction:rtl;justify-content:space-between;position:fixed">

</div>
 
    </form>
</body>
</html>
