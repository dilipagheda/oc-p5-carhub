using CarHub.Data.Models;
using CarHub.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly ApplicationDbContext _context;

        public MediaRepository(ApplicationDbContext context) { _context = context; }

        public Guid? AddNewMedia(Media mediaObj)
        {
            if(mediaObj != null)
            {
                _context.MediaList.Add(mediaObj);
                _context.SaveChanges();
                return mediaObj.Id;
            } else
            {
                return null;
            }
        }

        public void AddNewMediaToInventory(string inventoryId, bool isCover, Media mediaObj)
        {
            var inventoryMediaObj = new InventoryMedia()
            { InventoryId = Guid.Parse(inventoryId), IsCoverMedia = isCover };

            if(mediaObj != null && inventoryMediaObj != null)
            {
                _context.MediaList.Add(mediaObj);
                _context.SaveChanges();
                inventoryMediaObj.MediaId = mediaObj.Id;
                _context.InventoryMediaList.Add(inventoryMediaObj);
                _context.SaveChanges();
            }
        }

        public List<string> GetAllMediaFileNamesByInventoryId(string inventoryId)
        {
            var items = _context.InventoryMediaList
                .Where(x => x.InventoryId.ToString() == inventoryId)
                .Join(_context.MediaList, a => a.MediaId, b => b.Id, (a, b) => b.FileName)
                .Distinct()
                .ToList();

            return items;
        }

        public Media GetMediaById(string id)
        { return _context.MediaList.Where(m => m.Id.ToString() == id).FirstOrDefault(); }

        public List<string> DeleteMediaFromInventory(string inventoryId)
        {
            var mediaList = _context.InventoryMediaList.Where(x => x.InventoryId.ToString() == inventoryId).ToList();

            var mediaIds = mediaList
                .Where(x => x.InventoryId.ToString() == inventoryId)
                .Select(x => x.MediaId)
                .ToList();
            if(mediaList != null)
            {
                _context.InventoryMediaList.RemoveRange(mediaList);

                _context.SaveChanges();
            }

            //delete from master table as well
            var mediaToRemove = _context.MediaList.Where(x => mediaIds.Contains(x.Id)).ToList();
            var files = mediaToRemove.Select(x => x.FileName).ToList();
            if(mediaToRemove != null)
            {
                _context.MediaList.RemoveRange(mediaToRemove);
                _context.SaveChanges();
            }
            return files;
        }
    }
}
