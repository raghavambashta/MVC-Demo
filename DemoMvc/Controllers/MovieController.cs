using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoMvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMvc.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Info()
        {
            Movie movie = new Movie { Id = 1, Name = "war", Year = 2019, Rating = 4 };
            return View(movie);
        }
        public IActionResult Search()
        {
            return View();
        }
        public IActionResult List()
        {
            List<Movie> movies = GetMovies();
            return View(movies);
        }
        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie { Id = 1, Name ="war", Year=2019, Rating=4},
                new Movie { Id = 2, Name ="aaa", Year=2022, Rating=4},
                new Movie { Id = 3, Name ="bbb", Year=2021, Rating=2},
                new Movie { Id = 4, Name ="ccc", Year=2019, Rating=1},
                new Movie { Id = 5, Name ="ddd", Year=2020, Rating=3},
                new Movie { Id = 6, Name ="fff", Year=2019, Rating=4},
                new Movie { Id = 7, Name ="ggg", Year=2019, Rating=4},
                new Movie { Id = 2, Name ="aaa", Year=2022, Rating=4},
                new Movie { Id = 3, Name ="bbb", Year=2021, Rating=5},
                new Movie { Id = 4, Name ="ccc", Year=2019, Rating=5},
                new Movie { Id = 5, Name ="ddd", Year=2020, Rating=5},
                new Movie { Id = 6, Name ="fff", Year=2019, Rating=5},
                new Movie { Id = 7, Name ="ggg", Year=2019, Rating=2},
            };
            return movies;
        }
        public IActionResult Find(int id)
        {
            List<Movie> movies = GetMovies();
            Movie data = movies.Where(m => m.Id == id).FirstOrDefault();
            return View("Info", data);
        }
        [HttpGet]
        public IActionResult FindByRating()
        {
            List<int> ratinglist = new List<int> { 1, 2, 3, 4, 5 };
            ViewBag.rating = new SelectList(ratinglist);
            return View();
        }
        [HttpPost]
        public IActionResult FindByRating(int rating)
        {
            List<Movie> movies = GetMovies();
            var data = movies.Where((m) => m.Rating == rating);
            ViewBag.MovieList = data;
            List<int> ratinglist = new List<int> { 1, 2, 3, 4, 5};
            ViewBag.rating = new SelectList(ratinglist);
            return View();
        }
    }
}