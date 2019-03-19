using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    SQLContext DBContext;
    public string cookieVendorId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DBContext = new SQLContext();
        HttpCookie DivineVendor = Request.Cookies["DivineVendor"];
        cookieVendorId = DivineVendor["VendorId"].ToString();
    }

    protected void BtnRaise_Click(object sender, EventArgs e)
    {
        try
        {
            String CompId = getComplaintID();
            SqlCommand cmd = new SqlCommand("insert into Tbl_Admin_Notifications values('" + CompId + "','" + cookieVendorId + "','" + TxtAreaComplaint.Text + "')", DBContext._SqlConnection);
            cmd.ExecuteNonQuery();
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-info alert-dismissible' style='margin-top:8px;' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("Your notification has been <strong> sent.</strong>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
        }
        catch (Exception ex)
        {
            Response.Redirect("ReqError.aspx");
        }
    }
    public string getComplaintID()
    {
        string count = "0";
        SqlCommand cmd = new SqlCommand("select count(*) from Tbl_Admin_Notifications", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            count = dr.GetValue(0).ToString();
        }
        int nc = Convert.ToInt32(count);
        nc++;
        string ncount = nc.ToString();
        string CompId = "AdminNotif0" + ncount;
        dr.Close();
        return CompId;
    }
}