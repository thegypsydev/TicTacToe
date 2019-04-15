using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TicTacToe.Model;

namespace TicTacToe
{
    public partial class DashBoard : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        [WebMethod(EnableSession = true)]
        public static List<Users> GetUsersList()
        {
            return GlobalItems.OnlineUsers;
        }


        [WebMethod(EnableSession = true)]
        public static List<GameRequests> GetGameRequestsList()
        {
            return GlobalItems.Requests;
        }

        [WebMethod(EnableSession = true)]
        public static List<LiveMatch> GetLiveMatchList()
        {
            return GlobalItems.OngoingMatches;
        }

        [WebMethod(EnableSession = true)]
        public static void AddGameRequest(string sentto,string sentby, string status,string sender,string receiver)
        {
                GlobalItems.Requests.Add(new GameRequests(sentto,sentby,status,sender,receiver));
            
            
            
        }


        [WebMethod(EnableSession = true)]
        public static void RemoveRequest(string sender, string receiver)
        {
                for(var i=0;i<GlobalItems.Requests.Count;i++)
                {
                    GameRequests item = GlobalItems.Requests[i];
                var sentBy = item.SenderName;
                var sentTo = item.ReceiverName;
                if (sentTo != null && sentBy!=null)
                    if (sentTo == receiver && sentBy == sender)
                    {
                        GlobalItems.Requests.RemoveAt(i);

                    }
            }

        }


        [WebMethod(EnableSession = true)]
        public static void ChallengeAccepted(string sender, string receiver)
        {

            GlobalItems.OngoingMatches.Add(new LiveMatch(sender,receiver));

            int a = GlobalItems.OngoingMatches.Count;

            for (int i = 0; i < a; i++)
            {
                LiveMatch alpha = GlobalItems.OngoingMatches[i];

                if (alpha != null)
                {
                    var abc = alpha.Sender;
                }
            }

            for (var i = 0; i < GlobalItems.Requests.Count; i++)
            {
                GameRequests item = GlobalItems.Requests[i];
                var sentBy = item.SenderName;
                var sentTo = item.ReceiverName;
                if (sentTo != null && sentBy != null)
                    if (sentTo == receiver && sentBy == sender)
                    {
                        GlobalItems.Requests.RemoveAt(i);

                    }
            }

            
            




        }
    }
}