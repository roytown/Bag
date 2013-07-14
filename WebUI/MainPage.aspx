<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="MainPage.aspx.cs" Inherits="WebUI.MainPage" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    	<div class="welcome">
        <div class="dcl">
            <h2>待处理</h2>
            <ul>
                <li><a href="#"><img src="../images/li_01.png" />待办事项<b>(3)</b></a></li>
                <li><a href="#"><img src="../images/li_02.png" />未查看消息<b>(3)</b></a></li>
                <li><a href="#"><img src="../images/li_03.png" />待审核任务<b>(3)</b></a></li>
                <li><a href="#"><img src="../images/li_04.png" />新接收任务<b>(3)</b></a></li>
                <li><a href="#"><img src="../images/li_05.png" />新订单<b>(3)</b></a></li>
            </ul>
        </div>
        <div class="kjcz">
            <h2>快捷操作</h2>
            <ul>
                <li><a href="#"><span><img src="../images/li_001.png" /></span><b>新建研发任务</b></a></li>
                <li><a href="#"><span><img src="../images/li_002.png" /></span><b>检索研发任务</b></a></li>
                <li><a href="#"><span><img src="../images/li_001.png" /></span><b>新建生产任务</b></a></li>
                <li><a href="#"><span><img src="../images/li_002.png" /></span><b>检索研发任务</b></a></li>
                <li><a href="#"><span><img src="../images/li_003.png" /></span><b>订单时间统计</b></a></li>
                <li><a href="#"><span><img src="../images/li_004.png" /></span><b>提交质检记录</b></a></li>
                <li><a href="#"><span><img src="../images/li_005.png" /></span><b>指派质检员</b></a></li>
                <li><a href="#"><span><img src="../images/li_006.png" /></span><b>指派质检负责负责人</b></a></li>
                <li><a href="#"><span><img src="../images/li_006.png" /></span><b>指派任务负责人</b></a></li>
                <li><a href="#"><span><img src="../images/li_007.png" /></span><b>审核研发任务</b></a></li>
            </ul>
        </div>
    </div>
   
</asp:Content>