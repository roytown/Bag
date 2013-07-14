<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="RoleManage.aspx.cs" Inherits="WebUI.Security.RoleManage" %>

<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right_list">
    
            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table3" id="table3">
                <tr>
                    <th>角色ID</th>
                    <th>角色名称</th>
                    <th>简单说明</th>
                    <th width="200">操作</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("RoleId") %></td>
                            <td><%#Eval("Name") %></td>
                            <td><%#Eval("Description") %></td>
                            <td>
                             <i><a href="AddRole.aspx?action=modify&id=<%#Eval("RoleId") %>">修改</a>
                                 <bag:LinkButtonEx ID="del" runat="Server" Purview="system_role" Text="删除" OnClientClick="if(confirm('确认删除当前角色吗?')) return true else return false;" CommandName="Del" CommandArgument='<%#Eval("RoleId") %>' />
                                 <a href="RoleSetting.aspx?id=<%#Eval("RoleId") %>">角色参数设置</a></i> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
              
            </table>
           
            <div class="clear h10"></div>
        <a class="button mr10" href="<%=ResolveClientUrl("~/security/addrole.aspx") %>">增加角色</a>
        
	</div>
</asp:Content>
