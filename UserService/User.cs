//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserService 
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.UserAccounts = new HashSet<UserAccount>();
        }
    
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserPassword { get; set; }
        public string E_Mail { get; set; }
        public string HashCode { get; set; }
    
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}