﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDTO
{
    public class GenreDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public GenreDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public GenreDTO()
        {
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override bool Equals(object obj)
        {
            var dTO = obj as GenreDTO;
            return dTO != null &&
                   Id == dTO.Id;
        }
    }
}
