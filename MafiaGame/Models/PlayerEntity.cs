﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MafiaGame.Models
{
    public class PlayerEntity : Entity
    {
        public string Name { get; set; }

        public City City { get; set; }
    }
}