using AutoMapper;
using Invest.Application.Interfaces;
using Invest.Application.ViewModels.Users;
using Invest.CrossCutting.Auth.Interfaces;
using Invest.CrossCutting.Auth.ViewModels;
using Invest.CrossCutting.IoC.ExceptionHandler.Extensions;
using Invest.Domain.Entities;
using Invest.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Net;

namespace Invest.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;
        private readonly IUserRepository repository;

        public UserService(IMapper mapper, ITokenService tokenService,
            IUserRepository repository)
        {
            this.mapper = mapper;
            this.tokenService = tokenService;
            this.repository = repository;
        }

        public void ActivateByDocument(string document, string code)
        {
            User _user = repository.GetByDocumentAndCode(document, code);
            if (_user == null)
                throw new ApiException("Document/Code not found", HttpStatusCode.NotFound);

            _user.IsAuthorised = true;
            _user.Code = string.Empty;
            repository.Update(_user);
        }

        public bool ActivateUser(int userId)
        {
            User _user = GetByIdPrivate(userId);
            _user.IsAuthorised = true;

            repository.Update(_user);
            return true;
        }

        public UserResponseAuthenticateViewModel Authenticate(UserRequestAuthenticateViewModel user)
        {
            User _user = repository.GetByDocumentAndPassword(user.Document, UtilsService.EncryptPassword(user.Password));
            if (_user == null)
                throw new ApiException("Document/Password not found", HttpStatusCode.NotFound);

            if (!_user.IsAuthorised)
                throw new ApiException("Your account is not activate yet.", HttpStatusCode.NotFound);

            string token = tokenService.GenerateToken(mapper.Map<ContextUserViewModel>(_user));

            UserResponseAuthenticateViewModel _userResponse = mapper.Map<UserResponseAuthenticateViewModel>(_user);
            _userResponse.Token = token;

            return _userResponse;
        }

        public bool ChangePassword(UserRequestChangePasswordViewModel user)
        {
            User _user = repository.GetByDocumentAndCode(user.Document, user.Code);
            if (_user == null)
                throw new ApiException("Document/Code not found", HttpStatusCode.NotFound);

            _user.Code = string.Empty;
            _user.Password = UtilsService.EncryptPassword(user.Password);
            repository.Update(_user);

            return true;
        }

        public bool DeactivateUser(int userId)
        {
            User _user = GetByIdPrivate(userId);
            _user.IsAuthorised = false;

            repository.Update(_user);
            return true;
        }

        public bool ForgotPassword(string document)
        {
            //ValidationService.ValidEmail(email);
            User _user = repository.GetByDocument(document);
            if (_user == null)
                throw new ApiException("Document not found", HttpStatusCode.NotFound);

            _user.Code = UtilsService.GenerateCode(8);

            repository.Update(_user);

            return true;
        }

        public UserViewModel GetById(int userId)
        {
            User _user = GetByIdPrivate(userId);

            return mapper.Map<UserViewModel>(_user);
        }

        public bool Post(UserRequestCreateAccountViewModel user, string host)
        {
            //ValidationService.ValidEmail(user.Email);
            //ValidationService.ValidPassword(user.Password, user.PasswordConfirm);

            if (repository.GetByDocument(user.Document) != null)
                throw new ApiException("Document not found", HttpStatusCode.Conflict);

            try
            {
                User _user = mapper.Map<User>(user);

                _user.Code = UtilsService.GenerateCode(8);
                _user.IsActive = true;
                _user.IsAuthorised = true;
                _user.Password = UtilsService.EncryptPassword(user.Password);

                repository.Create(_user);

                return true;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public List<UserViewModel> Get()
        {
            return mapper.Map<List<UserViewModel>>(repository.Get());
        }

        public List<UserResponseListViewModel> GetAll()
        {
            return mapper.Map<List<UserResponseListViewModel>>(repository.GetAll());
        }

        public bool Put(UserUpdateAccount user)
        {
            User _user = GetByIdPrivate(user.Id);
            _user.Name = user.Name;

            repository.Update(_user);
            return true;
        }

        private User GetByIdPrivate(int userId)
        {
            User _user = repository.GetById(userId);
            if (_user == null)
                throw new ApiException("User not found", HttpStatusCode.NotFound);

            return _user;
        }
    }
}