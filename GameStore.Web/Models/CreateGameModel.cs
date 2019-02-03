using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GameStore.Web.Models
{
    public class CreateGameModel
    {
        public SelectList Categories { get; set; }
    }
}