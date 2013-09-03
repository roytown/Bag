<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MainMaster.Master" CodeBehind="AddStockLog.aspx.cs" Inherits="WebUI.Stock.AddStockLog" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right">
          <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
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
                  <td class="td2_1">订单类型：</td>
                <td colspan="2">
                    <asp:Literal ID="LtOrderType" runat="server"></asp:Literal>
                </td>
           	</tr>
               <tr>
            	<td class="td2_1">任务说明：</td>
                <td colspan="3">
                    <asp:Literal ID="LtDescription" runat="server"></asp:Literal>
                </td>
           	</tr>
        	<tr id="ordertr" runat="server" visible="false">
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table3" id="table3">
                        <tr>
                            <td>数量要求</td>
                            <td>时间要求</td>
                            <td>其他说明</td>
                            <td>质检负责人</td>
                            <td>生产负责人</td>
                          
                        </tr>
                        <asp:Repeater ID="RptOrder" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("Num")%></td>
                                    <td>
                                       <%#Eval("Time") %></td>
                                    <td><%#Eval("Description") %></td>
                                    <td><%#Eval("QualityUserName") %></td>
                                    <td><%#Eval("PublishUserName") %></td>
                                
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
            	<td class="td2_1">入库说明：</td>
                <td colspan="3">
                   <bag:TextBoxEx ID="tbDescription" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input" IsRequired="true" RequiredErrorMessage="请输入入库说明" />
                  
                    </td>
            </tr>
              <tr>
                  <td></td>
                  <td colspan="3">

                       <asp:Button ID="BtnOk" runat="server" CssClass="button mr10" Text="提交记录" OnClick="BtnOk_Click"/>
                    
                  </td>
              </tr>
        </table> 

     </div>
   
 </asp:Content>
