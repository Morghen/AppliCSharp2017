﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVideoDTOLibrary
{
    public class HitDTO
    {
        private int id;
        private TypeEnum type;
        private DateTime date;
        private int hit;

        public int Id { get => id; set => id = value; }
        public TypeEnum Type { get => type; set => type = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Hit { get => hit; set => hit = value; }

        public HitDTO(int id, TypeEnum type, DateTime date, int hit)
        {
            Id = id;
            Type = type;
            Date = date;
            Hit = hit;
        }

        public HitDTO(int id, string type, DateTime date, int hit)
        {
            Id = id;
            Type = (TypeEnum) Enum.Parse(typeof(TypeEnum),type);
            Date = date;
            Hit = hit;
        }

        public override string ToString()
        {
            return ""+Id+" "+Type+" "+Date+" "+Hit;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}