<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="AddUser.aspx.cs" Inherits="WebUI.Security.AddUser" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
     <div class="right">
    	
        	<table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
        		<tr>
            		<td class="td2_1">用户名：</td>
                    <td>
                        <bag:TextBoxEx ID="tbUserName" runat="Server" IsRequired="true" CssClass="input" RequiredErrorMessage="请输入用户名" />
                        </td>
           		</tr>
        		<tr>
            		<td class="td2_1">登录密码：</td>
                    <td>
                        <bag:TextBoxEx ID="tbPassword" runat="Server" TextMode="Password" IsRequired="true" RequiredErrorMessage="请输入登录密码" CssClass="input"  />
                        <span id="modifymsg" runat="Server" visible="false" style="padding-left:10px;color:red">如果不修改密码可留空</span> 
                    </td>
            	</tr>
        		<tr>
            		<td class="td2_1">Email：</td>
                    <td>
                        <bag:TextBoxEx ID="tbEmial" runat="Server" Type="Email" FormatErrorMessage="您输入的邮箱格式不正确" CssClass="input"  />
                     </td>
            	</tr>
                <tr>
            		<td class="td2_1">联系电话：</td>
                    <td>
                        <bag:TextBoxEx ID="tbPhone" runat="Server" CssClass="input"  />
                     </td>
            	</tr>
                <tr>
            		<td class="td2_1">所属角色：</td>
                    <td>
                        <asp:CheckBoxList ID="cbRoles" RepeatLayout="Flow" RepeatColumns="10" runat="server" DataTextField="Name" DataValueField="RoleId"></asp:CheckBoxList>
                     </td>
            	</tr>
                <tr>
            		<td class="td2_1">锁定：</td>
                    <td>
                        <asp:CheckBox ID="cbLocked" runat="server" />
                     </td>
            	</tr>
        		<tr>
            		<td class="td2_1"></td><td>
                        <asp:Button ID="BtnOk" OnClick="BtnOk_Click" runat="server" CssClass="button" Text="提  交" />
                        </td>
            	</tr>
        	</table>
        </div>

</asp:Content>
