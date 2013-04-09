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
    public int userId { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string location { get; set; }
    public List<String> tags { get; set; }
    public DateTime date { get; set; }


	public Listing(int userId, string title, string location, DateTime date)
	{
        this.userId = userId;
        this.title = title;
        this.location = location;
        this.date = date;
	}

    public Listing(int uid, int userId, string title, string location, DateTime date)
        : this(userId, title, location, date)
    {
        this.uid = uid;
    }
}