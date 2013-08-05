<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" MasterPageFile="~/MainMaster.Master" CodeBehind="Message.aspx.cs" Inherits="WebUI.Message" %>
<asp:Content ID="content" runat="Server" ContentPlaceHolderID="Content">
  <div id="pop_s" class="pop_s_box tips_s_center" style="display:block;left:35%;">
    <div class="pop_hd_s">
        <span class="tips_title_s">消息提示</span>
    </div>
    <div class="pop_bd_s h100_s clearfix">
        <span class="<%=IsSuccess?"success_s":"error_s" %> fl_s"></span>
        <p class="tips_text fl_s">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </p>
    </div>
    <div class="tips_btn_s">
        <asp:Repeater ID="Repeater1" runat="server">
             <HeaderTemplate>
                 <ul>
             </HeaderTemplate>
            <ItemTemplate>
               <li> <asp:HyperLink ID="HyperLink1" Target='<%#((bool)Eval("IsParent"))?"parent":"" %>' runat="server" NavigateUrl='<%#Eval("Url") %>' Text='<%#"["+Eval("Text")+"]" %>'></asp:HyperLink></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
       
    </div>
</div>
</asp:Content>
