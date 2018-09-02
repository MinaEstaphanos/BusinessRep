using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Yelp.Api.Models;

namespace BusinessRep.ViewModels
{
    public class BusinessSearchViewModel
    {
        [Required]
        public string BusinessName { get; set; }

        [Required]
        public string BusinessLocation  { get; set; }

        public IList<BusinessResponse> YelpBusinesses { get; set; }
    }
}