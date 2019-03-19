using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Register : System.Web.UI.Page
{

    public SQLContext DBContext;
    public SqlCommand _SqlCommand;
    public SqlDataAdapter _SqlDataAdapter;
    public SqlDataReader _SqlDataReader;
    public DataTable _DataTable;
    protected void Page_Load(object sender, EventArgs e)
    {
        DBContext = new SQLContext();
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void BtnRegister_Click1(object sender, EventArgs e)
    {
        int count = 0;
        SqlCommand cmd = new SqlCommand("select count(*) from Tbl_Vendor_Details where Var_Vdtl_Email='" + TxtEmail.Text + "'", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            count = dr.GetInt32(0);
        }
        dr.Close();

        if (count == 1)
        {
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-danger alert-dismissible' style='margin-top:5px;' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<strong> Email already exists! </strong> Please try to register with another one. "));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
        }
        else
        {
            try
            {
                _SqlCommand = new SqlCommand();
                string vendorId = getVendorID();
                string qry = "insert into Tbl_Vendor_Details "
                    + "values('" + vendorId + "','" + TxtUsername.Text + "'," + TxtMobile.Text + ",'" +  TxtAddress.Text + "'," + TxtPin.Text + ",'" + TxtEmail.Text + "','" + TxtPassword.Text + "')";
                _SqlCommand = new SqlCommand(qry, DBContext._SqlConnection);
                _SqlCommand.ExecuteNonQuery();
                HttpCookie DivineVendor = new HttpCookie("DivineVendor");
                DivineVendor["VendorId"] = vendorId;
                DivineVendor.Expires.Add(new TimeSpan(762, 0, 0));
                Response.Cookies.Add(DivineVendor);
                sendWelcocmeNotifications(vendorId,TxtUsername.Text);
                Response.Redirect("ScanQR.html", false);
            }
            catch (Exception exc)
            {
                Response.Redirect("ReqError.aspx");
            }
        }
    }
    public void sendWelcocmeNotifications(String _vendorId, String _userName)
    {
        string greetingMsg = "Hello "+_userName+"! we are happy, you are here! you have successfully registered  for vendor application thankyou. Regards, team Divine Admin. ";
        //string abtQr = "Dear "+_userName+ "! our delivery person need your qr identity on your door for carry our service better. Please find it on show qr menu in your app, print and stik on your door. thankyou. Regards, team Divine Admin.";
        //string abtPay = "Dear " + _userName + "! our vendors need payment at the end of every month to do our service more efficient. Be aware about to pay at month endings. thankyou. Regards, team Divine Admin.";
        SqlCommand _SqlCommand1 = new SqlCommand("insert into Tbl_Vendor_Notifications values('" + getNotID() + "','"+_vendorId+"','"+ greetingMsg + "')", DBContext._SqlConnection);
        _SqlCommand1.ExecuteNonQuery();
        //SqlCommand _SqlCommand2 = new SqlCommand("insert into Tbl_User_Notifications values('" + getNotID() + "','" + _userId + "','" + abtQr + "')", DBContext._SqlConnection);
        //_SqlCommand2.ExecuteNonQuery();
        //SqlCommand _SqlCommand3 = new SqlCommand("insert into Tbl_User_Notifications values('" + getNotID() + "','" + _userId + "','" + abtPay + "')", DBContext._SqlConnection);                
        //_SqlCommand3.ExecuteNonQuery();
    }
    private string getNotID()
    {
        string count = "0";
        SqlCommand cmd = new SqlCommand("select count(*) from Tbl_Vendor_Notifications", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            count = dr.GetValue(0).ToString();
        }
        int nc = Convert.ToInt32(count);
        nc++;
        string ncount = nc.ToString();
        string NotID = "DivineVNDRNot00" + ncount;
        dr.Close();
        return NotID;
    }
    private string getVendorID()
    {
        string count="0";
        SqlCommand cmd = new SqlCommand("select count(*) from Tbl_Vendor_Details", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            count = dr.GetValue(0).ToString();
        }
        int nc = Convert.ToInt32(count);
        nc++;
        string ncount = nc.ToString();
        string vendorID = "DivineVendor00"+ncount;
        dr.Close();
        return vendorID;
    }
    
}

