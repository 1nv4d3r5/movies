using Movies.DAL;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movies.Controllers
{
    public class MoviesController : ApiController
    {
        private MovieDataAccess _movieDataAccess;
        
        public MoviesController()
        {
            #region MoviesController

            this._movieDataAccess = new MovieDataAccess();

            #endregion
        }

        // GET: api/Movies
        public IEnumerable<Movie> Get()
        {
            #region Get

            return this._movieDataAccess.GetAll();

            #endregion
        }

        // GET: api/Movies/5
        public Movie Get(long ID)
        {
            #region Get

            return _movieDataAccess.GetByID(ID);

            #endregion
        }

        // POST: api/Movies
        public IHttpActionResult Post([FromBody]Movie movie)
        {
            #region Post

            if(ModelState.IsValid)
            {
                movie.CreatedDate = DateTime.Now;
                movie.MovieID = _movieDataAccess.GetNextMovieID();
                _movieDataAccess.Add(movie);
            }
            return StatusCode(HttpStatusCode.Created);
            
            #endregion
        }

        // PUT: api/Movies/
        public IHttpActionResult Put([FromBody]Movie movie)
        {
            #region Put

            if(ModelState.IsValid)
            {
                _movieDataAccess.Update(movie);
            }
            return StatusCode(HttpStatusCode.OK);

            #endregion
        }

        // DELETE: api/Movies/5
        public IHttpActionResult Delete(long ID)
        {
            #region Delete

            _movieDataAccess.Delete(ID);
            return StatusCode(HttpStatusCode.OK);

            #endregion
        }
    }
}
