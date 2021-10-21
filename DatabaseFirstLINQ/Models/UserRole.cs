<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirstLINQ.Models
{
    public partial class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
=======
﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirstLINQ.Models
{
    public partial class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
>>>>>>> a86ba17aba9026300ffc6a2d69aeaa1bc6573def
