using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Models.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public PostViewModel(string title, string description, string link)
        {
            Title = title;
            Description = description;
            Link = link;
        }

        public PostViewModel()
        {

        }
    }
}
