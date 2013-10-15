<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="MainPage.aspx.cs" Inherits="WebUI.MainPage" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    	<div class="welcome">
        <div id="waitdiv" class="dcl">
            <h2>待处理</h2>
            <ul id="waitlist">

                <li id="task1" runat="server" visible="false" purview="task_confirm">
                    <asp:HyperLink ID="HyperLink2" runat="server"><img src="../images/li_01.png" />待确认任务<b>(<asp:Literal ID="Literal2" runat="server">0</asp:Literal>)</b></asp:HyperLink>
                   </li>
                <li id="task2" runat="server" visible="false" purview="tech_confirm"><a href="/tech/devemanage.aspx?status=1"><img src="../images/li_02.png" />待确认研发任务<b>(<asp:Literal ID="Literal3" runat="server">0</asp:Literal>)</b></a></li>
                <li id="task3" runat="server" visible="false" purview="order_confirm"><a href="/order/ordermanage.aspx?status=0"><img src="../images/li_03.png" />待确认订单<b>(<asp:Literal ID="Literal4" runat="server">0</asp:Literal>)</b></a></li>
                <li id="task4" runat="server" visible="false" purview="stock_add">
                     <asp:HyperLink ID="HyperLink3" runat="server"><img src="../images/li_04.png" />待入库任务<b>(<asp:Literal ID="Literal5" runat="server">0</asp:Literal>)</b></asp:HyperLink></li>
                
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
   <script type="text/javascript">
       $(document).ready(function () {
           if($("#waitlist").children().length==0)
           {
               $("#waitdiv").css("display","none");
           }
       });
   </script>
</asp:Content>