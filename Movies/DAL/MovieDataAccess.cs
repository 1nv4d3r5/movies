using Movies.Models;
using Movies.Repository;
using Movies.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.DAL
{
    public class MovieDataAccess
    {
        private IXmlUnitOfWork _unitOfWork;
        private IMovieRepository _repository;

        public MovieDataAccess()
        {
            #region MovieDataAccess

            this._unitOfWork = UnitOfWorkFactory.CreateUnitOfWork<Movie>();
            this._repository = RepositoryFactory.CreateRepository<IMovieRepository, MovieRepository>(this._unitOfWork);

            #endregion
        }

        public IEnumerable<Movie> GetAll()
        {
            #region GetAll

            return _repository.GetAll();

            #endregion
        }

        public Movie GetByID(long ID)
        {
            #region GetByID

            return _repository.GetByKey(ID);

            #endregion
        }

        public long GetNextMovieID()
        {
            #region GetNextMovieID

            IEnumerable<Movie> movies = this.GetAll();
            long nextID = movies.Count() == 0 ? 1 : movies.Max(m => m.MovieID) + 1;

            return nextID;

            #endregion
        }

        public void Add(Movie movie)
        {
            #region Add

            try
            {
                _repository.Create(movie);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            #endregion
        }

        public void Update(Movie movie)
        {
            #region Update

            try
            {
                _repository.Update(movie);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            #endregion
        }

        public void Delete(long ID)
        {
            #region Delete

            try
            {
                Movie movieToDelete = _repository.GetByKey(ID);
                if (movieToDelete == null)
                    throw new ArgumentNullException("Not found");

                _repository.Delete(movieToDelete);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            #endregion
        }
    }
}