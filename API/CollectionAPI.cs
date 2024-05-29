using BugSpotterBE.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace BugSpotterBE.API
{
    public class CollectionAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/collections/{userId}", (BugSpotterBEDbContext db, int userId) => // get users collections
            {
                var usersCollections = db.Collections.Include(c => c.Posts).Where(c => c.UserId == userId).Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.UserId,
                    c.Favorite,
                    c.numberOfPosts,
                }).ToList();
                if (usersCollections.Any())
                {
                    return Results.Ok(usersCollections);
                }
                else
                {
                    return Results.NotFound("");
                }
            });
            app.MapGet("/collections/details/{collectionId}", (BugSpotterBEDbContext db, int collectionId) => // get single collection
            {
                var collection = db.Collections.Include(c => c.Posts).FirstOrDefault(c => c.Id == collectionId);
                if (collection != null)
                {
                    return Results.Ok(collection);
                }
                else
                {
                    return Results.NotFound("");
                }
            });
            app.MapPost("/collections", (BugSpotterBEDbContext db, CreateCollectionDTO newCollectionDTO) => // create collection
            {
                try
                {
                    Collection newCollection = new()
                    {
                        Id = newCollectionDTO.Id,
                        Name = newCollectionDTO.Name,
                        UserId = newCollectionDTO.UserId,
                        Favorite = newCollectionDTO.Favorite,
                    };
                db.Collections.Add(newCollection);
                db.SaveChanges();
                return Results.Created($"/collections/{newCollection.Id}", newCollection);
                }
                catch
                {
                    return Results.BadRequest("There was an issue creating this collection, please check your data");

                }
            });

            app.MapPut("/collections/{collectionId}", (BugSpotterBEDbContext db, int collectionId, UpdateCollectionDTO updatedCollection) => //update collection
            {
                try
                {
                    var collectionToUpdate = db.Collections.FirstOrDefault(c => c.Id == collectionId);
                    collectionToUpdate.Name = updatedCollection.Name;
                    collectionToUpdate.Favorite = updatedCollection.Favorite;
                    db.SaveChanges();
                    return Results.Created($"/collections/{collectionToUpdate.Id}", updatedCollection);
                } catch
                {
                    return Results.BadRequest("There was an issue updating the collection, check your data");
                }
            });

            app.MapDelete("/collections/{collectionId}", (BugSpotterBEDbContext db, int collectionId) =>  //delete collection
            {
                var collectionToDelete = db.Collections.FirstOrDefault(c => c.Id == collectionId);
                if (collectionToDelete != null)
                {
                    db.Collections.Remove(collectionToDelete);
                    db.SaveChanges();
                    return Results.NoContent();
                }
                else
                {
                    return Results.BadRequest("This collection doesnt exist");
                }
            });

        }
    }
}
