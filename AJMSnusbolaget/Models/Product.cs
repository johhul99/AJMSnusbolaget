﻿namespace AJMSnusbolaget.Models
{
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string brand { get; set; } = string.Empty;
            public int Price { get; set; }
            public int Quantity { get; set; }
 
        }
    }