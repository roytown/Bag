<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="AddTask.aspx.cs" Inherits="WebUI.Task.AddTask" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
     <div class="right">
        	<table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
        		<tr>
            		<td class="td2_1">任务名称：</td>
                    <td>
                        <bag:TextBoxEx ID="tbName" runat="Server" IsRequired="true" CssClass="input" RequiredErrorMessage="请输入任务标题" />
                    </td>
                    <td class="td2_1">任务编码：</td>
                    <td>
                        <bag:TextBoxEx ID="tbCode" runat="Server" Purview="task_code" CssClass="input"  />
                        <span id="codemsg" style="display:none" class="wrong">当前编码已经被使用</span>
                        <script type="text/javascript">                          
                            $(document).ready(function () {
                                $("#<%=tbCode.ClientID%>").bind("change", function () {
                                    $(this).addClass("ui-autocomplete-loading");
                                    $.get("/tools/ajax.aspx", { action: 'checktaskcode', code: $(this).val(),r:Math.random() }, function (data) {
                                        $("#<%=tbCode.ClientID%>").removeClass("ui-autocomplete-loading");
                                        if (data != "ok")
                                        {
                                            $("#codemsg").css("display","block");
                                        }
                                        else
                                        {
                                            $("#codemsg").css("display", "none");
                                        }
                                    });
                                });
                            });
                        </script> 
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
                        <asp:RadioButtonList ID="RblCollapse" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1" Text="可折叠" Selected="True" />
                            <asp:ListItem Value="0" Text="不可折叠" />
                        </asp:RadioButtonList>
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
                        <asp:TextBox ID="tbEcp" Enabled="false" runat="Server"  CssClass="input"  />
                    </td>
           		</tr>
        		<tr>
            		<td class="td2_1">客户名称：</td>
                    <td>
                        <bag:TextBoxEx ID="tbCustomer" runat="Server" IsRequired="true" RequiredErrorMessage="请输入客户名称" CssClass="input"  />
                     </td>
                    <td class="td2_1">客户电话：</td>
                    <td>
                        <bag:TextBoxEx ID="tbTelephone" runat="Server"  Type="Telephone"  CssClass="input"   FormatErrorMessage="您输入的电话格式不正确"/>
                     </td>
            	</tr>
               
                <tr>
            		<td class="td2_1">客户手机：</td>
                    <td colspan="3">
                        <bag:TextBoxEx ID="tbMobilePhone" runat="Server" Type="MobilePhone" CssClass="input" FormatErrorMessage="您输入的手机格式不正确"  />
                     </td>
            	</tr>
                <tr>
            		<td class="td2_1">任务说明：</td>
                    <td colspan="3">
                        <bag:TextBoxEx ID="tbDescription" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input"  />
                     </td>
            	</tr>
        		<tr>
            		<td class="td2_1"></td><td colspan="3">
                        <asp:Button ID="BtnOk" OnClick="BtnOk_Click" runat="server" CssClass="button" Text="提  交" />
                       
                        </td>
            	</tr>
        	</table>
        </div>

</asp:Content>
