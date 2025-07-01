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
    public partial class ExpenseDetails : System.Web.UI.Page
    {
        CommonFn.Commonfnx fn = new CommonFn.Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetExpenseDetails();
            }

        }

        private void GetExpenseDetails()
        {
            DataTable dt = fn.Fetch($"select e.ExpenseId, c.ClassName, s.SubjectName, e.ChargeAmount from Expense e inner join Subject s on e.SubjectId = s.SubjectId inner join Class c on e.ClassId = c.ClassId");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}