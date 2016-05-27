<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MediaWebCenter.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Multimedia Manager Center v 1.0</title>
    <link href="styles/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" >
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <table>
                <tr>
                    <td colspan="3" rowspan="1">
                        <h2>
                        <asp:Label ID="Label1" runat="server" ForeColor="LightGray"
                            Text="Multimedia Manager Center v 1.0"></asp:Label>
                        </h2>        
                    </td>
                    
                </tr>
                <tr>
                    <td colspan="3">
                        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" width="660" height="400">
                            <param name="src" value="flash/Rotacion.swf">
                            <param name="quality" value="high">
                            <embed src="Flash/Rotacion.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="660" height="400"></embed>
                        </object>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                    <div class="divContainer" >
                                            <div class="divInnerContainer">
                                                <asp:Label ID="Label2" runat="server"
                                                    CssClass="label" Text="User name"></asp:Label>&nbsp;
                                                <asp:TextBox ID="tbx_UserName" CssClass="textbox" Height="12px" runat="server" Width="150px"></asp:TextBox>
                                           </div>
                                           <div class="divInnerContainer"> 
                                                <asp:Label ID="Label3" runat="server"
                                                    CssClass="label" Text="Password"></asp:Label>&nbsp;
                                                <asp:TextBox ID="tbx_Password" CssClass="textbox" Height="12px" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                                           </div>
                                           <div class="divInnerContainerButton"> 
                                                <asp:ImageButton ID="imb_Enter" runat="server" ImageUrl="~/images/start 45x45.png" CssClass="loginButton" OnClick="imb_Enter_Click" />
                                           </div>
                                   </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                </table>
     </div>
    </form>
</body>
</html>
