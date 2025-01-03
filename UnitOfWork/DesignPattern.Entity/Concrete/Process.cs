﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Entity.Concrete
{
    public class Process
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Cost { get; set; }
    }
}
