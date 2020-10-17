using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;
using Procedures;
namespace RishIyerProject3
{
    public partial class AddRest : System.Web.UI.Page
    {
        Add add = new Add();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblSuccess.Visible = false;
            if (Session["UserType"] != null)
            {
                string userType = Session["UserType"].ToString();

                if (userType == "Rep")
                {

                    lblRepUsername.Visible = true;
                    txtRepUsername.Visible = true;
                    panelNavRep.Visible = true;
                    panelNavReviewer.Visible = false;
                    lblLoggedInAs.Text = "Logged in as " + userType + ", " + Session["UserName"].ToString();
                    panelGuest.Visible = false;
                }

                else if (userType == "Reviewer")
                {

                    lblRepUsername.Visible = false;
                    txtRepUsername.Visible = false;
                    //   repNav.Visible = false;
                    panelNavRep.Visible = false;
                    panelNavReviewer.Visible = true;
                    lblSignedInAsReviewer.Text = "Logged in as " + userType + ", " + Session["UserName"].ToString();
                    panelGuest.Visible = false;
                }

                else if (userType == "Guest")
                {
                    panelGuest.Visible = true;
                    panelNavRep.Visible = false;
                    panelNavReviewer.Visible = false;
                    lblTitle.Text = "Sorry you do not have access to this page.";
                    panelNewRest.Visible = false;
                    btnAddRest.Visible = false;

                }

            }
            else
            {
                panelNavRep.Visible = false;
                panelNavReviewer.Visible = false;
                lblTitle.Text = "Sorry you do not have access to this page.";
                panelGuest.Visible = true;
                panelNewRest.Visible = false;
            }
        }

        protected void btnAddRest_Click(object sender, EventArgs e)
        {

            string userType = Session["UserType"].ToString();
            if (txtRestName.Text == "")
            {
                lblNameError.Text = "Please enter a valid name";
            }

            else
            {
                lblNameError.Text = "";
            }

            if (txtRestPhone.Text == "")
            {
                lblPhoneError.Text = "Please enter a valid phone number";
            }

            else
            {

                lblPhoneError.Text = "";
            }

            if (txtRestDescription.Text == "")
            {
                lblDescriptionError.Text = "Please enter a valid description";
            }

            else
            {
                lblDescriptionError.Text = "";

            }

            if (txtRestImgURL.Text == "")
            {
                lblImgError.Text = "Please enter a valid Image URL";
            }

            else
            {
                lblImgError.Text = "";
            }

            if (txtRestType.Text == "")
            {
                lblTypeError.Text = "Please enter a valid type";

            }

            else
            {
                lblTypeError.Text = "";
            }

            if (txtRestAddress.Text == "")
            {

                lblAddressError.Text = "Please enter a valid address";
            }


            else
            {
                lblAddressError.Text = "";
            }

            if (userType == "Rep" && txtRepUsername.Text == "")
            {
                lblUsernameError.Text = "Please enter your username";
            }

            else
            {
                lblUsernameError.Text = "";
            }




            if (userType == "Reviewer" && txtRestAddress.Text != "" && txtRestDescription.Text != "" && txtRestImgURL.Text != "" && txtRestPhone.Text != "" && txtRestName.Text != "" & txtRestType.Text != "")
            {




                string name = txtRestName.Text;
                string description = txtRestDescription.Text;
                string imageURL = txtRestImgURL.Text;
                string type = txtRestType.Text;
                string address = txtRestAddress.Text;
                string phone = txtRestPhone.Text;


   

                add.AddRest(name, description, imageURL, type, address, phone, out DataSet myDS);
                
                    txtRestType.Text = "";
                    txtRestImgURL.Text = "";
                    txtRestDescription.Text = "";
                    txtRestAddress.Text = "";
                    txtRestPhone.Text = "";
                    txtRestName.Text = "";

                    lblSuccess.Text = "Your restaraunt has been successfully added.";
                    lblSuccess.Visible = true;
                

             


            }

            else if

                (userType == "Rep" && txtRestAddress.Text != "" && txtRestDescription.Text != "" && txtRestImgURL.Text != "" && txtRestPhone.Text != "" && txtRestName.Text != "" && txtRestType.Text != "" && txtRepUsername.Text != "")
            {





                string name = txtRestName.Text;
                string description = txtRestDescription.Text;
                string imageURL = txtRestImgURL.Text;
                string type = txtRestType.Text;
                string address = txtRestAddress.Text;
                string phone = txtRestPhone.Text;
                string repID = txtRepUsername.Text;


                add.AddRestWRep(name, description, imageURL, type, address, phone, repID, out DataSet myDS);
                



                    txtRepUsername.Text = "";
                    txtRestName.Text = "";
                    txtRestType.Text = "";
                    txtRestImgURL.Text = "";
                    txtRestDescription.Text = "";
                    txtRestAddress.Text = "";
                    txtRestPhone.Text = "";
                    lblSuccess.Text = "Your restaraunt has been successfully added.";
                    lblSuccess.Visible = true;


                
            }
        }
    }
}
