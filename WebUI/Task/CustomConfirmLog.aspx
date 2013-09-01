<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="CustomConfirmLog.aspx.cs" Inherits="WebUI.Task.CustomConfirmLog" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
     <div class="right">
        <table cellpadding="0" cellspacing="0" border="0" width="98%" class="table2">
        	<tr>
            	<td class="td2_1">任务编码：</td>
                <td>
                    <asp:Literal ID="LtTile" runat="server"></asp:Literal>
                </td>
           	</tr>
        	<tr>
            	<td class="td2_1">任务标题：</td>
                <td>
                    <asp:Literal ID="LtTitle" runat="server"></asp:Literal>
                    </td>
            </tr>
        	<tr>
            	<td class="td2_1">任务说明：</td>
                <td>
                    <asp:Literal ID="LtDescription" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
            	<td class="td2_1">确认结果：</td>
                <td>
                    
                </td>
            </tr>
            <tbody>

                <tr>
            	    <td class="td2_1">说明：</td>
                    <td>
                        <bag:TextBoxEx ID="tbDescription" Width="280" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input"  />
                    </td>
                </tr>
            </tbody>                 
            
        	<tr>
            	<td class="td2_1"></td><td>
                    <asp:Button ID="BtnOk" OnClick="BtnOk_Click" runat="server" CssClass="button" Text="提  交" />
            
                    </td>
            </tr>
        </table>
    </div>

</asp:Content>
