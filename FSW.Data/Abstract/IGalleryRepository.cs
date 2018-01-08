using FSW.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSW.Data.Abstract
{
    public interface IGalleryRepository
    {
        IEnumerable<Gallery> Galleries { get; }
        void SaveGallery(Gallery gallery);
        Gallery FindGallery(int Id);
        void DeleteGallery(int Id);
    }
}
