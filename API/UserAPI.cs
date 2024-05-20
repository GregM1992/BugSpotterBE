using BugSpotterBE.Models;
using Microsoft.EntityFrameworkCore;

namespace BugSpotterBE.API
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/users/{uid}", (BugSpotterBEDbContext db, string uid) => // check for user
            {
                var user = db.Users.FirstOrDefault(u => u.Uid == uid);

                if (user == null)
                {
                    return Results.NotFound("User not registered");
                }

                return Results.Ok(user);
            });

            app.MapPost("/users/register", (BugSpotterBEDbContext db, User newUser) => //register user
            {
                try
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return Results.Created($"/users/{newUser.Id}", newUser);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Unable to register user");
                }
            });

            app.MapPut("/users/{id}", (BugSpotterBEDbContext db, int id, User user) => // update user
            {
                var userBeingUpdated = db.Users.FirstOrDefault(u => u.Id == id);

                if (userBeingUpdated == null)
                {
                    return Results.NotFound("No user found");
                }

                userBeingUpdated.Uid = user.Uid;
                userBeingUpdated.UserName = user.UserName;
                userBeingUpdated.EmailAddress = user.EmailAddress;
                userBeingUpdated.Bio = user.Bio;
                userBeingUpdated.City = user.City;
                userBeingUpdated.State = user.State;
                db.SaveChanges();
                return Results.Ok("User has been updated");
            });



        }
    }
}
