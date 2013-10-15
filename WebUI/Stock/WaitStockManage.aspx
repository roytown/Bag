<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="WaitStockManage.aspx.cs" Inherits="WebUI.Stock.WaitStockManage" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right_list">
      
            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table3" id="table3">
                <tr>
                    <th>ID</th>
                    <th>任务标题</th>
                    <th>编码</th>
                    <th>EPC</th>
                    <th>销售负责人</th>
                    <th>客户姓名</th>
                    <th>联系电话</th>
                    <th>手机</th>
                    <th>说明</th>
                    <th>录入时间</th>
                    <th>任务状态</th>
                    <th width="200">操作</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("ID") %></td>
                            <td><%#Eval("Title") %></td>
                            <td><%#Eval("Code") %></td>
                            <td>&nbsp;<%#Eval("Ecp") %></td>
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
