﻿using DAL.Database;
using DAL.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.TextMessageRepository
{
    public class TextMessageRepository : ITextMessageRepository
    {
        private readonly DbChattyBox _context;
        public TextMessageRepository(DbChattyBox context) 
        {
            _context = context;
        }

        public void CreateTextMessage(TextMessage message)
        {
            _context.TextMessages.Add(message);
        }

        public void DeleteTextMessage(TextMessage message)
        {
            _context.TextMessages.Remove(message);
        }

        public TextMessage? GetLastTextMessage(int chatid)
        {
           return _context.TextMessages
                .Include(m => m.Sender)
                .Where(m => m.ChatId == chatid)
                .OrderByDescending(m => m.TimeStamp)
                .FirstOrDefault();
        }

        public TextMessage? GetById(int id)
        {
            return _context.TextMessages.FirstOrDefault(t => t.Id == id);
        }
    }
}
