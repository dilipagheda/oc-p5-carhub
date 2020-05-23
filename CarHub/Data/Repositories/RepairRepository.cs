using AutoMapper;
using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class RepairRepository : IRepairRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RepairRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Repair> GetAllRepairs() { return _context.Repairs; }

        public void AddNewRepair(Repair repairObj)
        {
            if(repairObj != null)
            {
                _context.Repairs.Add(repairObj);
                _context.SaveChanges();
            }
        }

        public Repair GetRepairDetailsByCarId(string carId)
        {
            if(carId == null)
                return null;

            return _context.Repairs.Where(r => r.CarId.ToString() == carId).FirstOrDefault();
        }

        public void DeleteRepairDetailsByCarId(string carId)
        {
            var repairToRemove = _context.Repairs.Where(x => x.CarId.ToString() == carId).FirstOrDefault();
            if(repairToRemove != null)
            {
                _context.Repairs.Remove(repairToRemove);
                _context.SaveChanges();
            }
        }

        public void EditRepair(string carId, Repair repairObj)
        {
            var currentRepair = _context.Repairs.Where(x => x.CarId.ToString() == carId).FirstOrDefault();
            if(currentRepair != null)
            {
                _mapper.Map(repairObj, currentRepair);
                _context.Entry(currentRepair).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}


