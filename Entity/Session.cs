﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Session
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public int? GameId { get; set; }
    }
}
