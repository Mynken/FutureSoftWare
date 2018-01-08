using FSW.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSW.Data.Entities;

namespace FSW.Data.Context
{
    public class EFGalleryRepository : IGalleryRepository
    {
        public IEnumerable<Gallery> Galleries
        {
            get
            {
                using (var context = new FSWContext())
                {
                    return context.Galleries.ToList();
                }
            }
        }
        public void DeleteGallery(int Id)
        {
            using (var context = new FSWContext())
            {
                Gallery dbEntry = context.Galleries.Find(Id);
                if (dbEntry != null)
                {
                    context.Galleries.Remove(dbEntry);
                    context.SaveChanges();
                }
            }
        }
        public Gallery FindGallery(int Id)
        {
            using (var context = new FSWContext())
            {
                var dbEntry = context.Galleries.Find(Id);
                return dbEntry;
            }
        }
        public void SaveGallery(Gallery gallery)
        {
            using (var context = new FSWContext())
            {
                if (gallery.id == 0)
                {
                    gallery.FileName = "/Content/img/gallery/" + gallery.FileName;
                    context.Galleries.Add(gallery);
                }
                else
                {
                    Gallery dbEntry = context.Galleries.Find(gallery.id);
                    if (dbEntry != null)
                    {
                        dbEntry.Desciption = gallery.Desciption;
                        dbEntry.FileName = gallery.FileName;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
