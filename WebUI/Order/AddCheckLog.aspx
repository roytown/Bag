<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="AddCheckLog.aspx.cs" Inherits="WebUI.Order.AddCheckLog" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <div id="epcdiv" class="right">
         <table id="epctable" runat="server" cellpadding="0" cellspacing="0" border="0" width="98%" class="table2">
             <tr>
            	<td class="td2_1">EPC：</td>
                <td>
                    <asp:TextBox ID="tbEpc" AutoPostBack="true" Enabled="true" OnTextChanged="tbEcp_TextChanged" runat="server" CssClass="input"/>
                    &nbsp;&nbsp;&nbsp;<input type="button" style="padding:0px 5px 0px 5px;" onclick="javascript:readcard('<%=tbEpc.ClientID%>');__doPostBack('<%=tbEpc.UniqueID%>','');" value="读卡" /> 
                </td>
           	</tr>
         </table>
     </div>
    <div id="maindiv" runat="server" class="right" visible="false">
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
                    <bag:TextBoxEx ID="tbDescription" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input" IsRequired="true" MaxTextLength="255" FormatErrorMessage="内容长度不能超过255个字符" RequiredErrorMessage="请输入质检说明"  />
                    </td>
            </tr>
              <tr>
                  <td></td>
                  <td>
                      <asp:HiddenField ID="HiddenField1" runat="server" />
                       <asp:Button ID="BtnOk" runat="server" CssClass="button mr10" Text="提交记录" OnClick="BtnOk_Click"/>
                    
                  </td>
              </tr>
        </table> 

     </div>
   
 </asp:Content>
