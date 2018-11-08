﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Netflix.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GenreDto Genre { get; set; }
        public byte GenreId { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte NumberInStock { get; set; }
    }
}