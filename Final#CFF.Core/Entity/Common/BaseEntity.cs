using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_CFF.Core.Entity.Common
{
    public  class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }= DateTime.Now;
        public DateTime?  UpdateTime {  get; set; }
        public bool IsDeleted { get; set; }
    }
}
