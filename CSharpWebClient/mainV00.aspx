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
        .auto-style4 {
            height: 22px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td class="title title">CSharpWebClient for Straker APIs&nbsp; Demo</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Available APIs</td>
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
                        <asp:LinkButton ID="lnkbRetrieveJobs0" runat="server" OnClick="lnkbRetrieveJobs_Click">2 Submit a text for translation</asp:LinkButton>
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
                    <td class="auto-style4, title">Info</td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>These pages written in ASP.Net c# provide a simple interface to the 
                        <a href=https://help.strakertranslations.com/hc/en-us/categories/115000412453-stingRAY-Translation-API" target="_blank">Straker Translation API</a>.
                        Straker provides a Sandbox environment to run and these these API. <p>You can send a .Resx XML file or 
                            a text. The API will create a job to be processed inside Straker translation services.
                            In a real enviroment the job will be "COMPLETE" once the file is translated. In the demo 
                            we have to "COMPLETE" the jobs manually. The returned file will be
                            returned untranslated.</p>
                        <p>Related info:</p>
                        <ul><li>-You need to get a token for the Straker test sandbox 
                             <a href=https://help.strakertranslations.com/hc/en-us/articles/115004055314-Getting-Started" target="_blank">in this page</a>.                          
                            </li>
                            -In order to read more about the job flow,                                                      
                             <a href=https://help.strakertranslations.com/hc/en-us/articles/115004055334-How-it-Works" target="_blank">read this page</a>.                          
                            </li>
                            <li>-These pages do not use any async feature and for clarity sake do not have any error verification.</li>
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
