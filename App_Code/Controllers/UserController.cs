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

    public User getUser(Guid id)
    {
        return UserDataService.getUser(id);
    }

    public List<Listing> getUserListings(Guid id, int limit = 0)
    {

        // get user listings

        return ListingDataService.getListingsBy(ListingDataService.ColumnNames.UserId, id.ToString(), limit);
    }

    public bool postUser(User user)
    {
        // post user to database

        return UserDataService.addUser(user);
    }

    public bool deleteUser(Guid id)
    {
        // delete user from database

        return UserDataService.deleteUser(id);
    }

    public bool updateUser(Guid id, User user)
    {
        // update user in database

        return UserDataService.updateUser(id, user);
    }
}