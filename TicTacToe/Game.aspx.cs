using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using TicTacToe.Model;

namespace TicTacToe
{
    public partial class Game : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        public static List<LiveMatch> GetLiveMatchList()
        {
            return GlobalItems.OngoingMatches;
        }
        [WebMethod(EnableSession = true)]
        public static string GameStatus(string clickedBy)
        {
            string status = "";
            string winner = GameWinner(clickedBy);
            if (winner .Equals( "X"))
            {
                status = "Winner is X";
            }else if (winner.Equals( "0"))
            {
                status = "Winner is 0";
            }
            else
            {
                string tie = IsGameTie(clickedBy );
                if (tie.Equals( "yes"))
                {
                    status = "Game is a Tie";
                }else if (tie .Equals( "no"))
                {
                    status = "proceed";
                }
            }
            return status;
        }

        [WebMethod(EnableSession = true), ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetCurrentChance(string username)
        {
            string current="";
            string playerX = "";
            string player0 = "";

            List<int> list=new List<int>();
            for (int i = 0; i < GlobalItems.OngoingMatches.Count; i++)
            {
                LiveMatch temp = GlobalItems.OngoingMatches[i];
                string gameId = temp.GameId;
                if (gameId.Contains(username))
                {
                    //current = temp.CurrentMove;
                    playerX= temp.Sender;
                    player0 = temp.Receiver;

                    list = temp.ButtonStatus;
                    if (list.Count == 0)
                        current = "X";
                    else if (list.Count%2 == 0)
                        current = "X";
                    else
                        current = "0";    
                                        
                }


            }
            return JsonConvert.SerializeObject(new { PlayerX = playerX, Player0 = player0, Current=current});
            ;

        }
        [WebMethod(EnableSession = true)]

        public static void AddMove(string username, string idPassed)
        {
            for (int i = 0; i < GlobalItems.OngoingMatches.Count; i++)
            {
                LiveMatch temp = GlobalItems.OngoingMatches[i];
                string gameId = temp.GameId;
                int buttonClicked = 0;
                if (gameId.Contains(username))
                {
                    //current = temp.CurrentMove;
                    if (idPassed == "one")
                        buttonClicked = 1;
                    else if (idPassed == "two")
                        buttonClicked = 2;
                    else if (idPassed == "three")
                        buttonClicked = 3;
                    else if (idPassed == "four")
                        buttonClicked = 4;
                    else if (idPassed == "five")
                        buttonClicked = 5;
                    else if (idPassed == "six")
                        buttonClicked = 6;
                    else if (idPassed == "seven")
                        buttonClicked = 7;
                    else if (idPassed == "eight")
                        buttonClicked = 8;
                    else if (idPassed == "nine")
                        buttonClicked = 9;

                    temp.ButtonStatus.Add(buttonClicked);

                    int a = temp.ButtonStatus.Count;


                }


            }


        }

        public static string GameWinner(string username)
        {
            String winner = "";
            List<int> buttonsStatus = GetButtonsStatus(username);
           
            string[] arrayButtons= {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            for (int i = 0; i < buttonsStatus.Count; i++)
            {
                int a = buttonsStatus[i]-1;

                if (i%2 == 0)
                {
                    arrayButtons[a] = "X";
                }
                else
                {
                    arrayButtons[a] = "0";

                }
            }

            if ((arrayButtons[0].Equals("X") && arrayButtons[1].Equals("X") && arrayButtons[2].Equals("X")) ||
                (arrayButtons[3].Equals("X") && arrayButtons[4].Equals("X") && arrayButtons[5].Equals("X")) ||
                (arrayButtons[6].Equals("X") && arrayButtons[7].Equals("X") && arrayButtons[8].Equals("X")) ||
                (arrayButtons[0].Equals("X") && arrayButtons[3].Equals("X") && arrayButtons[6].Equals("X")) ||
                (arrayButtons[1].Equals("X") && arrayButtons[4].Equals("X") && arrayButtons[7].Equals("X")) ||
                (arrayButtons[2].Equals("X") && arrayButtons[5].Equals("X") && arrayButtons[8].Equals("X")) ||
                (arrayButtons[0].Equals("X") && arrayButtons[4].Equals("X") && arrayButtons[8].Equals("X")) ||
                (arrayButtons[2].Equals("X") && arrayButtons[4].Equals("X") && arrayButtons[6].Equals("X"))  )
            {
                winner = "X";
            }
            else if ((arrayButtons[0].Equals("0") && arrayButtons[1].Equals("0") && arrayButtons[2].Equals("0")) ||
                     (arrayButtons[3].Equals("0") && arrayButtons[4].Equals("0") && arrayButtons[5].Equals("0")) ||
                     (arrayButtons[6].Equals("0") && arrayButtons[7].Equals("0") && arrayButtons[8].Equals("0")) ||
                     (arrayButtons[0].Equals("0") && arrayButtons[3].Equals("0") && arrayButtons[6].Equals("0")) ||
                     (arrayButtons[1].Equals("0") && arrayButtons[4].Equals("0") && arrayButtons[7].Equals("0")) ||
                     (arrayButtons[2].Equals("0") && arrayButtons[5].Equals("0") && arrayButtons[8].Equals("0")) ||
                     (arrayButtons[0].Equals("0") && arrayButtons[4].Equals("0") && arrayButtons[8].Equals("0")) ||
                     (arrayButtons[2].Equals("0") && arrayButtons[4].Equals("0") && arrayButtons[6].Equals("0")))
            {
                winner = "0";
            }
            return winner;
        }

        public static List<Int32> GetButtonsStatus(string username)
        {
            List<int> buttonsStatus = new List<int>();

            for (int i = 0; i < GlobalItems.OngoingMatches.Count; i++)
            {
                LiveMatch temp = GlobalItems.OngoingMatches[i];
                string gameId = temp.GameId;
                if (gameId.Contains(username))
                {
                    buttonsStatus = temp.ButtonStatus;
                }
            }

            return buttonsStatus;

        }

        public static string IsGameTie(string username)
        {
            List<int> buttonsStatus = GetButtonsStatus(username);

            string tie = "";
            if (buttonsStatus.Count == 9)
            {
                tie = "yes";
            }
            else
            {
                tie = "no";
            }

            return tie;
        }
    }
}