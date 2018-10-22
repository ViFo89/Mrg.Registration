using Mrg.Registration.Domain;
using System;

namespace Mrg.Registration
{
    public interface IRepository
    {
        void Save(Guid id, Customer customer);

        Customer Get(Guid id);

        void Delete(Guid id);
    }
}