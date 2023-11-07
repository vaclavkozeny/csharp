using System;

namespace Upload3.Model
{
    public class StoredFileGallery
    {
        public Guid StoredFileId { get; set; }
        public int GalleryId { get; set; }
        public StoredFile StoredFile { get; set; }
        public Gallery Gallery { get; set; }
        public string Name { get; set; }
    }
}