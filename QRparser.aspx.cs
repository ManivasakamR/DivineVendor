using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
    SQLContext DBContext;
    public string filename = "";
    string srcfile = ""; string dstfile = "";
    ImageCompressor Ic;
    public string userID = "";
    public double reqMor;
    public double reqEve;
    public double todayReqMor;
    public double todayReqEve;
    public string currentDate;
    
    protected void Page_Load(object sender, EventArgs e)
    {        
        currentDate = DateTime.Now.ToString("dd/MMM/yyyy");        
        DBContext = new SQLContext();
        try
        {
            HttpCookie DivineQRFile = Request.Cookies["DivineQRFile"];
            filename = DivineQRFile["Filename"].ToString();
        }
        catch (Exception exq)
        {
            Response.Redirect("ScanQR.html");
        }
        try {
            srcfile =Path.Combine(Request.MapPath("~/upload"), filename);
            dstfile= Path.Combine(Request.MapPath("~/upload/proc"), filename);                        
            Ic = new ImageCompressor(srcfile, dstfile);            
        }
        catch(Exception eXc)
        {

        }        

        var QCreader = new BarcodeReader();        
        var QCresult = QCreader.Decode(new Bitmap(dstfile));
        userID = QCresult.Text;
        if (QCresult != null)
        {        

            SqlCommand cmd = new SqlCommand("select count(*) from  Tbl_User_Details where Var_Udtl_Uid='" + QCresult.Text + "'", DBContext._SqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read()) {
                i=dr.GetInt32(0);
            }

            dr.Close();
            if (i == 1)
            {
                SqlCommand cmd1 = new SqlCommand("select Var_Udtl_Name,Var_Udtl_DoorNo," +
                    "Var_Udtl_ApartmentName,Var_Udtl_AreaName,Flt_Udtl_reqMor" +
                    ",Flt_Udtl_reqEve from Tbl_User_Details where  Var_Udtl_Uid='"+QCresult.Text+"'", DBContext._SqlConnection);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-success' role='alert'>"));                                        
                    MyServerControlDiv.Controls.Add(new LiteralControl("<h3 style='font-size:18px !important; text-align:center;'><strong> " + dr1.GetValue(0).ToString() + " </strong></h3>"));
                    MyServerControlDiv.Controls.Add(new LiteralControl("<h4 style='font-size:16px !important;text-align:center;'> Door No " + dr1.GetValue(1).ToString() + "</h4>"));
                    MyServerControlDiv.Controls.Add(new LiteralControl("<h4 style='font-size:16px !important;text-align:center;'> " + dr1.GetValue(2).ToString() + "</h4>"));
                    MyServerControlDiv.Controls.Add(new LiteralControl("<h4 style='font-size:16px !important;text-align:center;'> " + dr1.GetValue(3).ToString() + "</h4>"));
                    MyServerControlDiv.Controls.Add(new LiteralControl("<h3 style='font-size:18px !important;text-align:center;'> <strong> Req. Morning: </strong>" + dr1.GetValue(4).ToString() + "</h3>"));
                    MyServerControlDiv.Controls.Add(new LiteralControl("<h3 style='font-size:18px !important;text-align:center;'> <strong> Req. Eve: </strong>" + dr1.GetValue(5).ToString() + "</h3>"));
                    MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
                    isRecordExist();                    
                }
                dr1.Close();
            }
            else
            {
                MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-info alert-dismissible' role='alert'>"));
                MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert'><span aria-hidden='true'>&times;</span></button>"));
                MyServerControlDiv.Controls.Add(new LiteralControl("<strong>Sorry!</strong> the information doesnot exist. further details please contact administrator."));                
                MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
            }            
           
        }
        else
        {
            Response.Redirect("ScanQR.html");
        }        
    }

    public void isRecordExist()
    {
        
        SqlCommand cmd2 = new SqlCommand("select count(*) from  Tbl_Purchase_Details where Var_Purdtl_UId='" + userID + "' and Dt_Purdtl_Date='" + currentDate + "'", DBContext._SqlConnection);
        SqlDataReader dr2 = cmd2.ExecuteReader();
        int i = 0;
        while (dr2.Read())
        {
            i = dr2.GetInt32(0);
        }
        dr2.Close();     

        if (i == 0)
        {
            string purID=getPurID();
            SqlCommand cmd3 = new SqlCommand("insert into Tbl_Purchase_Details values('"+purID+"','"+userID+"','"+ currentDate + "',0,0,'N')", DBContext._SqlConnection);
            cmd3.ExecuteNonQuery();
        }
        getTodaysData();
    }
    public void getTodaysData() {
        SqlCommand cmd4 = new SqlCommand("select Flt_Purdtl_Morning,Flt_Purdtl_Evening from Tbl_Purchase_Details where Var_Purdtl_UId='" + userID + "' and Dt_Purdtl_Date='" + currentDate + "'", DBContext._SqlConnection);
        SqlDataReader dr4 = cmd4.ExecuteReader();
        SqlCommand cmd5 = new SqlCommand("select Flt_Udtl_reqMor,Flt_Udtl_reqEve from Tbl_User_Details where Var_Udtl_Uid='" + userID + "'", DBContext._SqlConnection);
        SqlDataReader dr5 = cmd5.ExecuteReader();

        while (dr5.Read())
        {
            reqMor = dr5.GetDouble(0);
            reqEve = dr5.GetDouble(1);
        }
        while (dr4.Read())
        {
            todayReqMor = dr4.GetDouble(0);
            todayReqEve = dr4.GetDouble(1);
        }

        if (reqMor == todayReqMor)
        {
            BtnProcess.Text = "Mor. Deliveried";
            BtnProcess.Enabled = false;
        }
        if (reqEve == todayReqEve)
        {
            BtnProcess1.Text = "Eve. Deliveried";
            BtnProcess1.Enabled = false;
        }
    }

    public string getPurID() {
        string count = "0";
        SqlCommand cmd6 = new SqlCommand("select count(*) from Tbl_Purchase_Details", DBContext._SqlConnection);
        SqlDataReader dr6 = cmd6.ExecuteReader();
        while (dr6.Read())
        {
            count = dr6.GetValue(0).ToString();
        }
        int nc = Convert.ToInt32(count);
        nc++;
        string ncount = nc.ToString();
        string CompId = "DivinePur0" + ncount;
        dr6.Close();
        return CompId;        
    }
    public void sendNotification(string session) {
        string msg = currentDate.ToString()+" Dear " + userID+"! our vendors have deliveried milk for your "+session+" purchase. have it and enjoy thanks. regards, team Divine milks.";
        SqlCommand cmd7 = new SqlCommand("insert into Tbl_User_Notifications values('"+ getNotifId() +"','"+ userID+"','"+msg+"')", DBContext._SqlConnection);
        cmd7.ExecuteNonQuery();        
    }
    public string getNotifId() {
        string count = "0";
        SqlCommand cmd8 = new SqlCommand("select count(*) from Tbl_User_Notifications", DBContext._SqlConnection);
        SqlDataReader dr8 = cmd8.ExecuteReader();
        while (dr8.Read())
        {
            count = dr8.GetValue(0).ToString();
        }
        int nc = Convert.ToInt32(count);
        nc++;
        string ncount = nc.ToString();
        string CompId = "DivineNotif00" + ncount;
        dr8.Close();
        return CompId;
     }

    protected void BtnProcess_Click(object sender, EventArgs e)
    {
        SqlCommand cmd9 = new SqlCommand("update Tbl_Purchase_Details set Flt_Purdtl_Morning='"+reqMor+ "' where Var_Purdtl_UId='" + userID + "' and Dt_Purdtl_Date='" + currentDate + "'", DBContext._SqlConnection);
        cmd9.ExecuteNonQuery();
        sendNotification("morning");
        BtnProcess.Text = "Mor. Deliveried";
        BtnProcess.Enabled = false;
        sxusMsg();
        addQRScanBtn();

    }

    protected void BtnProcess1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd10 = new SqlCommand("update Tbl_Purchase_Details set Flt_Purdtl_Evening='" + reqEve + "' where Var_Purdtl_UId='" + userID + "' and Dt_Purdtl_Date='" + currentDate + "'", DBContext._SqlConnection);
        cmd10.ExecuteNonQuery();
        sendNotification("evening");
        BtnProcess1.Text = "Eve. Deliveried";
        BtnProcess1.Enabled = false;
        sxusMsg();
        addQRScanBtn();

    }
    public void sxusMsg()
    {
        DivInfo.Controls.Add(new LiteralControl("<div class='alert alert-info alert-dismissible' role='alert'>"));
        DivInfo.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert'><span aria-hidden='true'>&times;</span></button>"));
        DivInfo.Controls.Add(new LiteralControl("<strong>Success!</strong> Notification sent."));
        DivInfo.Controls.Add(new LiteralControl("</div>"));
    }
    public void addQRScanBtn()
    {
        DivInfo.Controls.Add(new LiteralControl("<a class='btn btn-primary btn-block' href='ScanQR.html' style='text-align:center; margin-top:2px;'>Scan next</a>"));
    }

}