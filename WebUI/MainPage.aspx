<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="MainPage.aspx.cs" Inherits="WebUI.MainPage" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    	<div class="welcome">
        <div class="dcl">
            <h2>待处理</h2>
            <ul>

                <li><a href="#"><img src="../images/li_01.png" />待办事项<b>(3)</b></a></li>
                <li><a href="#"><img src="../images/li_02.png" />未查看消息<b>(3)</b></a></li>
                <li><a href="#"><img src="../images/li_03.png" />待审核任务<b>(3)</b></a></li>
                <li><a href="#"><img src="../images/li_04.png" />新接收任务<b>(3)</b></a></li>
                <li><a href="#"><img src="../images/li_05.png" />新订单<b>(3)</b></a></li>
            </ul>
        </div>
        <div class="kjcz">
            <h2>快捷操作</h2>
            <ul>
                <asp:Repeater ID="RptShortCuts" runat="server" OnItemDataBound="RptShortCuts_ItemDataBound">
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink ID="HyperLink1" runat="server">
                                <span><asp:Image ID="Image1" runat="server" /></span><b><asp:Literal ID="Literal1" runat="server"></asp:Literal></b>
                            </asp:HyperLink>
                         </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
   
</asp:Content>