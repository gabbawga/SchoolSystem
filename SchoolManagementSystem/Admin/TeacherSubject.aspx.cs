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
    public partial class TeacherSubject : System.Web.UI.Page
    {
        CommonFn.Commonfnx fn = new CommonFn.Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTeacherSubject();
                GetSubject();
                GetClass();
                GetTeacher();
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
            DataTable dt = fn.Fetch("select * from subject");
            ddlSubject.DataSource = dt;
            ddlSubject.DataTextField = "SubjectName";
            ddlSubject.DataValueField = "SubjectId";
            ddlSubject.DataBind();
        }

        private void GetTeacher()
        {
            DataTable dt = fn.Fetch("select * from teacher");
            ddlTeacher.DataSource = dt;
            ddlTeacher.DataTextField = "Name";
            ddlTeacher.DataValueField = "TeacherId";
            ddlTeacher.DataBind();
        }

        private void GetTeacherSubject()
        {
            string query = $"select ts.Id, c.Classname, s.SubjectName, t.Name from TeacherSubject ts inner join Class c on ts.ClassId = c.ClassId inner join Subject s on ts.SubjectId = s.SubjectId inner join Teacher t on ts.TeacherId = t.TeacherId";
            DataTable dt = fn.Fetch(query);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string teacherId = ddlTeacher.SelectedItem.Value;
            string subjectId = ddlSubject.SelectedItem.Value;
            string classId = ddlClass.SelectedItem.Value;
            try
            {
                string query = $"Insert into TeacherSubject values({classId},{subjectId},{teacherId})";
                fn.Query(query);

                lblMsg.Text = "Inserted Successfully !";
                lblMsg.CssClass = "alert alert-success";
                ddlTeacher.SelectedIndex = 0;
                ddlSubject.SelectedIndex = 0;
                ddlClass.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                lblMsg.Text = "The subject or class already exists";
                lblMsg.CssClass = "alert alert-warning";
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {


            }
            catch (Exception ex) { 
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetTeacherSubject();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}