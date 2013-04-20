<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListingDBTest.aspx.cs" Inherits="Test_Pages_ListingDBTest" %>

<!DOCTYPE html>

<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="OUT" runat="server"></asp:Label>

        <asp:Label ID="Test" runat="server"></asp:Label>
        <asp:Button ID="TestButton" runat="server" OnClick="TestButton_Click" />
    </div>
    </form>
</body>
</html>
