using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetPet.Models
{
    public class BaseIDModel
    {
        public int ID { get; set; }

        public DateTime? Updated { get; set; }

        public DateTime Created { get; set; }
    }
}
