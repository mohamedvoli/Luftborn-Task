﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTask.Domain.Entities
{
    public class BaseClass
    {
        public int Id { get; set; } 
        public bool IsDeleted { get; set; } = false; 

        
    }
}
