<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MainMaster.Master" CodeBehind="DeveConfirm.aspx.cs" Inherits="WebUI.Tech.DeveConfirm" %>
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
        		<tr>
            		<td class="td2_1">任务编码：</td>
                    <td>
                       <bag:TextBoxEx ID="tbCode" Width="100" runat="Server" CssClass="input"  IsRequired="true" RequiredErrorMessage="请输入研发任务编码" Purview="tech_code"/>
                     </td>
            	</tr>
        		
                <tr>
            		<td class="td2_1">研发负责人：</td>
                    <td>
                        <bag:TextBoxEx ID="tbDevelopUserName" Width="100" runat="Server" CssClass="input"  IsRequired="true" RequiredErrorMessage="请输入研发负责人" Purview="tech_developconfirm"/>
                     </td>
            	</tr>
               
                <tr>
            		<td class="td2_1">说明：</td>
                    <td>
                        <bag:TextBoxEx ID="tbDescription" Width="280" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input"  />
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