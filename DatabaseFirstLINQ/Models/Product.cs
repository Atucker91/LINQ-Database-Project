<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirstLINQ.Models
{
    public partial class Product
    {
        public Product()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
=======
﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirstLINQ.Models
{
    public partial class Product
    {
        public Product()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
>>>>>>> a86ba17aba9026300ffc6a2d69aeaa1bc6573def
