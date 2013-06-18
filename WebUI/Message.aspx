<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="WebUI.Message" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("Url") %>' Text='<%#Eval("Text") %>'></asp:HyperLink>
               
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
