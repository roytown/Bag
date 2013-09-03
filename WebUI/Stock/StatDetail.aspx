<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="StatDetail.aspx.cs" Inherits="WebUI.Stock.StatDetail" %>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="Server">
    <!--[if lt IE 9]><script language="javascript" type="text/javascript" src="<%=ResolveClientUrl("~/scripts/jqplot/excanvas.min.js") %>"></script><![endif]-->
    <script type="text/javascript" src="<%=ResolveClientUrl("~/scripts/jqplot/jquery.jqplot.min.js") %>"></script>
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("/css/jquery.jqplot.min.css") %>" />
    <link type="text/css" rel="stylesheet" href="/css/shCoreDefault.min.css" />
    <link type="text/css" rel="stylesheet" href="/css/shThemejqPlot.min.css" />
    <script type="text/javascript" src="/scripts/jqplot/syntaxhighlighter/shCore.min.js"></script>
    <script type="text/javascript" src="/scripts/jqplot/syntaxhighlighter/shBrushJScript.min.js"></script>
    <script type="text/javascript" src="/scripts/jqplot/syntaxhighlighter/shBrushXml.min.js"></script>
    <script class="include" type="text/javascript" src="/scripts/jqplot/plugins/jqplot.barRenderer.min.js"></script>     <script class="include" type="text/javascript" src="/scripts/jqplot/plugins/jqplot.pieRenderer.min.js"></script>
  <script class="include" type="text/javascript" src="/scripts/jqplot/plugins/jqplot.categoryAxisRenderer.min.js"></script>
  <script class="include" type="text/javascript" src="/scripts/jqplot/plugins/jqplot.pointLabels.min.js"></script>
    <div class="right">
          <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
            <tr>
            	<td class="td2_1">任务编码：</td>
                <td>
                    <asp:Literal ID="LtCode" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">任务标题：</td>
                <td>
                    <asp:Literal ID="LtTitle" runat="server"></asp:Literal>
                </td>

           	</tr>
             <tr>
            	<td class="td2_1">任务说明：</td>
                <td colspan="3">
                    <asp:Literal ID="LtDescription" runat="server"></asp:Literal>
                </td>
           	</tr>
            <tr>
                <td colspan="4">
                    统计图表
                </td>
            </tr>
              <tr>
                <td colspan="4">
                    <script class="code" type="text/javascript">$(document).ready(function () {
                        $.jqplot.config.enablePlugins = true;
                        var s1 = <%=s1%>;
                        var ticks =<%=Ticks%>;

                        plot1 = $.jqplot('chart1', [s1], {
                           
                            animate: !$.jqplot.use_excanvas,
                            seriesDefaults: {
                                renderer: $.jqplot.BarRenderer,
                                rendererOptions: {               
                                    varyBarColor: true
                                },
                                pointLabels: { show: true }
                            },
                            title:'任务统计报表',
                            axesDefaults:{
                                max:<%=maxDays+5%>
                            },
                            axes: {
                                xaxis: {
                                    renderer: $.jqplot.CategoryAxisRenderer,
                                    ticks: ticks
                                }
                            },
                            highlighter: { show: false }
                        });
                    });</script>                    <div id="chart1" style="margin-top:20px; margin-left:20px; width:650px; height:300px;"></div>
                </td>
            </tr>
        </table>
</div>
</asp:Content>
