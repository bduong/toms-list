using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Image
/// </summary>
public class Image
{
    public int imageId { get; set; }
    public byte[] data { get; set; }
    public string contentType { get; set; }
    public int height { get; set; }
    public int width { get; set; }

    public Image(byte[] data, string contentType, int height, int width)
    {
        this.data = data;
        this.contentType = contentType;
        this.height = height;
        this.width = width;
    }

    public Image(int id, byte[] data, string contentType, int height, int width) : this(data, contentType, height, width)
    {
        this.imageId = id;        
    }
}