using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Models;
namespace SchoolManagementSystem.Admin
{
    public partial class Student : System.Web.UI.Page
    {
        CommonFn.Commonfnx fn = new CommonFn.Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudent();
                GetClass();
            }
        }

        private void GetClass()
        {
            DataTable dt = fn.Fetch($"select * from class");
            ddlClass.DataSource = dt;
            ddlClass.DataValueField = "ClassId";
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataBind();
        }

        private void GetStudent()
        {

            DataTable dt = fn.Fetch($"select s.StudentId, s.Name, s.DOB, s.Gender, s.Mobile, s.RollNo, s.Address, c.ClassName, s.ClassId from Student s inner join  Class c on s.ClassId = c.ClassId");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string dob = txtCalendar.Text.Trim();
                string gender = ddlGender.SelectedItem.Text.Trim();
                string mobile = txtMobile.Text.Trim();
                string rollNo = txtRollNo.Text.Trim();
                string address = txtAddress.Text.Trim();
                string classId = ddlClass.SelectedItem.Value;

                string query = $"Insert into Student  Values('{name}','{dob}','{gender}',{mobile},'{rollNo}','{address}',{classId})";

                fn.Query(query);


                lblMsg.Text = "Inserted Successfully";
                lblMsg.CssClass = "alert alert-success";

                txtName.Text = string.Empty;
                txtRollNo.Text = string.Empty;
                ddlGender.SelectedIndex = 0;
                txtMobile.Text = string.Empty;
                txtAddress.Text = string.Empty;
                ddlClass.SelectedIndex = 0;
                txtCalendar.Text = string.Empty;
            }
            catch(Exception ex)
            {
                string safeMessage = HttpUtility.JavaScriptStringEncode(ex.Message);
                Response.Write($"<script>alert('{safeMessage}');</script>");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetStudent();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetStudent();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int StudentId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                fn.Query($"delete from Student where StudentId = {StudentId}");
                GridView1.EditIndex = -1;
                GetStudent();
            }
            catch (Exception ex)
            {
                string safeMessage = HttpUtility.JavaScriptStringEncode(ex.Message);
                Response.Write($"<script>alert('{safeMessage}');</script>");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GetStudent();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int StudentId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                string name = ((TextBox)row.FindControl("txtNameEdit")).Text.Trim();
                string mobile = ((TextBox)row.FindControl("txtMobileEdit")).Text.Trim();
                string rollNo = ((TextBox)row.FindControl("txtRollNolEdit")).Text.Trim();
                string classId = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddlClassEdit")).SelectedValue;
                string address = ((TextBox)row.FindControl("txtAddressEdit")).Text.Trim();

                fn.Query($"Update Student set Name = '{name}', Mobile = '{mobile}', RollNo = '{rollNo}', classId = {classId}, Address = '{address}' where StudentId = {StudentId}");

                GridView1.EditIndex = -1;

                lblMsg.Text = "Inserted Successfully !";
                lblMsg.CssClass = "alert alert-success";

                GetStudent();

            }
            catch (Exception ex)
            {
                string safeMessage = HttpUtility.JavaScriptStringEncode(ex.Message);
                Response.Write($"<script>alert('{safeMessage}');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
            {

                DropDownList ddlClass = (DropDownList)e.Row.FindControl("ddlClassEdit");
                if (ddlClass != null)
                {
                    DataTable classTable = fn.Fetch("SELECT * FROM Class");
                    ddlClass.DataSource = classTable;
                    ddlClass.DataTextField = "ClassName";
                    ddlClass.DataValueField = "ClassId";
                    ddlClass.DataBind();


                    string className = DataBinder.Eval(e.Row.DataItem, "ClassName").ToString();
                    ListItem item = ddlClass.Items.FindByText(className);
                    if (item != null)
                        ddlClass.SelectedValue = item.Value;
                }
            }
        }
    }
}