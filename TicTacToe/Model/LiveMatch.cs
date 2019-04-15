using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe.Model
{
    public class LiveMatch
    {
        public  string Sender { get; set; }

        public  string Receiver { get; set; }
        public  List<Int32> ButtonStatus = new List<Int32>();
        public string GameId { get; set; }
        public string PLayerX { get; set; }
        public string Player0 { get; set; }

        public string Tie { get; set; }
        public  string Winner { get; set; }
        public  string CurrentMove { get; set; }


        public  string Button1 { get; set; }
        public  string Button2 { get; set; }
        public  string Button3 { get; set; }
        public  string Button4 { get; set; }
        public  string Button5 { get; set; }
        public  string Button6 { get; set; }
        public  string Button7 { get; set; }
        public  string Button8 { get; set; }
        public  string Button9 { get; set; }

        public LiveMatch(string sender,string receiver)
        {
            Sender = sender;
            Receiver = receiver;
            CurrentMove = sender;
            PLayerX = sender;
            Player0 = receiver;
            Tie = "No";
            Winner = "";
            GameId = sender + receiver;

            Button1 = "1"; Button2 = "2"; Button3 = "3";
            Button4 = "4"; Button5 = "5"; Button6 = "6";
            Button7 = "7"; Button8 = "8"; Button9 = "9";

        }
    }
}