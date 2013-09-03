<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="AddCheckLog.aspx.cs" Inherits="WebUI.Order.AddCheckLog" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right">
         <div style="width:98%;margin:10px;">
             <bag:ButtonEx ID="btnResult" CssClass="button"  runat="server" Text="订单完成" Purview="order_resultlog" OnClick="btnResult_Click" />
             
         </div>
         <br /><br />
          <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
            <tr>
            	<td class="td2_1">说明：</td>
                <td>
                    <asp:RadioButtonList ID="RblType" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0" Text="抽检" Selected="True" />
                        <asp:ListItem Value="1" Text="质检" />
                    </asp:RadioButtonList>
                  
                    </td>
            </tr>
             <tr>
            	<td class="td2_1">说明：</td>
                <td>
                    <bag:TextBoxEx ID="tbDescription" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input"  />
                    </td>
            </tr>
              <tr>
                  <td></td>
                  <td>

                       <asp:Button ID="BtnOk" runat="server" CssClass="button mr10" Text="提交记录" OnClick="BtnOk_Click"/>
                    
                  </td>
              </tr>
        </table> 

     </div>
   
 </asp:Content>
