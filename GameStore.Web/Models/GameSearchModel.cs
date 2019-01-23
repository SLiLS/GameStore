using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.Web.Models
{
    public class GameSearchModel
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public string GameCategory { get; set; }
        public decimal Price { get; set; }
       
    }
}