<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebUI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%=ResolveClientUrl("~/css/reset.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/css/login.css")%>" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="bg">
		<div class="login">
			<div class="left"></div>
			<div class="right">
				
					<table border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td align="right" width="67">用户名:</td>
							<td width="235"> <asp:TextBox ID="TbUserName" runat="server"></asp:TextBox></td>
							<td></td>
						</tr>
						<tr>
							<td align="right">密码:</td>
							<td><asp:TextBox ID="TbPassword" runat="server" TextMode="Password"></asp:TextBox></td>
							<td></td>
						</tr>
						<tr>
							<td align="right">验证码:</td>
							<td>
                                <asp:TextBox ID="TbCheckCode" runat="server" Width="60"></asp:TextBox>
                               &nbsp;<img id="CheckCodeImg" src="<%=ResolveClientUrl("~/checkcode.aspx") %>" style=" vertical-align:inherit; cursor:pointer" onclick="javascript:RefreshCheckCode();" alt="看不到验证码？点击重新换一个！" />
                                 <br /><asp:Label ID="LbMsg" ForeColor="Red" runat="server" Text=""></asp:Label>
							</td>
							<td></td>
						</tr>
        
						<tr>
							<td></td>
							<td rowspan="2">
                                 <asp:Button ID="Button1" runat="server" CssClass="submit mr30" Text="登录" OnClick="Button1_Click" />
                                <input type="button" value="重  置" class="submit" onclick="javascript: reset();" /></td>
						</tr>
                        
					</table>
			<script type="text/javascript">
            <!--
                function RefreshCheckCode() {
                    document.getElementById("CheckCodeImg").src = "<%=ResolveClientUrl("~/checkcode.aspx")%>?r=" + Math.random();
                }

			    function reset()
			    {
			        document.getElementById("<%=TbUserName.ClientID%>").value = "";
			        document.getElementById("<%=TbPassword.ClientID%>").value = "";
			        document.getElementById("<%=TbCheckCode.ClientID%>").value = "";
			    }
                //-->
            </script>
			</div>
		</div>
	</div>
	<div class="bottom">
		<p>苏州轻舟箱包服饰有限公司</p>
	</div>
   
    </form>
</body>
</html>
