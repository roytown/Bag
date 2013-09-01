<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Message.aspx.cs" Inherits="WebUI.Message" %>
<asp:Content ID="content" runat="Server" ContentPlaceHolderID="Content">
    <div style="width:90%;padding:10px;"></div>
  <div id="pop_s" class="pop_s_box tips_s_center" style="padding:0px;">
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
    	<tr>
    		<td>
                <div class="pop_bd_s">
                <span class="<%=IsSuccess?"success_s":"error_s" %> fl_s" ></span>
                <p class="tips_text fl_s">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </p>
            </div>
    		</td>
    	</tr>
        <tr>
            <td style="text-align:center;padding:10px;">
                <div class="tips_btn_s">
                    <asp:Repeater ID="Repeater1" runat="server">
                         <HeaderTemplate>
                             <ul>
                         </HeaderTemplate>
                        <ItemTemplate>
                           <li style="display:inline;"> <asp:HyperLink ID="HyperLink1" Target='<%#((bool)Eval("IsParent"))?"parent":"" %>' runat="server" NavigateUrl='<%#Eval("Url") %>' Text='<%#"["+Eval("Text")+"]" %>'></asp:HyperLink></li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
       
                </div>
            </td>
        </tr>
    </table>
    
    
     
</div>
</asp:Content>
