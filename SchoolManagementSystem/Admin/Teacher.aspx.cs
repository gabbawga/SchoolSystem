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
    public partial class Teacher : System.Web.UI.Page
    {
        CommonFn.Commonfnx fnx = new CommonFn.Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTeacher();
            }
         
        }

        private void GetTeacher()
        {
            DataTable dt = fnx.Fetch("select * from Teacher");
            GridView1.DataSource = dt;  
            GridView1.DataBind();   
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //aqui nos iremos pegar dado de todos os inputs
                string profName = txtName.Text.Trim();
                string profEmail = txtEmail.Text.Trim();
                string profGender = ddlGender.SelectedItem.Text.Trim();
                string profMobile = txtMobile.Text.Trim();
                string profAddress = txtAddress.Text.Trim();
                string profPassword = txtPassword.Text.Trim();
                string profCalendar = txtCalendar.Text.Trim();
                string query = $"select * from Teacher where email = '{profEmail}'";
                DataTable dt = fnx.Fetch(query);
                if (dt.Rows.Count == 0)
                {
                    string insertQuery = $"insert into Teacher values ('{profName}', '{profCalendar}', '{profGender}', '{profMobile}', '{profEmail}', '{profAddress}', '{profPassword}')";
                    fnx.Query(insertQuery);
                    lblMsg.Text = "Inserted Successfully !";
                    lblMsg.CssClass = "alert alert-success";
                    txtName.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    ddlGender.SelectedIndex = 0;
                    txtMobile.Text = string.Empty;
                    txtAddress.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtCalendar.Text = string.Empty;
                }
                else
                {
                    lblMsg.Text = "The teacher already exists";
                    lblMsg.CssClass = "alert alert-warning";
                }

            }
            catch (Exception ex)
            {
                string safeMessage = HttpUtility.JavaScriptStringEncode(ex.Message);
                Response.Write($"<script>alert('{safeMessage}');</script>");
            }
            finally
            {
                GetTeacher();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetTeacher();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;   
            GetTeacher();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int profId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                fnx.Query($"delete from Subject where subjectId = {profId}");
                GridView1.EditIndex = -1;
                GetTeacher();
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
            GetTeacher();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int teacherId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                string profName = ((TextBox)row.FindControl("txtNameEdit")).Text.Trim();
                string profMobile = ((TextBox)row.FindControl("txtMobileEdit")).Text.Trim();
                string profPassword = ((TextBox)row.FindControl("txtPasswordEdit")).Text.Trim();
                
                string query = $"update from Teacher set Name = '{profName}' and Mobile = {profMobile} and Password = {profPassword} where TeacherId = {teacherId}";

                GridView1.EditIndex = -1;
                GetTeacher();

            }
            catch(Exception ex)
            {
                string safeMessage = HttpUtility.JavaScriptStringEncode(ex.Message);
                Response.Write($"<script>alert('{safeMessage}');</script>");
            }
        }
    }
}