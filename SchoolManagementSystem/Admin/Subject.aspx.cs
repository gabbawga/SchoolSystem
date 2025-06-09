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
    public partial class Subject : System.Web.UI.Page
    {
        CommonFn.Commonfnx fn = new CommonFn.Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSubject();
                GetClass();

            }
        }

        private void GetClass()
        {
            DataTable dt = fn.Fetch("select * from class");
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassId";
            ddlClass.DataBind();    
        }

        private void GetSubject()
        {
            DataTable dt = fn.Fetch("select s.subjectId, c.className, s.subjectName from Subject s inner join Class c on c.ClassId = s.ClassId");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string classVal = ddlClass.SelectedItem.Text.Trim();
                DataTable dt = fn.Fetch($"select * from Subject where SubjectId = {ddlClass.SelectedItem.Value}");
                if (dt.Rows.Count == 0)
                {
                    string query = $"insert into subject values ({ddlClass.SelectedItem.Value},'{txtSubject.Text.Trim()}')";
                    fn.Query(query);
                    lblMsg.Text = "Inserted Successfully !";
                    lblMsg.CssClass = "alert alert-success";
                    ddlClass.SelectedIndex = 0;
                    txtSubject.Text = string.Empty;
                }
                else
                {
                    lblMsg.Text = "The subject or class already exists";
                    lblMsg.CssClass = "alert alert-warning";
                }
            }
            catch (Exception ex) 
            {
                string safeMessage = HttpUtility.JavaScriptStringEncode(ex.Message);
                Response.Write($"<script>alert('{safeMessage}');</script>");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetSubject();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GetSubject();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int idSubject = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string subjectName = (row.FindControl("txtSubjectEdit") as TextBox).Text;
                fn.Query($"update subject set subjectName = '{subjectName}' where subjectId = {idSubject}");
                GridView1.EditIndex = -1;
                GetSubject();


            }catch(Exception ex)
            {
                string safeMessage = HttpUtility.JavaScriptStringEncode(ex.Message);
                Response.Write($"<script>alert('{safeMessage}');</script>");
            }
        }



        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetSubject();
        }
    }


}