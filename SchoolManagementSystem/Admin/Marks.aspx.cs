using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Admin
{
    public partial class Marks : System.Web.UI.Page
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
                GetMarks();
                GetClass();
                GetSubject();
            }

        }

        private void GetSubject()
        {
            DataTable dt = fn.Fetch("select * from subject");
            ddlSubject.DataSource = dt;
            ddlSubject.DataTextField = "SubjectName";
            ddlSubject.DataValueField = "SubjectId";
            ddlSubject.DataBind();
        }

        private void GetClass()
        {
            DataTable dt = fn.Fetch("select * from class");
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassId";
            ddlClass.DataBind();
        }

        private void GetMarks()
        {
            DataTable dt = fn.Fetch("select e.ExameId, c.ClassName, s.SubjectName, e.RollNo, e.TotalMarks, e.OutOfMarks from Exam e inner join Class c on e.classId = c.ClassId inner join Subject s on e.SubjectId = s.SubjectId");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                string classId = ddlClass.SelectedItem.Value;
                string subjectId = ddlSubject.SelectedItem.Value;
                string rollNumber = txtRollNumber.Text.Trim();
                string marks = txtTotalMark.Text.Trim();
                string outMarks = txtOutOfMark.Text.Trim();

                string query = $"Insert into Exam values({classId}, {subjectId}, '{rollNumber}', {marks}, {outMarks})";

                fn.Query(query);

                lblMsg.Text = "Inserted Successfully";
                lblMsg.CssClass = "alert alert-success";

                ddlClass.SelectedIndex = 0;
                ddlSubject.SelectedIndex = 0;
                txtRollNumber.Text = string.Empty;
                txtTotalMark.Text = string.Empty;
                txtOutOfMark.Text = string.Empty;
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
            GetMarks();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetMarks();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int examId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                fn.Query($"delete from Student where StudentId = {examId}");
                GridView1.EditIndex = -1;
                GetMarks();
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
            GetMarks();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int examId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                string classId = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlClassEdit")).SelectedValue;
                string subjectId = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlSubjectEdit")).SelectedValue;
                string rollNo = ((TextBox)row.FindControl("txtRollNolEdit")).Text.Trim();
                string totalMarks = ((TextBox)row.FindControl("txtTotalMarksEdit")).Text.Trim();
                string totalOutMarks = ((TextBox)row.FindControl("txtOutOfMarkEdit")).Text.Trim();


                string query = $"Update Exam set classId = {classId}, subjectId = {subjectId}, RollNo = '{rollNo}', TotalMarks = {totalMarks}, OutOfMarks = {totalOutMarks} where ExameId = {examId}";

                fn.Query(query);

                GridView1.EditIndex = -1;

                lblMsg.Text = "Inserted Successfully !";
                lblMsg.CssClass = "alert alert-success";

                GetMarks();

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


                DropDownList ddlSubject = (DropDownList)e.Row.FindControl("ddlSubjectEdit");
                if (ddlSubject != null)
                {
                    DataTable subjectTable = fn.Fetch("SELECT * FROM Subject");
                    ddlSubject.DataSource = subjectTable;
                    ddlSubject.DataTextField = "SubjectName";
                    ddlSubject.DataValueField = "SubjectId";
                    ddlSubject.DataBind();

                    string subjectName = DataBinder.Eval(e.Row.DataItem, "SubjectName").ToString();
                    ListItem item = ddlSubject.Items.FindByText(subjectName);
                    if (item != null)
                        ddlSubject.SelectedValue = item.Value;
                }

            }
        }
    }
}