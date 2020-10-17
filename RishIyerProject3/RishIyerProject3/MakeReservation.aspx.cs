 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace RishIyerProject3
{
    public partial class MakeReservation : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ReservationRequested"] != null)
            {
                if (Session["ReservationRequested"].ToString() != "")
                {
                    ddlRests.SelectedValue = Session["ReservationRequested"].ToString();
                }
            }
            else
            {
                ddlRests.SelectedIndex = 1;
            }

            panelNavRep.Visible = false;
            panelNavReviewer.Visible = false;
            panelGuest.Visible = false;

            if (Session["UserType"] != null)
            {
                string userType = Session["UserType"].ToString();
                if (userType == "Rep")
                {
                    panelNavRep.Visible = true;
                    panelNavReviewer.Visible = false;
                    lblLoggedInAs.Text = "Logged in as " + userType + ", " + Session["UserName"].ToString();
                    panelGuest.Visible = false;
                }
                else if (userType == "Reviewer")
                {
                    panelNavReviewer.Visible = true;
                    panelNavRep.Visible = false;
                    panelGuest.Visible = false;
                    lblSignedInAsReviewer.Text = "Logged in as " + userType + ", " + Session["UserName"].ToString();
                }

                else if (userType == "Guest")
                {
                    panelNavReviewer.Visible = false;
                    panelNavRep.Visible = false;
                    panelGuest.Visible = true;

                }
            }

            if (Session["UserType"] == null)
            {
                panelGuest.Visible = true;
            }

            if (!IsPostBack)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetRests";
               
                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                ddlRests.DataSource = myDS;
                ddlRests.DataTextField = "Name";
                ddlRests.DataValueField = "RestID";
                ddlRests.DataBind();
            }
        }
        protected void btnSubmitReservation_Click(object sender, EventArgs e)
        {

            if(txtFirstName.Text=="")
            {
                lblFirstNameError.Text = " Please enter a valid first name";
            }

            else if(txtFirstName.Text!="")
            {
                lblFirstNameError.Text = "";
            }

            if (txtLastName.Text == "")
            {
                lblLastNameError.Text = "Please enter a valid last name";
            }
            else if (txtLastName.Text != "")
            {
                lblLastNameError.Text = "";
            }
            if(txtPhoneNumber.Text=="")
            {
                lblPhoneError.Text = "Please enter a valid phone number";
            }
            else if(txtPhoneNumber.Text!="")
            {
                lblPhoneError.Text = "";
            }

            if(txtDate.Text=="")
            {
                lblDateError.Text = "Please enter a valid date";
            }

            else if(txtDate.Text!="")
            {
                lblDateError.Text = "";
            }

            if(txtTime.Text=="")
            {
                lblTimeError.Text = "Please enter a valid time";
            }

            else if(txtTime.Text!="")
            {
                lblTimeError.Text = "";
            }

            if (txtTime.Text != "" && txtDate.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && txtPhoneNumber.Text != "") {



                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                string restID = ddlRests.SelectedValue;

                string firstname = txtFirstName.Text;
                string lastname = txtLastName.Text;
                string phone = txtPhoneNumber.Text;
                string date = txtDate.Text;
                string time = txtTime.Text;
                string name = ddlRests.SelectedItem.Text;

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddReservation";


                objCommand.Parameters.AddWithValue("@RestID", restID);
                objCommand.Parameters.AddWithValue("@PhoneNumber", phone);
                objCommand.Parameters.AddWithValue("@FirstName", firstname);
                objCommand.Parameters.AddWithValue("@LastName", lastname);
                objCommand.Parameters.AddWithValue("@Date", date);
                objCommand.Parameters.AddWithValue("@Time", time);
                objCommand.Parameters.AddWithValue("@Name", name);


                objDB.DoUpdateUsingCmdObj(objCommand);
                Session["ReservationRequested"] = "";
                txtDate.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtPhoneNumber.Text = "";
                txtTime.Text = "";
                lblDisplay.Text = " Your reservation has been saved. We look forward to seeing you at  " + ddlRests.SelectedItem;
            }
        }
    }
}