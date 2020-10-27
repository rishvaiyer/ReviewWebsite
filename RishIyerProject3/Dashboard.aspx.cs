using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using Procedures;
using System.Data;



namespace RishIyerProject3
{
    public partial class Dashboard : System.Web.UI.Page
    {
        DBConnect objDB = new  DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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


                getAll();

               
            }


        }


        public void getAll()
        {
            Get get = new Get();

            if(get.GetAllRests(out DataSet myDS))
            {

         
                gvAllRests.DataSource = myDS;

                String[] names = new String[1];
                names[0] = "RestID";
                gvAllRests.DataKeyNames = names;
                gvAllRests.DataBind();
            }

           else
            {
                lblTitle.Text= "No restaraunts avaliable..";
            }

            
        }
        protected void gvAllRests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


      
        protected void ddlTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
        protected void ddlTypes2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }



        protected void gvAllRests_RowCommand(Object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string selectedRestID = gvAllRests.DataKeys[rowIndex].Value.ToString();
         

            if(e.CommandName == "Select")
            {          //Get rest name using stored procedure and add the name to See Reviews through session object
                Session["RestIDReview"] = selectedRestID;
                Response.Redirect("SeeReviews.aspx");
            }

            else if(e.CommandName == "MakeReservation")
            {

      
                Session["ReservationRequested"] = selectedRestID;
                Response.Redirect("MakeReservation.aspx");
            }
       
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAll();
        }

        protected void showMatching_Click(object sender, EventArgs e)
        {
            string theType = ddlTypes.SelectedValue;
            string theType2 = ddlTypes2.SelectedValue;
            Get get = new Get();
            if (get.GetMatching(theType, theType2, out DataSet myDS))
            {

                gvAllRests.DataSource = myDS;
                gvAllRests.DataBind();
            }
            else
            {
                gvAllRests.DataBind();
            }

        }
    }
        
    }

       