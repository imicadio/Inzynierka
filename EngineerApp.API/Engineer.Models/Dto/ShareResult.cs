﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Models.Dto
{
    public class SearchResult<T> : BaseModelDto where T : BaseModelDto
    {
        public List<T> Results { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPageCount { get; set; }
        public int Count { get; set; }
    }
}
