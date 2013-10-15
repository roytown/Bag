<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="OrderManage.aspx.cs" Inherits="WebUI.Order.OrderManage" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right_list">
      
            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table3" id="table3">
                <tr>
                    <th>ID</th>
                    <th>时间要求</th>
                    <th>数量要求</th>
                    <th>其他说明</th>
                    <th>发布人</th>
                    <th>生产负责人</th>
                    <th>质检负责人</th>
                    <th>提交时间</th>
                    <th>订单状态</th>
                    <th width="200">操作</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("ID") %></td>
                            <td><%#((DateTime)Eval("Time")).ToString("yyyy-MM-dd") %></td>
                            <td><%#Eval("Num") %>件</td>
                            <td><%#Eval("Description") %></td>
                            <td><%#Eval("UserName") %></td>
                            <td><%#(Eval("PublishUserName")==null || Eval("PublishUserName").ToString()=="")?"未确定":Eval("PublishUserName") %></td>
                            <td><%#(Eval("QualityUserName")==null|| Eval("QualityUserName").ToString()=="")?"未确定":Eval("QualityUserName") %></td>
                          
                            <td><%#((DateTime)Eval("AddTime")).ToString("yyyy-MM-dd") %></td>
                            <td><%#TaskModule.OrderBll.GetOrderStatus((Model.OrderStatus)Eval("Status")) %></td>
                            <td>
                             <i>
                                 <bag:LinkButtonEx ID="lbConfirm" runat="server" Text="确认" Purview="order_manage" />
                                 <bag:LinkButtonEx ID="lbResult" OnClientClick="javascript:if(!confirm('确认执行订单完成操作吗')) return false;" runat="server" CommandName="Result" CommandArgument='<%#Eval("Id") %>' Text="订单完成" Purview="order_resultlog"/>
                                 
                                 <bag:LinkButtonEx ID="lbLast" runat="server" Text="提交质检记录" Purview="order_addchecklog" />
                                 <bag:LinkButtonEx ID="lbDetail" runat="server" Text="查看明细" Purview="order_view,order_addchecklog,order_viewchecklog" />
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
