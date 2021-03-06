﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.DTO
{
  public  class GameDTO
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string OperationSystem { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string VideoCard { get; set; }
    }
}
