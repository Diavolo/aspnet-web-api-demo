using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiApplication.Permanence
{
    [Table("dbo.Person")]
    public class Person
    {
        [Key, Column(Order =1)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}