using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using EmployeeInfo.Config;
using System.IO;
using System.Globalization;

namespace EmployeeInfo.Default
{
    public partial class Default : System.Web.UI.Page
    {
        Connection con = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeeNo();
                GrideViewLoad();
            }
        }
        private void EmployeeNo()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT         MAX(EmployeeNo)+1 AS EmployeeNo FROM              EmployeeRecord", con.conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conn;
                con.conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    txtEmployeeNo.Text = sdr["EmployeeNo"].ToString();
                 
                }
                con.conn.Close();
            }
        }
        private void Update()
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

            FileUpload1.SaveAs(Server.MapPath("~/upload/" + filename));
            string sql = @"Update  EmployeeRecord
                         set   Title=@Title ,EmployeeName=@EmployeeName,Photo=@Photo ,Phone=@Phone ,Address=@Address, NIC=@NIC ,DOB=@DOB ,City=@City ,path=@path where( EmployeeNo ='" + txtEmployeeNo.Text + "')";

            SqlCommand MyCommand = new SqlCommand(sql, con.conn);


            MyCommand.Parameters.AddWithValue("@Title", drpTitle.Text);
            MyCommand.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
            MyCommand.Parameters.AddWithValue("@Photo", "~/upload/" + filename);
            MyCommand.Parameters.AddWithValue("@Phone", txtPhone.Text);
            MyCommand.Parameters.AddWithValue("@Address", txtAddress.Text);
            MyCommand.Parameters.AddWithValue("@NIC", txtNIc.Text);
            MyCommand.Parameters.AddWithValue("@DOB", txtDateOfBirth.Text);
            MyCommand.Parameters.AddWithValue("@City",drpCity.Text);
            MyCommand.Parameters.AddWithValue("@Gender",rbNGender.Text);
            MyCommand.Parameters.AddWithValue("@path", filename);
            con.conn.Open();
            int Result = MyCommand.ExecuteNonQuery();
            con.conn.Close();

            if (Result > 0)
            {


                string msg = "SuccessFully Update";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + msg + "');", true);
                EmployeeNo();
                GrideViewLoad();

            }
            else
            {
                string msg = "Update fail";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + msg + "');", true);
                return;
            }
        }
        private void Save()
        {

       
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

            FileUpload1.SaveAs(Server.MapPath("~/upload/" + filename));

            string sql = @"INSERT INTO  EmployeeRecord
                            (EmployeeNo,Title,Photo,EmployeeName,Phone,Address,NIC,DOB,City,Gender,path)
                            VALUES        (@EmployeeNo,@Title,@Photo,@EmployeeName,@Phone,@Address,@NIC,@DOB,@City,@Gender,@path)";

            SqlCommand MyCommand = new SqlCommand(sql, con.conn);
           
           

         
            MyCommand.Parameters.AddWithValue("@EmployeeNo", txtEmployeeNo.Text);
            MyCommand.Parameters.AddWithValue("@Title", drpTitle.SelectedValue);
            MyCommand.Parameters.AddWithValue("@Photo", "~/upload/" +  filename);
            MyCommand.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
            MyCommand.Parameters.AddWithValue("@Phone", txtPhone.Text);
            MyCommand.Parameters.AddWithValue("@Address", txtAddress.Text);
            MyCommand.Parameters.AddWithValue("@NIC", txtNIc.Text);

            MyCommand.Parameters.AddWithValue("@DOB", txtDateOfBirth.Text);
            MyCommand.Parameters.AddWithValue("@City", drpCity.SelectedValue);
            MyCommand.Parameters.AddWithValue("@Gender", rbNGender.Text);
            MyCommand.Parameters.AddWithValue("@path", filename);


            con.conn.Open();
            int Result = MyCommand.ExecuteNonQuery();
            con.conn.Close();

            if (Result > 0)
            {

                string msg = "Success";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + msg + "');", true);
                EmployeeNo();
                GrideViewLoad();
            }
            else
            {

            }

        }
        private void GrideViewLoad()
        {
            con.conn.Open();  // open the connection 
            SqlDataAdapter Sqa = new SqlDataAdapter("select * from EmployeeRecord", con.conn);
            DataSet ds = new DataSet();
            Sqa.Fill(ds);   // fill the dataset 
            dgvData.DataSource = ds; // give data to GridView
            dgvData.DataBind();
            con.conn.Close();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                Save();
            }
            if (btnSave.Text == "Update")
            {
                Update();
            }


        }

        protected void dgvData_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
            txtEmployeeName.Text = dgvData.SelectedRow.Cells[2].Text;
            txtEmployeeNo.Text = dgvData.SelectedRow.Cells[0].Text;
            txtPhone.Text = dgvData.SelectedRow.Cells[3].Text;
      

            string DateString = dgvData.SelectedRow.Cells[4].Text;
            DateTime date = Convert.ToDateTime(DateString);
            txtDateOfBirth.Text = date.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
            txtNIc.Text = dgvData.SelectedRow.Cells[5].Text;
            txtAddress.Text = dgvData.SelectedRow.Cells[6].Text;
            drpTitle.SelectedItem.Text = dgvData.SelectedRow.Cells[7].Text;
            rbNGender.Text = dgvData.SelectedRow.Cells[8].Text;
            drpCity.SelectedItem.Text = dgvData.SelectedRow.Cells[9].Text;
            txtEmployeeNo.ReadOnly = true;
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
           
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = @"DELETE FROM            dbo.EmployeeRecord
                            WHERE (EmployeeNo= '" + txtEmployeeNo.Text + "' )";

            SqlCommand MyCommand = new SqlCommand(sql, con.conn);
            con.conn.Open();
            int Result = MyCommand.ExecuteNonQuery();
            con.conn.Close();

            if (Result > 0)
            {
                string msg = "Successfully Delete";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + msg + "');", true);
                EmployeeNo();
                GrideViewLoad();

                //  SerachDetails();
            }
            else
            {

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            drpCity.SelectedItem.Text = "--Select PLease--";
            drpTitle.SelectedItem.Text= "--Select PLease--";
            txtNIc.Text = "";
            txtEmployeeName.Text = "";
            rbNGender.Text = "";
            txtPhone.Text = "";
            txtDateOfBirth.Text = "";
            txtAddress.Text = "";
            txtEmployeeNo.ReadOnly = false;

        }

     
        protected void btnReport_Click1(object sender, EventArgs e)
        {
            Session["ReportName"] = "EmployeeReport.rpt";
            // Session["Backlink"] = "frmMushakReport.aspx";
            Session["Qurey"] = "SELECT       * FROM dbo.EmployeeRecord   WHERE        (EmployeeNo = N'" + txtEmployeeNo.Text+ "' )";
            Response.Redirect("~/WebForm1.aspx");

        }

      
    }
}