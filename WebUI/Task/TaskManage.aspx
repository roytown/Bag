<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="TaskManage.aspx.cs" Inherits="WebUI.Task.TaskManage" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right_list">
      
            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table3" id="table3">
                <tr>
                    <th>ID</th>
                    <th>任务标题</th>
                    <th>编码</th>
                    <th>销售负责人</th>
                    <th>客户姓名</th>
                    <th>联系电话</th>
                    <th>手机</th>
                    <th>说明</th>
                    <th>录入时间</th>
                    <th>任务状态</th>
                    <th width="200">操作</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("ID") %></td>
                            <td><%#Eval("Title") %></td>
                            <td><%#Eval("Code").ToString()==""?"未确定":Eval("Code") %></td>
                            <td><%#(Eval("SaleUserName")==null||Eval("SaleUserName").ToString()=="")?"未确定":Eval("SaleUserName")  %></td>
                            <td><%#Eval("Customer") %></td>
                            <td><%#Eval("Telephone") %></td>
                            <td><%#Eval("MobilePhone") %></td>
                            <td><%#Eval("Description") %></td>
                            <td><%#((DateTime)Eval("AddTime")).ToString("yyyy-MM-dd") %></td>
                           
                            <td>
                                <%#TaskModule.TaskBll.GetTaskState((Model.TaskState)Eval("Status")) %>
                            </td>
                            <td>
                             <i>
                                 <asp:LinkButton ID="lbModify" runat="server" Text="修改" />
                                 <asp:LinkButton ID="lbDel" runat="server" Text="删除" CommandName="Del" CommandArgument='<%#Eval("Id") %>' />
                                 <asp:LinkButton ID="lbConfirm" runat="server" Text="确认" />
                                 <bag:LinkButtonEx ID="lbAddOrder" runat="server" Text="提交客户确认记录" Purview="task_customconfirm" />
                                 <bag:LinkButtonEx ID="lbOrderExpand" runat="server" Text="追加订单" Purview="order_expand" />
                                 <bag:LinkButtonEx ID="lbDetail" runat="server" Text="查看任务明细" Purview="task_manage" />
                                 <bag:LinkButtonEx ID="lbStock" runat="server" Text="提交入库记录" Purview="stock_add" />
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
