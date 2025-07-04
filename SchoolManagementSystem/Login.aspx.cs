using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        CommonFn.Commonfnx fn = new CommonFn.Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Value.Trim();
            string senha = txtSenha.Value.Trim();
            if(user == "Admin" && senha == "123") 
            {
                Session["admin"] = user;
                Response.Redirect("Admin/AdminHome.aspx");
            }
            else
            {
                lblMsg.Text = "Erro ao realizar o login";
            }



        }
    }
}