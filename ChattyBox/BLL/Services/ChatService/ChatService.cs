﻿using AutoMapper;
using BLL.DataTransferObjects.ChatDtos;
using BLL.DataTransferObjects.UserDtos;
using DAL.Database.Entities;
using DAL.Exceptions;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ChatService
{
    public  class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChatService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddUserById(int userId, int chatId)
        {
            _unitOfWork.Chats.AddUserById(userId, chatId);
            _unitOfWork.Save();
        }
        
        public void CreateChat(CreateChatDTO dto)
        {
            _unitOfWork.Chats.CreateChat(dto.Name, dto.UserId);
            _unitOfWork.Save();
        }
        
        public void DeleteChat(int chatId)
        {
            _unitOfWork.Chats.DeleteChat(chatId);
            _unitOfWork.Save();
        }

        public void DeleteUserById(int userId, int chatId)
        {
            _unitOfWork.Chats.DeleteUserById(userId, chatId);
            _unitOfWork.Save();
        }

        public GetChatDTO GetChat(int id, int pageNumber, int messagePerPage)
        {
            var chat = _unitOfWork.Chats.GetChat(id, pageNumber,messagePerPage);

            if (chat == null) 
                throw new NotFoundException("Nie znaleziono chatu");

            return _mapper.Map<GetChatDTO>(chat);
        }

        public int GetChatMessagesCount(int id)
        {
            return _unitOfWork.Chats.GetChatMessagesCount(id);
        }

        public IEnumerable<UserDTO> GetUsersInChat(int chatId)
        {
            var users = _unitOfWork.Chats.GetUsersInChat(chatId);

            if (users == null)
                throw new NotFoundException("Nie znaleziono użytkowników");

            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public void AssignRole(int userId, int chatId, int roleId)
        {
            _unitOfWork.Chats.AssignRole(userId, chatId, roleId);
            _unitOfWork.Save();
        }

        public void RevokeRole(int userId, int chatId)
        {
            _unitOfWork.Chats.RevokeRole(userId, chatId);
            _unitOfWork.Save();
        }
        public string GetUserRole(int userId, int chatId)
        {
			return _unitOfWork.Chats.GetUserRole(userId, chatId).Name;
		}
    }
}