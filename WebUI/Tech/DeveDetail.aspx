<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="DeveDetail.aspx.cs" Inherits="WebUI.Tech.DeveDetail" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
   <div class="right_list">
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
            <asp:Literal ID="LtEcp" runat="server"></asp:Literal>
        </td>
    </tr>
        <tr>
        <td class="td2_1">销售负责人：</td>
        <td colspan="3">
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
</asp:Content>
