﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Upload3.Model
{
    public class Thumbnail
    {
        [ForeignKey("FileId")]
        public StoredFile File { get; set; }
        [Key]
        public Guid FileId { get; set; }
        [Key]
        public ThumbnailType Type { get; set; }
        public byte[] Blob { get; set; }
    }
    public enum ThumbnailType
    {
        Square,
        SameAspectRatio
    }
}
