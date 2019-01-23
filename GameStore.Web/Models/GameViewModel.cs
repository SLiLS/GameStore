using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace GameStore.Web.Models
{
    public class GameViewModel
    {
        public int GameId { get; set; }

        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public string GameCategory { get; set; }
        
        public decimal Price { get; set; }
        public string OperationSystem { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string VideoCard { get; set; }
    }
}