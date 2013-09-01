using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controls
{
    public class AttachmentField : HiddenField
    {
        private const string SWFUPLOAD_JS = "Controls.Upload.swfupload.js";
        private const string SWFUPLOAD_SWF = "Controls.Upload.swfupload.swf";
        private const string SWFUPLOAD_BTN = "Controls.Images.uploadbtn.png";
        private const string SWFUPLOAD_HANDLER = "Controls.Upload.handlers.js";
        private const string SWFUPLOAD_DEFAULTIMAGE_ERROR = "Controls.Images.error.gif";
        private const string SWFUPLOAD_DEFAULTIMAGE_TOOBIG = "Controls.Images.toobig.gif";
        private const string SWFUPLOAD_DEFAULTIMAGE_UPLOADLIMIT = "Controls.Images.uploadlimit.gif";
        private const string SWFUPLOAD_DEFAULTIMAGE_ZEROBYTE = "Controls.Images.zerobyte.gif";

        private const string SWFUPLOAD_DEFAULTIMAGE_GIF = "Controls.Images.format.gif.png";
        private const string SWFUPLOAD_DEFAULTIMAGE_JPEG = "Controls.Images.format.jpeg.png";
        private const string SWFUPLOAD_DEFAULTIMAGE_BMP = "Controls.Images.format.bmp.png";
        private const string SWFUPLOAD_DEFAULTIMAGE_PNG = "Controls.Images.format.png.png";
        private const string SWFUPLOAD_DEFAULTIMAGE_MP3 = "Controls.Images.format.mp3.png";
        private const string SWFUPLOAD_DEFAULTIMAGE_PDF = "Controls.Images.format.pdf.png";
        private const string SWFUPLOAD_DEFAULTIMAGE_DOCX = "Controls.Images.format.docx.png";
        private const string SWFUPLOAD_DEFAULTIMAGE_XLSX = "Controls.Images.format.xlsx.png";
        private const string SWFUPLOAD_DEFAULTIMAGE_PPTX = "Controls.Images.format.pptx.png";
        private const string SWFUPLOAD_DEFAULTIMAGE_RAR = "Controls.Images.format.rar.png";
        private const string SWFUPLOAD_DEFAULTIMAGE_ZIP = "Controls.Images.format.zip.png";
        private const string SWFUPLOAD_DEFAULTIMAGE_DELETE = "Controls.Images.delete.png";
       
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
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("SWFUPLOAD_DEFAULTICON"))
            {
                StringBuilder builder = new StringBuilder("<script type='text/javascript'>");
                builder.Append("var SWFUPLOAD_ICON={deleteimg:'" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_DELETE) + "',");
                builder.Append("gificon:'" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_GIF) + "',");
                builder.Append("jpegicon:'" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_JPEG) + "',");
                builder.Append("bmpicon:'" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_BMP) + "',");
                builder.Append("pngicon:'" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_PNG) + "',");
                builder.Append("docxicon:'" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_DOCX) + "',");
                builder.Append("xlsxicon:'" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_XLSX) + "',");
                builder.Append("pptxicon:'" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_PPTX) + "',");
                builder.Append("raricon:'" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_RAR) + "',");
                builder.Append("zipicon:'" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_ZIP) + "',");
                builder.Append("pdficon:'" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_PDF) + "',");
                builder.Append("mp3icon:'" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_MP3) + "'}");
                builder.Append("</script>");

                this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "SWFUPLOAD_DEFAULTICON", builder.ToString());
            }

           
            this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Attachment" + this.UniqueID, BuildScript());

            base.OnLoad(e);
        }
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            string delimg=Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_DELETE);
            string deleteurl=ResolveClientUrl(DeleteUrl);
            writer.Write("<div id='" + this.ClientID + "_AttachContainer' " + (string.IsNullOrEmpty(ContainerCssClass) ? "" : ("class='" + ContainerCssClass + "'")) + ">");
            writer.Write("<div class='"+this.ButtonStyle+"'><span id=\"" + this.ClientID + "_buttonPlaceholder\"></span></div>");
            writer.Write("<div id=\"" + this.ClientID + "_fileProgressContainer\" style=\"height: 75px;\"></div>");
            writer.Write("<div id=\"" + this.ClientID + "_thumbnails\">");
            if (!string.IsNullOrEmpty(Value))
            {
                string[] arr = Value.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in arr)
                {
                    writer.Write("<div style='float:left;margin:5px;height:130px;overflow:hidden;width:80px;position:relative'>");
                    writer.Write("<img style='position:absolute;top:0px;right:0px;width:16px;cursor:pointer' src='" + delimg + "' url='" + item + "' onclick=\"javascript:deleteimg($(this),'" + deleteurl + "','" + this.ClientID + "');\"/>");
                    writer.Write("<img style='width:80px;' src='" + GetIcon(Path.GetExtension(item).ToLower()) + "'/>");
                    writer.Write("<span style='width:80px;height:25px;line-height:25px;float:left;text-align:center;overflow:hidden'>" + Path.GetFileNameWithoutExtension(item) + "</span>");
                    writer.Write("<div>");
                }
            }
            writer.Write("</div>");
            writer.Write("</div>");
            base.Render(writer);

        }

        private string GetIcon(string ext)
        {
            string icon="";
            switch (ext)
            {
                case ".jpg":
                    icon = Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_JPEG);
                    break;
                case ".png":
                    icon = Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_PNG);
                    break;
                case ".gif":
                    icon = Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_GIF);
                    break;
                case ".bmp":
                    icon = Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_BMP);
                    break;
                case ".pdf":
                    icon = Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_PDF);
                    break;
                case ".doc":
                case ".docx":
                    icon = Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_DOCX);
                    break;
                case ".xls":
                case ".xlsx":
                    icon = Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_XLSX);
                    break;
                case "ppt":
                case ".pptx":
                    icon = Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_PPTX);
                    break;
                case ".rar":
                    icon = Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_RAR);
                    break;
                case ".zip":
                    icon = Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_DEFAULTIMAGE_ZIP);
                    break;
            }
            return icon;
        }

        private string BuildScript()
        {
            StringBuilder builder = new StringBuilder("<script type='text/javascript'>");
           
            builder.Append("$(document).ready(function(){");
            builder.Append("var swfu_" + this.ClientID + ";");
            builder.Append("swfu_" + this.ClientID + " = new SWFUpload({upload_url: '" + ResolveClientUrl(this.UploadUrl) + "',post_params: {\"PHPSESSID\": \"NONE\"},file_size_limit : \"" + this.FileSizeLimit.ToString() + " MB\",	file_types : \"" + FileTypes + "\",file_upload_limit : \"0\",file_queue_error_handler : fileQueueError,	file_dialog_complete_handler : fileDialogComplete,upload_progress_handler : uploadProgress,	upload_error_handler : uploadError,	upload_success_handler : uploadSuccess,	upload_complete_handler : uploadComplete,");
            builder.Append("button_placeholder_id : \"" + this.ClientID + "_buttonPlaceholder\",button_width: " + this.ButtonWidth.ToString() + ",button_height: " + this.ButtonHeight.ToString() + ",button_text : '" + this.ButtonText + "',button_text_style:'"+this.ButtonTextStyle+"',button_window_mode: SWFUpload.WINDOW_MODE.TRANSPARENT,button_cursor: SWFUpload.CURSOR.HAND,");
            builder.Append("flash_url : \"" + Page.ClientScript.GetWebResourceUrl(this.GetType(), SWFUPLOAD_SWF) + "\",");
            builder.Append("custom_settings : {id:'" + this.ClientID + "',deleteurl:'"+ResolveClientUrl(this.DeleteUrl)+"',upload_target : \"" + this.ClientID + "_fileProgressContainer\",thumbnail_target:\"" + this.ClientID + "_thumbnails\"},debug: false});");
            builder.Append("});");
            builder.Append("</script>");

            return builder.ToString();
        }



        public string ContainerCssClass
        {
            get
            {
                if (this.ViewState["ContainerCssClass"] != null)
                {
                    return (string)this.ViewState["ContainerCssClass"];
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["ContainerCssClass"] = value;
            }
        }

        public string ButtonTextStyle
        {
            get
            {
                if (this.ViewState["ButtonTextStyle"] != null)
                {
                    return (string)this.ViewState["ButtonTextStyle"];
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["ButtonTextStyle"] = value;
            }
        }

        public string ButtonText
        {
            get
            {
                if (this.ViewState["ButtonText"] != null)
                {
                    return (string)this.ViewState["ButtonText"];
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["ButtonText"] = value;
            }
        }

        public string ButtonStyle
        {
            get
            {
                if (this.ViewState["ButtonStyle"] != null)
                {
                    return (string)this.ViewState["ButtonStyle"];
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["ButtonStyle"] = value;
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
                return 18;
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

        public string DeleteUrl
        {
            get
            {
                if (this.ViewState["DeleteUrl"] != null)
                {
                    return (string)this.ViewState["DeleteUrl"];
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["DeleteUrl"] = value;
            }
        }        
    }
}
