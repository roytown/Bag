<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="AddOrder.aspx.cs" Inherits="WebUI.Order.AddOrder" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
  
    <div class="right" id="epcdiv" runat="Server">
     <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
        <tr>
            <td class="td2_1">EPC：</td>
            <td>
               <asp:TextBox ID="tbEpc" AutoPostBack="true" Enabled="true" OnTextChanged="tbEcp_TextChanged" runat="server" CssClass="input"/>
                    &nbsp;&nbsp;&nbsp;<input type="button" style="padding:0px 5px 0px 5px;" onclick="javascript:readcard('<%=tbEpc.ClientID%>');__doPostBack('<%=tbEpc.UniqueID%>','');" value="读卡" /> 
                </td>
        </tr>
    </table>
        </div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:Panel ID="PnNew" Visible="false" runat="server" CssClass="right">
          <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
            <tr>
                <td class="td2_1">完成时间：</td>
                <td>
                    <bag:Date ID="date1" runat="Server" />
                   
                </td>
            </tr>
              <tr>
               <td class="td2_1">订单量说明：</td>
                <td>
                    <bag:TextBoxEx ID="tbNum"  CssClass="input" runat="server" IsRequired="true" RequiredErrorMessage="请输入订单量说明"></bag:TextBoxEx> 件
                     
                 </td>
            </tr>
             <tr>
            	<td class="td2_1">其它说明：</td>
                <td>
                    <bag:TextBoxEx ID="tbDescription" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input"  />
                    </td>
            </tr>
              <tr>
                  <td></td>
                  <td>

                       <asp:Button ID="BtnOk" runat="server" CssClass="button mr10" Text="确 定" OnClick="BtnOk_Click"/>
                    
                  </td>
              </tr>
        </table> 
        
     </asp:Panel>
    <asp:Panel ID="PnChange" Visible="false" runat="server" CssClass="right">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
            <tr>
                <td class="td2_1">时间调整至：</td>
                <td>
                   <bag:Date ID="date2" runat="Server" />
                </td>
            </tr>
              <tr>
               <td class="td2_1">订单量说明：</td>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0">
                    	<tr>
                    		<td style="border:none"><asp:Literal ID="LtCurrentNum" runat="server"></asp:Literal> + </td>
                            <td style="border:none"><bag:TextBoxEx ID="tbAddNum"  onchange="javascript:calNum();" CssClass="input" runat="server" Width="50"></bag:TextBoxEx></td>
                            <td style="border:none">
                                = <span id="numspan"><asp:Literal ID="LtCurrentNum1" runat="server"></asp:Literal></span>件 
                            </td>
                    	</tr>
                    </table>

                 </td>
            </tr>
              <tr>
                  <td></td>
                  <td>

                       <asp:Button ID="Button1" runat="server" CssClass="button mr10" Text="确 定" OnClick="BtnOk_Click"/>
                    
                  </td>
              </tr>
        </table> 
       
    </asp:Panel>
            
      
     <script type="text/javascript">
         function calNum()
         {
             var o=$("#<%=tbAddNum.ClientID%>");
                var c=o.attr("currentnum");
                $("#numspan").html(new Number(c)+new Number(o.val()));
            }
        </script>
 </asp:Content>

