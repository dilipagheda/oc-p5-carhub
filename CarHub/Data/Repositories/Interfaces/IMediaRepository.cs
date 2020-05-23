using CarHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHub.Data.Repositories.Interfaces
{
    public interface IMediaRepository
    {
        public Guid? AddNewMedia(Media mediaObj);

        public Media GetMediaById(string id);

        public void AddNewMediaToInventory(string inventoryId, bool isCover, Media mediaObj);

        public List<string> GetAllMediaFileNamesByInventoryId(string inventoryId);

        public List<string> DeleteMediaFromInventory(string inventoryId);
    }
}
