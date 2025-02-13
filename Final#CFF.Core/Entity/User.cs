using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity.Common;
using Final_CFF.Core.Enums;

namespace Final_CFF.Core.Entity;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string UserEmail { get; set; }
    public string Image { get; set; }
    public string PasswordHash { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public int Role { get; set; }
    public bool IsBanned { get; set; }
    public DateTime? UnlockTime { get; set; }
    public Guid ApertmentId { get; set; }
    public Apartment Apartment { get; set; }
}
