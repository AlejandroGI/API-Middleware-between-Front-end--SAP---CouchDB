﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klp_api.Models.Res.Categories
{
    public class ValidationCategoriesResBodyModel
    {
        public CategoriesResBodyModel[] docs { get; set; }
        public string bookmark { get; set; }
    }
}
