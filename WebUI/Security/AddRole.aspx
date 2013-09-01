﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="AddRole.aspx.cs" Inherits="WebUI.Security.AddRole" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
     <div class="right">
    	
        	<table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
        		<tr>
            		<td class="td2_1">角色名称：</td>
                    <td>
                        <bag:TextBoxEx ID="tbName" runat="Server" IsRequired="true" CssClass="input" RequiredErrorMessage="请输入角色名称" />
                        </td>
           		</tr>
        		<tr>
            		<td class="td2_1">角色说明：</td>
                    <td>
                        <bag:TextBoxEx ID="tbDescription" Height="130" runat="Server" TextMode="MultiLine" Rows="6" CssClass="input"  />
                     </td>
            	</tr>
        		<tr>
            		<td class="td2_1">权限设置：</td>
                    <td>  
                      
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        	 <asp:Repeater ID="RptResource" runat="server" OnItemDataBound="RptResource_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td style="border-right:none">
                                            <%#Eval("Name") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border:none">
                                            <asp:Repeater ID="RptPurview" runat="server">
                                                <ItemTemplate>
                                                    <input type="checkbox" name="purview" <%#CheckedResult(currentResource+"_"+Eval("Value").ToString()) %> value="<%#currentResource+"_"+Eval("Value") %>"/><%#Eval("Name") %>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                       
                    </td>
            	</tr>
        		
        		<tr>
            		<td class="td2_1"></td><td>
                        <asp:Button ID="BtnOk" OnClick="BtnOk_Click" runat="server" CssClass="coolbg" Text="提  交" />
                        </td>
            	</tr>
        	</table>
        </div>

</asp:Content>
