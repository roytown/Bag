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
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("glDatePicker"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "glDatePicker", "<script src=\"" + Page.ClientScript.GetWebResourceUrl(this.GetType(), "Controls.Date.glDatePicker.min.js") + "\" type=\"text/javascript\"></script>");
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
            DateTime s = SelectedDate.HasValue ? SelectedDate.Value : DateTime.Now;
            writer.Write("<script type='text/javascript'>$('#" + this.ClientID + "').glDatePicker({showAlways: false,cssName:'default',dowOffset:"+DayOfWeekOffset.ToString()+",allowMonthSelect: true, allowYearSelect: true,selectedDate: new Date(" + s.Year.ToString() + "," + (s.Month-1).ToString() + "," + s.Day.ToString() + ")});</script>");
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

        public DateTime? SelectedDate
        {
            get
            {
                if (!string.IsNullOrEmpty(Text))
                {
                    return DateTime.Parse(this.Text);
                }

                return null;
            }
            set
            {
                this.ViewState["SelectedDate"] = value;
                if (value!=null && value.HasValue)
                {
                    this.Text = value.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    this.Text = "";
                }
            }
        }

        public DateTime Value
        {
            get
            {
                if (!string.IsNullOrEmpty(Text))
                {
                    return DateTime.Parse(this.Text);
                }

                return DateTime.Now;
            }
            set
            {
                this.ViewState["Value"] = value;
              
               this.Text = value.ToString("yyyy-MM-dd");
                
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
