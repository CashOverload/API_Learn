﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Matrix.Data
{
    internal class User
    {
        public int Id { get; set; }
        public string ?Email { get; set; }
        public string ?First_Name { get; set; }
        public string ?Last_Name { get; set; }
        public string ?Avatar { get; set; }
    }
}
