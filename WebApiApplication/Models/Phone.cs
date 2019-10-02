using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiApplication.Permanence;

namespace WebApiApplication.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PersonFullName { get; set; }
        public string PhoneNumber { get; set; }

        public Phone() { }
        public Phone(Phone phone)
        {
            Id = phone.Id;
            PersonId = phone.PersonId;
            PersonFullName = phone.PersonFullName;
            PhoneNumber = phone.PhoneNumber;
        }

        public static async Task<List<Phone>> GetAllAsync()
        {
            using(var webApiContext = new WebApiContext())
            {
                var phones = await webApiContext.Phones.ToListAsync();

                return phones.Select(s => (Phone)s).ToList();
            }
        }

        public static async Task<Phone> GetByIdAsync(int id)
        {
            using(var webApiContext = new WebApiContext())
            {
                var phone = await webApiContext.Phones.FirstOrDefaultAsync(w => w.Id == id);

                return (Phone) phone;
            }
        }

        public async Task<bool> CreateAsync()
        {
            using(var webApiContext = new WebApiContext())
            {
                var phone = await webApiContext.Phones.FirstOrDefaultAsync(w => w.Id == Id);

                if (phone != null) return false;

                var newPhone = new Permanence.Phone();
                Compose(ref newPhone);

                webApiContext.Phones.Add(newPhone);
                var response = await webApiContext.SaveChangesAsync();

                return response == 1;
            }
        }

        public async Task<bool> UpdateAsync()
        {
            using(var webApiContext = new WebApiContext())
            {
                var phone = await webApiContext.Phones.FirstOrDefaultAsync(w => w.Id == Id);
                if (phone == null) return false;

                Compose(ref phone);

                var response = await webApiContext.SaveChangesAsync();

                return response == 1;
            }
        }

        public async Task<bool> RemoveAsync()
        {
            using(var webApiContext = new WebApiContext())
            {
                var phone = await webApiContext.Phones.FirstOrDefaultAsync(w => w.Id == Id);
                if (phone == null) return false;

                webApiContext.Phones.Remove(phone);
                var response = await webApiContext.SaveChangesAsync();

                return response == 1;
            }
        }

        private void Compose(ref Permanence.Phone phone)
        {
            if (phone == null) return;

            phone.Id = Id;
            phone.PersonId = PersonId;
            phone.PhoneNumber = PhoneNumber;
        }

        public static explicit operator Phone(Permanence.Phone phone)
        {
            if (phone == null) return null;

            var person = Person.GetById(phone.PersonId);

            var p = new Phone
            {
                Id = phone.Id,
                PersonId = phone.PersonId,
                PersonFullName = person != null ? $"{person.FirstName} {person.LastName}" : string.Empty,
                PhoneNumber = phone.PhoneNumber
            };

            return p;
        }
    }
}