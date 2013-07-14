<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="ChangePassword.aspx.cs" Inherits="WebUI.Security.ChangePassword" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right">
    	
        	<table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
        		<tr>
            		<td class="td2_1">旧密码：</td>
                    <td>
                        <bag:TextBoxEx ID="oldPwd" runat="Server" TextMode="Password" IsRequired="true" CssClass="input" RequiredErrorMessage="请输入旧密码" />
                        </td>
           		</tr>
        		<tr>
            		<td class="td2_1">新密码：</td>
                    <td>
                        <bag:TextBoxEx ID="newPwd" runat="Server" TextMode="Password" IsRequired="true" CssClass="input" RequiredErrorMessage="请输入新密码"  />
                     </td>
            	</tr>
        		<tr>
            		<td class="td2_1">重复新密码：</td>
                    <td>  
                        <bag:TextBoxEx ID="confirmPwd" runat="Server"  TextMode="Password" CssClass="input" ValueErrorMessage="两次输入的密码不相同" /></td>
            	</tr>
        		
        		<tr>
            		<td class="td2_1"></td><td>
                        <asp:Button ID="BtnOk" OnClick="BtnOk_Click" runat="server" CssClass="button" Text="提  交" />
                        <input type="button" value="重  置" class="button" onclick="reset()" /></td>
            	</tr>
        	</table>
        </div>
    <script type="text/javascript">
        function reset() {
            document.getElementById("<%=oldPwd.ClientID%>").value = "";
            document.getElementById("<%=newPwd.ClientID%>").value = "";
            document.getElementById("<%=confirmPwd.ClientID%>").value = "";
        }
    </script>
</asp:Content>
