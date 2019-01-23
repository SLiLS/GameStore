using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities
{
   public class Requirement
    {
        [Key]
        [ForeignKey("Game")]
        public int Id { get; set; }
        public string OperationSystem { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string VideoCard { get; set; }
        public Game Game { get; set; }
       
    }
}
