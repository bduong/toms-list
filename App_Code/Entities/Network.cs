using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Network
/// </summary>
public class Network
{
    public int id { get; set; }
    public string name { get; set; }
    public string pattern { get; set; }
	public Network()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Network(string name, string pattern)
    {
        this.name = name;
        this.pattern = pattern;
    }
    public Network(int id, string name, string pattern)
    {
        this.id = id;
        this.name = name;
        this.pattern = pattern;
    }
}