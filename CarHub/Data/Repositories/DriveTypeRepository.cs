using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class DriveTypeRepository : IDriveTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public DriveTypeRepository(ApplicationDbContext context) { _context = context; }

        public List<DriveType> GetAllDriveTypes() { return _context.DriveTypes.ToList(); }

        public string GetDriveTypeById(int id)
        { return _context.DriveTypes.Where(x => x.Id == id).Select(x => x.DriveTypeName).FirstOrDefault(); }

        public int ManageDriveType(DriveType driveTypeObj)
        {
            if(driveTypeObj != null)
            {
                var existringDriveType = _context.DriveTypes
                    .Where(x => x.DriveTypeName.ToLower().Equals(driveTypeObj.DriveTypeName.ToLower()))
                    .FirstOrDefault();
                if(existringDriveType != null)
                {
                    existringDriveType.DriveTypeName = driveTypeObj.DriveTypeName;
                    _context.SaveChanges();
                    return existringDriveType.Id;
                } else
                {
                    _context.DriveTypes.Add(driveTypeObj);
                    _context.SaveChanges();
                    return driveTypeObj.Id;
                }
            } else
            {
                return 0;
            }
        }
    }
}
