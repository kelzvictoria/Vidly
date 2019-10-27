using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name="Subscribed to Newsletter?")]
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name="Date of Birth")]
        [DataType(DataType.DateTime)]
        [Min18YesrsIfAMember]
        public DateTime? BirthDay { get; set; }

    }
}