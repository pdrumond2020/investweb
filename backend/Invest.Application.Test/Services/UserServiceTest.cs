using AutoMapper;
using FizzWare.NBuilder;
using Invest.Application.Interfaces;
using Invest.Application.Services;
using Invest.Application.ViewModels.Users;
using Invest.CrossCutting.Auth.Interfaces;
using Invest.CrossCutting.IoC.AutoMapper;
using Invest.Domain.Entities;
using Invest.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Invest.Application.Test.Services
{
    public class UserServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ITokenService> _mocktoken;
        private readonly Mock<IUserRepository> _mockRepository;

        private bool disposed = false;

        public UserServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;

            _mockMapper = new Mock<IMapper>();
            _mocktoken = new Mock<ITokenService>();
            _mockRepository = new Mock<IUserRepository>();

            //var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(profile: ActivatorUtilities.GetServiceOrCreateInstance<AutoMapperSetup>(provider)));
            //_mapper = mapperConfig.CreateMapper();
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperSetup());
            });
            _mapper = mockMapper.CreateMapper();

            _service = new UserService(_mapper, _mocktoken.Object, _mockRepository.Object);
        }

        [Fact]
        public void ServiceListAll_ShouldReturns_Success()
        {
            _testOutput.WriteLine("Lista não pode ser vazia.");
            var users = Builder<User>.CreateListOfSize(10).All().Build().ToList();
            var expectedRepo = users.AsQueryable();
            var expectedMap = _mapper.Map<List<UserResponseListViewModel>>(users);

            _mockRepository
                .Setup(x => x.GetAll())
                .Returns(expectedRepo);

            _mockMapper
                .Setup(x => x.Map<List<UserResponseListViewModel>>(users))
                .Returns(expectedMap);

            var result = _service.GetAll();

            Assert.NotNull(users);
            Assert.NotNull(result);
            Assert.IsType<List<UserResponseListViewModel>>(result.ToList());
            Assert.Equal(expectedRepo.Count().ToString(), result.Count.ToString());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
            }
        }
    }
}