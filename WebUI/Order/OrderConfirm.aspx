<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master"  CodeBehind="OrderConfirm.aspx.cs" Inherits="WebUI.Order.OrderConfirm" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
     <div class="right">
        	<table cellpadding="0" cellspacing="0" border="0" width="98%" class="table2">

                <tr>
            		<td class="td2_1">生产负责人：</td>
                    <td>
                        <bag:TextBoxEx ID="tbPublishUserName" Width="100" runat="Server" CssClass="input autocomplete-user" IsRequired="true"  RequiredErrorMessage="请输入生产负责人"  />
                     </td>
                    <td class="td2_1">质检负责人：</td>
                    <td>
                        <bag:TextBoxEx ID="tbQualityUserName" Width="100" runat="Server" CssClass="input autocomplete-user" IsRequired="true"  RequiredErrorMessage="请输入质检负责人"   />
                     </td>
            	</tr>
               
                <tr>
            		<td class="td2_1">说明：</td>
                    <td colspan="3">
                        <bag:TextBoxEx ID="tbDescription" Width="280" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input"  />
                     </td>
            	</tr>
        		<tr>
            		<td class="td2_1"></td>
                    <td colspan="3">
                        <asp:Button ID="BtnOk" OnClick="BtnOk_Click" runat="server" CssClass="button" Text="提  交" />
            
                        </td>
            	</tr>
        	</table>
        </div>

</asp:Content>
