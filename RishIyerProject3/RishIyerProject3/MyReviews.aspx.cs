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
    public partial class MyReviews : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            panelNavRep.Visible = false;
            panelGuest.Visible = false;
            panelNavReviewer.Visible = false;
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            if (Session["UserType"] != null)
            {

                string strUsertype = Session["UserType"].ToString();
                if (strUsertype == "Reviewer")
                {
                    panelNavRep.Visible = false;
                    panelGuest.Visible = false;
                    panelNavReviewer.Visible = true;
                    lblLoggedInAs.Text = "Logged in as " + strUsertype + ", " + Session["UserName"].ToString();


                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetMyReviews";
                    string strUsername = Session["UserName"].ToString();
                    SqlParameter inputParameter = new SqlParameter("@Username", strUsername);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    inputParameter.Size = 50;
                    objCommand.Parameters.Add(inputParameter);

                    DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                    if (myDS.Tables[0].Rows.Count > 0)
                    {

                        gvMyReviews.DataSource = myDS;
                        String[] names = new string[1];
                        names[0] = "ReviewID";
                        gvMyReviews.DataKeyNames = names;
                        gvMyReviews.DataBind();


                    }
                    else
                    {

                        gvMyReviews.Visible = false;
                       

                    }
                }
                else
                {
                    panelGuest.Visible = true;
                    lblTitle.Text = " Sorry you do not have access to this page.";
                }
            }
        }







        protected void gvMyReviews_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvMyReviews_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvMyReviews.EditIndex = e.NewEditIndex;
            gvMyReviews.DataBind();



        }


        protected void gvMyReviews_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {



            int rowIndex = e.RowIndex;
            string selectedReviewID = gvMyReviews.DataKeys[rowIndex].Value.ToString();
            TextBox TboxFoodQuality;
            TboxFoodQuality = (TextBox)gvMyReviews.Rows[rowIndex].Cells[3].Controls[0];

             



            int newFoodQuality = int.Parse(TboxFoodQuality.Text);


            TextBox TboxService;
            TboxService = (TextBox)gvMyReviews.Rows[rowIndex].Cells[4].Controls[0];
            int newService = int.Parse(TboxService.Text);


            TextBox TboxAtmosphere;
            TboxAtmosphere = (TextBox)gvMyReviews.Rows[rowIndex].Cells[5].Controls[0];
            int newAtmosphere = int.Parse(TboxAtmosphere.Text);

            TextBox TboxPrice;
            TboxPrice = (TextBox)gvMyReviews.Rows[rowIndex].Cells[6].Controls[0];
            int newPrice = int.Parse(TboxAtmosphere.Text);

            TextBox TboxComments;
            TboxComments = (TextBox)gvMyReviews.Rows[rowIndex].Cells[7].Controls[0];
            string newComments = TboxComments.Text;

            double doublePrice = double.Parse(TboxPrice.Text);
            double doubleAtmosphere = double.Parse(TboxAtmosphere.Text);
            double doubleService = double.Parse(TboxService.Text);
            double doubleFoodQuality = double.Parse(TboxFoodQuality.Text);


            double avgRating = ((doublePrice + doubleAtmosphere + doubleFoodQuality + doubleService) / 4);
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();



            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "EditReview";

            objCommand.Parameters.AddWithValue("@ReviewID", selectedReviewID);
            objCommand.Parameters.AddWithValue("@FoodQuality", newFoodQuality);
            objCommand.Parameters.AddWithValue("@Atmosphere", newAtmosphere);
            objCommand.Parameters.AddWithValue("@Service", newService);
            objCommand.Parameters.AddWithValue("@Price", newPrice);
            objCommand.Parameters.AddWithValue("@Comments", newComments);
            objCommand.Parameters.AddWithValue("@AvgRating", avgRating);

            objDB.DoUpdateUsingCmdObj(objCommand);


           
            gvMyReviews.EditIndex = -1;
            gvMyReviews.DataBind();
            Response.Redirect("MyReviews.aspx");


        }
        protected void gvMyReviews_RowCommand(Object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string selectedReviewID = gvMyReviews.DataKeys[rowIndex].Value.ToString();

            if(e.CommandName == "Select")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "DeleteReview";

                objCommand.Parameters.AddWithValue("@ReviewID", selectedReviewID);
                lblShowIndex.Text = selectedReviewID;
                objDB.DoUpdateUsingCmdObj(objCommand);
                gvMyReviews.DataBind();
                Response.Redirect("MyReviews.aspx");

            }
        }

        

      

      
        protected void gvMyReviews_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvMyReviews.EditIndex = -1;
            gvMyReviews.DataBind();


        }


    }
}