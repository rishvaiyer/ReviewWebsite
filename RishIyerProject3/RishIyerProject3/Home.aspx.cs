using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utilities;
using Procedures;
using System.Data.SqlClient;



namespace RishIyerProject3
{
    public partial class Home : System.Web.UI.Page
    {

        Get get = new Get();
        DBConnect objDB = new DBConnect(); 
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lblSignUp.Visible = false;
                lblLogInRep.Visible = false;
                lblLogInReviewer.Visible = false;
                lblSuccessCreation.Visible = false;
                btnSignUp.Visible = false;
                panelSignUp.Visible = false;
                panelReviewerLookup.Visible = false;
                panelRepLookup.Visible = false;
                btnCreateNewAccount.Visible = true;

            }
        }

        protected void btnGuest_Click(object sender, EventArgs e)
        {

            subTitle.Visible = false;

            Session["UserName"] = "Guest";
            Session["UserType"] = "Guest";
            string strUsername = Session["UserName"].ToString();
            string strUsertype = Session["UserType"].ToString();


            Response.Redirect("Dashboard.aspx");
        }

        protected void btnRep_Click(object sender, EventArgs e)
        {
            subTitle.Visible = false;
            lblSignUp.Visible = false;
            lblLogInRep.Visible = true;
            lblLogInReviewer.Visible = false;
            btnRep.Visible = false;
            btnReview.Visible = false;
            btnGuest.Visible = false;
            panelRepLookup.Visible = true;
            panelReviewerLookup.Visible = false;
            panelSignUp.Visible = false;
            lblSuccessCreation.Visible = false;
            btnSignUp.Visible = false;
            btnCreateNewAccount.Visible = false;

        }

        protected void btnReview_Click(object sender, EventArgs e)
        {
            subTitle.Visible = false;

            lblSignUp.Visible = false;
            lblLogInRep.Visible = false;
            lblLogInReviewer.Visible = true;
            btnRep.Visible = false;
            btnReview.Visible = false;
            btnGuest.Visible = false;
            panelRepLookup.Visible = false;
            panelReviewerLookup.Visible = true;
            panelSignUp.Visible = false;
            lblSuccessCreation.Visible = false;
            btnSignUp.Visible = false;
            btnCreateNewAccount.Visible = false;
        }




        protected void btnReviewerLookup_Click(object sender, EventArgs e)
        {

            string Username = txtReviewerLookup.Text;

           // Get get = new Get();
            if(get.FindReviewer(Username, out DataSet myDS))
            {
                
                Session["UserName"] = txtReviewerLookup.Text;
                Session["UserType"] = "Reviewer";
                string strUsername = Session["UserName"].ToString();
                string strUsertype = Session["UserType"].ToString();


                Response.Redirect("Dashboard.aspx");


            }
            else
            {
                lblErrorReviewer.Text = " Sorry we could not find your account.";
                btnBackReviewer.Visible = true;
                btnBackRep.Visible = false;
                
            }
        }


        protected void btnRepLookup_Click(object sender, EventArgs e)
        {


            string Username = txtRepLookup.Text;

            // Get get = new Get();
            if (get.FindRep(Username, out DataSet myDS))
            {

                Session["UserName"] = txtRepLookup.Text;
                Session["UserType"] = "Rep";
                string strUsername = Session["UserName"].ToString();
                string strUsertype = Session["UserType"].ToString();



                Response.Redirect("Dashboard.aspx");
                //If found than, set active user and active user type in session storage
                //Redirect to manage restaraunts aspx
            }
            else
            {
                lblErrorRep.Text = " Sorry we could not find your account";
                btnBackRep.Visible = true;
                
            }
        }

        protected void btnCreateNewAccount_Click(object sender, EventArgs e)
        {
            lblLogInReviewer.Visible = false;
            lblLogInRep.Visible = false;
            panelSignUp.Visible = true;
            panelReviewerLookup.Visible = false;
            panelRepLookup.Visible = false;
            lblSuccessCreation.Visible = false;
            btnSignUp.Visible = false;
           
            btnRep.Visible = false;
            btnReview.Visible = false;
            btnSignUp.Visible = true;
            btnGuest.Visible = false;
            btnCreateNewAccount.Visible = false;


        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtUsernameSignUp.Text == "")
            {
                lblErrorUsername.Text = "Please enter a valid username";
            }
            else
            {
                lblErrorUsername.Text = "";
            }

            if (txtFirstNameSignUp.Text == "")
            {
                lblErrorFirstName.Text = "Please enter a valid first name.";
            }
            else
            {
                lblErrorFirstName.Text = "";
            }

            if (txtLastNameSignUp.Text == ""){
                lblErrorLastName.Text = "Please enter a valid last name.";
            }

            else
            {
                lblErrorLastName.Text = "";
            }

        



            if(txtLastNameSignUp.Text!="" && txtFirstNameSignUp.Text!="" && txtUsernameSignUp.Text!="") 
            {

                lblErrorLastName.Text = "";
                lblErrorFirstName.Text = "";
                lblErrorUsername.Text = "";
                string type = ddlSignUpType.SelectedValue;
                string firstname = txtFirstNameSignUp.Text;
                string lastname = txtLastNameSignUp.Text;
                string username = txtUsernameSignUp.Text;
                if (type == "Reps")
                {


                    DBConnect objDB = new DBConnect();
                    SqlCommand objCommand = new SqlCommand();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "CreateRepAccount";

                    objCommand.Parameters.AddWithValue("@Username", username);

                    objCommand.Parameters.AddWithValue("@FirstName", firstname);
                    objCommand.Parameters.AddWithValue("@LastName", lastname);


                    objDB.DoUpdateUsingCmdObj(objCommand);
                    txtFirstNameSignUp.Text = "";
                    subTitle.Visible = false;
                    txtLastNameSignUp.Text = "";
                    txtUsernameSignUp.Text = "";
                    panelSignUp.Visible = false;
                    lblSuccessCreation.Visible = true;
                }

                else if (type == "Reviewers")
                {
                    DBConnect objDB = new DBConnect();
                    SqlCommand objCommand = new SqlCommand();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "CreateReviewerAccount";

                    objCommand.Parameters.AddWithValue("@Username", username);

                    objCommand.Parameters.AddWithValue("@FirstName", firstname);
                    objCommand.Parameters.AddWithValue("@LastName", lastname);


                    objDB.DoUpdateUsingCmdObj(objCommand);
                    txtFirstNameSignUp.Text = "";
                    subTitle.Visible = false;
                    txtLastNameSignUp.Text = "";
                    txtUsernameSignUp.Text = "";
                    panelSignUp.Visible = false;
                    lblSuccessCreation.Visible = true;



                }
            }
        }

        protected void btnBackReviewer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }


        protected void btnBackSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnBackRep_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}