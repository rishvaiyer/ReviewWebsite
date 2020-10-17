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
    public partial class AddReview : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        Add add = new Add();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnReviewExist.Visible = false;
            panelNavRep.Visible = false;
            panelGuest.Visible = false;

            if (Session["UserType"] == null)
            {
                Session["UserType"] = "Guest";
            }

            string userType = Session["UserType"].ToString();
            if (userType != null)
            {
                if (userType == "Reviewer")
                {
                    panelNavReviewer.Visible = true;
                    panelNavRep.Visible = false;
                    panelGuest.Visible = false;
                    lblSignedInAsReviewer.Text = "Logged in as " + userType + ", " + Session["UserName"].ToString();
                }

                else if (userType == "Guest")
                {
                    lblTitle.Text = "Sorry you do not have access to this page. You may login as reviewer for access.";
                    panelGuest.Visible = true;
                    panelNavRep.Visible = false;
                    panelNavReviewer.Visible = false;
                    btnAddNewRest.Visible = false;
                    btnAddRest.Visible = false;
                    panelAddNewReview.Visible = false;
                    panelAddNewRest.Visible = false;
                }
                else if (userType == "Rep")
                {
                    lblTitle.Text = "Sorry you do not have access to this page. You may login as reviewer for access.";
                    panelGuest.Visible = false;
                    panelNavRep.Visible = true;
                    btnAddNewRest.Visible = false;
                    btnAddRest.Visible = false;
                    panelNavReviewer.Visible = false;
                    panelAddNewReview.Visible = false;
                    panelAddNewRest.Visible = false;
                }


            }


            if (!IsPostBack)
            {
                panelAddNewRest.Visible = false;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetRests";

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                ddlRests.DataSource = myDS;
                ddlRests.DataTextField = "Name";
                ddlRests.DataValueField = "RestID";
                ddlRests.DataBind();
            }
        }

        protected void btnSubmitReview_Click(object sender, EventArgs e)
        {


            if (txtComments.Text == "")
            {
                lblCommentsError.Text = "Comments cannot be blank.";
            }

            else if (txtComments.Text != "")
            {
                lblCommentsError.Text = "";
            }

           
            if (txtComments.Text !="")
            {
                string username = Session["UserName"].ToString();
                string restID = ddlRests.SelectedValue;
                string comments = txtComments.Text;
                string quality = ddlRateQuality.SelectedValue;
                string service = ddlRateService.SelectedValue;
                string price = ddlRatePrice.SelectedValue;
                string atmosphere = ddlRateAtmosphere.SelectedValue;
                double intQuality = double.Parse(quality);
                double intService = double.Parse(service);
                double intPrice = double.Parse(price);
                double intAtmosphere = double.Parse(atmosphere);

                double avgRating = ((intQuality + intService  + intAtmosphere) / 3);



                add.AddReview(username, restID, comments, quality, service, price, atmosphere, avgRating, out DataSet myDS);

                lblSuccess.Text = "Your review has been successfully added.";
                txtComments.Text = "";
                ddlRateAtmosphere.SelectedValue = "1";
                ddlRatePrice.SelectedValue = "1";
                ddlRateQuality.SelectedValue = "1";
                ddlRatePrice.SelectedValue = "1";


            }
        }

        protected void btnAddRest_Click(object sender, EventArgs e)
        {




            if (txtRestName.Text == "")
            {
                btnReviewExist.Visible = true;
                lblNameError.Text = "Please enter a valid name";
            }

            else
            {
                lblNameError.Text = "";
            }

            if (txtRestPhone.Text == "")
            {
                btnReviewExist.Visible = true;
                lblPhoneError.Text = "Please enter a valid phone number";
            }

            else
            {

                lblPhoneError.Text = "";
            }

            if (txtRestDescription.Text == "")
            {
                btnReviewExist.Visible = true;
                lblDescriptionError.Text = "Please enter a valid description";
            }

            else
            {
                lblDescriptionError.Text = "";

            }

            if (txtRestImgURL.Text == "")
            {
                btnReviewExist.Visible = true;
                lblImgError.Text = "Please enter a valid Image URL";
            }

            else
            {
                lblImgError.Text = "";
            }

            if (txtRestType.Text == "")
            {
                btnReviewExist.Visible = true;
                lblTypeError.Text = "Please enter a valid type";

            }

            else
            {
                lblTypeError.Text = "";
            }

            if (txtRestAddress.Text == "")
            {
                btnReviewExist.Visible = true;
                lblAddressError.Text = "Please enter a valid address";
            }


            else
            {
                lblAddressError.Text = "";
            }


            if (txtRestAddress.Text != "" && txtRestDescription.Text != "" && txtRestImgURL.Text != "" && txtRestPhone.Text != "" && txtRestName.Text != "" & txtRestType.Text != "")
            {



                string name = txtRestName.Text;
                string description = txtRestDescription.Text;
                string imageURL = txtRestImgURL.Text;
                string type = txtRestType.Text;
                string address = txtRestAddress.Text;
                string phone = txtRestPhone.Text;

                Add add = new Add();

                add.AddRest(name, description, imageURL, type, address, phone, out DataSet myDS);




                ddlRests.DataBind();
                lblSuccess.Text = "Your restaraunt was successfully added.";
                btnReviewExist.Visible = true;
                panelAddNewReview.Visible = true;
                panelAddNewRest.Visible = false;

            }

            else
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = " There was an error. Make sure all fields are filled out.";
            }
        }

        protected void btnAddNewRest_Click(object sender, EventArgs e)
        {

            btnAddNewRest.Visible = false;
            ddlRests.DataBind();
            panelAddNewRest.Visible = true;
            panelAddNewReview.Visible = false;
            btnReviewExist.Visible = true;
            btnAddRest.Visible = true;
        }

        protected void btnReviewExist_Click(object sender, EventArgs e)
        {
            btnAddNewRest.Visible = true;
            panelAddNewRest.Visible = false;
            panelAddNewReview.Visible = true;
            btnAddRest.Visible = false;
            btnReviewExist.Visible = false;
            lblAddressError.Visible = false;
            lblDescriptionError.Visible = false;
            lblNameError.Visible = false;
            lblPhoneError.Visible = false;
            lblTypeError.Visible = false;
            lblImgError.Visible = false;


        }
    }
}