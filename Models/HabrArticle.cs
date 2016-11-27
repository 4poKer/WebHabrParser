﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace WebHabrParser.Models
{
    public class HabrArticle
    {
       
        public ObjectId Id { get; set; }

        public int HabrId { get; set; }
 
        public string Theme { get; set; }

        public string Title { get; set; }

        public List<string> Tags { get; set; }

        public string PublicationDate { get; set; }
    }
}