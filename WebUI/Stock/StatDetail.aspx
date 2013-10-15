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

    <script class="include" type="text/javascript" src="/scripts/jqplot/plugins/jqplot.barRenderer.min.js"></script>
     <script class="include" type="text/javascript" src="/scripts/jqplot/plugins/jqplot.pieRenderer.min.js"></script>
  <script class="include" type="text/javascript" src="/scripts/jqplot/plugins/jqplot.categoryAxisRenderer.min.js"></script>
  <script class="include" type="text/javascript" src="/scripts/jqplot/plugins/jqplot.pointLabels.min.js"></script>
    <div class="right">
          <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table2">
            <tr>
            	<td class="td2_1">任务编码：</td>
                <td>
                    &nbsp;<asp:Literal ID="LtCode" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">任务标题：</td>
                <td>
                    &nbsp;<asp:Literal ID="LtTitle" runat="server"></asp:Literal>
                </td>

           	</tr>
             <tr>
            	<td class="td2_1">型号：</td>
                <td>
                    &nbsp;<asp:Literal ID="LtModel" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">款式：</td>
                <td>
                    &nbsp;<asp:Literal ID="LtType" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">材质：</td>
                <td>
                   &nbsp;<asp:Literal ID="LtMaterial" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">品质：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtQuality" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">品牌：</td>
                <td>
                   &nbsp; <asp:Literal ID="LTBrand" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">颜色：</td>
                <td>
                  &nbsp; <asp:Literal ID="LtColor" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">硬度：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtHardness" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">成色：</td>
                <td>
                    &nbsp;<asp:Literal ID="LtFineness" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">尺寸：</td>
                <td>
                    &nbsp;<asp:Literal ID="LtSize" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">图案：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtPattern" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">大小：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtBigness" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">价格：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtPrice" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">风格：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtStyle" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">里料质地：</td>
                <td>
                  &nbsp;  <asp:Literal ID="LtTexture" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">内部结构：</td>
                <td>
                  &nbsp;  <asp:Literal ID="LtInternalStructure" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">提拎部件：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtCarryPart" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">可否折叠：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtCollapse" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">箱包场合：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtSituation" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">流行元素：</td>
                <td>
                   &nbsp;<asp:Literal ID="LtPopularElement" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">EPC：</td>
                <td>
                   &nbsp; <asp:Literal ID="LtEcp" runat="server"></asp:Literal>
                </td>
           	</tr>
             <tr>
            	<td class="td2_1">任务说明：</td>
                <td colspan="3">
                   &nbsp; <asp:Literal ID="LtDescription" runat="server"></asp:Literal>
                </td>
           	</tr>
             
            <tr>
                <td colspan="4">
                    统计图表
                </td>
            </tr>
              <tr>
                <td colspan="4" style="position:relative;height:400px;" valign="top">
                    
                    <div style="padding:10px;float:left;">
                        <ul style="list-style-type:none">
                            <li style="float:left;border:solid 1px #cccccc;margin:5px;padding:5px; cursor:pointer " onclick="showtype(1)">柱状图</li>
                            <li style="float:left;border:solid 1px #cccccc;margin:5px;padding:5px;cursor:pointer" onclick="showtype(2)">饼状图</li>
                        </ul>
                    </div>
                    <script class="code" type="text/javascript">
                        var array=<%=datearray%>;
                    $(document).ready(function () {
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
                            title:'任务统计柱状图报表(以天为单位)',
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
                     
                     $('#chart1').bind('jqplotDataHighlight', 
                            function (ev, seriesIndex, pointIndex, data) {
                                       
                                $('#info2').html(array[pointIndex]);
                                $("#info2").css("display","block");
                                $("#info2").css("left",ev.pageX);
                                $("#info2").css("top",ev.pageY-50);
                            }
                        );
                    
                     $('#chart1').bind('jqplotDataUnhighlight', 
                         function (ev) {
                             $("#info2").css("display","none");
                         }
                     );

                     var plot3 = $.jqplot('chart2', <%=pie%>, {
                         seriesDefaults:{
                             shadow: false, 
                             renderer:$.jqplot.PieRenderer, 
                             rendererOptions:{
                                 showDataLabels: true
                             }
                         },
                         title:'任务统计饼状图报表',
                         legend:{ show: true }      
                     });
                    });
                      
                        function showtype(a)
                        {
                            if(a==1)
                            {
                                $("#chart2").css("z-index","-1");
                                $("#chart1").css("z-index","999");
                            }
                            else
                            {
                                $("#chart2").css("z-index","999");
                                $("#chart1").css("z-index","-1");
                            }
                        }
                    </script>
                    <div id="chart1" style="z-index:999;position:absolute;left:0px;top:30px;margin-top:20px; margin-left:20px; width:650px; height:300px;">
                        
                    </div>
                    <div id="chart2" style="z-index:-1; position:absolute;left:0px;top:30px; margin-top:20px; margin-left:20px; width:650px; height:300px;"></div>

                </td>
            </tr>
        </table>
</div>
    <div id="info2" style="display:none;left:0px;border:solid 1px #cccccc;z-index:10000;top:100px;position:absolute; background-color:white;padding:5px;">

    </div>
</asp:Content>
