<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="StockLogManage.aspx.cs" Inherits="WebUI.Stock.StockLogManage" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right_list">
      
        <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table3" id="table3">
            <tr>
                <th>ID</th>
                <th>任务编码</th>
                <th>入库时间</th>
                <th>订单类型</th>
                <th>销售负责人</th>
                <th>入库操作人</th>
                <th>入库说明</th>
                
                <th width="200">查看</th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("ID") %></td>
                        <td><%#Eval("Task.Code") %></td>
                        <td><%#((DateTime)Eval("AddTime")).ToString("yyyy-MM-dd") %></td>
                        <td><%#(bool)Eval("HasOrder") ?"有订单":"无订单" %></td>
                        <td><%#Eval("Task.SaleUserName") %></td>
                        <td><%#Eval("UserName") %></td>                     
                        <td><%#Eval("Description") %></td>
                        <td>
                            <i>
                                <bag:LinkButtonEx ID="lbDetail" runat="server" Text="查看明细" Purview="stock_manage" />
                            </i> </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
                
        </table>
          
        <div class="clear h10"></div>
    <bag:Pager ID="pager1" runat="Server" Width="100%" PageSize="20" GenerateGoToSection="true" OnCommand="pager_Command" PageClause="页码" GoToLastClause="上一页" NextToPageClause="下一页"/>
        <div class="clear h10"></div>
</div>

</asp:Content>
