<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="CustomConfirmLog.aspx.cs" Inherits="WebUI.Task.CustomConfirmLog" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
     <div class="right">
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
            	<td class="td2_1">任务说明：</td>
                <td colspan="3">
                    <asp:Literal ID="LtDescription" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
            	<td class="td2_1">确认结果：</td>
                <td>
                    <asp:RadioButtonList ID="RblResult" RepeatDirection="Horizontal" RepeatLayout="Flow"  RepeatColumns="3" runat="server">
                        <asp:ListItem Value="0" Text="要求修改"  />
                        <asp:ListItem Value="1" Text="有订单" Selected="True"/>
                        <asp:ListItem Value="2" Text="无订单" />
                    </asp:RadioButtonList>
                </td>
            </tr>
          
        </table>

        <table id="order" cellpadding="0" cellspacing="0" border="0" width="98%" class="table2">
             <tr>
            	<td class="td2_1">订单数量说明：</td>
                <td style="padding-right:10px;">
                    <bag:TextBoxEx ID="tbOrderNum" Width="536px" Height="" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input"  />
                </td>
            </tr>
            <tr>
            	<td class="td2_1">订单时间说明：</td>
                <td>
                    <bag:TextBoxEx ID="tbOrderTime" Width="100%" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input"  />
                </td>
            </tr>
            <tr>
            	<td class="td2_1">其它说明：</td>
                <td>
                    <bag:TextBoxEx ID="tbOrderDesc" Width="100%" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input"  />
                </td>
            </tr>
         </table>

         <div style="padding-left:200px;padding-top:20px;">

              <asp:Button ID="BtnOk" OnClick="BtnOk_Click" runat="server" CssClass="button" Text="提  交" />
            
         </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $("input").bind("click", function () {
                if($(this).val()=="1")
                {
                    $("#order").css("display", "block");
                }
                else
                {
                    $("#order").css("display", "none");
                }
            });
        });
    </script>

</asp:Content>
