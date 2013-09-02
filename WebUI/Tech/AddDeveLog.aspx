<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="AddDeveLog.aspx.cs" Inherits="WebUI.Tech.AddDeveLog" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
     <div class="right_list">
         <div style="width:100%;">
             <bag:ButtonEx ID="btnDesign" CommandName="BeginDesign" Visible="false" runat="server" Text="开始设计" Purview="tech_design" OnClick="Btn_Click" />
             <bag:ButtonEx ID="btnPlate" CommandName="BeginPlate" Visible="false" runat="server" Text="开始制版" Purview="tech_plate" />
             <bag:ButtonEx ID="btnSample" CommandName="BeginSample" Visible="false" runat="server" Text="开始打样" Purview="tech_sample" />
             <bag:ButtonEx ID="btnPackage" CommandName="BeginPackage" Visible="false" runat="server" Text="开始制作样包" Purview="tech_package" />
         </div>
         <table cellpadding="0" cellspacing="0" border="0" width="98%" class="table2">
        	<tr>
            	<td class="td2_1">任务编码：</td>
                <td>
                    <asp:Literal ID="LtCode" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">任务标题：</td>
                <td>
                    <asp:Literal ID="LtTitle" runat="server"></asp:Literal>
                </td>

           	</tr>
             <tr>
            	<td class="td2_1">销售负责人：</td>
                <td>
                    <asp:Literal ID="LtSaleUserName" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">任务标题：</td>
                <td>
                    <asp:Literal ID="LtDeveUserName" runat="server"></asp:Literal>
                </td>

           	</tr>
        	<tr>
            	<td class="td2_1">任务说明：</td>
                <td>
                    <asp:Literal ID="LtDescription" runat="server"></asp:Literal>
                    </td>
            </tr>
        	<tr>
                <td colspan="2">
                    <table>
                        <tr>
                            <td>操作类型</td>
                            <td>起始时间</td>
                            <td>结束时间</td>
                            <td>总用时</td>
                            <td>操作人</td>
                        </tr>
                        <asp:Repeater ID="RptLogs" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>操作类型</td>
                                    <td>起始时间</td>
                                    <td>结束时间</td>
                                    <td>总用时</td>
                                    <td>操作人</td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
        	</tr>
        	
        </table>
	</div>
</asp:Content>
