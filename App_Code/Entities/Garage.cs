using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Garage
/// </summary>
public class Garage
{
    public int GarageID { get; set; }
    public Guid userID { get; set; }
    public DateTime DateBegin { get; set; }
    public DateTime DateEnd { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public int imageId { get; set; }

    public Garage(int id, Guid userID, DateTime DateBegin, DateTime DateEnd, string Address, string Description): 
        this(userID, DateBegin, DateEnd, Address, Description)
    {
        this.GarageID = id;
    }

    public Garage(Guid userID, DateTime DateBegin, DateTime DateEnd, string Address, string Description) 
        : this(userID, DateBegin, DateEnd, Address)
	{
        this.Description = Description;
	}

    public Garage(Guid userID, DateTime DateBegin, DateTime DateEnd, string Address) //allow null description
    {
        this.userID = userID;
        this.DateBegin = DateBegin;
        this.DateEnd = DateEnd;
        this.Address = Address;
        imageId = 0;
    }
}