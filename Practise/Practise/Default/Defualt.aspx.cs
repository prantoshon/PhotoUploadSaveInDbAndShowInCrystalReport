using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Practise.Config;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;

namespace Practise.Default
{
    public partial class Defualt : System.Web.UI.Page
    {
        Conncetion con = new Conncetion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeePinDropDownload();
                ScriptManager.GetCurrent(this).RegisterPostBackControl(this.btnSave);

            }
           
        }
        private void EmployeePinDropDownload()
        {

            con.conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT   PIN as Pin,Pin + ' | ' + Name_of_Employee as Name FROM            hrd.Employee", con.conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            drpEmployee.DataTextField = "Name";
            drpEmployee.DataValueField = "Pin";
            drpEmployee.DataSource = rdr;
            drpEmployee.DataBind();
            drpEmployee.Items.Insert(0, new ListItem("---Select Employee---", "0"));
            con.conn.Close();


        }
        private void Department(string field)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT        hrd.Department.Name, hrd.Department.Code, hrd.Employee.PIN FROM            hrd.Department INNER JOIN hrd.Employee ON hrd.Department.Code = hrd.Employee.Department_Code  WHERE(hrd.Employee.PIN = @Value1)", con.conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conn;
                con.conn.Open();
                cmd.Parameters.AddWithValue("@Value1", field);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    txtDepartmnet.Text = sdr["Name"].ToString();
                

                }
                con.conn.Close();
            }
        }
        protected void drpEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            Department(drpEmployee.SelectedValue);
        }

        protected void Yeschk_CheckedChanged(object sender, EventArgs e)
        {
            if (Yeschk.Checked == true)
            {
                Nochk.Checked = false;
            }
          
        }

        protected void Nochk_CheckedChanged(object sender, EventArgs e)
        {
            if (Nochk.Checked == true)
            {
                Yeschk.Checked = false;
            }
          
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
             
    
            if (FileUpload1.HasFile)
            {
                
                string[] fileName = FileUpload1.FileName.Split('.');
                if ((fileName[fileName.Length - 1] == "jpg") ||
                    (fileName[fileName.Length - 1] == "gif") ||
                    (fileName[fileName.Length - 1] == "bmp") ||
                    (fileName[fileName.Length - 1] == "jpeg") ||
                    (fileName[fileName.Length - 1] == "png"))
                { }

                else
                {
                    string msg = "file not allow";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + msg + "');", true);
                    return;
                }
            } 
            SaveMethodCall();
        }

        private void SaveMethodCall()
        {
            //if (Validation() == 1) { return; }
            string outsideofdahaka ;
            if (Yeschk.Checked == true)
            {
                outsideofdahaka = "yes";
            }
            else
            {
                outsideofdahaka = "no";

            }
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            if (filename == "")
            {
                return;
            }

            FileUpload1.SaveAs(Server.MapPath("~/upload/" + filename));
            using (SqlCommand command = con.conn.CreateCommand())
            {
                command.CommandText = "INSERT INTO  Employeestatus (date,outsideofdahaka,covidstatus,deptpin,employeePin,photo,photopath) VALUES (@date,@outsideofdahaka,@covidstatus,@deptpin,@employeePin,@photo,@photopath)";

                command.Parameters.AddWithValue("@date", txtDate.Text.Trim());
                command.Parameters.AddWithValue("@outsideofdahaka", outsideofdahaka);
                command.Parameters.AddWithValue("@covidstatus", rbn.Text);
                command.Parameters.AddWithValue("@deptpin", txtDepartmnet.Text);
                command.Parameters.AddWithValue("@employeePin",drpEmployee.SelectedValue);
                command.Parameters.AddWithValue("@photo", "~/upload/" + filename);
                command.Parameters.AddWithValue("@photopath",  filename);
                con.conn.Open();
                int i = command.ExecuteNonQuery();

                if (i > 0)
                {

                    //Response.Write("<script>alert('Save Successfully');</script>");
                    string msg = "Success";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + msg + "');", true);
                    //ConncentionClose();
                    con.conn.Close();
                    //Grid();

                }

            }

          
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            Session["ReportName"] = "Test.rpt";
            // Session["Backlink"] = "frmMushakReport.aspx";
            Session["Qurey"] = "SELECT       * FROM dbo.Query ";
            Response.Redirect("~/Report/ReportViewer.aspx");
        }
    }
}