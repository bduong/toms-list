using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public Guid uid { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string location { get; set; }
    public byte[] photo { get; set; }

	public User(string name, string email)
	{
        this.name = name;
        this.email = email;
        photo = new byte[1];
        this.location = "";
		//
		// TODO: Add constructor logic here
		//
	}

    public User(string name, string email, string location)
    {
        this.name = name;
        this.email = email;
        photo = new byte[1];
        this.location = location;
        //
        // TODO: Add constructor logic here
        //
    }
    public User(Guid uid, string name, string email) : this(name,email)
    {
        this.uid = uid;
    }

    public User(Guid uid, string name, string email, string location) : this(name, email, location)
    {
        this.uid = uid;
    }


}