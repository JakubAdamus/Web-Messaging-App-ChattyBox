﻿using DAL.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UserRepository
{
    public interface IUserRepository
    {
        User LoginUser(string email, string password);
        User RegisterUser(string email, string username, string password);
    }
    
}
