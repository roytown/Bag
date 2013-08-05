using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controls
{
    public class Date:TextBox
    {
        protected override void OnLoad(EventArgs e)
        { 
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("jquery"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "jquery", "<script src=\"" + this.ResolveClientUrl("~/Scripts/jquery-1.8.2.min.js") + "\" type=\"text/javascript\"></script>");
            }
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("glDatePicker"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "glDatePicker", "<script src=\"" + this.ResolveClientUrl("~/Scripts/glDatePicker.min.js") + "\" type=\"text/javascript\"></script>");
            }

            base.OnLoad(e);
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);

            writer.AddAttribute("gldp-id", this.ClientID + "_date");
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            writer.Write(" <div gldp-el=\"" + this.ClientID + "_date\"  style=\"width:"+this.PickerWidth.ToString()+"px; height:"+this.PickerHeight.ToString()+"px; position:absolute; top:70px; left:100px;\"></div>");
            writer.Write("<script type='text/javascript'>$('#" + this.ClientID + "').glDatePicker({showAlways: false,cssName:'default',dowOffset:"+DayOfWeekOffset.ToString()+",allowMonthSelect: true, allowYearSelect: true,selectedDate: new Date(" + SelectedDate.Year.ToString() + "," + SelectedDate.Month.ToString() + "," + SelectedDate.Day.ToString() + ")});</script>");
        }

        public string Theme
        {
            get
            {
                if (this.ViewState["Theme"] != null)
                {
                    return (string)this.ViewState["Theme"];
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["Theme"] = value;
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                if (!string.IsNullOrEmpty(Text))
                {
                    return DateTime.Parse(this.Text);

                    //return DateTime.Now;
                   // string[] arr = this.Text.Split(new char[] { '年', '月', '日' }, StringSplitOptions.RemoveEmptyEntries);
                   // return new DateTime(int.Parse(arr[0]), int.Parse(arr[1]), int.Parse(arr[2]));  
                }

                return DateTime.Now;
            }
            set
            {
                this.ViewState["SelectedDate"] = value;
            }
        }

        public int PickerWidth
        {
            get
            {
                if (this.ViewState["PickerWidth"] != null)
                {
                    return (int)this.ViewState["PickerWidth"];
                }
                return 300;
            }
            set
            {
                this.ViewState["PickerWidth"] = value;
            }
        }

        public int PickerHeight
        {
            get
            {
                if (this.ViewState["PickerHeight"] != null)
                {
                    return (int)this.ViewState["PickerHeight"];
                }
                return 300;
            }
            set
            {
                this.ViewState["PickerHeight"] = value;
            }
        }

        public int DayOfWeekOffset
        {
            get
            {
                if (this.ViewState["DayOfWeekOffset"] != null)
                {
                    return (int)this.ViewState["DayOfWeekOffset"];
                }
                return 0;
            }
            set
            {
                this.ViewState["DayOfWeekOffset"] = value;
            }
        }
    }
}
