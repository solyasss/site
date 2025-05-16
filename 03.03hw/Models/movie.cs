using System.ComponentModel.DataAnnotations;
namespace _03._03hw.Models;

public class movie
{
   
        public int id { get; set; }

        [Required]
        public string title { get; set; }
        public string director { get; set; }
        public string genre { get; set; }
        public int year { get; set; }
        public string poster { get; set; }
        public string description { get; set; }
    }
