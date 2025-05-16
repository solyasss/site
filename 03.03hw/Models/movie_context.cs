using Microsoft.EntityFrameworkCore;
namespace _03._03hw.Models;

public class movie_context : DbContext
    {
        public movie_context(DbContextOptions<movie_context> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                movies.AddRange(
                    new movie
                    {
                        title = "Legally Blonde",
                        director = "Robert Luketic",
                        genre = "Comedy",
                        year = 2001,
                        poster = "/images/legally_blonde.jpg",
                        description = "Elle Woods proves that pink power and a positive attitude can conquer all."
                    },
                    new movie
                    {
                        title = "Enchanted",
                        director = "Kevin Lima",
                        genre = "Fantasy",
                        year = 2007,
                        poster = "/images/enchanted.jpg",
                        description = "A fairytale princess is thrust into modern-day New York City in this charming story."
                    },
                    new movie
                    {
                        title = "The Princess Diaries",
                        director = "Garry Marshall",
                        genre = "Comedy",
                        year = 2001,
                        poster = "/images/princess_diaries.jpg",
                        description = "A clumsy teenager discovers she is the heir to the throne of Genovia."
                    },
                    new movie
                    {
                        title = "Mean Girls",
                        director = "Mark Waters",
                        genre = "Comedy",
                        year = 2004,
                        poster = "/images/mean_girls.jpg",
                        description = "Cady navigates the tough social circles of high school. Hilarious and pink vibes."
                    },
                    new movie
                    {
                        title = "Clueless",
                        director = "Amy Heckerling",
                        genre = "Comedy",
                        year = 1995,
                        poster = "/images/clueless.jpg",
                        description = "Cher is popular and stylish, but learns there's more to life than a flawless wardrobe."
                    },
                    new movie
                    {
                        title = "Pitch Perfect",
                        director = "Jason Moore",
                        genre = "Comedy/Musical",
                        year = 2012,
                        poster = "/images/pitch_perfect.jpg",
                        description = "Collegiate a cappella groups battle it out with music and wit."
                    },
                    new movie
                    {
                        title = "A Cinderella Story",
                        director = "Mark Rosman",
                        genre = "Romance/Comedy",
                        year = 2004,
                        poster = "/images/cinderella_story.jpg",
                        description = "Modern retelling of the Cinderella tale with texting and secret identities."
                    },
                    new movie
                    {
                        title = "Bridget Jones's Diary",
                        director = "Sharon Maguire",
                        genre = "Romantic Comedy",
                        year = 2001,
                        poster = "/images/bridget_jones.jpg",
                        description = "Bridget chronicles her life struggles with humor, romance, and personal growth."
                    },
                    new movie
                    {
                        title = "Confessions of a Shopaholic",
                        director = "P.J. Hogan",
                        genre = "Romantic Comedy",
                        year = 2009,
                        poster = "/images/shopaholic.jpg",
                        description = "Rebecca Bloomwood’s love of shopping leads to comedic mishaps and romance."
                    },
                    new movie
                    {
                        title = "13 Going on 30",
                        director = "Gary Winick",
                        genre = "Romantic Comedy",
                        year = 2004,
                        poster = "/images/13_going_on_30.jpg",
                        description = "A 13-year-old magically becomes 30 overnight. Whimsical and heartwarming."
                    }
                );
                SaveChanges();
            }
        }

        public DbSet<movie> movies { get; set; }
    }

