<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="AddDeveLog.aspx.cs" Inherits="WebUI.Tech.AddDeveLog" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    
     <div class="right_list">
         <table id="epctable" runat="server" cellpadding="0" cellspacing="0" border="0" width="98%" class="table2">
             <tr>
            	<td class="td2_1">EPC：</td>
                <td>
                    <asp:TextBox ID="tbEpc" Width="200" AutoPostBack="true" Enabled="true" OnTextChanged="tbEcp_TextChanged" runat="server" CssClass="input"/>
                    &nbsp;&nbsp;&nbsp;<input type="button" style="padding:0px 5px 0px 5px;" onclick="javascript:readcard('<%=tbEpc.ClientID%>');__doPostBack('<%=tbEpc.UniqueID%>','');" value="读卡" /> 
                </td>
           	</tr>
         </table>
         <div id="maintable" runat="server" visible="false">
         <div style="width:98%;margin:10px;">
             <bag:ButtonEx ID="btnDesign" CssClass="button" CommandName="BeginDesign" Visible="false" runat="server" Text="开始设计" Purview="tech_design" OnClick="Btn_Click" />
             <bag:ButtonEx ID="btnPlate" CssClass="button" CommandName="BeginPlate" Visible="false" runat="server" Text="开始制版" Purview="tech_plate"  OnClick="Btn_Click" />
             <bag:ButtonEx ID="btnSample" CssClass="button" CommandName="BeginSample" Visible="false" runat="server" Text="打样生产" Purview="tech_sample"  OnClick="Btn_Click" />
             <bag:ButtonEx ID="btnPackage" CssClass="button" CommandName="BeginPackage" Visible="false" runat="server" Text="交付" Purview="tech_package"  OnClick="Btn_Click" />
         </div>
         <br /><br />
         <table cellpadding="0" cellspacing="0" border="0" width="98%" class="table2">
             <tr>
            	<td class="td2_1">EPC：</td>
                <td>
                    <asp:Literal ID="LtEpc" runat="server"></asp:Literal>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
                 <td class="td2_1">任务编码：</td>
                <td>

                    <asp:Literal ID="LtCode" runat="server"></asp:Literal>
                </td>
           	</tr>
        	<tr>
            	
                <td class="td2_1">任务标题：</td>
                <td>
                    <asp:Literal ID="LtTitle" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">销售负责人：</td>
                <td>
                    <asp:Literal ID="LtSaleUserName" runat="server"></asp:Literal>
                </td>
           	</tr>
            
        	<tr>
            	<td class="td2_1">任务说明：</td>
                <td colspan="3">
                    <asp:Literal ID="LtDescription" runat="server"></asp:Literal>
                    </td>
            </tr>
        	<tr>
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table3" id="table3">
                        <tr>
                            <td>操作类型</td>
                            <td>起始时间</td>
                            <td>结束时间</td>
                            <td>总用时</td>
                            <td>起始操作人</td>
                            <td>结束操作人</td>
                        </tr>
                        <asp:Repeater ID="RptLogs" OnItemDataBound="RptLogs_ItemDataBound" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Model.LogActionDictionary.Dic[(Model.LogAction)Eval("Action")] %></td>
                                    <td>
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
                                    <td><asp:Literal ID="Literal2" runat="server"></asp:Literal></td>
                                    <td><asp:Literal ID="Literal3" runat="server"></asp:Literal></td>
                                    <td><%#Eval("StartUserName") %></td>
                                    <td><%#Eval("EndUserName") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
        	</tr>
        	
        </table>
         </div>
	</div>
</asp:Content>
