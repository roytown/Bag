<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="TaskManage.aspx.cs" Inherits="WebUI.Task.TaskManage" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right_list">
        <table>
            <tr>
                <td>发布时间：</td>
                <td colspan="2" style="height:30px;">
                    <bag:Date ID="date1" runat="Server" DayOfWeekOffset="1"/> 至 <bag:Date ID="date2" runat="Server" DayOfWeekOffset="1"/>
                 </td>
            </tr>
            <tr>
                <td>任务编码：</td>
                <td colspan="2" style="height:30px;">
                    <asp:TextBox ID="tbCode" runat="server"></asp:TextBox>  
                 </td>
            </tr>
            <tr>
                <td style="height:30px;">发布人：</td>
                <td>
                     <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
                </td>
                <td style="padding-left:10px;">
                    <asp:Button ID="BtnFilter" runat="server" CssClass="button mr10" CommandName="Lock" Text="筛选" OnClick="BtnFilter_Click" />
                </td>
            </tr>
        </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table3" id="table3">
                <tr>
                    <th>ID</th>
                    <th>任务标题</th>
                    <th>编码</th>
                    <th>客户姓名</th>
                    <th>联系电话</th>
                    <th>手机</th>
                    <th>说明</th>
                    <th>录入时间</th>
                    <th>任务状态</th>
                    <th width="200">操作</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("ID") %></td>
                            <td><%#Eval("Title") %></td>
                            <td><%#Eval("Code") %></td>
                            <td><%#Eval("Customer") %></td>
                            <td><%#Eval("Telephone") %></td>
                            <td><%#Eval("MobilePhone") %></td>
                            <td><%#Eval("Description") %></td>
                            <td><%#((DateTime)Eval("AddTime")).ToString("yyyy-MM-dd") %></td>
                           
                            <td>
                                <%#TaskModule.TaskBll.GetTaskState((Model.TaskState)Eval("State")) %>
                            </td>
                            <td>
                             <i><a href="AddTask.aspx?action=modify&id=<%#Eval("ID") %>">修改</a>
                                 <bag:LinkButtonEx ID="LinkButtonEx1" runat="Server" Purview="system_user" OnClientClick="if(confirm('确认删除当前用户吗?')) return true else return false;" Text="删除" CommandName="Del" CommandArgument='<%#Eval("UserId") %>' />
                                  <bag:LinkButtonEx ID="del" runat="Server" Purview="system_user" OnClientClick="if(confirm('确认删除当前用户吗?')) return true else return false;" Text="删除" CommandName="Del" CommandArgument='<%#Eval("UserId") %>' />
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
