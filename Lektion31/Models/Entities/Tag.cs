﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion31.Models.Entities.Abstract;

namespace Lektion31.Models.Entities
{
    public class Tag : IEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}