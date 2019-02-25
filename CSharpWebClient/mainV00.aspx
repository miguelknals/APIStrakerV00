<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mainV00.aspx.cs" Inherits="CSharpWebClient.mainV00" %>

<!DOCTYPE html>
<link rel="stylesheet" media="screen" href="APIStrakerV00.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td class="title">CSharpWebClient for Straker APIs&nbsp; Demo</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Web interface demo for Straker APIs:</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkbFileJob4Translation" runat="server" OnClick="lnkbFileJob4Translation_Click">1 Submits a file job for translation</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkbText4Translation" runat="server" OnClick="Text4Translation_Click">2 Submit a text for translation</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkbRetrieveJobs" runat="server" OnClick="lnkbRetrieveJobs_Click">3 Retrieves a list of jobs </asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkListAvailableLanguages" runat="server" OnClick="lnkListAvailableLanguages_Click">4 Gets the list of available languages.</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkShowHidePanel" runat="server" OnClick="lnkShowHidePanel_Click">LinkButton</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlSettings" runat="server">
                            <table>
                                <tr>
                                    <td>Host</td>
                                    <td>
                                        <asp:TextBox ID="txtHost" runat="server" Width="311px">https://sandbox.strakertranslations.com:443</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Token</td>
                                    <td>
                                        <asp:TextBox ID="txtToken" runat="server" Width="312px">9E839CBE-E581-4BB6-B5B792BF0E1C15B3</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnSaveCookies" runat="server" Text="Save variables" OnClick="btnSaveCookies_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1"></td>
                                    <td class="auto-style1">
                                        <asp:Label ID="lblCookie" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                </table>
                        <asp:Label ID="lblOut" runat="server"></asp:Label>
                    <br />
                    <br />
            <table style="width:100%;">
                <tr>
                    <td>

<h4 id="1-6-mit-license">More info...</h4>
<ul>
<li>For more info visit my page <a href="http://www.mknals.com/04_4_CSharpWebClient.html" target="_blank">CSharpWebClient for Straker APIs Demo</a> or the github  <a href="https://github.com/miguelknals/APIStrakerV00" target="_blank">https://github.com/miguelknals/APIStrakerV00</a>. </li>
<li>Feel free to contact me if you want miguelknals at gmail dot com. </li>
</ul>



                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            MIT License - Copyright 2019 miguel canals - <a href="http://www.mknals.com" target="_blank">www.mknals.com</a> 
        </div>
    </form>
</body>
</html>
