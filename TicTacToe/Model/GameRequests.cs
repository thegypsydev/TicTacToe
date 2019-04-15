using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    public class GameRequests
    {
        public string SentBy { get; set; }
        public string SentTo { get; set; }
        public string Status { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }


        public GameRequests(string sentto, string sentby, string status,string sender,string receiver)
        {
            SentBy = sentby;
            SentTo = sentto;
            Status = status;
            SenderName = sender;
            ReceiverName = receiver;
        }

    }
}