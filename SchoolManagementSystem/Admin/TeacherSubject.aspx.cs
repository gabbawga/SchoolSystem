//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using SchoolManagementSystem.Models;

//namespace SchoolManagementSystem.Admin
//{
//    public partial class TeacherSubject : System.Web.UI.Page
//    {
//        CommonFn.Commonfnx fn = new CommonFn.Commonfnx();
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (Session["admin"] == null)
//            {
//                Response.Redirect("../Login.aspx");
//            }
//            if (!IsPostBack)
//            {
//                GetTeacherSubject();
//                GetSubject();
//                GetClass();
//                GetTeacher();
//            }
//        }

//        private void GetClass()
//        {
//            DataTable dt = fn.Fetch("select * from class");
//            ddlClass.DataSource = dt;
//            ddlClass.DataTextField = "ClassName";
//            ddlClass.DataValueField = "ClassId";
//            ddlClass.DataBind();
//        }

//        private void GetSubject()
//        {
//            DataTable dt = fn.Fetch("select * from subject");
//            ddlSubject.DataSource = dt;
//            ddlSubject.DataTextField = "SubjectName";
//            ddlSubject.DataValueField = "SubjectId";
//            ddlSubject.DataBind();
//        }

//        private void GetTeacher()
//        {
//            DataTable dt = fn.Fetch("select * from teacher");
//            ddlTeacher.DataSource = dt;
//            ddlTeacher.DataTextField = "Name";
//            ddlTeacher.DataValueField = "TeacherId";
//            ddlTeacher.DataBind();
//        }

//        private void GetTeacherSubject()
//        {
//            string query = @"SELECT ts.Id, 
//                            ts.ClassId, c.ClassName, 
//                            ts.SubjectId, s.SubjectName, 
//                            ts.TeacherId, t.Name 
//                     FROM TeacherSubject ts
//                     INNER JOIN Class c ON ts.ClassId = c.ClassId
//                     INNER JOIN Subject s ON ts.SubjectId = s.SubjectId
//                     INNER JOIN Teacher t ON ts.TeacherId = t.TeacherId";
//            DataTable dt = fn.Fetch(query);
//            GridView1.DataSource = dt;
//            GridView1.DataBind();
            
//        }

//        protected void btnAdd_Click(object sender, EventArgs e)
//        {
//            string teacherId = ddlTeacher.SelectedItem.Value;
//            string subjectId = ddlSubject.SelectedItem.Value;
//            string classId = ddlClass.SelectedItem.Value;
//            try
//            {
//                string query = $"Insert into TeacherSubject values({classId},{subjectId},{teacherId})";
//                fn.Query(query);

//                lblMsg.Text = "Inserted Successfully !";
//                lblMsg.CssClass = "alert alert-success";
//                ddlTeacher.SelectedIndex = 0;
//                ddlSubject.SelectedIndex = 0;
//                ddlClass.SelectedIndex = 0;
//            }
//            catch(Exception ex)
//            {
//                lblMsg.Text = "The subject or class already exists";
//                lblMsg.CssClass = "alert alert-warning";
//            }
//        }

//        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
//        {
//            try
//            {
//                GridViewRow row = GridView1.Rows[e.RowIndex];
//                int teacherSubjectId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
//                string classId = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddlClassEdit")).SelectedValue;
//                string subjectId = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddlSubjectEdit")).SelectedValue;
//                string teacherId = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddlTeacherEdit")).SelectedValue;

//                fn.Query($"Update TeacherSubject set ClassId = {classId}, subjectId ={subjectId}, teacherId = {teacherId} where Id = {teacherSubjectId}");

//                GridView1.EditIndex = -1;

//                lblMsg.Text = "Inserted Successfully !";
//                lblMsg.CssClass = "alert alert-success";

//                GetTeacherSubject();

//            }
//            catch (Exception ex) {
//                string safeMessage = HttpUtility.JavaScriptStringEncode(ex.Message);
//                Response.Write($"<script>alert('{safeMessage}');</script>");
//            }
//        }

//        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
//        {
//            GridView1.PageIndex = e.NewPageIndex;
//            GetTeacherSubject();
//        }

//        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
//        {
//            GridView1.EditIndex = -1;
//            GetTeacherSubject();
//        }

//        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
//        {
//            try
//            {
//                GridViewRow row = GridView1.Rows[e.RowIndex]; 
//                int TeacherSubjectId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
//                fn.Query($"delete from TeacherSubject where subjectId = {TeacherSubjectId}");
//                GridView1.EditIndex = -1;
//                GetTeacherSubject();
//            }
//            catch (Exception ex)
//            {
//                string safeMessage = HttpUtility.JavaScriptStringEncode(ex.Message);
//                Response.Write($"<script>alert('{safeMessage}');</script>");
//            }
//        }

//        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
//        {
//            GridView1.EditIndex = e.NewEditIndex;
//            GetTeacherSubject();
//        }
//        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
//        {
//            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
//            {
                
//                DropDownList ddlClass = (DropDownList)e.Row.FindControl("ddlClassEdit");
//                if (ddlClass != null)
//                {
//                    DataTable classTable = fn.Fetch("SELECT * FROM Class");
//                    ddlClass.DataSource = classTable;
//                    ddlClass.DataTextField = "ClassName";
//                    ddlClass.DataValueField = "ClassId";
//                    ddlClass.DataBind();

                    
//                    string className = DataBinder.Eval(e.Row.DataItem, "ClassName").ToString();
//                    ListItem item = ddlClass.Items.FindByText(className);
//                    if (item != null)
//                        ddlClass.SelectedValue = item.Value;
//                }

               
//                DropDownList ddlSubject = (DropDownList)e.Row.FindControl("ddlSubjectEdit");
//                if (ddlSubject != null)
//                {
//                    DataTable subjectTable = fn.Fetch("SELECT * FROM Subject");
//                    ddlSubject.DataSource = subjectTable;
//                    ddlSubject.DataTextField = "SubjectName";
//                    ddlSubject.DataValueField = "SubjectId";
//                    ddlSubject.DataBind();

//                    string subjectName = DataBinder.Eval(e.Row.DataItem, "SubjectName").ToString();
//                    ListItem item = ddlSubject.Items.FindByText(subjectName);
//                    if (item != null)
//                        ddlSubject.SelectedValue = item.Value;
//                }

               
//                DropDownList ddlTeacher = (DropDownList)e.Row.FindControl("ddlTeacherEdit");
//                if (ddlTeacher != null)
//                {
//                    DataTable teacherTable = fn.Fetch("SELECT * FROM Teacher");
//                    ddlTeacher.DataSource = teacherTable;
//                    ddlTeacher.DataTextField = "Name";
//                    ddlTeacher.DataValueField = "TeacherId";
//                    ddlTeacher.DataBind();

//                    string teacherName = DataBinder.Eval(e.Row.DataItem, "Name").ToString();
//                    ListItem item = ddlTeacher.Items.FindByText(teacherName);
//                    if (item != null)
//                        ddlTeacher.SelectedValue = item.Value;
//                }
//            }
//        }
//    }

//}