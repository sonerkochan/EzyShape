using EzyShape.Infrastructure.Data.Models;
using EzyShape.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using EzyShape.Core.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using EzyShape.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace EzyShape.Controllers
{
    [Authorize(Roles = "Trainer,Client")]
    public class ChatController : Controller
    {
        private readonly IRepository repo;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public ChatController(
            IRepository _repo,
            UserManager<User> _userManager,
            RoleManager<IdentityRole> _roleManager)
        {
            repo = _repo;
            userManager = _userManager;
            roleManager = _roleManager;
        }


        [Route("/messages")]
        [HttpGet]
        public async Task<IActionResult> Index(string receiverId = null)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (User.IsInRole("Trainer"))
            {
                // Load all clients of this trainer
                var clients = repo.All<User>()
                    .Where(u => u.TrainerId == currentUserId)
                    .Select(u => new
                    {
                        Id = u.Id,
                        Name = u.FirstName + " " + u.LastName
                    })
                    .ToList();

                ViewBag.Partners = clients;
                ViewBag.SelectedClientId = receiverId;

                // Return TrainerChat.cshtml explicitly
                return View("TrainerChat");
            }
            else if (User.IsInRole("Client"))
            {
                // You can do client-specific data loading here if needed
                var currentUser = await repo.GetByIdAsync<User>(currentUserId);
                receiverId = currentUser.TrainerId;
                var myTrainer = await repo.GetByIdAsync<User>(receiverId);
                string TrainerName= $"{myTrainer.FirstName} {myTrainer.LastName}";

                ViewBag.SelectedTrainerId = receiverId; // example
                ViewBag.TrainerName = TrainerName; // example

                // Return ClientChat.cshtml explicitly
                return View("ClientChat");
            }
            else
            {
                return Forbid(); // Only Trainer or Client can access
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetMessages(string receiverId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // First get the messages
            var messages = await repo.All<ChatMessage>()
                .Where(m =>
                    (m.SenderId == userId && m.ReceiverId == receiverId) ||
                    (m.SenderId == receiverId && m.ReceiverId == userId))
                .OrderBy(m => m.SentAt)
                .Select(m => new
                {
                    senderId = m.SenderId,
                    text = m.MessageText,
                    time = m.SentAt.ToString("HH:mm"),
                    isRead = m.IsRead
                })
                .ToListAsync();

            var unreadMessages = await repo.All<ChatMessage>()
                .Where(m => m.SenderId == receiverId &&
                           m.ReceiverId == userId &&
                           !m.IsRead)
                .ToListAsync();

            foreach (var message in unreadMessages)
            {
                message.IsRead = true;
            }

            if (unreadMessages.Any())
            {
                await repo.SaveChangesAsync();
            }

            return Json(messages);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage([FromBody] MessageDto message)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var chatMessage = new ChatMessage
            {
                SenderId = userId,
                ReceiverId = message.ReceiverId,
                MessageText = message.MessageText,
                SentAt = DateTime.UtcNow
            };

            await repo.AddAsync(chatMessage);
            await repo.SaveChangesAsync();

            // Return the saved message info as JSON (you can customize what you return)
            return Json(new
            {
                messageText = chatMessage.MessageText,
                sentAt = chatMessage.SentAt.ToString("o") // ISO 8601 format
            });
        }


        [HttpGet]
        public async Task<IActionResult> GetUnreadMessageCount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var unreadCount = await repo.All<ChatMessage>()
                .CountAsync(m => m.ReceiverId == userId && !m.IsRead);

            return Json(new { unreadCount });
        }
    }


    public class MessageDto
    {
        public string ReceiverId { get; set; }
        public string MessageText { get; set; }
    }

}
