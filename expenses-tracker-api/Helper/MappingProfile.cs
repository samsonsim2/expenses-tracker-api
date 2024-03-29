﻿using AutoMapper;
using expenses_tracker_api.DTO;
using expenses_tracker_api.Models;

namespace expenses_tracker_api.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Transaction, TransactionDTO>();
            CreateMap<TransactionDTO, Transaction>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
