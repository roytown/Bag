<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="MainPage.aspx.cs" Inherits="WebUI.MainPage" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    	<div class="welcome">
        <div class="dcl">
            <h2>待处理</h2>
            <ul>

                <li id="task1" runat="server" purview="task_confirm"><a href="#"><img src="../images/li_01.png" />待确认任务<b>(3)</b></a></li>
                <li id="task2" runat="server" purview="tech_confirm"><a href="#"><img src="../images/li_02.png" />待确认研发任务<b>(3)</b></a></li>
                <li id="task3" runat="server" purview="order_confirm"><a href="#"><img src="../images/li_03.png" />待确认订单<b>(3)</b></a></li>
                <li id="task4" runat="server" purview="stock_add"><a href="#"><img src="../images/li_04.png" />待入库任务<b>(3)</b></a></li>
                
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