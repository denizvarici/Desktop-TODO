﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Todo:IEntity
    {
        public int Id { get; set; }
        public string TodoTitle { get; set; }
        public string TodoText { get; set; }
        public int TodoIsDoneInfo { get; set; }

    }
}
