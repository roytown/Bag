<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="StockFilter.aspx.cs" Inherits="WebUI.Stock.StockFilter" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right">
          <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
            <tr>
                <td>按入库时间：</td>
                <td  style="height:30px;">
                    <bag:Date ID="date1" runat="Server" DayOfWeekOffset="1"/> 至 <bag:Date ID="date2" runat="Server" DayOfWeekOffset="1"/>
                 </td>
            </tr>
             <tr>
                <td>按任务编码：</td>
                <td  style="height:30px;">
                    <asp:TextBox ID="tbCode" runat="server"></asp:TextBox>  
                 </td>
            </tr>
            <tr>
                <td>按销售负责人：</td>
                <td  style="height:30px;">
                    <asp:TextBox ID="tbSaleUserName" CssClass="autocomplete-user" runat="server"></asp:TextBox>  
                 </td>
            </tr>
            
            <tr>
                <td style="height:30px;">按入库操作人：</td>
                <td>
                     <asp:TextBox ID="tbUserName" CssClass="autocomplete-user" runat="server"></asp:TextBox>
                </td>

            </tr>
            
              <tr>
                  <td></td>
                  <td>

                       <asp:Button ID="BtnFilter" runat="server" CssClass="button mr10"  Text="筛选" OnClick="BtnFilter_Click"/>
                    
                  </td>
              </tr>
        </table> 

     </div>
   
 </asp:Content>
