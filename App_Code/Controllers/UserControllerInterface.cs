using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// interface class for UserController
/// </summary>
public interface UserControllerInterface
{

    #region get_functions

    /// <summary>
    /// fetch the user from the database
    /// </summary>
    /// <param name="name">id of the user</param>
    /// <returns>user object</returns>
    User getUser(Guid id);

    /// <summary>
    /// get the recently posted listings for a given user
    /// </summary>
    /// <param name="id">id of the user</param>
    /// <param name="limit">limit on the size of the result set</param>
    /// <returns>list of listings</returns>
    List<Listing> getUserListings(Guid id, int limit);

    #endregion

    #region post_functions

    /// <summary>
    /// post user to database
    /// </summary>
    /// <param name="user">user object to be posted</param>
    /// <returns>user posted successfully</returns>
    bool postUser(User user);

    #endregion

    #region delete_functions

    /// <summary>
    /// delete user from database
    /// </summary>
    /// <param name="id">id of the user to be deleted</param>
    /// <returns>user deleted successfully</returns>
    bool deleteUser(Guid id);

    #endregion

    #region update_functions

    /// <summary>
    /// update user info in database
    /// </summary>
    /// <param name="id">id of the user to be updated</param>
    /// <param name="user">user object to be updated to</param>
    /// <returns>user updated successfully</returns>
    bool updateUser(Guid id, User user);

    #endregion
}