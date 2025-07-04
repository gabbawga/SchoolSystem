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
    public partial class EmployeeDetails : System.Web.UI.Page
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
                GetTeacher();
            }
        }

        private void GetTeacher()
        {
            DataTable dt = fn.Fetch("select * from teacher");
            ddlTeacher.DataSource = dt;
            ddlTeacher.DataValueField = "TeacherId";
            ddlTeacher.DataTextField = "Name";
            ddlTeacher.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int teacherId = Convert.ToInt32(ddlTeacher.SelectedValue);
            string data = txtCalendar.Text.Trim();
                
            string query = $"select ta.id, t.Name, ta.status, ta.Date from TeacherAttendance ta inner join Teacher t on ta.TeacherId = t.TeacherId where t.TeacherId = {teacherId} and ta.Date = '{data}'";

            DataTable dt = fn.Fetch(query);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            lblMsg.Text = "Inserted Succesffuly";
            lblMsg.CssClass = "alert alert-success";
        }
    }
}
