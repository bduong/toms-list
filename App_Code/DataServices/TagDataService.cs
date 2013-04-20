﻿using System;
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
        SqlDataReader reader = find.ExecuteReader();
        int id;
        if (reader.Read())
        {
            id = (int) reader["TagId"];
        }
        else
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Tags (Name) VALUES (@Name); SELECT SCOPE_IDENTITY()", conn);
            cmd.Parameters.AddWithValue("@Name", name);
            id = (int)cmd.ExecuteScalar();
        }
        conn.Close();
        return new Tag(id, name);
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

    public static Boolean deleteTag(Tag tag)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM Tags where TagId = @TagId", conn);
        cmd.Parameters.AddWithValue("@TagId", tag.id);
        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }
}