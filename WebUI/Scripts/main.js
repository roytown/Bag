
function adjustIfrHt(){
    var ht = $(window).height();
	var topHeader = $(".top").height();
    $(".wrap_con_l_s clearfix").height(ht);
    $("#rightFrame").height(ht);
    $(".wrap_con_l_s clearfix").height(ht - topHeader);
    $("#rightFrame").height(ht - topHeader);
}
$(window).resize(adjustIfrHt);



