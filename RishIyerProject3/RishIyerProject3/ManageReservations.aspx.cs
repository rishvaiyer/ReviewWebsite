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
    public partial class ManageReservations : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            
                panelNavRep.Visible = false;
                panelNavReviewer.Visible = false;
                panelGuest.Visible = false;
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

            if (Session["UserType"] != null)
            {
                

                    string userType = Session["UserType"].ToString();
                    if (userType == "Rep")
                    {
                        panelNavRep.Visible = true;
                        panelNavReviewer.Visible = false;
                        lblLoggedInAs.Text = "Logged in as " + userType + ", " + Session["UserName"].ToString();
                        panelGuest.Visible = false;
                  
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "ManageReservations";
                    string strUsername = Session["UserName"].ToString();
                    SqlParameter inputParameter = new SqlParameter("@Username", strUsername);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    inputParameter.Size = 50;
                    objCommand.Parameters.Add(inputParameter);

                    DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                    if (myDS.Tables[0].Rows.Count > 0)
                    {

                        gvManageReservations.DataSource = myDS;
                        String[] names = new string[1];
                        names[0] = "ReservationID";
                        gvManageReservations.DataKeyNames = names;
                        gvManageReservations.DataBind();

                    }

                    else
                    {
                        display.Text = "There are currently no reservations to manage.";
                    }



                }

                    else
                {
                    display.Text = "Sorry you do not have access to this page.";
                }


            }

            else
            {
                display.Text = "Sorry you do not have access to this page.";
                panelGuest.Visible = true;
            }
        }

        

        protected void gvManageReservations_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvManageReservations_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvManageReservations.EditIndex = e.NewEditIndex;
            gvManageReservations.DataBind();
        }
        protected void gvManageReservations_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            int rowIndex = e.RowIndex;
            string selectedReservationID = gvManageReservations.DataKeys[rowIndex].Value.ToString();
            TextBox TboxDate;
            TboxDate = (TextBox)gvManageReservations.Rows[rowIndex].Cells[3].Controls[0];
            TextBox TboxTime;
            TboxTime = (TextBox)gvManageReservations.Rows[rowIndex].Cells[4].Controls[0];
            TextBox TboxFirstName;
            TboxFirstName = (TextBox)gvManageReservations.Rows[rowIndex].Cells[5].Controls[0];
            TextBox TboxLastName;
            TboxLastName = (TextBox)gvManageReservations.Rows[rowIndex].Cells[6].Controls[0];

            if (TboxDate.Text != "" && TboxFirstName.Text != "" && TboxLastName.Text != "" && TboxTime.Text != "")
            {
              
                string newDate = TboxDate.Text;
                
                string newTime = TboxTime.Text;
               
                string newFirstName = TboxFirstName.Text;
                
                string newLastName = TboxLastName.Text;

                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "EditReservation";
                objCommand.Parameters.AddWithValue("@ReservationID", selectedReservationID);
                objCommand.Parameters.AddWithValue("@FirstName", newFirstName);
                objCommand.Parameters.AddWithValue("@LastName", newLastName);
                objCommand.Parameters.AddWithValue("@Date", newDate);
                objCommand.Parameters.AddWithValue("@Time", newTime);



                objDB.DoUpdateUsingCmdObj(objCommand);



                gvManageReservations.EditIndex = -1;

                gvManageReservations.DataBind();
                Response.Redirect("ManageReservations.aspx");
                lblError.Text = "";
            }
            else
            {
                lblError.Text = "You have left one or more fields blank or entered an invalid input. Please check and try again.";
            }
        }

      
        protected void gvManageReservations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string selectedReservationID = gvManageReservations.DataKeys[rowIndex].Value.ToString();

            if (e.CommandName == "Select")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CancelReservation";

                objCommand.Parameters.AddWithValue("@ReservationID", selectedReservationID);

                objDB.DoUpdateUsingCmdObj(objCommand);
                gvManageReservations.DataBind();
                Response.Redirect("ManageReservations.aspx");
                display.Text = "Reservation" + selectedReservationID + " has been cancelled";
            }
        }

        




      

      
        protected void gvManageReservations_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvManageReservations.EditIndex = -1;
            gvManageReservations.DataBind();

        }
    }
}