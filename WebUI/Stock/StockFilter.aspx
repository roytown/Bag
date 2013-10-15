<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="StockFilter.aspx.cs" Inherits="WebUI.Stock.StockFilter" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right">
          <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
            <tr>
                <td class="td2_1">按入库时间：</td>
                <td>
                    <bag:Date ID="date1" runat="Server" DayOfWeekOffset="1"/> 至 <bag:Date ID="date2" runat="Server" DayOfWeekOffset="1"/>
                 </td>
                 <td class="td2_1">按任务编码：</td>
                <td>
                    <asp:TextBox ID="tbCode" runat="server"></asp:TextBox>  
                 </td>
            </tr>
            <tr>
                <td class="td2_1">按销售负责人：</td>
                <td >
                    <asp:TextBox ID="tbSaleUserName" CssClass="autocomplete-user" runat="server"></asp:TextBox>  
                 </td>
                 <td class="td2_1">按入库操作人：</td>
                <td>
                     <asp:TextBox ID="tbUserName" CssClass="autocomplete-user" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
            		<td class="td2_1">型号：</td>
                    <td>
                        <asp:TextBox ID="tbModel" runat="Server"  CssClass="input" />
                    </td>
                    <td class="td2_1">款式：</td>
                    <td>
                        <asp:TextBox ID="tbType" runat="Server"  CssClass="input"  />
                     </td>
           		</tr>
                <tr>
            		<td class="td2_1">材质：</td>
                    <td>
                        <asp:TextBox ID="tbMaterail" runat="Server"  CssClass="input" />
                    </td>
                    <td class="td2_1">品质：</td>
                    <td>
                        <asp:TextBox ID="tbQuality" runat="Server"  CssClass="input"  />
                     </td>
           		</tr>
                <tr>
            		<td class="td2_1">品牌：</td>
                    <td>
                        <asp:TextBox ID="tbBrand" runat="Server"  CssClass="input"  />
                    </td>
                    <td class="td2_1">颜色：</td>
                    <td>
                        <asp:TextBox ID="tbColor" runat="Server"  CssClass="input"  />
                     </td>
           		</tr>
                <tr>
            		<td class="td2_1">硬度：</td>
                    <td>
                        <asp:TextBox ID="tbHardness" runat="Server" CssClass="input"  />
                    </td>
                    <td class="td2_1">成色：</td>
                    <td>
                        <asp:TextBox ID="tbFineness" runat="Server" CssClass="input"  />
                     </td>
           		</tr>
                <tr>
            		<td class="td2_1">尺寸：</td>
                    <td>
                        <asp:TextBox ID="tbSize" runat="Server"  CssClass="input"  />
                    </td>
                    <td class="td2_1">图案：</td>
                    <td>
                        <asp:TextBox ID="tbPattern" runat="Server" CssClass="input"  />
                     </td>
           		</tr>
                <tr>
            		<td class="td2_1">大小：</td>
                    <td>
                        <asp:TextBox ID="tbBigness" runat="Server"  CssClass="input" />
                    </td>
                    <td class="td2_1">价格：</td>
                    <td>
                        <asp:TextBox ID="tbPrice" runat="Server"  CssClass="input"  />
                     </td>
           		</tr>
                <tr>
            		<td class="td2_1">风格：</td>
                    <td>
                        <asp:TextBox ID="tbStyle" runat="Server"  CssClass="input"  />
                    </td>
                    <td class="td2_1">里料质地：</td>
                    <td>
                        <asp:TextBox ID="tbTexture" runat="Server" CssClass="input"  />
                     </td>
           		</tr>
                <tr>
            		<td class="td2_1">内部结构：</td>
                    <td>
                        <asp:TextBox ID="tbInternalStructure" runat="Server" CssClass="input" />
                    </td>
                    <td class="td2_1">提拎部件：</td>
                    <td>
                        <asp:TextBox ID="tbCarryPart" runat="Server" CssClass="input"  />
                     </td>
           		</tr>
                <tr>
            		<td class="td2_1">可否折叠：</td>
                    <td>
                        <asp:DropDownList ID="RblCollapse" runat="server" >
                            <asp:ListItem Value="-1" Text="不限" Selected="True" />
                            <asp:ListItem Value="1" Text="可折叠" />
                            <asp:ListItem Value="0" Text="不可折叠" />
                        </asp:DropDownList>
                    </td>
                    <td class="td2_1">箱包场合：</td>
                    <td>
                        <asp:TextBox ID="tbSituation" runat="Server" Purview="task_code" CssClass="input"  />
                     </td>
           		</tr>
                <tr>
            		<td class="td2_1">流行元素：</td>
                    <td>
                        <asp:TextBox ID="tbPopularElement" runat="Server"  CssClass="input" />
                    </td>
                    <td class="td2_1">EPC：</td>
                    <td>
                        <asp:TextBox ID="tbEcp" runat="Server"  CssClass="input"  />
                         &nbsp;&nbsp;&nbsp;<input type="button" style="padding:0px 5px 0px 5px;" onclick="javascript:readcard('<%=tbEcp.ClientID%>')" value="读卡" /> 
                    </td>
           		</tr>
              <tr>
                  <td></td>
                  <td colspan="3">

                       <asp:Button ID="BtnFilter" runat="server" CssClass="button mr10"  Text="筛选" OnClick="BtnFilter_Click"/>
                    
                  </td>
              </tr>
        </table> 

     </div>
   
 </asp:Content>
