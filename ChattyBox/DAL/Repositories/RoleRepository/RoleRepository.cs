﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;
using DAL.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.RoleRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbChattyBox _context;
        public RoleRepository(DbChattyBox context)
        {
            _context = context;
        }
        public void CreateRole(Role role)
        {
            _context.Roles.Add(role);
        }

        public void DeleteRole(Role role)
        {
            _context.Roles.Remove(role);
        }

        public Role? GetById(int id)
        {
           return _context.Roles.FirstOrDefault(x => x.Id == id);
        }

        public Role? GetByName(string name)
        {
            return _context.Roles.FirstOrDefault(x => x.Name == name);
        }

        public bool RoleExists(string name)
        {
            return _context.Roles.Any(x => x.Name == name);
        }
    }
}
