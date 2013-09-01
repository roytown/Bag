<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="DeveManage.aspx.cs" Inherits="WebUI.Tech.DeveManage" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right_list">
      
            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table3" id="table3">
                <tr>
                    <th>ID</th>
                    <th>任务标题</th>
                    <th>编码</th>
                    <th>销售负责人</th>
                    <th>研发负责人</th>
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
                             <td><%#(Eval("SaleUserName")==null || Eval("SaleUserName").ToString()=="")?"未确定":Eval("SaleUserName") %></td>
                            <td><%#(Eval("DevelopUserName")==null || Eval("DevelopUserName").ToString()=="")?"未确定":Eval("DevelopUserName") %></td>
                          
                            <td><%#Eval("Description") %></td>
                            <td><%#((DateTime)Eval("AddTime")).ToString("yyyy-MM-dd") %></td>
                           
                            <td>
                                <%#TaskModule.TaskBll.GetTaskState((Model.TaskState)Eval("Status")) %>
                            </td>
                            <td>
                             <i>
                                 <bag:LinkButtonEx ID="lbAddlog" runat="server" Text="发布研发日志" Purview="tech_addlog" />
                                 <asp:LinkButton ID="lbDevelopConfirm" runat="server" Text="研发确认" />
                                 <bag:LinkButtonEx ID="lbDetail" runat="server" Text="查看研发明细" Purview="tech_viewlog" />
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

