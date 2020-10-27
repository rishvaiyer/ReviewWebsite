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
    public partial class SeeReviews : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

            panelGuest.Visible = false;
            panelNavRep.Visible = false;
            panelNavReviewer.Visible = false;
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
            if (Session["RestIDReview"] == null)
            {
                lblNoReviews.Text = "You have not selected a restaraunt to see the reviews for.";
                panelRatings.Visible = false;
                imgPickedRest.Visible = false;
            }

            else
            {
                string reviewRestID = Session["RestIDReview"].ToString();


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetReviewByRestID";

                SqlParameter inputParameter = new SqlParameter("@RestID", reviewRestID);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.Int;

                objCommand.Parameters.Add(inputParameter);

                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                if (myDS.Tables[0].Rows.Count > 0)
                {

                    gvSpecificReviews.DataSource = myDS;
                    gvSpecificReviews.DataBind();


                    string nameValue = ((myDS.Tables[0].Rows[0]["Name"]).ToString());
                    string imgURL = ((myDS.Tables[0].Rows[0]["ImgURL"]).ToString());
                    imgPickedRest.Visible = true;
                    imgPickedRest.ImageUrl = imgURL;
                    lblTitle.Text = "Reviews For " + nameValue;


                    int countGridViewNum = myDS.Tables[0].Rows.Count;


                    int avgQuality = 0;
                    int avgService = 0;
                    int avgAtmosphere = 0;
                    int avgPrice = 0;
                    for (int i = 0; i < countGridViewNum; i++)
                    {
                        avgQuality += int.Parse(gvSpecificReviews.Rows[i].Cells[2].Text);
                        string avgQualityString = avgQuality.ToString();
                        double doubleAvgQuality = (double.Parse(avgQualityString) / countGridViewNum);
                        string finalAvgQuality = String.Format("{0:0.0}", doubleAvgQuality);
                        lblAvgFoodQuality.Text = "Food Quality Rating: " + finalAvgQuality + "<span class='yellow'>★</span>";

                        avgService += int.Parse(gvSpecificReviews.Rows[i].Cells[3].Text);
                        string avgServiceString = avgService.ToString();
                        double doubleAvgService = (double.Parse(avgServiceString) / countGridViewNum);
                        string finalAvgService = String.Format("{0:0.0}", doubleAvgService);
                        lbLAvgService.Text = "Service Rating: " + finalAvgService + "<span class='yellow'>★</span>";

                        avgAtmosphere += int.Parse(gvSpecificReviews.Rows[i].Cells[4].Text);
                        string avgAtmosphereString = avgAtmosphere.ToString();
                        double doubleAvgAtmosphere = (double.Parse(avgAtmosphereString) / countGridViewNum);
                        string finalAvgAtmosphere = String.Format("{0:0.0}", doubleAvgAtmosphere);
                        lblAvgAtmosphere.Text = "Atmosphere Rating: " + finalAvgAtmosphere + "<span class='yellow'>★</span>";


                        avgPrice += int.Parse(gvSpecificReviews.Rows[i].Cells[5].Text);
                        string avgPriceString = avgPrice.ToString();
                        double doubleAvgPrice = (double.Parse(avgPriceString) / countGridViewNum);


                        string finalAvgPrice = "";
                        if(doubleAvgPrice >= 1 && doubleAvgPrice < 2  ) //greater than or equal to 1 but less than 2 so 1-2 
                        {
                             finalAvgPrice = "<span class='green'>$ </span> [Extremely Affordable]";
                        }

                        else if(doubleAvgPrice >=2 && doubleAvgPrice < 3)
                        {
                            finalAvgPrice = "<span class='green'>$$ </span> [Affordable]";
                        }

                        else if(doubleAvgPrice >=3 && doubleAvgPrice <4)
                        {
                            finalAvgPrice = "<span class='green'>$$$ </span> [Averagely Expensive]";
                        }

                        else if(doubleAvgPrice >=4 && doubleAvgPrice <5)
                        {
                            finalAvgPrice = "<span class='green'>$$$$ </span> [Moderately Expensive]";
                        }

                        else if(doubleAvgPrice == 5)
                        {
                            finalAvgPrice = "<span class='green'>$$$$$ </span> [Very Expensive]";
                        }
                        lblAvgPrice.Text = "Overall Price Rating: " + finalAvgPrice;


                        double overallRating = (doubleAvgAtmosphere + doubleAvgService + doubleAvgQuality) / 3;
                        string overallRatingString = String.Format("{0:0.0}", overallRating);
                        lblOverallRating.Text = " Overall Rating for " + nameValue + ": " + overallRatingString + "<span class='yellow'>★</span>";

                    }
                }
                else
                {
                    panelRatings.Visible = false;
                    imgPickedRest.Visible = false;
                    lblNoReviews.Text = "Sorry, there are no reviews for this restaraunt quite yet!";
                    gvSpecificReviews.Visible = false;

                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}
