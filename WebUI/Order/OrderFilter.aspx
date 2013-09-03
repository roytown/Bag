<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="OrderFilter.aspx.cs" Inherits="WebUI.Order.OrderFilter" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right">
          <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
            <tr>
                <td>按时间：</td>
                <td  style="height:30px;">
                    <bag:Date ID="date1" runat="Server" DayOfWeekOffset="1"/> 至 <bag:Date ID="date2" runat="Server" DayOfWeekOffset="1"/>
                 </td>
            </tr>
             <tr>
                <td>按生产负责人：</td>
                <td  style="height:30px;">
                    <asp:TextBox ID="tbPublishUserName" CssClass="autocomplete-user" runat="server"></asp:TextBox>  
                 </td>
            </tr>
            <tr>
                <td>按质检负责人：</td>
                <td  style="height:30px;">
                    <asp:TextBox ID="tbQualityUserName" CssClass="autocomplete-user" runat="server"></asp:TextBox>  
                 </td>
            </tr>
              <tr>
                <td>按任务编码：</td>
                <td  style="height:30px;">
                    <asp:TextBox ID="tbCode" runat="server"></asp:TextBox>  
                 </td>
            </tr>
             <tr>
                <td>按状态：</td>
                <td  style="height:30px;">
                    <asp:DropDownList ID="DdlStatus" runat="server">
                        <asp:ListItem Value="-1" Text="不限" />
                        <asp:ListItem Value="0" Text="新订单" />
                        <asp:ListItem Value="1" Text="进行中" />
                        <asp:ListItem Value="2" Text="订单已完成" />
                        
                    </asp:DropDownList>
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