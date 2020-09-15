using FitBody.DataBase;
using FitBody.Models;
using FitBody.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitBody.Api
{
    public static class DatabaseInitializer
    {
        public static void Initialize(FitBodyContext context)
        {
            context.Database.Migrate();

            if (context.Users.Any()) // Database is not empty, don't add on top of existing data
                return;

            var categories = new List<Category>
            {
                new Category
                {
                    Title = "Prehrana"
                },
                new Category
                {
                    Title = "Vjezbe"
                },
                new Category
                {
                    Title = "Sport"
                },
                new Category
                {
                    Title = "Zdravlje"
                },
                new Category
                {
                    Title = "Mrsavljenje"
                },
                new Category
                {
                    Title = "Lifestyle"
                }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            var subcategories = new List<Subcategory>
            {
                new Subcategory
                {
                    Title = "Nutricionizam",
                    Category = categories.ElementAt(0)
                },
                new Subcategory
                {
                    Title = "Dijete i jelovnici",
                    Category = categories.ElementAt(0)
                },
                new Subcategory
                {
                    Title = "Dodaci prehrani",
                    Category = categories.ElementAt(0)
                },
                new Subcategory
                {
                    Title = "Recepti",
                    Category = categories.ElementAt(0)
                },
                new Subcategory
                {
                    Title = "Fitness discipline",
                    Category = categories.ElementAt(1)
                },
                new Subcategory
                {
                    Title = "Popis fitness centara",
                    Category = categories.ElementAt(1)
                },
                new Subcategory
                {
                    Title = "Savjeti za vjezbanje",
                    Category = categories.ElementAt(1)
                },
                new Subcategory
                {
                    Title = "Opisi vjezbi",
                    Category = categories.ElementAt(1)
                },
                new Subcategory
                {
                    Title = "Programi treninga",
                    Category = categories.ElementAt(1)
                },
                new Subcategory
                {
                    Title = "Video",
                    Category = categories.ElementAt(1)
                },
                new Subcategory
                {
                    Title = "Indoor sportovi",
                    Category = categories.ElementAt(2)
                },
                new Subcategory
                {
                    Title = "Outdoor sportovi",
                    Category = categories.ElementAt(2)
                },
                new Subcategory
                {
                    Title = "Ozljede i bolesti",
                    Category = categories.ElementAt(3)
                },
                new Subcategory
                {
                    Title = "Um i tijelo",
                    Category = categories.ElementAt(3)
                },
                new Subcategory
                {
                    Title = "Savjeti",
                    Category = categories.ElementAt(4)
                },
                new Subcategory
                {
                    Title = "Ljepota",
                    Category = categories.ElementAt(5)
                },
                new Subcategory
                {
                    Title = "Slobodno vrijeme",
                    Category = categories.ElementAt(5)
                },
                new Subcategory
                {
                    Title = "Kako to rade poznati",
                    Category = categories.ElementAt(5)
                },
                new Subcategory
                {
                    Title = "Sportska moda",
                    Category = categories.ElementAt(5)
                },
                new Subcategory
                {
                    Title = "Intervjui",
                    Category = categories.ElementAt(5)
                },
            };
            context.SubCategories.AddRange(subcategories);
            context.SaveChanges();

            var tags = new List<Tag>
            {
                new Tag
                {
                    Title = "hrana"
                },
                new Tag
                {
                    Title = "sport"
                },
                new Tag
                {
                    Title = "zdravlje"
                },
                new Tag
                {
                    Title = "moda"
                },
                new Tag
                {
                    Title = "sunce"
                },
                new Tag
                {
                    Title = "vitamini"
                },
                new Tag
                {
                    Title = "omega-3"
                },
                new Tag
                {
                    Title = "kolagen"
                },
                new Tag
                {
                    Title = "proteini"
                },
                new Tag
                {
                    Title = "whey"
                },
                new Tag
                {
                    Title = "oprema"
                },
            };
            context.Tags.AddRange(tags);
            context.SaveChanges();

            #region Users
            var adminSalt = UserService.GenerateSalt();
            var admin = new User
            {
                BirthDate = new DateTime(1997, 5, 13),
                Email = "emina@edu.fit.ba",
                FirstName = "Emina",
                LastName = "Mesic",
                Image = "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",
                Permission = 2, // Administrator
                Height = 1.69f,
                Weight = 62.0f,
                Info = "I am a super user",
                Mobile = "+38673265312",
                UserName = "desktop",
                PasswordSalt = adminSalt,
                PasswordHash = UserService.GenerateHash(adminSalt, "test"),
                Active = true,
                Gender = "Female",
            };
            context.Users.Add(admin);


            var bloggerSalt = UserService.GenerateSalt();
            var blogger = new User
            {
                BirthDate = new DateTime(1997, 4, 17),
                Email = "blogger@com.test",
                FirstName = "blogger",
                LastName = "blogger",
                Image = "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",
                Permission = 1, // Trainer 
                Height = 1.75f,
                Weight = 65.0f,
                Info = "I am a trainer",
                Mobile = "+38673265313",
                UserName = "blogger",
                PasswordSalt = bloggerSalt,
                PasswordHash = UserService.GenerateHash(bloggerSalt, "test"),
                Active = true,
                Gender = "Male"
            };
            context.Users.Add(blogger);


            var userSalt = UserService.GenerateSalt();
            var user = new User
            {
                BirthDate = new DateTime(1997, 8, 1),
                Email = "user@test.com",
                FirstName = "user",
                LastName = "user",
                Image = "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",
                Permission = 0, // User
                Height = 1.83f,
                Weight = 98.0f,
                Info = "",
                Mobile = "+38673265314",
                UserName = "mobile",
                PasswordSalt = userSalt,
                PasswordHash = UserService.GenerateHash(userSalt, "test"),
                Active = true,
                Gender = "Male"
            };
            context.Users.Add(user);
            context.SaveChanges();
            #endregion

            #region User followings
            context.UsersFollows.Add(new UserFollow
            {
                UserFollowed = admin,
                UserFollowing = user
            });
            context.UsersFollows.Add(new UserFollow
            {
                UserFollowed = blogger,
                UserFollowing = user
            });
            context.SaveChanges();
            #endregion

            var post = new Post
            {
                Title = "Kako fizička aktivnost poboljšava ukupno zdravlje i štiti od bolesti?",
                User = blogger,
                DateCreated = DateTime.UtcNow,
                SubcategoryId = 14,
                Content = @"Redovna fizička aktivnost, uz primjerenu prehranu i kvalitetan san, preduvjeti su za održavanje zdravlja u ljudi svih dobnih skupina. Studije potvrđuju da bez obzira na dob, spol, zdravstveno stanje ili neki drugi faktor, fizička aktivnost donosi niz zdravstvenih prednosti, od održavanja zdravlja do ubrzavanja oporavka ili poboljšanja stanja kod bolesnih osoba.

Također, potvrđeno je da redovna fizička aktivnost smanjuje stopu smrtnosti od niza kroničnih bolesti, poput kardiovaskularnih bolesti, visokog krvnog tlaka, dijabetesa i karcinoma debelog crijeva.

Unatoč poznatim i stalno isticanim prednostima fizičke aktivnosti, većina odraslih osoba, a i sve veći broj djece, živi većinom sjedilačkim načinom života te nisu dovoljno aktivni da bi iskoristili zdravstvene prednosti fizičke aktivnosti kojom se bave. Pretežno sjedilačkim načinom života se definira onaj način života u kojem se u roku od 14 dana ne provodi nijedna vrsta fizičke aktivnosti, poput nekog sporta ili vježbanja

Provođenje redovite fizičke aktivnosti, minimalno 30 minuta umjerene fizičke aktivnosti najmanje 5 puta tjedno, ili 20 minuta intenzivnije fizičke aktivnosti najmanje 3 puta tjedno, ključno je za održavanje dobroga zdravlja. Naime, redovna fizička aktivnost ima pozitivne učinke na cjelokupno zdravlje, ali i na sve organe pojedinačno te, posljedično, pomaže u prevenciji niza zdravstvenih problema i bolesti.

Redovna fizička aktivnost smanjuje rizik od razvoja i smrti od nekih od glavnih uzročnika smrtnosti u svijetu. Redovna fizička aktivnost poboljšava zdravlje na više razina:

- smanjuje rizik od prerane smrti od srčanih bolesti i drugih stanja povezanih s ovim bolestima
- smanjuje opasnost od razvoja dijabetesa
- smanjuje opasnost od razvoja povišenog srčanog tlaka
- smanjuje krvni tlak kod osoba koje boluju od povišenog krvnog tlaka
- smanjuje opasnost od razvoja karcinoma debelog crijeva i dojke
- pomaže u održavanju tjelesne težine
- pomaže u izgradnji i održavanju zdravih kostiju, mišića i zglobno-tetivnog tkiva
- pomaže starijim osobama da se lakše kreću te smanjuje opasnost od padova i lomova
- smanjuje osjećaje depresije i tjeskobe
- pomaže psihološkom zdravlju"
            };
            context.Posts.Add(post);
            context.SaveChanges();

            var postTags = new List<PostTag>()
            {
                new PostTag {
                    Post=post,
                    TagId=1
                },
                new PostTag {
                    Post=post,
                    TagId=3
                },
            };
            context.PostTags.AddRange(postTags);
            context.SaveChanges();

            var thread = new Thread
            {
                 Title = "Thread title",
                 DateCreated = DateTime.UtcNow,
                 User = user,
                 Content = "Hello, I am new here."
            };
            context.Threads.Add(thread);
            context.SaveChanges();

            var comment = new Comment
            {
                User = blogger,
                DatePosted = DateTime.UtcNow,
                Content = "Hello user, hope you find the info you need here"
            };
            context.Comments.Add(comment);

            var commentThread = new ThreadComment
            {
                Thread = thread,
                Comment = comment
            };
            context.ThreadComments.Add(commentThread);
            context.SaveChanges();
        }
    }
}
