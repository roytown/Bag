using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;
using ExpressionExtended;
using TaskModule;
namespace WebUI.Stock
{
    public partial class StockLogManage : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void pager_Command(object sender, CommandEventArgs e)
        {
            int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
            pager1.CurrentIndex = currnetPageIndx;
            BindData();
        }

        private void BindData()
        {
            int count = 0;
            string user = Util.DataSecurity.FilterBadChar(RequestString("user"));
            string saleusername = Util.DataSecurity.FilterBadChar(RequestString("saleusername"));
            string code = Util.DataSecurity.FilterBadChar(RequestString("code"));
            DateTime? ds = RequestDateTime("ds");
            DateTime? de = RequestDateTime("de");

            Expression<Func<Model.StockLog, bool>> expression = m => true;
            if (!string.IsNullOrEmpty(saleusername))
            {
                PageStatus.Add("saleusername", saleusername);
                expression = expression.And(m => m.Task.SaleUserName.Contains(saleusername));
            }
            if (!string.IsNullOrEmpty(user))
            {

                PageStatus.Add("user", user);
                expression = expression.And(m => m.UserName.Contains(user));
            }
            if (!string.IsNullOrEmpty(code))
            {

                PageStatus.Add("code", code);
                expression = expression.And(m => m.Task.Code.Contains(code));
            }
            if (ds != null && ds.HasValue)
            {
                PageStatus.Add("ds", ds.Value.ToString("yyyy-MM-dd"));
                DateTime t1 = new DateTime(ds.Value.Year, ds.Value.Month, ds.Value.Day);
                expression = expression.And(m => m.AddTime >= t1);
            }
            if (de != null && de.HasValue)
            {

                PageStatus.Add("de", de.Value.ToString("yyyy-MM-dd"));
                DateTime dt = new DateTime(de.Value.Year, de.Value.Month, de.Value.Day + 1);
                expression = expression.And(m => m.AddTime <= dt);
            }

            string bigness = RequestString("bigness");
            if (!string.IsNullOrEmpty(bigness))
            {
                 PageStatus.Add("bigness",bigness);
                 expression = expression.And(m => m.Task.Bigness.Contains(bigness));
            }
            string brand = RequestString("brand");
            if (!string.IsNullOrEmpty(brand))
            {
                PageStatus.Add("brand", brand);
                expression = expression.And(m => m.Task.Brand.Contains(brand));
            }
            string carrypart = RequestString("carrypart");
            if (!string.IsNullOrEmpty(carrypart))
            {
                PageStatus.Add("carrypart", carrypart);
                expression = expression.And(m => m.Task.CarryPart.Contains(carrypart));
            }
            string color = RequestString("color");
            if (!string.IsNullOrEmpty(color))
            {
                PageStatus.Add("color", color);
                expression = expression.And(m => m.Task.Color.Contains(color));
            }
            string ecp = RequestString("ecp");
            if (!string.IsNullOrEmpty(ecp))
            {
                PageStatus.Add("ecp", ecp);
                expression = expression.And(m => m.Task.Ecp.Contains(ecp));
            }
            string fineness = RequestString("fineness");
            if (!string.IsNullOrEmpty(fineness))
            {
                PageStatus.Add("fineness", fineness);
                expression = expression.And(m => m.Task.Fineness.Contains(fineness));
            }
            string hardness = RequestString("hardness");
            if (!string.IsNullOrEmpty(hardness))
            {
                PageStatus.Add("hardness", hardness);
                expression = expression.And(m => m.Task.Hardness.Contains(hardness));
            }
            string internalstructure = RequestString("internalstructure");
            if (!string.IsNullOrEmpty(internalstructure))
            {
                PageStatus.Add("internalstructure", internalstructure);
                expression = expression.And(m => m.Task.InternalStructure.Contains(internalstructure));
            }
            string materail = RequestString("materail");
            if (!string.IsNullOrEmpty(materail))
            {
                PageStatus.Add("materail", materail);
                expression = expression.And(m => m.Task.Materail.Contains(materail));
            }
            string model = RequestString("model");
            if (!string.IsNullOrEmpty(model))
            {
                PageStatus.Add("model", model);
                expression = expression.And(m => m.Task.Model.Contains(model));
            }
            string pattern = RequestString("pattern");
            if (!string.IsNullOrEmpty(pattern))
            {
                PageStatus.Add("pattern", pattern);
                expression = expression.And(m => m.Task.Brand.Contains(pattern));
            }
            string popularelement = RequestString("popularelement");
            if (!string.IsNullOrEmpty(popularelement))
            {
                PageStatus.Add("popularelement", popularelement);
                expression = expression.And(m => m.Task.PopularElement.Contains(popularelement));
            }
            string price = RequestString("price");
            if (!string.IsNullOrEmpty(price))
            {
                PageStatus.Add("price", price);
                expression = expression.And(m => m.Task.Price.Contains(price));
            }
            string quality = RequestString("quality");
            if (!string.IsNullOrEmpty(quality))
            {
                PageStatus.Add("quality", quality);
                expression = expression.And(m => m.Task.Quality.Contains(quality));
            }
            string situation = RequestString("situation");
            if (!string.IsNullOrEmpty(situation))
            {
                PageStatus.Add("situation", situation);
                expression = expression.And(m => m.Task.Situation.Contains(situation));
            }
            string size = RequestString("size");
            if (!string.IsNullOrEmpty(size))
            {
                PageStatus.Add("size", size);
                expression = expression.And(m => m.Task.Size.Contains(size));
            }
            string style = RequestString("style");
            if (!string.IsNullOrEmpty(style))
            {
                PageStatus.Add("style", style);
                expression = expression.And(m => m.Task.Style.Contains(style));
            }
            string texture = RequestString("texture");
            if (!string.IsNullOrEmpty(texture))
            {
                PageStatus.Add("texture", texture);
                expression = expression.And(m => m.Task.Texture.Contains(texture));
            }
            string type = RequestString("type");
            if (!string.IsNullOrEmpty(type))
            {
                PageStatus.Add("type", type);
                expression = expression.And(m => m.Task.Type.Contains(type));
            }
            int collapse = RequestInt32("collapse",-1);
            if (collapse==0 || collapse==1)
            {
                PageStatus.Add("collapse", collapse.ToString());
                expression = expression.And(m => m.Task.Collapse == (collapse==1));
            }

            PageStatus.Add("page", pager1.CurrentIndex.ToString());
            Repeater1.DataSource = StockLogBll.GetStockLogList(pager1.CurrentIndex, pager1.PageSize, expression, out count,true);
            Repeater1.DataBind();
            pager1.ItemCount = count;

            if (count < pager1.PageSize)
            {
                pager1.Visible = false;
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                LinkButton lbDetail = e.Item.FindControl("lbDetail") as LinkButton;

                Model.StockLog log = e.Item.DataItem as Model.StockLog;

                lbDetail.OnClientClick = "javascript:OpenDialog('任务统计明细','/stock/statdetail.aspx?id=" + log.Task.Id.ToString() + "',800,500);return false;";
            }
        }
    }
}