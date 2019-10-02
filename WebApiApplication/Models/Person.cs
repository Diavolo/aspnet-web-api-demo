using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiApplication.Permanence;

namespace WebApiApplication.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime BirthDate { get; set; }

        public Person() { }
        public Person(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Gender = person.Gender;
            DocumentNumber = person.DocumentNumber;
            BirthDate = person.BirthDate;
        }

        public static async Task<List<Person>> GetAllAsync()
        {
            using (var webApiContext = new WebApiContext())
            {
                var person = await webApiContext.People.ToListAsync();
                return person.Select(s => (Person) s).ToList();
            }
        }

        public static async Task<Person> GetByIdAsync(int id)
        {
            using (var webApiContext = new WebApiContext())
            {
                var person = await webApiContext.People.FirstOrDefaultAsync(w => w.Id == id);
                return (Person) person;
            }
        }

        public static Person GetById(int id)
        {
            using (var webApiContext = new WebApiContext())
            {
                var person = webApiContext.People.FirstOrDefault(w => w.Id == id);
                return (Person)person;
            }
        }

        public async Task<bool> CreateAsync()
        {
            using(var webApiContext = new WebApiContext())
            {
                var person = await webApiContext.People.FirstOrDefaultAsync(w => w.Id == Id);
                if (person != null) return false;

                var newPerson = new Permanence.Person();
                Compose(ref newPerson);

                webApiContext.People.Add(newPerson);
                var response = await webApiContext.SaveChangesAsync();

                return response == 1;
            }
        }

        public async Task<bool> UpdateAsync()
        {
            using(var webApiContext = new WebApiContext())
            {
                var person = await webApiContext.People.FirstOrDefaultAsync(w => w.Id == Id);
                if (person == null) return false;

                Compose(ref person);

                var response = await webApiContext.SaveChangesAsync();

                return response == 1;
            }
        }

        public async Task<bool> RemoveAsync()
        {
            using(var webApiContext = new WebApiContext())
            {
                var person = await webApiContext.People.FirstOrDefaultAsync(w => w.Id == Id);

                if (person == null) return false;

                webApiContext.People.Remove(person);
                var response = await webApiContext.SaveChangesAsync();

                return response == 1;
            }
        }

        private void Compose(ref Permanence.Person person)
        {
            if (person == null) return;

            person.Id = Id;
            person.FirstName = FirstName;
            person.LastName = LastName;
            person.Gender = Gender.ToLower().Equals("female") ? "f" : "m";
            person.DocumentNumber = DocumentNumber;
            person.BirthDate = BirthDate;
        }

        public static explicit operator Person(Permanence.Person person)
        {
            if (person == null) return null;

            var p = new Person
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender.Equals("f") ? "Femenino" : "Masculino",
                DocumentNumber = person.DocumentNumber,
                BirthDate = person.BirthDate
            };

            return p;
        }
    }
}