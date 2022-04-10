﻿using CoreStructure3._1.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CoreStructure3._1.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
    }
}