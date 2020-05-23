using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CarHub.Data.Repositories
{
    public class BodyTypeRepository : IBodyTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public BodyTypeRepository(ApplicationDbContext context) { _context = context; }

        public List<BodyType> GetAllBodyTypes() { return _context.BodyTypes.ToList(); }

        public string GetBodyTypeById(int id)
        { return _context.BodyTypes.Where(x => x.Id == id).Select(x => x.BodyTypeName).FirstOrDefault(); }

        public int ManageBodyType(BodyType bodyTypeObj)
        {
            if(bodyTypeObj != null)
            {
                var existingBodyType = _context.BodyTypes
                    .Where(x => x.BodyTypeName.ToLower().Equals(bodyTypeObj.BodyTypeName.ToLower()))
                    .FirstOrDefault();
                if(existingBodyType != null)
                {
                    existingBodyType.BodyTypeName = bodyTypeObj.BodyTypeName;
                    _context.SaveChanges();
                    return existingBodyType.Id;
                } else
                {
                    _context.BodyTypes.Add(bodyTypeObj);
                    _context.SaveChanges();
                    return bodyTypeObj.Id;
                }
            } else
            {
                return 0;
            }
        }
    }
}
