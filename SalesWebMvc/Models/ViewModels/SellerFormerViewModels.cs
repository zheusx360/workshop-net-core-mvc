﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormerViewModels
    {
        public Seller seller { get; set;}
        public ICollection <Department> Departments { get; set; }

    }
}