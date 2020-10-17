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
    public partial class MyRests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlAssign.Visible = false;
            noRests.Visible = false;
            panelNavReviewer.Visible = false;
            panelGuest.Visible = false;
            btnAssign.Visible = false;
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            if (Session["UserType"] != null)
            {

                string strUsertype = Session["UserType"].ToString();
                if (strUsertype == "Rep")
                {


                    panelNavRep.Visible = true;
                    panelGuest.Visible = false;
                    panelNavReviewer.Visible = false;
                    lblLoggedInAs.Text = "Logged in as " + strUsertype + ", " + Session["UserName"].ToString();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetMyRests";
                    string strUsernameFinal = Session["UserName"].ToString();
                    SqlParameter inputParameter = new SqlParameter("@Username", strUsernameFinal);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    inputParameter.Size = 20;

                    objCommand.Parameters.Add(inputParameter);
                    DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                    if (myDS.Tables[0].Rows.Count > 0)
                    {
                        ddlAssign.Visible = false;

                        noRests.Visible = false;
                        gvMyRests.DataSource = myDS;
                        String[] names = new string[1];
                        names[0] = "RestID";
                        gvMyRests.DataKeyNames = names;
                        gvMyRests.DataBind();


                    }


                    else
                    {
                        objCommand.Parameters.Clear();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "GetOpenRests";
                         
                        DataSet myDS2 = objDB.GetDataSetUsingCmdObj(objCommand);
                        ddlAssign.DataSource = myDS2;
                        ddlAssign.DataTextField = "Name";
                        ddlAssign.DataValueField = "RestID";
                        ddlAssign.DataBind();
                        ddlAssign.Visible = true;
                        btnAssign.Visible = true;
                        gvMyRests.Visible = false;
                        noRests.Visible = true;

                        noRests.Text = "You represent no restaurants currently. You can choose one from the drop down to represent.";


                    }
                }
                else if(strUsertype == "Reviewer")
                {
                    panelNavRep.Visible = false;
                    panelGuest.Visible = false;
                    panelNavReviewer.Visible = true;
                    lblTitle.Text = " You do not have access to this page.";
                }

                else if(strUsertype=="Guest")
                {
                    panelGuest.Visible = true;
                    panelNavReviewer.Visible = false;
                    panelNavRep.Visible = false;
                    lblTitle.Text = " Sorry you do not have access to this page.";
                }
            }
            else
            {
                Session["UserType"] = "Guest";
                panelGuest.Visible = true;
                panelNavRep.Visible = false;
                panelNavReviewer.Visible = false;
                lblTitle.Text = "Access error";
            }
        }







        protected void gvMyRests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvMyRests_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvMyRests.EditIndex = e.NewEditIndex;
            gvMyRests.DataBind();

        }

        protected void gvMyRests_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {



            int rowIndex = e.RowIndex;
            string selectedRestID = gvMyRests.DataKeys[rowIndex].Value.ToString();


            TextBox TboxImgURL;
            TboxImgURL = (TextBox)gvMyRests.Rows[rowIndex].Cells[1].Controls[0];
            if (TboxImgURL.Text == "")
            {
                lblError.Text = "Please enter a valid image URL";
            }

            else if (TboxImgURL.Text != "")
            {

                lblError.Text = "";
            }

            TextBox TboxName;
            TboxName = (TextBox)gvMyRests.Rows[rowIndex].Cells[2].Controls[0];

            if (TboxName.Text == "")
            {
                lblError.Text = "Please enter a valid name.";
            }

            else if (TboxName.Text != "")
            {
                lblError.Text = "";
            }


            TextBox TboxType;
            TboxType = (TextBox)gvMyRests.Rows[rowIndex].Cells[3].Controls[0];
            if (TboxType.Text == "")
            {
                lblError.Text = "Please enter a valid category.";
            }

            else if (TboxType.Text != "")
            {
                lblError.Text = "";
            }


            TextBox TboxPhone;
            TboxPhone = (TextBox)gvMyRests.Rows[rowIndex].Cells[4].Controls[0];
            if (TboxPhone.Text == "")
            {
                lblError.Text = "Please enter a valid phone number";
            }

            else if (TboxPhone.Text != "")
            {
                lblError.Text = "";
            }

            TextBox TboxDescription;
            TboxDescription = (TextBox)gvMyRests.Rows[rowIndex].Cells[5].Controls[0];
            if (TboxDescription.Text == "")
            {
                lblError.Text = "Please enter a valid description";
            }

            else if (TboxDescription.Text != "")
            {
                lblError.Text = "";

            }

            TextBox TboxAddress;
            TboxAddress = (TextBox)gvMyRests.Rows[rowIndex].Cells[6].Controls[0];


            if (TboxAddress.Text == "")
            {
                lblError.Text = "Please enter a valid address";
            }

            else if (TboxAddress.Text != "")
            {
                lblError.Text = "";
            }

            if (lblError.Text == "")
            {

                string newAddress = TboxAddress.Text;
                string newDescription = TboxDescription.Text;
                string newPhone = TboxPhone.Text;
                string newType = TboxType.Text;
                string newName = TboxName.Text;
                string newImgURL = TboxImgURL.Text;
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "EditRest";
                objCommand.Parameters.AddWithValue("@ImgURL", newImgURL);
                objCommand.Parameters.AddWithValue("@RestID", selectedRestID);
                objCommand.Parameters.AddWithValue("@Name", newName);
                objCommand.Parameters.AddWithValue("@Phone", newPhone);
                objCommand.Parameters.AddWithValue("@Address", newAddress);
                objCommand.Parameters.AddWithValue("@Description", newDescription);
                objCommand.Parameters.AddWithValue("@Type", newType);


                objDB.DoUpdateUsingCmdObj(objCommand);
            


                gvMyRests.EditIndex = -1;
                gvMyRests.DataBind();
                Response.Redirect("MyRests.aspx");
            }
        }
    



        protected void gvMyRests_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvMyRests.EditIndex = -1;
            gvMyRests.DataBind();

        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {

            
            string RestID = ddlAssign.SelectedValue;
            string RepID = Session["UserName"].ToString();
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AssignRest";
            objCommand.Parameters.AddWithValue("@RestID", RestID);
            objCommand.Parameters.AddWithValue("@RepID", RepID);

           objDB.GetDataSetUsingCmdObj(objCommand);
            gvMyRests.DataBind();
            ddlAssign.DataBind();

            Response.Redirect("MyRests.aspx");
            ddlAssign.Visible = false;
            btnAssign.Visible = false;
        }
    }
}


    

