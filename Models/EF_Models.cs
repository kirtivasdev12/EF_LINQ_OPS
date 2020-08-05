using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EF_LINQ_OPS.Models
{
    public class Reviewer // Hold reviewer details
    {
        [Key]
        public int reviewer_id { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public int city { get; set; }
        public string state { get; set; }

        public int num_review { get; set; }
        public List<Review> Review { get; set; }
    }

    public class Review // Holds review type and ratings
    {
        [Key]
        public int review_id { get; set; }
        public int reviewer_id { get; set; }
        public string review_Details { get; set; }
        public int review_rating { get; set; }
        public int item_id { get; set; }
    }

    public class Items_reviewed //Holds Item Details
    {
        [Key]
        public int item_id { get; set; } //Each cuisine will have Unique ID
        public int type_code { get; set; }
        public string item_Name { get; set; } //cuisines 

        public string item_desc { get; set; } //type of dish
        
    }

    public class ref_item_type
    {
        [Key]
        public int item_code { get; set; }
        public string item_desc { get; set; } 
    }

    
}
