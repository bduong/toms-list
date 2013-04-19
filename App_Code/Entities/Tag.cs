using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Tag
/// </summary>
public class Tag
{
    public int id { get; set; }
    public string name { get; set; }

	public Tag(int id, string name)
	{
        this.id = id;
        this.name = name;
	}
}