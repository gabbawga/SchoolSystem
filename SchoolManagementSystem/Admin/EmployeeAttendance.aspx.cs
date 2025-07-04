using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Admin
{
    public partial class EmployeeAttendance : System.Web.UI.Page
    {
        CommonFn.Commonfnx fn = new CommonFn.Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                GetAttendance();
            }
        }

        private void GetAttendance()
        {
            DataTable dt = fn.Fetch("select TeacherId,Name,Mobile,Email from Teacher");
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {


            foreach(GridViewRow row in GridView1.Rows)
            {
                int teacherId = Convert.ToInt32(row.Cells[1].Text);

                RadioButton rb1 = (row.Cells[0].FindControl("RadioButton1") as RadioButton);
                RadioButton rb2 = (row.Cells[0].FindControl("RadioButton2") as RadioButton);
                int status = 0;
                if (rb1.Checked)
                {
                    status = 1;
                }
                else if (rb2.Checked)
                {
                    status = 0;
                }

                string query = $"Insert Into TeacherAttendance values ({teacherId},{status}, '{DateTime.Now.ToString("yyy/MM/dd")}')";
                fn.Query(query);

                lblMsg.Text = "Inserted Succesffuly";
                lblMsg.CssClass = "alert alert-success";
            }
        }
    }
}