<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="UserManage.aspx.cs" Inherits="WebUI.Security.UserManage" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right_list">
    <script type="text/javascript">
        jQuery(function () {
            $("#checkAll").bind("click", function () {
                if (jQuery(this).attr("checked")) {// 全选   
                    
                    jQuery("input[type=checkbox][name=usercheck]").each(function () {
                        jQuery(this).attr("checked", true);
                    });
                } else {// 取消全选    
                    jQuery("input[type=checkbox][name=usercheck]").each(function () {
                        jQuery(this).attr("checked", false);
                    });
                }
            });
        });
    </script>
        <table>
            <tr>
                <td>当前角色：</td><td colspan="2"><asp:DropDownList ID="DdlRoles" DataValueField="RoleId" DataTextField="Name" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>用户名：</td>
                <td>
                    <asp:TextBox ID="TbUserName" runat="server"></asp:TextBox>

                </td>
                <td style="padding-left:10px;">
                    <asp:Button ID="BtnFilter" runat="server" CssClass="button mr10" CommandName="Lock" Text="筛选" OnClick="BtnFilter_Click" />
                </td>
            </tr>
        </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table3" id="table3">
                <tr>
                    <th>
                        <input id="checkAll" type="checkbox"/>
                    </th>
                    <th>用户ID</th>
                    <th>登录名</th>
                    <th>EMIAL</th>
                    <th>联系方式</th>
                    <th>注册日期</th>
                    <th>最近登录日期</th>
                    <th>最近登录IP</th>
                    <th>状态</th>
                    <th width="200">操作</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input type="checkbox" name="usercheck" value="<%#Eval("UserId") %>" />
                            </td>
                            <td><%#Eval("UserId") %></td>
                            <td><%#Eval("UserName") %></td>
                            <td><%#Eval("Email") %></td>
                            <td><%#Eval("Phone") %></td>
                            <td><%#((DateTime)Eval("JoinTime")).ToString("yyyy-MM-dd") %></td>
                            <td><%#((DateTime?)Eval("LastLoginTime")).HasValue?((DateTime?)Eval("LastLoginTime")).Value.ToString("yyyy-MM-dd"):"没有记录" %></td>
                            <td><%#Eval("LastLoginIP") %></td>
                            <td>
                                <%#((bool)Eval("IsLocked"))?"<font class=\"red fl\">账户被锁定</font>":"<font class=\"green fl\">账户正常</font>" %>
                                </td>
                            <td>
                             <i><a href="AddRole.aspx?action=modify&id=<%#Eval("UserId") %>">修改</a>
                                 <bag:LinkButtonEx ID="del" runat="Server" Purview="system_user" OnClientClick="if(confirm('确认删除当前用户吗?')) return true else return false;" Text="删除" CommandName="Del" CommandArgument='<%#Eval("UserId") %>' />
                                </i> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                
            </table>
          
            <div class="clear h10"></div>
        <bag:Pager ID="pager1" runat="Server" Width="100%" PageSize="20" GenerateGoToSection="true" OnCommand="pager_Command" PageClause="页码" GoToLastClause="上一页" NextToPageClause="下一页"/>
         <div class="clear h10"></div>
        <a class="button mr10" href="<%=ResolveClientUrl("~/security/adduser.aspx") %>">增加用户</a>
        <asp:Button ID="Button1" runat="server" CssClass="button mr10" CommandName="Lock" Text="锁定选择" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" CssClass="button mr10" CommandName="UnLock" Text="解锁选择" OnClick="Button1_Click" />
	</div>

</asp:Content>
