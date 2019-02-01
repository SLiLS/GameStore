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
  public class Cart
    {

        [Key]
        public int Id { get; set; }


        public string ClientCartId { get; set; }

        public int Sum { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }



    }
}
