<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MainMaster.Master" CodeBehind="DeveConfirm.aspx.cs" Inherits="WebUI.Tech.DeveConfirm" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
     <div class="right">
        	<table cellpadding="0" cellspacing="0" border="0" width="98%" class="table2">
        		<tr>
            	   <td class="td2_1">任务编码：</td>
                    <td>
                       &nbsp<asp:Literal ID="LtCode" runat="server"></asp:Literal>
                     </td>
                    <td class="td2_1">任务标题：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtTitle" runat="server"></asp:Literal>
                    </td>

           	    </tr>
                
                 <tr>
            	    <td class="td2_1">型号：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtModel" runat="server"></asp:Literal>
                    </td>
                    <td class="td2_1">款式：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtType" runat="server"></asp:Literal>
                        </td>
           	    </tr>
                <tr>
            	    <td class="td2_1">材质：</td>
                    <td>
                       &nbsp<asp:Literal ID="LtMaterial" runat="server"></asp:Literal>
                    </td>
                    <td class="td2_1">品质：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtQuality" runat="server"></asp:Literal>
                        </td>
           	    </tr>
                <tr>
            	    <td class="td2_1">品牌：</td>
                    <td>
                        &nbsp<asp:Literal ID="LTBrand" runat="server"></asp:Literal>
                    </td>
                    <td class="td2_1">颜色：</td>
                    <td>
                       &nbsp<asp:Literal ID="LtColor" runat="server"></asp:Literal>
                        </td>
           	    </tr>
                <tr>
            	    <td class="td2_1">硬度：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtHardness" runat="server"></asp:Literal>
                    </td>
                    <td class="td2_1">成色：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtFineness" runat="server"></asp:Literal>
                        </td>
           	    </tr>
                <tr>
            	    <td class="td2_1">尺寸：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtSize" runat="server"></asp:Literal>
                    </td>
                    <td class="td2_1">图案：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtPattern" runat="server"></asp:Literal>
                        </td>
           	    </tr>
                <tr>
            	    <td class="td2_1">大小：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtBigness" runat="server"></asp:Literal>
                    </td>
                    <td class="td2_1">价格：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtPrice" runat="server"></asp:Literal>
                        </td>
           	    </tr>
                <tr>
            	    <td class="td2_1">风格：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtStyle" runat="server"></asp:Literal>
                    </td>
                    <td class="td2_1">里料质地：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtTexture" runat="server"></asp:Literal>
                        </td>
           	    </tr>
                <tr>
            	    <td class="td2_1">内部结构：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtInternalStructure" runat="server"></asp:Literal>
                    </td>
                    <td class="td2_1">提拎部件：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtCarryPart" runat="server"></asp:Literal>
                        </td>
           	    </tr>
                <tr>
            	    <td class="td2_1">可否折叠：</td>
                    <td>
                       &nbsp <asp:Literal ID="LtCollapse" runat="server"></asp:Literal>
                    </td>
                    <td class="td2_1">箱包场合：</td>
                    <td>
                        &nbsp<asp:Literal ID="LtSituation" runat="server"></asp:Literal>
                        </td>
           	    </tr>
                <tr>
            	    <td class="td2_1">流行元素：</td>
                    <td>
                       &nbsp<asp:Literal ID="LtPopularElement" runat="server"></asp:Literal>
                    </td>
                   <td class="td2_1">研发负责人：</td>
                    <td>
                       &nbsp <bag:TextBoxEx ID="tbDevelopUserName" Width="100" runat="Server" CssClass="input autocomplete-user"  IsRequired="true" RequiredErrorMessage="请输入研发负责人" Purview="tech_confirm"/>
                     </td>
           	    </tr>
                 <tr>
            	    <td class="td2_1">任务说明：</td>
                    <td colspan="3">
                        &nbsp<asp:Literal ID="LtDescription" runat="server"></asp:Literal>
                    </td>
           	    </tr>
                <tr>
                     <td class="td2_1">EPC：</td>
                    <td colspan="3">
                        <asp:Literal ID="LtEcp" runat="server"></asp:Literal>
                        &nbsp;&nbsp;
                        <input type="button" value="写卡" style="padding:0px 5px 0px 5px" onclick="javascript:writecard('<%=ecp%>');return false;"/>
                    </td>
                    
                </tr>
               
                <tr>
            		<td class="td2_1">补充说明：</td>
                    <td colspan="3">
                        <bag:TextBoxEx ID="tbDescription" Width="400" runat="Server" MaxTextLength="255" FormatErrorMessage="内容长度不能超过255个字符" TextMode="MultiLine" Rows="6" CssClass="input"  />
                     </td>
            	</tr>
        		<tr>
            		<td class="td2_1"></td><td colspan="3">
                        <asp:Button ID="BtnOk" OnClick="BtnOk_Click" OnClientClick="javascript:return checkuser();" runat="server" CssClass="button" Text="提  交" />
            
                        </td>
            	</tr>
        	</table>
        </div>
    <script type="text/javascript">
        var w=false;
        function checkuser()
        {
            var r=w;
            if (!w) {
                alert("当前没有写卡，无法提交");
                return false;
            }
            var u=$("#<%=tbDevelopUserName.ClientID%>").val();
            if (u==null||u=="") {
                alert("当前没有分配研发负责人，无法提交");
                return false;
               
            }

            return true;
        }
        function writecard(a)
        {
            var ret;
            var rdcard = document.getElementById("rdcard");
            ret = rdcard.Connet();
            if (ret != 1) {
                alert("连接设备失败");
                return;
            }
            
            if (rdcard.WriteData(1, 2, 6, a,"00000000") == 1) {
                alert("写入成功");
                w=true;
            }
            else {
                alert("写入失败!");
            }

            rdcard.DisConnect();

        }
    </script>
</asp:Content>