﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="TaskFilter.aspx.cs" Inherits="WebUI.Task.TaskFilter" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div class="right">
          <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
            <tr>
                <td class="td2_1">发布时间：</td>
                <td colspan="3"  style="height:30px;">
                    <bag:Date ID="date1" runat="Server" DayOfWeekOffset="1"/> 至 <bag:Date ID="date2" runat="Server" DayOfWeekOffset="1"/>
                 </td>
            </tr>
             <tr>
                <td class="td2_1">任务标题：</td>
                <td  style="height:30px;">
                    <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>  
                 </td>
                  <td class="td2_1">任务编码：</td>
                <td  style="height:30px;">
                    <asp:TextBox ID="tbCode" runat="server"></asp:TextBox>  
                 </td>
            </tr>
            <tr>
                <td class="td2_1">EPC：</td>
                <td  style="height:30px;">
                    <asp:TextBox ID="tbEpc" runat="server"></asp:TextBox> 
                    <input type="button" style="padding:0px 5px 0px 5px;" onclick="javascript:readcard('<%=tbEpc.ClientID%>')" value="读卡" /> 
                 </td>
                <td class="td2_1">任务状态：</td>
                <td  style="height:30px;">
                    <asp:DropDownList ID="DdlStatus" runat="server">
                        <asp:ListItem Value="-1" Text="不限" />
                        <asp:ListItem Value="0" Text="新任务" />
                        <asp:ListItem Value="1" Text="已确认，待研发" />
                        <asp:ListItem Value="2" Text="研发确认，可开始研发" />
                        <asp:ListItem Value="3" Text="设计中" />
                        <asp:ListItem Value="4" Text="设计结束，可制版" />
                        <asp:ListItem Value="5" Text="制版中" />
                        <asp:ListItem Value="6" Text="制版结束，可打样" />
                        <asp:ListItem Value="7" Text="打样中" />
                        <asp:ListItem Value="8" Text="打样结束，样包可生产" />
                        <asp:ListItem Value="9" Text="样包生产中" />
                        <asp:ListItem Value="10" Text="样包已完成，等待客户确认" />
                        <asp:ListItem Value="11" Text="待客户确认订单" />
                        <asp:ListItem Value="12" Text="订单生产中" />
                        <asp:ListItem Value="13" Text="样包可入库" />
                        <asp:ListItem Value="14" Text="样包已入库" />
                    </asp:DropDownList>
                 </td>
            </tr>
            <tr>
                <td class="td2_1" style="height:30px;">发布人：</td>
                <td>
                     <asp:TextBox ID="tbUserName" CssClass="autocomplete-user" runat="server"></asp:TextBox>
                </td>
            
                <td class="td2_1" style="height:30px;">销售负责人：</td>
                <td>
                     <asp:TextBox ID="tbSaleUserName" CssClass="autocomplete-user" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                  <td></td>
                  <td colspan="3">

                       <asp:Button ID="BtnFilter" runat="server" CssClass="button mr10"  Text="筛选" OnClick="BtnFilter_Click"/>
                    
                  </td>
              </tr>
        </table> 

     </div>
  
 </asp:Content>
