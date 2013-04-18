using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Listing
/// </summary>
public class Listing
{
    public int uid { get; set; }
    public Guid userId { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string location { get; set; }
    public List<String> tags { get; set; }
    public DateTime date { get; set; }


	public Listing(Guid userId, string title, string description, string location, DateTime date)
	{
        this.userId = userId;
        this.title = title;
        this.location = location;
        this.description = description;
        this.date = date;
        this.description = description;
        this.tags = new List<String>();
	}

    public Listing(int uid, Guid userId, string title, string description, string location, DateTime date)
        : this(userId, title, description, location, date)
    {
        this.uid = uid;
    }
}