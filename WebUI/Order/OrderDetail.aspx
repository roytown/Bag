<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="OrderDetail.aspx.cs" Inherits="WebUI.Order.OrderDetail" %>

<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right">
          <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
              <tr>
            	<td class="td2_1">任务编码：</td>
                <td>
                    &nbsp;<asp:Literal ID="LtCode" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">任务标题：</td>
                <td>
                    &nbsp;<asp:Literal ID="LtTitle" runat="server"></asp:Literal>
                </td>

           	</tr>
             <tr>
            	<td class="td2_1">型号：</td>
                <td>
                    &nbsp;<asp:Literal ID="LtModel" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">款式：</td>
                <td>
                    &nbsp;<asp:Literal ID="LtType" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">材质：</td>
                <td>
                   &nbsp;<asp:Literal ID="LtMaterial" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">品质：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtQuality" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">品牌：</td>
                <td>
                   &nbsp; <asp:Literal ID="LTBrand" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">颜色：</td>
                <td>
                  &nbsp; <asp:Literal ID="LtColor" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">硬度：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtHardness" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">成色：</td>
                <td>
                    &nbsp;<asp:Literal ID="LtFineness" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">尺寸：</td>
                <td>
                    &nbsp;<asp:Literal ID="LtSize" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">图案：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtPattern" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">大小：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtBigness" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">价格：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtPrice" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">风格：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtStyle" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">里料质地：</td>
                <td>
                  &nbsp;  <asp:Literal ID="LtTexture" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">内部结构：</td>
                <td>
                  &nbsp;  <asp:Literal ID="LtInternalStructure" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">提拎部件：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtCarryPart" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">可否折叠：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtCollapse" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">箱包场合：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtSituation" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">流行元素：</td>
                <td>
                   &nbsp;<asp:Literal ID="LtPopularElement" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">EPC：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtEcp" runat="server"></asp:Literal>
                </td>
           	</tr>
             <tr>
            	<td class="td2_1">任务说明：</td>
                <td colspan="3">
                   &nbsp; <asp:Literal ID="LtTaskDescription" runat="server"></asp:Literal>
                </td>
           	</tr>
            <tr>
            	<td class="td2_1">数量：</td>
                <td colspan="3">
                    <asp:Literal ID="LtNum" runat="server"></asp:Literal>
                </td>
           	</tr>
              <tr>
                <td class="td2_1">时间：</td>
                <td colspan="3">
                    <asp:Literal ID="LtTime" runat="server"></asp:Literal>
                </td>
              </tr>
              <tr>
            	<td class="td2_1">生产负责人：</td>
                <td>
                    <asp:Literal ID="Ltpublishusername" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">质检负责人：</td>
                <td>
                    <asp:Literal ID="ltqualityusername" runat="server"></asp:Literal>
                </td>

           	</tr>
             <tr>
            	<td class="td2_1">其他说明：</td>
                <td colspan="3">
                    <asp:Literal ID="LtDescription" runat="server"></asp:Literal>
                </td>
           	</tr>
            <tr id="tr1" runat="server" purview="checklog_view">
                <td colspan="4">
                    质检明细
                </td>
            </tr>
               <tr id="tr2" runat="server">
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table3" id="table2">
                        <tr>
                            <td>记录类型</td>
                            <td>记录人</td>
                            <td>记录时间</td>
                            <td>说明</td>
                        </tr>
                       <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#((Model.CheckLogType)Eval("Type")==Model.CheckLogType.Quality)?"质检":"抽检" %></td>
                                <td><%#Eval("UserName") %></td>
                                <td><%#((DateTime)Eval("AddTime")).ToString("yyyy-MM-dd") %></td>
                                <td><%#Eval("Description") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    </table>
                 </td>
            </tr>
            
    </table>
        </div>
    </asp:Content>
