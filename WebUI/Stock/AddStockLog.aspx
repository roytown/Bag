<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MainMaster.Master" CodeBehind="AddStockLog.aspx.cs" Inherits="WebUI.Stock.AddStockLog" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
     <div id="epcdiv"  runat="server" class="right">
         <table cellpadding="0" cellspacing="0" border="0" width="98%" class="table2">
             <tr>
            	<td class="td2_1">EPC：</td>
                <td>
                    <asp:TextBox ID="tbEpc" AutoPostBack="true" Enabled="true" OnTextChanged="tbEcp_TextChanged" runat="server" CssClass="input"/>
                    &nbsp;&nbsp;&nbsp;<input type="button" style="padding:0px 5px 0px 5px;" onclick="javascript:readcard('<%=tbEpc.ClientID%>');__doPostBack('<%=tbEpc.UniqueID%>','');" value="读卡" /> 
                </td>
           	</tr>
         </table>
     </div>
   <div id="maindiv" runat="server" class="right" visible="false">
       <asp:HiddenField ID="HiddenField1" runat="server" />
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
            	<td class="td2_1">型号：</td>
                <td>
                    <asp:Literal ID="LtModel" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">款式：</td>
                <td>
                    <asp:Literal ID="LtType" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">材质：</td>
                <td>
                   <asp:Literal ID="LtMaterial" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">品质：</td>
                <td>
                    <asp:Literal ID="LtQuality" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">品牌：</td>
                <td>
                    <asp:Literal ID="LTBrand" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">颜色：</td>
                <td>
                   <asp:Literal ID="LtColor" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">硬度：</td>
                <td>
                    <asp:Literal ID="LtHardness" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">成色：</td>
                <td>
                    <asp:Literal ID="LtFineness" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">尺寸：</td>
                <td>
                    <asp:Literal ID="LtSize" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">图案：</td>
                <td>
                    <asp:Literal ID="LtPattern" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">大小：</td>
                <td>
                    <asp:Literal ID="LtBigness" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">价格：</td>
                <td>
                    <asp:Literal ID="LtPrice" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">风格：</td>
                <td>
                    <asp:Literal ID="LtStyle" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">里料质地：</td>
                <td>
                    <asp:Literal ID="LtTexture" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">内部结构：</td>
                <td>
                    <asp:Literal ID="LtInternalStructure" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">提拎部件：</td>
                <td>
                    <asp:Literal ID="LtCarryPart" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">可否折叠：</td>
                <td>
                    <asp:Literal ID="LtCollapse" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">箱包场合：</td>
                <td>
                    <asp:Literal ID="LtSituation" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">流行元素：</td>
                <td>
                   <asp:Literal ID="LtPopularElement" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">EPC：</td>
                <td>
                     <asp:Literal ID="LtEpc" runat="server"></asp:Literal>
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

                       <asp:Button ID="BtnOk" runat="server" OnClientClick="javascript:if(checkepc()==false) return false;" CssClass="button mr10" Text="提交记录" OnClick="BtnOk_Click"/>
                    
                  </td>
              </tr>
        </table> 

     </div>
   <script type="text/javascript">
       function checkepc()
       {
           v=$('#<%=tbDescription.ClientID%>').val();
           if(v==null||v=="")
           {
               alert("请填写入库说明");
               return false;
           }

           return true;
       }
   </script>
 </asp:Content>
