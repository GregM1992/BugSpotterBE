using BugSpotterBE.Models;
using Microsoft.EntityFrameworkCore;

namespace BugSpotterBE.API
{
    public class Post_API
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/posts", (BugSpotterBEDbContext db) => // Gets all posts with their tags 
            {
                var allPosts = db.Posts.Include(p => p.Tags).Select(p => new
                {
                    p.Id,
                    p.UserId,
                    p.CollectionId,
                    p.Image,
                    p.Latitude,
                    p.Longitude,
                    p.Description,
                    p.Favorite,
                    Tags = p.Tags.Select(t => new
                    {
                        t.Id,
                        t.TagType,
                    })
                }).ToList();
                if (allPosts == null)
                {
                    return Results.NotFound("There are no posts");
                }
                else
                {
                    return Results.Ok(allPosts);
                }
            });
            app.MapGet("/posts/{userId}", (BugSpotterBEDbContext db, int userId) => //get single users posts 
            {
                var usersPosts = db.Posts.Where(p => p.UserId == userId).Include(p => p.Tags).Select(p => new
                {
                    p.Id,
                    p.UserId,
                    p.CollectionId,
                    p.Image,
                    p.Latitude,
                    p.Longitude,
                    p.Description,
                    p.Favorite,
                    Tags = p.Tags.Select(t => new
                    {
                        t.Id,
                        t.TagType,
                    })
                }).ToList();
                if (usersPosts == null)
                {
                    return Results.NotFound("This user has no posts yet");
                }
                else
                {
                    return Results.Ok(usersPosts);
                }
            });
            app.MapGet("/posts/details/{postId}", (BugSpotterBEDbContext db, int postId) => //get single post by postId
            {
                var singlePost = db.Posts.Include(p => p.Tags).Where(p => p.Id == postId).Select(p => new
                {
                    p.Id,
                    p.UserId,
                    p.CollectionId,
                    p.Image,
                    p.Latitude,
                    p.Longitude,
                    p.Description,
                    p.Favorite,
                    Tags = p.Tags.Select(t => new
                    {
                        t.Id,
                        t.TagType,
                    })
                }).FirstOrDefault();
                if (singlePost == null)
                {
                    return Results.NotFound("This post does not exist");
                }
                else
                {
                    return Results.Ok(singlePost);
                }
            });

            app.MapGet("/postTags/{postId}", (BugSpotterBEDbContext db, int postId) =>
            {
                var postTags = db.Posts.Include(p => p.Tags).Where(p => p.Id == postId).Select(p => new
                {
                    Tags = p.Tags.Select(t => new
                    {
                        t.Id,
                        t.TagType
                    })
                }).FirstOrDefault();

                if (postTags == null)
                {
                    return Results.NotFound("This post does not exist");
                }
                else
                {
                    return Results.Ok(postTags);
                }
            });

            app.MapPost("/posts", (BugSpotterBEDbContext db, CreatePostDTO newPostDTO) => // create new post
            {

                try
                {
                    Post newPost = new()
                    {
                        Id = newPostDTO.Id,
                        UserId = newPostDTO.UserId,
                        CollectionId = newPostDTO.CollectionId,
                        Image = newPostDTO.Image,
                        Latitude = newPostDTO.Latitude,
                        Longitude = newPostDTO.Longitude,
                        Description = newPostDTO.Description,
                        Favorite = newPostDTO.Favorite,
                    };
                    db.Posts.Add(newPost);
                    db.SaveChanges();
                    return Results.Created($"/posts/{newPost.Id}", newPost);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Unable to create post, check your data and try again");
                }

            });
            app.MapPut("/posts/{postId}", (BugSpotterBEDbContext db, int postId, UpdatePostDTO updatedPost) => // update post
            {
                var postToUpdate = db.Posts.Where( p => p.Id == postId ).FirstOrDefault();
                if (postToUpdate != null)
                {
                    postToUpdate.CollectionId = updatedPost.CollectionId;
                    postToUpdate.Image = updatedPost.Image;
                    postToUpdate.Latitude = updatedPost.Latitude;   
                    postToUpdate.Longitude = updatedPost.Longitude;
                    postToUpdate.Description = updatedPost.Description;
                    postToUpdate.Favorite = updatedPost.Favorite;
                    db.SaveChanges();
                    return Results.Created($"/posts/{postToUpdate.Id}", updatedPost);
                }
                else
                {
                    return Results.BadRequest("Could not update post, please check your data and try again");
                }

            });
            app.MapDelete("/posts/{postId}", (BugSpotterBEDbContext db, int postId) => // delete post by postId
            {
                var postToDelete = db.Posts.FirstOrDefault(p => p.Id == postId);
                if (postToDelete != null)
                {
                db.Posts.Remove(postToDelete);
                db.SaveChanges();
                return Results.NoContent();
                }
                else
                {
                    return Results.NotFound("Something went wrong, this post may not exist");
                }

            });
            app.MapGet("/posts/tags/{tagId}", (BugSpotterBEDbContext db, int tagId) => //get posts that match tagId
            {
                var filteredPosts = db.Posts.Include(p => p.Tags).Where(p => p.Tags.Any( t => t.Id == tagId)).Select(p => new
                {
                    p.Id,
                    p.UserId,
                    p.CollectionId,
                    p.Image,
                    p.Longitude,
                    p.Latitude,
                    p.Description,
                    p.Favorite,
                    Tags = p.Tags.Select(t => new
                    {
                        t.Id,   
                        t.TagType
                    })
                }).ToList();
                if (filteredPosts.Count > 0)
                {
                    return Results.Ok(filteredPosts);
                }
                else 
                {
                    return Results.NotFound("there are no posts that match this tag");
                };
            });

            app.MapGet("/collections/posts/{collectionId}", (BugSpotterBEDbContext db, int collectionId) =>
            {
                var postsByCollectionId = db.Posts.Include(p => p.Tags).Where(p => p.CollectionId == collectionId).Select(p => new
                {
                    p.Id,
                    p.UserId,
                    p.CollectionId,
                    p.Image,
                    p.Latitude,
                    p.Longitude,
                    p.Description,
                    p.Favorite,
                    Tags = p.Tags.Select(t => new
                    {
                        t.Id,
                        t.TagType
                    })
                }).ToList();
                if (!postsByCollectionId.Any())
                {
                    return Results.NotFound("There are no posts in this collection");
                }
                else
                {
                    return Results.Ok(postsByCollectionId);
                }
            });
        }
    }
}


