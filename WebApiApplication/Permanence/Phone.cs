using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiApplication.Permanence
{
    [Table("dbo.Phone")]
    public class Phone
    {
        [Key, Column(Order = 1)]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PhoneNumber { get; set; }
    }
}