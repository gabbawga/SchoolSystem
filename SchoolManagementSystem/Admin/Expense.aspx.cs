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
    public partial class Expense : System.Web.UI.Page
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
                GetExpense();
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
            DataTable dt = fn.Fetch("select * from subject");
            ddlSubject.DataSource = dt;
            ddlSubject.DataTextField = "SubjectName";
            ddlSubject.DataValueField = "SubjectId";
            ddlSubject.DataBind();
        }

        private void GetExpense()
        {
            DataTable dt = fn.Fetch($"select e.ExpenseId, c.ClassName, s.SubjectName, e.ChargeAmount from Expense e inner join Subject s on e.SubjectId = s.SubjectId inner join Class c on e.ClassId = c.ClassId");
            GridView1.DataSource = dt;  
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string query = $"insert into Expense (ClassId, SubjectId, ChargeAmount) values ('{ddlClass.SelectedValue}', '{ddlSubject.SelectedValue}', '{txtChargeAmount.Text}')";

                fn.Query(query);

                lblMsg.Text = "Inserted Successfully !";
                lblMsg.CssClass = "alert alert-success";
                ddlClass.SelectedIndex = 0;
                ddlSubject.SelectedIndex = 0;
                txtChargeAmount.Text = string.Empty;

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
            GetExpense();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetExpense();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int expenseId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                fn.Query($"delete from Expense where expenseId = {expenseId}");
                GridView1.EditIndex = -1;
                GetExpense();
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
            GetExpense();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int expenseId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                string classId = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddlClassEdit")).SelectedValue;
                string subjectId = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddlSubjectEdit")).SelectedValue;
                string expenseAmount = (row.FindControl("txtFeesEdit") as TextBox).Text;

                fn.Query($"Update Expense set ClassId = {classId}, subjectId ={subjectId}, ChangeAmount = {expenseAmount} where Id = {expenseId}");

                GridView1.EditIndex = -1;

                lblMsg.Text = "Inserted Successfully !";
                lblMsg.CssClass = "alert alert-success";

                GetExpense();

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