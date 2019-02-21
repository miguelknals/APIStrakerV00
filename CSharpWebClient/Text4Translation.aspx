<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Text4Translation.aspx.cs" Inherits="CSharpWebClient.Text4Translation" %>

<!DOCTYPE html>
<link rel="stylesheet" media="screen" href="APIStrakerV00.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
.auto-style1 { height: 28px;}
.auto-style2 { height: 25px; }

        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go to main" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2, title">Submits a text for translation</td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>The API translate/file method is done thru a POST<br />
                        used&nbsp;to submit a new text/file job. The parameter<br />
                        that&nbsp;must be passed is a source_file that follows the<br />
&nbsp;.NET RESX format (an XML simple format).</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>*Title</td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" Width="343px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>*Source language</td>
                    <td>
                        <asp:DropDownList ID="ddwSource" runat="server" Width="190px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>*Target language</td>
                    <td>
                        <asp:DropDownList ID="ddwTarget" runat="server" Width="190px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">*Text</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtText4Translate" runat="server" Height="114px" TextMode="MultiLine" Width="342px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Call back uri (URL for API post content and status)</td>
                    <td>
                        <asp:TextBox ID="txtUriCallBack" runat="server" Width="350px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Token</td>
                    <td>
                        <asp:TextBox ID="txtToken" runat="server" Width="350px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Job workflow</td>
                    <td>
                        <asp:DropDownList ID="ddwWorkFlow" runat="server" Width="260px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Reserved words (comma list of non translatable words)</td>
                    <td>
                        <asp:TextBox ID="txtReservedWords" runat="server" Width="260px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Priorty (1-lowest, 5-highest)</td>
                    <td>
                        <asp:DropDownList ID="ddwPiority" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Purchase Order</td>
                    <td>
                        <asp:TextBox ID="txtPurchaseOrder" runat="server" Width="350px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSend" runat="server" Text="Send job" OnClick="btnSend_Click" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
        <asp:Label ID="lblOut" runat="server"></asp:Label>
            <br />
        <table>
            <tr>
                <td>Note1: You can find more info about these fields in the 
                    <a href="https://help.strakertranslations.com/hc/en-us/articles/115004060414-Translate"  target="_blank" >Straker 
                        API Reference for Translate File and Translate Text</a> </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Note2: File should follow .NET RESX format. Example:&nbsp; </td>
            </tr>
            <tr>
                <td class="monospace pezquenina">
                    
                    &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;<br />
                    &lt;root&gt;<br />
                    &nbsp;&nbsp;&lt;data name=&quot;unique_identifier&quot;&gt;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&lt;value&gt;Welcome to the Straker Translations API&lt;/value&gt;<br />
                    &nbsp;&nbsp;&lt;/data&gt;<br />
                    &nbsp;&nbsp;&lt;data name=&quot;a_different_identifier&quot;&gt;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&lt;value&gt;Connecting to the straker translation system is easy&lt;/value&gt;<br />
                    &nbsp;&nbsp;&lt;/data&gt;<br />
                    &nbsp;&nbsp;&lt;data name=&quot;must_be_unique&quot;&gt;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&lt;value&gt;Remember to do all testing in the sandbox first&lt;/value&gt;<br />
                    &nbsp;&nbsp;&lt;/data&gt;<br />
                    &lt;/root&gt;
                        </td>
            </tr>
            <tr>
                <td>
                    
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    
                    You can find more information in the 
                    <a href="https://help.strakertranslations.com/hc/en-us/articles/115004087913-XML-Structure"  target="_blank" >Straker Developer Guide - 
                        XML Structure</a>.</td>
            </tr>
        </table>
            <br />
            <br />
            MIT License - Copyright 2019 miguel canals - <a href="http://www.mknals.com" target="_blank">www.mknals.com</a>
        </div>
    </form>
</body>
</html>
