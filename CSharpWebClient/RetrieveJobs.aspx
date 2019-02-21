<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetrieveJobs.aspx.cs" Inherits="CSharpWebClient.RetrieveJobs" %>

<!DOCTYPE html>
<link rel="stylesheet" media="screen" href="APIStrakerV00.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go to main" />
                    </td>
                </tr>
                <tr>
                    <td class="title">Retrieve jobs</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Here is the list of submited jobs:</td>
                </tr>
                <tr>
                    <td>In a production environment QUEUED jobs should become complete thru the Straker translation process. In this demo in order to emulate the &quot;translation&quot; processo you should press the &quot;COMPLETE&quot; link. After that the column will have the url of the translated file.</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <asp:GridView class="pezquenina" ID="gdvJobs" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblOut" runat="server"></asp:Label>
        <br />
            MIT License - Copyright 2019 miguel canals - <a href="http://www.mknals.com" target="_blank">www.mknals.com</a> 
    </form>
</body>
</html>
