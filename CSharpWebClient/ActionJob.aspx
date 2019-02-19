<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActionJob.aspx.cs" Inherits="CSharpWebClient.ActionJob" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblOut" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Retun to joblist" />
        </div>
    </form>
</body>
</html>
