using AutoMapper;
using FitBody.Common.Contracts;
using FitBody.DataBase;
using FitBody.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitBody.Services
{
    public interface IPostService : IBaseDataService<Post, PostDto, PostInsertModel>
    {
        bool Like(int postId, int userId);
        bool Save(int postId, int userId);
        void Update(PostUpdateModel model);
        IList<PostDto> Get(PostSearchRequest search);
        IList<PostLikesDto> GetLikedPosts(int? userId);
        IList<PostDto> GetLikedPostsByUser(int userId);
        IList<PostDto> GetSavedPostsByUser(int userId);
        IList<PostDto> GetPostsByFollowingUsers(int userId);
        IList<PostDto> GetRecommendedPosts(int userId);
        IList<PostReportDto> GetMostLikedPosts();
    }

    public class PostService : BaseDataService<Post, PostDto, PostInsertModel>, IPostService
    {
        public PostService(FitBodyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<PostDto> Get()
        {
            return _mapper.Map<IList<PostDto>>(_table
                .Include(x => x.User)
                .Include(x => x.Subcategory)
                .ThenInclude(x => x.Category)
                .AsNoTracking().ToList());
        }

        public override PostDto Get(int id)
        {
            return _mapper.Map<PostDto>(_context.Posts
                .Include(x => x.Subcategory)
                .ThenInclude(x => x.Category)
                .Include(x => x.User)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id));
        }

        public override PostDto Insert(PostInsertModel obj)
        {
            obj.Tags = obj.Tags.Distinct().ToList();

            var post = _mapper.Map<Post>(obj);
            post.DateCreated = DateTime.UtcNow;
            _context.Posts.Add(post);

            var tags = _context.Tags.ToList();
            foreach (var item in obj.Tags)
            {
                var tag = tags.FirstOrDefault(x => x.Title == item);

                if (tag == null)
                {
                    tag = new Tag
                    {
                        Title = item
                    };
                    _context.Tags.Add(tag);
                }

                _context.PostTags.Add(new PostTag
                {
                    Post = post,
                    Tag = tag
                });
            }

            _context.SaveChanges();

            post = _context.Posts
                .Include(x => x.Subcategory)
                .ThenInclude(x => x.Category)
                .Include(x => x.User)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == post.Id);

            return _mapper.Map<PostDto>(post);
        }

        public void Update(PostUpdateModel model)
        {
            var tags = _context.Tags.ToList();

            var post = _context.Posts.FirstOrDefault(a => a.Id == model.Id);
            var postTags = _context.PostTags.Where(a => a.PostId == model.Id).ToList();
            if (post != null)
            {
                post.Title = model.Title;
                post.SubcategoryId = model.SubcategoryId;
                post.Content = model.Content;
                post.DateModified = DateTime.UtcNow;

                foreach (var item in model.Tags)
                {
                    var tag = tags.FirstOrDefault(x => x.Title == item);

                    if (tag == null)
                    {
                        _context.Tags.Add(tag);
                    }

                    if (!postTags.Any(a => a.TagId == tag.Id))
                    {
                        _context.PostTags.Add(new PostTag { PostId = model.Id, TagId = tag.Id });
                    }
                }
                _context.Update(post);
                _context.SaveChanges();
            }
        }

        public bool Like(int postId, int userId)
        {
            var newPostLike = new PostLiked
            {
                PostId = postId,
                UserId = userId
            };

            var exists = _context.LikedPosts.FirstOrDefault(x => x.UserId == userId && x.PostId == postId);
            if (exists != null)
            {
                _context.Remove(exists);
                _context.SaveChanges();
                return false; // false = not liked anymore
            }
            else
            {
                _context.Add(newPostLike);
                _context.SaveChanges();
                return true; // true = liked now
            }
        }

        public bool Save(int postId, int userId)
        {
            var newPostSave = new PostSaved
            {
                PostId = postId,
                UserId = userId
            };

            var exists = _context.SavedPosts.FirstOrDefault(x => x.UserId == userId && x.PostId == postId);
            if (exists != null)
            {
                _context.Remove(exists);
                _context.SaveChanges();
                return false; // false = not saved anymore
            }
            else
            {
                _context.Add(newPostSave);
                _context.SaveChanges();
                return true; // true = save now
            }
        }

        public IList<PostDto> Get(PostSearchRequest search)
        {
            var query = _context.Posts.Include(a => a.Subcategory)
                .ThenInclude(a => a.Category)
                .Include(a => a.User)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Title))
            {
                query = query.Where(x => x.Title.Contains(search.Title));
            }

            if (search.CategoryId != null && search.CategoryId != 0)
            {
                query = query.Where(x => x.Subcategory.CategoryId == search.CategoryId);
            }

            if (search.SubcategoryId != null && search.SubcategoryId != 0) // search.SubcategoryId.HasValue
            {
                query = query.Where(x => x.SubcategoryId == search.SubcategoryId);
            }

            var entities = query.ToList();

            var result = _mapper.Map<IList<PostDto>>(entities.Where(x => 1 == 1));


            return result;
        }

        public IList<PostLikesDto> GetLikedPosts(int? userId)
        {
            var list = _context.Posts.Where(x => 1 == 1);

            if (userId.HasValue)
            {
                list = list.Where(a => a.UserId == userId);
            }

            var postLikes = new List<PostLikesDto>();

            foreach (var item in list.ToList())
            {
                var likes = _context.LikedPosts.Where(s => s.PostId == item.Id).Count();
                postLikes.Add(new PostLikesDto
                {
                    Likes = likes,
                    PostId = item.Id,
                    Title = item.Title
                });
            }

            return postLikes.OrderByDescending(x => x.Likes).ToList();
        }

        public IList<PostDto> GetSavedPostsByUser(int userId)
        {
            var list = _context.SavedPosts.Where(x => x.UserId == userId).Select(x => x.Post).ToList();

            return _mapper.Map<IList<PostDto>>(list);
        }

        public IList<PostDto> GetLikedPostsByUser(int userId)
        {
            var list = _context.LikedPosts.Where(x => x.UserId == userId).Select(x => x.Post).ToList();

            return _mapper.Map<IList<PostDto>>(list);
        }

        public IList<PostDto> GetPostsByFollowingUsers(int userId)
        {
            var following = _context.UsersFollows.Where(a => a.UserFollowingId == userId).Select(a => a.UserFollowedId).ToList();

            //x.UserId == userId
            var list = _context.Posts.Where(x => following.Any(y => y == x.UserId)).ToList();

            return _mapper.Map<IList<PostDto>>(list);
        }

        public IList<PostReportDto> GetMostLikedPosts()
        {
            var list = _context.Posts
                .Include(a => a.User)
                .Include(a => a.Subcategory)
                .ThenInclude(a => a.Category)
                .ToList();
            var postLikes = new List<PostReportDto>();

            foreach (var item in list)
            {
                var likes = _context.LikedPosts.Where(s => s.PostId == item.Id).Count();
                postLikes.Add(new PostReportDto
                {
                    Likes = likes,
                    Id = item.Id,
                    Title = item.Title,
                    CategoryId = item.Subcategory.CategoryId,
                    Categoryname = item.Subcategory.Category.Title,
                    Content = item.Content,
                    DateCreated = item.DateCreated,
                    DateModified = item.DateModified,
                    SubcategoryId = item.SubcategoryId,
                    Subcategoryname = item.Subcategory.Title,
                    UserId = item.UserId,
                    Username = item.User.UserName
                });
            }

            return postLikes.OrderByDescending(x => x.Likes).ToList();
        }

        public IList<PostDto> GetRecommendedPosts(int userId)
        {
            var listLiked = _context.LikedPosts.Where(a => a.UserId == userId).ToList();

            if (!listLiked.Any())
                return _mapper.Map<IList<PostDto>>(_context.Posts
                    .Include(x => x.User)
                    .Include(x => x.Subcategory)
                    .ThenInclude(x => x.Category)
                    .Take(5)
                    .ToList());

            List<int> listTags = new List<int>();
            foreach (var item in listLiked)
            {
                var list = _context.PostTags.Where(a => a.PostId == item.PostId).Select(a => a.TagId).ToList();
                listTags.AddRange(list);
            }
            listTags = listTags.Distinct().ToList();

            var listPostTags = _context.PostTags
                .Where(a => listTags.Any(y => y == a.TagId))
                .Select(x => x.PostId)
                .Distinct()
                .ToList();

            var postlikesIds = GetLikedPosts(null)
                .Where(x => listPostTags.Any(l => l == x.PostId))
                .Select(x => x.PostId)
                .ToList();

            var posts = _context.Posts
                .Where(x => postlikesIds.Any(y => y == x.Id))
                .Include(x => x.User)
                .Include(x => x.Subcategory)
                .ThenInclude(x => x.Category)
                .ToList();

            if (!posts.Any())
                return _mapper.Map<IList<PostDto>>(_context.Posts
                    .Include(x => x.User)
                    .Include(x => x.Subcategory)
                    .ThenInclude(x => x.Category)
                    .Take(5)
                    .ToList());

            return _mapper.Map<IList<PostDto>>(posts.Take(5));
        }

    }
}
