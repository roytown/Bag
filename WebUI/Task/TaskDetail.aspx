<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainMaster.Master" CodeBehind="TaskDetail.aspx.cs" Inherits="WebUI.Task.TaskDetail" %>
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
                    <asp:Literal ID="LtCode" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">任务标题：</td>
                <td>
                    <asp:Literal ID="LtTitle" runat="server"></asp:Literal>
                </td>

           	</tr>
             <tr>
            	<td class="td2_1">型号：</td>
                <td>
                    <asp:Literal ID="LtModel" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">款式：</td>
                <td>
                    <asp:Literal ID="LtType" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">材质：</td>
                <td>
                   <asp:Literal ID="LtMaterial" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">品质：</td>
                <td>
                    <asp:Literal ID="LtQuality" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">品牌：</td>
                <td>
                    <asp:Literal ID="LTBrand" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">颜色：</td>
                <td>
                   <asp:Literal ID="LtColor" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">硬度：</td>
                <td>
                    <asp:Literal ID="LtHardness" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">成色：</td>
                <td>
                    <asp:Literal ID="LtFineness" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">尺寸：</td>
                <td>
                    <asp:Literal ID="LtSize" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">图案：</td>
                <td>
                    <asp:Literal ID="LtPattern" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">大小：</td>
                <td>
                    <asp:Literal ID="LtBigness" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">价格：</td>
                <td>
                    <asp:Literal ID="LtPrice" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">风格：</td>
                <td>
                    <asp:Literal ID="LtStyle" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">里料质地：</td>
                <td>
                    <asp:Literal ID="LtTexture" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">内部结构：</td>
                <td>
                    <asp:Literal ID="LtInternalStructure" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">提拎部件：</td>
                <td>
                    <asp:Literal ID="LtCarryPart" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">可否折叠：</td>
                <td>
                    <asp:Literal ID="LtCollapse" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">箱包场合：</td>
                <td>
                    <asp:Literal ID="LtSituation" runat="server"></asp:Literal>
                    </td>
           	</tr>
            <tr>
            	<td class="td2_1">流行元素：</td>
                <td>
                   <asp:Literal ID="LtPopularElement" runat="server"></asp:Literal>
                </td>
                <td class="td2_1">EPC：</td>
                <td>
                    <asp:Literal ID="LtEcp" runat="server"></asp:Literal>
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
                    订单列表
                </td>
            </tr>
             <tr>
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table3" id="table1">
                        <tr>
                            <td>时间要求</td>
                            <td>数量要求</td>
                            <td>其他说明</td>
                            <td>发布人</td>
                            <td>生产负责人</td>
                            <td>质检负责人</td>
                            <td>提交时间</td>
                        </tr>
                       <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                              
                                <td><%#Eval("Time") %></td>
                                <td><%#Eval("Num") %></td>
                                <td><%#Eval("Description") %></td>
                                <td><%#Eval("UserName") %></td>
                                <td><%#(Eval("PublishUserName")==null || Eval("PublishUserName").ToString()=="")?"未确定":Eval("PublishUserName") %></td>
                                <td><%#(Eval("QualityUserName")==null|| Eval("QualityUserName").ToString()=="")?"未确定":Eval("QualityUserName") %></td>
                          
                                <td><%#((DateTime)Eval("AddTime")).ToString("yyyy-MM-dd") %></td>
                                
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    </table>
                </td>
        	</tr>
             <tr>
                 <td colspan="4">
                     操作明细
                 </td>
             </tr>
              <tr>
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" class="table3" id="table3">
                        <tr>
                            <td>操作类型</td>
                            <td>起始时间</td>
                            <td>结束时间</td>
                            <td>总用时</td>
                            <td>起始操作人</td>
                            <td>结束操作人</td>
                        </tr>
                        <asp:Repeater ID="RptLogs" OnItemDataBound="RptLogs_ItemDataBound" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Model.LogActionDictionary.Dic[(Model.LogAction)Eval("Action")] %></td>
                                    <td>
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
                                    <td><asp:Literal ID="Literal2" runat="server"></asp:Literal></td>
                                    <td><asp:Literal ID="Literal3" runat="server"></asp:Literal></td>
                                    <td><%#Eval("StartUserName") %></td>
                                    <td><%#Eval("EndUserName") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
        	</tr>
            <tr id="stattr1" runat="server" visible="false">
                <td colspan="4">
                    统计图表
                </td>
            </tr>
              <tr id="stattr2" runat="server" visible="false">
                <td colspan="4" style="position:relative;height:400px;" valign="top">
                    <div style="width:100%;padding:10px;float:left;">
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
                    <div id="chart1" style="z-index:999;position:absolute;left:0px;top:30px;margin-top:20px; margin-left:20px; width:650px; height:300px;"></div>
                    <div id="chart2" style="z-index:-1; position:absolute;left:0px;top:30px; margin-top:20px; margin-left:20px; width:650px; height:300px;"></div>

                </td>
            </tr>
        </table>
</div>
    <div id="info2" style="display:none;left:0px;border:solid 1px #cccccc;z-index:10000;top:100px;position:absolute; background-color:white;padding:5px;">

    </div>
</asp:Content>