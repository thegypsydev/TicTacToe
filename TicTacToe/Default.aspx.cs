using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;

namespace TicTacToe
{
    public partial class Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            error_username.Visible = false;
            error_pwd.Visible = false;
            invalid_user.Visible = false;
        }

        [WebMethod(EnableSession = true)]
        public static string Verify_User(string username, string pwd)

        {
            
            var connManager = WebConfigurationManager.ConnectionStrings["DBConnection"];
            SqlConnection dbConn = new SqlConnection(connManager.ConnectionString);
            try

            {
                dbConn.Open();
                SqlCommand cmd = new SqlCommand("TicTacToe_VerifyUser", dbConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar) { Value = username });
                cmd.Parameters.Add(new SqlParameter("@Pwd", SqlDbType.VarChar) { Value = pwd });

                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
               
                if (rd.HasRows)
                {
                    var Username = rd["Username"].ToString();

                    var status = "notfound";
                    foreach (var users in GlobalItems.OnlineUsers)
                    {
                        var userName = users.Username;
                        if (userName.Equals(Username))
                        {
                            status = "found";
                            break;
                        }
                        

                    }

                    if (status.Equals("found"))
                    {
                        return "alreadyLoggedIn";

                    }
                    else
                    {
                        GlobalItems.OnlineUsers.Add(new Users
                        {
                            PlayerId = rd["PlayerId"].ToString(),
                            Name = rd["Name"].ToString(),
                            Email = rd["Email"].ToString(),
                            Username = rd["Username"].ToString(),
                            GamesPlayed = rd["GamesPlayed"].ToString(),
                            GamesWon = rd["GamesWon"].ToString(),
                            Status = "Online"
                        });

                        GlobalItems.TotalPlayersOnline= GlobalItems.OnlineUsers.Count;

                        return "success";
                    }


                }
                else
                {
                    //invalid_user.Visible = true;
                    return "invalidCredentials";
                }

              

                
                
            }

            catch (Exception ex)

            {
                return "error" + ex;
                //return "error";

            }
        }

        
    }
}