using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities; 
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Procedures
{
    public class Add
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        public Boolean AddRest(string name, string description, string imageURL, string type, string address, string phone, out DataSet myDS)
        {
            try
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddNewRest";

                objCommand.Parameters.AddWithValue("@Name", name);
                objCommand.Parameters.AddWithValue("@Description", description);
                objCommand.Parameters.AddWithValue("@ImgURL", imageURL);
                objCommand.Parameters.AddWithValue("@Address", address);
                objCommand.Parameters.AddWithValue("@Phone", phone);
                objCommand.Parameters.AddWithValue("@Type", type);

                objDB.DoUpdateUsingCmdObj(objCommand);

                myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                if (myDS.Tables[0].Rows.Count > 1)
                {
                    return true;
                }
                return false;
            }

            catch
            {
                myDS = null;
                return false;


            }

        }

        public Boolean AddRestWRep(string name, string description, string imageURL, string type, string address, string phone, string repID, out DataSet myDS)
        {
            try
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddNewRestAsRep";

                objCommand.Parameters.AddWithValue("@Name", name);
                objCommand.Parameters.AddWithValue("@Description", description);
                objCommand.Parameters.AddWithValue("@ImgURL", imageURL);
                objCommand.Parameters.AddWithValue("@Address", address);
                objCommand.Parameters.AddWithValue("@Phone", phone);
                objCommand.Parameters.AddWithValue("@Type", type);
                objCommand.Parameters.AddWithValue("@RepID", repID);

                objDB.DoUpdateUsingCmdObj(objCommand);

                myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                if (myDS.Tables[0].Rows.Count > 1)
                {
                    return true;
                }
                return false;
            }

            catch
            {
                myDS = null;
                return false;


            }

        }


        public Boolean AddReview(string username, string restID, string comments, string quality, string service, string price, string atmosphere, double avgRating, out DataSet myDS)
        {
            try
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddReview";

                objCommand.Parameters.AddWithValue("@Username", username);
                objCommand.Parameters.AddWithValue("@RestID", restID);
                objCommand.Parameters.AddWithValue("@Comments", comments);
                objCommand.Parameters.AddWithValue("@FoodQuality", quality);
                objCommand.Parameters.AddWithValue("@Service", service);
                objCommand.Parameters.AddWithValue("Price", price);
                objCommand.Parameters.AddWithValue("@Atmosphere", atmosphere);
                objCommand.Parameters.AddWithValue("@AvgRating", avgRating);



                objDB.DoUpdateUsingCmdObj(objCommand);

                myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                if (myDS.Tables[0].Rows.Count > 1)
                {
                    return true;
                }
                return false;
            }

            catch
            {
                myDS = null;
                return false;


            }

        }
    }
}

