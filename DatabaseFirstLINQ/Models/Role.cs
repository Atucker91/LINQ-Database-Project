<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirstLINQ.Models
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
=======
﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirstLINQ.Models
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
>>>>>>> a86ba17aba9026300ffc6a2d69aeaa1bc6573def
