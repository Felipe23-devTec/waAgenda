using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace waAgenda
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            string emailTxt = email.Text;
            string senhaTxt = senha.Text;
            if(string.IsNullOrEmpty(emailTxt) && string.IsNullOrEmpty(senhaTxt))
            {
                MessageBox.Show("Email e senha invalidos!");

                //// Injetando um script JavaScript para exibir um alerta ou em campo
                //string script = "<script type=\"text/javascript\">alert('Email e senha não preenchidos');</script>";
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
                //message.Text = "Email e senha não preenchidos";
                //message.ForeColor = System.Drawing.Color.Red;
                


            }
            else
            {
                message.Text = "";

                


                // Save to session state in a Web Forms page class.
                Session["Username"] = emailTxt;
                Response.Redirect("index.aspx");
                
            }
            
        }
    }
}