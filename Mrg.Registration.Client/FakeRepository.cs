using Mrg.Registration.Domain;
using System;
using System.Collections.Generic;

namespace Mrg.Registration.Client
{
    internal class FakeRepository : IRepository
    {
        private Dictionary<Guid, Customer> database = new Dictionary<Guid, Customer>();

        public void Delete(Guid id)
        {
            database.Remove(id);
        }

        public Customer Get(Guid id)
        {
            return database[id];
        }

        public void Save(Guid id, Customer customer)
        {
            if (database.ContainsKey(id))
            {
                database[id] = customer;
            }
            else
            {
                database.Add(id, customer);
            }
        }
    }
}