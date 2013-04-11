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
    public string password { get; set; }
    public string email { get; set; }
    public string location { get; set; }

	public User(string name, string password)
	{
        this.name = name;
        this.password = password;
		//
		// TODO: Add constructor logic here
		//
	}
    public User(Guid uid, string name, string password) : this(name,password)
    {
        this.uid = uid;
    }



}