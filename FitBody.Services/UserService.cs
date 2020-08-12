using AutoMapper;
using FitBody.Common.Configuration;
using FitBody.Common.Contracts;
using FitBody.Common.Requests;
using FitBody.DataBase;
using FitBody.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Services.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FitBody.Services
{
    public interface IUserService
    {
        IList<UserDto> Get(UserSearchRequest search);
        UserDto Get(int id);
        UserDto Insert(UserInsertRequest user);
        UserDto Update(int id, UserUpdateRequest user);
        AuthenticatedUser Login(UserLoginRequest user);
        bool Follow(int postId, int userId);
        void ChangeStatus(int id);
        void ChangePermission(int id);
        List<UserFollowDto> GetFollowers(int UserId);
        IList<UserReportDto> GetMostFollowed();

    }

    public class UserService : IUserService
    {
        protected readonly FitBodyContext _context;
        private readonly IMapper _mapper;
        private readonly IOptions<AppSettings> _options;

        public UserService(FitBodyContext context, IMapper mapper, IOptions<AppSettings> options)
        {
            _context = context;
            _mapper = mapper;
            _options = options;
        }

        public UserDto Get(int id)
        {
            var entity = _context.Users.FirstOrDefault(x => x.Id == id);

            return _mapper.Map<UserDto>(entity);
        }

        public IList<UserDto> Get(UserSearchRequest search)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.FirstName))
            {
                query = query.Where(x => x.FirstName == search.FirstName);
            }

            if (!string.IsNullOrWhiteSpace(search?.LastName))
            {
                query = query.Where(x => x.LastName == search.LastName);
            }

            if (!string.IsNullOrWhiteSpace(search?.UserName))
            {
                query = query.Where(x => x.UserName.Contains(search.UserName));
            }

            if (!string.IsNullOrWhiteSpace(search?.Email))
            {
                query = query.Where(x => x.Email == search.Email);
            }

            var entities = query.ToList();

            var result = _mapper.Map<IList<UserDto>>(entities.Where(x => 1 == 1));


            return result;
        }

        public UserDto Insert(UserInsertRequest request)
        {
            var entity = _mapper.Map<Models.User>(request);
            _context.Add(entity);

            if (request.Password != request.ConfirmPassword)
            {
                throw new Exception("Password and confirm password do not match");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            _context.SaveChanges();

            return _mapper.Map<UserDto>(entity);
        }

        public UserDto Update(int id, UserUpdateRequest request)
        {
            var entity = _context.Users.Find(id);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<UserDto>(entity);
        }

        public AuthenticatedUser Login(UserLoginRequest request)
        {
            var entity = _context.Users.FirstOrDefault(x => x.UserName == request.UserName);

            #region User existence check
            if (entity == null)
            {
                throw new UserException("Wrong username or password");
            }

            var hash = GenerateHash(entity.PasswordSalt, request.Password);

            if (hash != entity.PasswordHash)
            {
                throw new UserException("Wrong username or password");
            }
            #endregion

            #region Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString()),
                    new Claim(ClaimTypes.Name, entity.UserName),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            #endregion

            var user = _mapper.Map<AuthenticatedUser>(entity);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }

        public bool Follow(int userfollowingId, int userfollowedId)
        {
            var newUserFollow = new UserFollow
            {
                UserFollowedId = userfollowedId,
                UserFollowingId = userfollowingId
            };

            var exists = _context.UsersFollows.FirstOrDefault(x => x.UserFollowingId == userfollowingId && x.UserFollowedId == userfollowedId);
            if (exists != null)
            {
                _context.Remove(exists);
                _context.SaveChanges();
                return false;
            }
            else
            {
                _context.Add(newUserFollow);
                _context.SaveChanges();
                return true; 
            }
        }

        public void ChangeStatus(int id)
        {
            var user = _context.Users.FirstOrDefault(a => a.Id == id);
            if (user != null)
            {
                user.Active = !user.Active;
                _context.SaveChanges();
            }
        }


        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public void ChangePermission(int id)
        {
            var user = _context.Users.FirstOrDefault(a => a.Id == id);
            if (user != null)
            {
                user.Permission = 1;
                _context.SaveChanges();
            }
        }
        public List<UserFollowDto> GetFollowers(int UserId)
        {
            var list = _context.UsersFollows.Where(a => a.UserFollowedId == UserId).Select(s=>s.UserFollowing).ToList();
            return _mapper.Map<List<UserFollowDto>>(list);
        }
        public IList<UserReportDto> GetMostFollowed()
        {
            var list = _context.Users.ToList();
            var userList = new List<UserReportDto>();

            foreach (var item in list)
            {
                var followers = _context.UsersFollows.Where(a => a.UserFollowedId == item.Id).Count();
                userList.Add(new UserReportDto {
                    Active = item.Active,
                    BirthDate = item.BirthDate,
                    Email = item.Email,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Followers = followers,
                    Gender = item.Gender,
                    Height = item.Height,
                    Id = item.Id,
                    Image = item.Image,
                    Info = item.Info,
                    Mobile = item.Mobile,
                    Permission = item.Permission,
                    UserName = item.UserName,
                    Weight = item.Weight
                });
            }
            return userList.OrderByDescending(a => a.Followers).ToList();
        }
    }
}
