<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebUI.Index" %>
<%@ Import Namespace="Web" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=Title %></title>
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
  	<link href="css/style.css" rel="stylesheet" type="text/css" />
  	<script type="text/javascript" src="Scripts/jquery-1.8.2.min.js"></script>
  	<script src="Scripts/main.js" type="text/javascript"></script>
    <style type="text/css">
		html{overflow-y:hidden;overflow-x:hidden;}
	</style>
</head>
<body>
    <form id="form1" runat="server">
      	<div class="wrap_s">
		<div class="wrap_top_s">
		<!-- top部分 -->
			<div class="top">
				<img src="<%=ResolveClientUrl("~/images/logo.png") %>"" class="logo" />
				<ul class="nav">

					<li class="nav_01"><a href="#">任务</a></li>
					<li class="nav_02"><a href="#">技术</a></li>
					<li class="nav_03"><a href="#">生产</a></li>
					<li class="nav_04"><a href="#">仓储</a></li>
					<li class="nav_05"  onclick="javascript:GetMenu('system')"><a href="javascript:void(0)">系统</a></li>
				</ul>
				<div class="login">
					<p class="login_left"></p>
					<dl class="login_middle">
						<dt><a href="#"><%=RequestContext.Current.User.UserName %></a></dt>
						<dt><a href="<%=ResolveClientUrl("~/logoff.aspx") %>">退出</a></dt>
					</dl>
					<p class="login_right"></p>
				</div>
			</div>
	<!-- //top部分 -->
	</div>
<script type="text/javascript">
    function GetMenu(m)
    {
     
        $("#menulist").css("display", "none");
        $("#loading").css("display", "block");
        $.get("<%=ResolveClientUrl("~/tools/LeftMenu.aspx")%>", { menu: m }, function (data) {
            $("#loading").css("display", "none");
            $("#menulist").css("display", "block");
            $("#menulist").html(data);
        });
    }
</script>
	<div class="wrap_con_s">
	<!-- left部分 -->
		<div class="wrap_con_l_s clearfix">
			<div class="left">
                <div id="loading" style="display:none;text-align:center;padding-top:50px;">
                    <img src="<%=ResolveClientUrl("~/images/loading.gif") %>" />
                </div>
				<ul id="menulist">
					<li><a href="">新建研发任务</a></li>
					<li><a href="">我负责的任务</a></li>
					<li><a href="" class="act">查询任务</a></li>
				</ul>
			</div>
		</div>
	<!-- //left部分 -->
	<!-- 内容部分 -->
		<div class="wrap_con_main_s clearfix">
			<iframe width="100%"  id="rightFrame" frameborder="0" src="MainPage.aspx"></iframe>
		</div>
	<!-- //内容部分 -->

	

	</div>

	</div>
	<script type="text/javascript">adjustIfrHt();</script>
    </form>
</body>
</html>
