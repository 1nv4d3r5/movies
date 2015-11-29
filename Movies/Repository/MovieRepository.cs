using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Movies.Repository
{
    public class MovieRepository : XmlRepository<Movie, long>, IMovieRepository
    {
        public MovieRepository(XDocument document)
            : base(document)
        {

        }
    }
}