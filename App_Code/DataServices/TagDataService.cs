using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for TagDataService
/// </summary>
public class TagDataService
{

    public static Tag createNewTag(string name)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand find = new SqlCommand("SELECT TagId FROM Tags where Name = @Name", conn);
        find.Parameters.AddWithValue("@Name", name);
        SqlDataReader reader = find.ExecuteReader();
        int id;
        if (reader.Read())
        {
            id = (int) reader["TagId"];
        }
        else
        {
            reader.Close();
            find.Dispose();
            SqlCommand cmd = new SqlCommand("INSERT INTO Tags (Name) VALUES (@Name); SELECT CONVERT(int, SCOPE_IDENTITY())", conn);
            cmd.Parameters.AddWithValue("@Name", name);
            id = (int)cmd.ExecuteScalar();
        }
        conn.Close();
        return new Tag(id, name);
    }

    public static List<Tag> getTagsFromListing(Listing listing)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT TagId FROM ListingTags where ListingId = @ListingId", conn);
        cmd.Parameters.AddWithValue("@ListingId", listing.ListingId);
        SqlDataReader reader = cmd.ExecuteReader();

        List<Tag> tags = new List<Tag>();

        while (reader.Read())
        {
            int tagId = (int) reader["TagId"];
            tags.Add(new Tag(tagId));
        }
        cmd.Dispose();
        reader.Dispose();

        string selectStr = "SELECT Name FROM Tags where TagId = @TagId";

        foreach (Tag t in tags) {
            SqlCommand getName = new SqlCommand(selectStr, conn);
            getName.Parameters.AddWithValue("@TagId", t.id);
            SqlDataReader nameReader = getName.ExecuteReader();
            if (nameReader.Read())
            {
                t.name = (string) nameReader["Name"];
            }
            getName.Dispose();
            nameReader.Dispose();
        }
        return tags;
    }

    public static Tag getTag(int id)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Tags where TagId = @TagId", conn);
        cmd.Parameters.AddWithValue("@TagId", id);
        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        string name = (string)reader["Name"];
        conn.Close();
        return new Tag(id, name);

    }
    public static List<Tag> getTagsByName(string name)
    {
        List<Tag> returnList = new List<Tag>();
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Tags where Name = @Name", conn);
        cmd.Parameters.AddWithValue("@Name", name);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            int id = (int)reader["TagId"];
            Tag t = new Tag(id, name);
            returnList.Add(t);
        }
        conn.Close();
        return returnList;
    }

    public static Boolean deleteTag(int id)
    {
        Tag tag = getTag(id);
        List<int> listingIds = ListingDataService.getListingOfTag(id.ToString());
        foreach (int listingId in listingIds)
        {
            Listing listing = ListingDataService.getListing(listingId.ToString());
            ListingDataService.deleteListingTag(listing, tag);
        }


        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM Tags where TagId = @TagId", conn);
        cmd.Parameters.AddWithValue("@TagId", tag.id);
        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }
}