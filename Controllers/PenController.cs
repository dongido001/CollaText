
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollaText.Models;
using System.Net;
using PusherServer;

namespace CollaText.Controllers
{
    public class PenController : Controller
    {
        private readonly CollaTextPenContext _context;
        public PenController(CollaTextPenContext context)
        {
            _context = context;
        }
        // GET: Pen
        public async Task<IActionResult> Index(int? id)
        {
            ViewData["Pen"] = _context.Pens.SingleOrDefault(d => d.ID == id);
            return View(await _context.Pens.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title")] Pen pen, string sessionID)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pen);
                await _context.SaveChangesAsync();

                await Trigger(new {Title = pen.Title, penId = pen.ID, sessionID = sessionID}, "coll-text-editor", "newPen");

                return RedirectToAction(nameof(Index));
            }
            return View(pen);
        }

        public async Task<IActionResult> Trigger(object data, string channelName, string eventName)
        {
            var options = new PusherOptions
            {
              Cluster = "eu", // <PUSHER_APP_CLUSTER>
              Encrypted = true
            };
                    
            var pusher = new Pusher(
                "<PUSHER_APP_ID>", 
                "<PUSHER_APP_KEY>", 
                "<PUSHER_APP_SECRET>", 
                options
            );
                
            var result = await pusher.TriggerAsync(
                channelName,
                eventName,
                data
            );
                    
            return new OkObjectResult(data);
        }


        [HttpPost]
        public async Task<IActionResult> ContentChange(int penId, string Content, string sessionID)
        {
            await Trigger(new {Content = Content, penId = penId, sessionID = sessionID}, "coll-text-editor", "contentChange");
            
            var pen = await _context.Pens.SingleOrDefaultAsync(m => m.ID == penId);
            if( pen != null) {
                pen.Content = Content;
                _context.SaveChanges();
            }
            return new OkObjectResult(new { content = Content, penId = penId, sessionID = sessionID });
        }

    }
}