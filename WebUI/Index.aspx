<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebUI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src=""></script>
    <style type="text/css">
    em.cuowu {
				color: red;
				font-size: 16px;
				font-weight: normal;
				line-height: 1.4;
				margin-top: 0.5em;
				
		}
    em.valid{color:black;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
       
       <table border="0" cellspacing="0" cellpadding="0" width="100%">
       	<tr>
       		<td>  <bag:TextBoxEx ID="tb" runat="Server" Type="Email"  IsRequired="true"/>   </td>
               <td></td>
       	</tr>
           <tr>
               <td><bag:CheckBoxEx ID="cb" runat="Server" IsRequired="true" /></td>
           </tr>
       </table>
       
   
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <div class="error">
            <ul>

            </ul>
        </div>
    </form>
</body>
</html>
