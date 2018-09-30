using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactEditor.Services
{
    public interface IDataProvider
    {
        bool Delete(IContact contact);

        List<IContact> GetAllContacts();

        IContact GetContactById(int id);

        bool Insert(IContact contact);

        bool Update(IContact contact);
    }
}
