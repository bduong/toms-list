using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// implementation class for UserControllerInterface
/// </summary>
public class UserController: UserControllerInterface
{
    /// <summary>
    /// constructor for UserController
    /// </summary>
    public UserController()
    {

    }

    public User getUser(String id)
    {
        User user = new User("test_user", "test_password");
        return user;
    }

    public ArrayList getUserListings(String id, int limit)
    {
        ArrayList listings = new ArrayList();

        // get user listings

        return listings;
    }

    public bool postUser(User user)
    {
        // post user to database

        return true;
    }

    public bool deleteUser(String id)
    {
        // delete user from database

        return true;
    }

    public bool updateUser(String id, User user)
    {
        // update user in database

        return true;
    }
}