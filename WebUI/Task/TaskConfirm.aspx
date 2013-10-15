<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MainMaster.Master" CodeBehind="TaskConfirm.aspx.cs" Inherits="WebUI.Task.TaskConfirm" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
     <div class="right">
        	<table cellpadding="0" cellspacing="0" border="0" width="98%" class="table2">
        		<tr>
            		<td class="td2_1">任务名称：</td>
                    <td>
                        <asp:Literal ID="LtTile" runat="server"></asp:Literal>
                    </td>
           		</tr>
        		<tr>
            		<td class="td2_1">任务说明：</td>
                    <td>
                       <asp:Literal ID="LtDescription" runat="server"></asp:Literal>
                     </td>
            	</tr>
                <tr id="codetr" runat="Server"  purview="task_code">
            		<td class="td2_1">任务编码：</td>
                    <td>
                        <bag:TextBoxEx ID="tbCode" Width="100" runat="Server" IsRequired="true" RequiredErrorMessage="请输入任务编码" Purview="task_code" CssClass="input"  />
                     </td>
            	</tr>
        		<tr>
            		<td class="td2_1">销售负责人：</td>
                    <td>
                        <bag:TextBoxEx ID="tbSaleUserName" Width="100" runat="Server" IsRequired="true" RequiredErrorMessage="请输入销售负责人" Purview="task_confirm" CssClass="input autocomplete-user"  />
                     </td>
            	</tr>
                             
                <tr>
            		<td class="td2_1">说明：</td>
                    <td>
                        <bag:TextBoxEx ID="tbDescription" Width="280" runat="Server" MaxTextLength="255" FormatErrorMessage="内容长度不能超过255个字符" TextMode="MultiLine" Rows="6" CssClass="input"  />
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