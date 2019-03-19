<%@ Page Language="C#"%>

<%        
    HttpCookie DivineQRFile = new HttpCookie("DivineQRFile");
    HttpFileCollection files = HttpContext.Current.Request.Files;
    HttpPostedFile uploadfile = files[0];
    uploadfile.SaveAs(Server.MapPath(".") + "\\upload\\" + uploadfile.FileName);
    DivineQRFile["Filename"] = uploadfile.FileName;
    DivineQRFile.Expires.Add(new TimeSpan(762, 0, 0));
    Response.Cookies.Add(DivineQRFile);
    HttpContext.Current.Response.Write("Upload successfully!");
%>
