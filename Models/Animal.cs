using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VetPet.Common;
using VetPet.Models.Enum;

namespace VetPet.Models
{
    public class Animal : BaseIDModel
    {
        public AnimalType Type { get; set; }

        [StringLength(Constants.AttributeValidation.DefaultLength100)]
        public string Name { get; set; }

        #region Relations
        [ForeignKey(nameof(User))]
        [StringLength(Constants.AttributeValidation.UserIdLength)]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        #endregion
    }
}
