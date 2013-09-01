<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="AddTask.aspx.cs" Inherits="WebUI.Task.AddTask" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
     <div class="right">
        	<table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
        		<tr>
            		<td class="td2_1">任务名称：</td>
                    <td>
                        <bag:TextBoxEx ID="tbName" runat="Server" IsRequired="true" CssClass="input" RequiredErrorMessage="请输入任务标题" />
                        </td>
           		</tr>
        		<tr id="codetr" runat="Server" visible="false">
            		<td class="td2_1">任务编码：</td>
                    <td>
                        <bag:TextBoxEx ID="tbCode" runat="Server" Purview="task_code" CssClass="input"  />
                     </td>
            	</tr>
        		<tr>
            		<td class="td2_1">客户名称：</td>
                    <td>
                        <bag:TextBoxEx ID="tbCustomer" runat="Server" IsRequired="true" RequiredErrorMessage="请输入客户名称" Purview="task_code" CssClass="input"  />
                     </td>
            	</tr>
                <tr>
            		<td class="td2_1">客户电话：</td>
                    <td>
                        <bag:TextBoxEx ID="tbTelephone" runat="Server"  Type="Telephone"  CssClass="input"   FormatErrorMessage="您输入的电话格式不正确"/>
                     </td>
            	</tr>
                <tr>
            		<td class="td2_1">客户手机：</td>
                    <td>
                        <bag:TextBoxEx ID="tbMobilePhone" runat="Server" Type="MobilePhone" CssClass="input" FormatErrorMessage="您输入的手机格式不正确"  />
                     </td>
            	</tr>
                <tr>
            		<td class="td2_1">任务说明：</td>
                    <td>
                        <bag:TextBoxEx ID="tbDescription" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input"  />
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
