<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="AddOrder.aspx.cs" Inherits="WebUI.Order.AddOrder" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right">
          <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
            <tr>
                <td>任务编码：</td>
                <td  style="height:30px;">
                    <asp:Literal ID="LtCode" runat="server"></asp:Literal>
                 </td>
            </tr>
             <tr>
                <td>任务标题：</td>
                <td  style="height:30px;">
                    <asp:Literal ID="LtTitle" runat="server"></asp:Literal>
                 </td>
            </tr>
            <tr>
                <td>时间说明：</td>
                <td  style="height:30px;">
                    <asp:TextBox ID="tbTime" runat="server"></asp:TextBox>  
                 </td>
            </tr>
              <tr>
                <td>订单量说明：</td>
                <td  style="height:30px;">
                    <asp:TextBox ID="tbNum" runat="server"></asp:TextBox>  
                 </td>
            </tr>
             <tr>
            	<td class="td2_1">订单说明：</td>
                <td>
                    <bag:TextBoxEx ID="tbDescription" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input"  />
                    </td>
            </tr>
              <tr>
                  <td></td>
                  <td>

                       <asp:Button ID="BtnOk" runat="server" CssClass="button mr10" OnClientClick="javascript:var r=Confirm();return r;"  Text="确 定" OnClick="BtnOk_Click"/>
                    
                  </td>
              </tr>
        </table> 

     </div>
   
 </asp:Content>

