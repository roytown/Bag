using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controls
{
    public class FileUpload:CompositeControl
    {
        private TextBox _textbox;
        private HiddenField _hidden;

        private const string SWFUPLOAD_JS = "Controls.Upload.swfupload.js";
        private const string SWFUPLOAD_SWF = "Controls.Upload.swfupload.swf";
        private const string SWFUPLOAD_HANDLER = "Controls.Upload.fileupload.js";
        private const string SWFUPLOAD_BTN = "Controls.Images.uploadbtn.png";
        protected override void OnLoad(EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(SWFUPLOAD_JS))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), SWFUPLOAD_JS, "<script src=\"" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_JS) + "\" type=\"text/javascript\"></script>");
            }

            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(SWFUPLOAD_HANDLER))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), SWFUPLOAD_HANDLER, "<script src=\"" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_HANDLER) + "\" type=\"text/javascript\"></script>");
            }

            EnsureChildControls();

            this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "FileUpload" + this.UniqueID, BuildScript());

            base.OnLoad(e);
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            _textbox = new TextBox();
            _textbox.ID = "tb";
            _textbox.Width = Width;
            _textbox.Height = Height;
            _textbox.CssClass = CssClass;
            _textbox.Enabled = false;
            this.Controls.Add(_textbox);
            _hidden = new HiddenField();
            _hidden.ID = "hd";
            this.Controls.Add(_hidden);
        }


        protected override void Render(HtmlTextWriter writer)
        {
            EnsureChildControls();
            writer.Write("<div id='" + this.ClientID + "_AttachContainer'>");
            _textbox.RenderControl(writer);
            writer.Write("&nbsp;&nbsp;<span id=\"" + this.ClientID + "_buttonPlaceholder\"></span>");
            writer.Write("<div id=\"" + this.ClientID + "_fileProgressContainer\" style=\"height:75px;display:none\"></div>");
            _hidden.RenderControl(writer);

            writer.Write("</div>");
          
        }

        private string BuildScript()
        {
            StringBuilder builder = new StringBuilder("<script type='text/javascript'>");
            builder.Append("$(document).ready(function(){");
            builder.Append("var swfu_" + this.ClientID + ";");
            builder.Append("swfu_" + this.ClientID + " = new SWFUpload({upload_url: '" + ResolveClientUrl(this.UploadUrl) + "',file_post_name:'resume_file',file_size_limit : \"" + this.FileSizeLimit.ToString() + " MB\",	file_types : \"" + FileTypes + "\",file_upload_limit : \"0\",file_queue_limit:'1',");
            //handler
            builder.Append("file_queued_handler : fileQueued,file_queue_error_handler : fileQueueError,upload_progress_handler : uploadProgress,upload_error_handler : uploadError,upload_success_handler : uploadSuccess,	upload_complete_handler : uploadComplete,");
            //button
            builder.Append("button_placeholder_id : \"" + this.ClientID + "_buttonPlaceholder\",button_width: " + this.ButtonWidth.ToString() + ",button_height: " + this.ButtonHeight.ToString() + ",button_image_url  : '" + ResolveClientUrl(this.ButtonImage) + "',button_cursor: SWFUpload.CURSOR.HAND,");
            //flash
            builder.Append("flash_url : \"" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_SWF) + "\",");
            //custom
            builder.Append("custom_settings : {id:'" + this.ClientID + "',hid:'"+_hidden.ClientID+"',tid:'"+_textbox.ClientID+"',progress_target  : \"" + this.ClientID + "_fileProgressContainer\"}");
            builder.Append(",debug: false});");
            builder.Append("});");
            builder.Append("</script>");

            return builder.ToString();
        }


        public string ButtonImage
        {
            get
            {
                if (this.ViewState["ButtonImage"] != null)
                {
                    return (string)this.ViewState["ButtonImage"];
                }
                return Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_BTN);
            }
            set
            {
                this.ViewState["ButtonImage"] = value;
            }
        }

        public int ButtonWidth
        {
            get
            {
                if (this.ViewState["ButtonWidth"] != null)
                {
                    return (int)this.ViewState["ButtonWidth"];
                }
                return 180;
            }
            set
            {
                this.ViewState["ButtonWidth"] = value;
            }
        }

        public int ButtonHeight
        {
            get
            {
                if (this.ViewState["ButtonHeight"] != null)
                {
                    return (int)this.ViewState["ButtonHeight"];
                }
                return 22;
            }
            set
            {
                this.ViewState["ButtonHeight"] = value;
            }
        }
        public int FileSizeLimit
        {
            get
            {
                if (this.ViewState["FileSizeLimit"] != null)
                {
                    return (int)this.ViewState["FileSizeLimit"];
                }
                return 1;
            }
            set
            {
                this.ViewState["FileSizeLimit"] = value;
            }
        }

        public string FileTypes
        {
            get
            {
                if (this.ViewState["FileTypes"] != null)
                {
                    return (string)this.ViewState["FileTypes"];
                }
                return "*.*";
            }
            set
            {
                this.ViewState["FileTypes"] = value;
            }
        }

        public string UploadUrl
        {
            get
            {
                if (this.ViewState["UploadUrl"] != null)
                {
                    return (string)this.ViewState["UploadUrl"];
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["UploadUrl"] = value;
            }
        }

        public string FilePath
        {
            get
            {
                EnsureChildControls();
                return _hidden.Value;
            }
            set
            {
                EnsureChildControls();
                _hidden.Value = value;
            }
        }
    }
}
