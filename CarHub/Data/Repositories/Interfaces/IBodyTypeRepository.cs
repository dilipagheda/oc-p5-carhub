using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories.Interfaces
{
    public interface IBodyTypeRepository
    {
        public List<BodyType> GetAllBodyTypes();

        public string GetBodyTypeById(int id);

        public int ManageBodyType(BodyType bodyTypeObj);
    }
}
