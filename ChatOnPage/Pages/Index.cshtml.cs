using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ChatOnPage.Data;
using ChatOnPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ChatOnPage.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public List<Message> Messages { set; get; }
        [BindProperty]
        [Required]
        public string Text { set; get; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Messages = _db.Messages.ToList();
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Messages.Add(new Message(Text, DateTime.Now, User.Identity.Name));
                _db.SaveChanges();
            }
            Messages = _db.Messages.ToList();
        }
    }
}
