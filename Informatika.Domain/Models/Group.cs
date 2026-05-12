using System;
using System.Collections.Generic;
using System.Text;
using Templates;

namespace Informatika.Domain.Models
{
    public class Group : BaseBdEntityWithId
    {
        public string Name { get; set; } = null!;

        public List<User> Users { get; set; } = [];
    }
}
