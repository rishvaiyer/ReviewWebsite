using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Data.SqlClient;
using System.Data;


namespace Procedures
{
   public class Get
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();


        public Boolean GetAllRests(out DataSet myDS)
        {
            try { 
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAllRests";


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


        public Boolean GetMatching(string theType, out DataSet myDS)
        {
            try
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetMatchingRests";
                objCommand.Parameters.AddWithValue("@Type", theType);

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

        public Boolean FindReviewer(string Username, out DataSet myDS)
        {
            try
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "FindReviewer";

                SqlParameter inputParameter = new SqlParameter("@Username", Username);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;
                objCommand.Parameters.Add(inputParameter);

                myDS = objDB.GetDataSetUsingCmdObj(objCommand);


                if (myDS.Tables[0].Rows.Count >= 1)
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


        public Boolean FindRep(string Username, out DataSet myDS)
        {
            try
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "FindRep";

                SqlParameter inputParameter = new SqlParameter("@Username", Username);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;
                objCommand.Parameters.Add(inputParameter);

                myDS = objDB.GetDataSetUsingCmdObj(objCommand);


                if (myDS.Tables[0].Rows.Count >= 1)
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
