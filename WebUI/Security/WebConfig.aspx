<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="WebConfig.aspx.cs" Inherits="WebUI.Security.WebConfig" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
     <div class="right">
    	
        	<table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
        		<tr>
            		<td class="td2_1">系统标题：</td>
                    <td>
                        <bag:TextBoxEx ID="tbTitle" runat="Server" IsRequired="true" CssClass="input" RequiredErrorMessage="请输入系统标题" />
                        </td>
           		</tr>
        		<tr>
            		<td class="td2_1">系统版权：</td>
                    <td>
                        <bag:TextBoxEx ID="tbCopyright" runat="Server" IsRequired="true" CssClass="input" RequiredErrorMessage="请输入系统版权" />
                        </td>
           		</tr>
                <tr>
            		<td class="td2_1">票据有效时长：</td>
                    <td>
                        <bag:TextBoxEx ID="tbTickeTime" Width="50" runat="Server" IsRequired="true" CssClass="input" RequiredErrorMessage="请输入票据有效时长" Type="Int" FormatErrorMessage="只能输入整数" />分钟
                        </td>
           		</tr>
                <tr>
            		<td class="td2_1">密码长度最小值：</td>
                    <td>
                        <bag:TextBoxEx ID="tbMinLength" Width="50" runat="Server"  CssClass="input" Type="Int" FormatErrorMessage="只能输入整数" />
                        </td>
           		</tr>
                <tr>
            		<td class="td2_1">密码长度最大值：</td>
                    <td>
                        <bag:TextBoxEx ID="tbMaxLength" Width="50" runat="Server"  CssClass="input" Type="Int" FormatErrorMessage="只能输入整数" />
                        </td>
           		</tr>
                <tr>
            		<td class="td2_1">课程选择修改次数：</td>
                    <td>
                        <bag:TextBoxEx ID="tbSelLessonTimes" Width="50" runat="Server"  CssClass="input" Type="Int" FormatErrorMessage="只能输入整数" />
                        </td>
           		</tr>
                 <tr>
            		<td class="td2_1">作业修改限制次数：</td>
                    <td>
                        <bag:TextBoxEx ID="tbHomeworkCommitTimes" Width="50" runat="Server"  CssClass="input" Type="Int" FormatErrorMessage="只能输入整数" />
                        </td>
           		</tr>
                
        		<tr>
            		<td class="td2_1"></td><td>
                        <asp:Button ID="BtnOk" OnClick="BtnOk_Click" runat="server" CssClass="coolbg" Text="提  交" />
                        </td>
            	</tr>
        	</table>
        </div>

</asp:Content>