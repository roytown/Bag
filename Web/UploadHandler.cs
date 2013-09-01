using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Web
{
    public class UploadHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {

            try
            {
                if (context.Session["UserName"] == null)
                {
                    return;
                }
                string userName = context.Session["UserName"].ToString();

                if (context.Request.Files.Count > 0)
                {
                    WebConfig config = ConfigFactory.GetWebConfig();
                    string virtualPath = config.UploadDir + "/" + userName;
                    string uploadPath = context.Server.MapPath(context.Request.ApplicationPath + "/" + virtualPath);

                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    string fileName = "";
                    StringBuilder buider = new StringBuilder("{");
                    string basePath = VirtualPathUtility.AppendTrailingSlash(context.Request.ApplicationPath);
                    //for (int j = 0; j < context.Request.Files.Count; j++)
                    // {
                    HttpPostedFile uploadFile = context.Request.Files[0];
                    if (uploadFile.ContentLength > 0)
                    {
                        fileName = GetFileName(uploadPath, uploadFile.FileName);
                        uploadFile.SaveAs(Path.Combine(uploadPath, fileName));
                        //buider.Append("{");
                        buider.AppendFormat("filename:'{0}',dir:'{1}'", fileName, Path.Combine(virtualPath+"/", fileName));
                        //buider.Append("},");
                    }
                    //}
//                     if (buider.Length > 0)
//                     {
//                         buider.Remove(buider.Length - 1, 1);
//                     }
                    buider.Append("}");

                    context.Response.Write(buider.ToString());
                }

                
            }
            catch
            {
                context.Response.StatusCode = 500;
                context.Response.Write("An error occured");
                context.Response.End();
            }
            finally
            {
                context.Response.End();
            }

        }

        private string GetFileName(string dir, string fileName)
        {
            string fileNameNoext = Path.GetFileNameWithoutExtension(fileName);
            string ext = Path.GetExtension(fileName);
            string temp = fileNameNoext;
            int loop = 1;
            while (true)
            {
                if (!File.Exists(Path.Combine(dir, fileNameNoext+ext)))
                {
                    break;
                }

                fileNameNoext = temp + "(" + loop++.ToString() + ")";
            }

            return fileNameNoext + ext;
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}
