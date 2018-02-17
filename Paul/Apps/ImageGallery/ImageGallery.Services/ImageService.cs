using ImageGallery.Data;
using ImageGallery.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ImageGallery.Services
{
    public class ImageService : IImage
    {
        private readonly ImageGalleryDbContext _ctx;

        public ImageService(ImageGalleryDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<GalleryImage> GetAll()
        {
            return _ctx.GalleryImages.Include(img => img.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return GetAll().Where(img => img.Id == id).First();
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetAll().Where(img => img.Tags.Any(t => t.Description == tag));
        }
    }
}
