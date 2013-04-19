using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Listing
/// </summary>
public class Listing
{
    public int ListingId { get; set; }
    public Guid userId { get; set; }
    public string title { get; set; }
    public decimal price { get; set; }
    public string description { get; set; }
    public string location { get; set; }
    public List<String> tags { get; set; }
    public DateTime date { get; set; }


	public Listing(Guid userId, string title, string description, decimal price, string location, DateTime date)
	{
        this.userId = userId;
        this.title = title;
        this.location = location;
        this.price = price;
        this.description = description;
        this.date = date;
        this.description = description;
        this.tags = new List<String>();
	}

    public Listing(int uid, Guid userId, string title, string description, decimal price, string location, DateTime date)
        : this(userId, title, description, price, location, date)
    {
        this.ListingId = uid;
    }
}