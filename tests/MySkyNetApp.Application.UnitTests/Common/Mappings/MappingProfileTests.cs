using System;
using System.Runtime.Serialization;
using AutoMapper;
using MySkyNetApp.Application.Common.Mappings;
using MySkyNetApp.Application.CreateHelloWorld;
using MySkyNetApp.Domain.Models;
using Xunit;

namespace MySkyNetApp.Application.UnitTests.Common.Mappings
{
    public class MappingProfileTests
    {

        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingProfileTests()
        {
            _configuration = new MapperConfiguration(config =>
                config.AddProfile<MappingProfile>());

            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(HelloWorldResponse), typeof(CreateHelloWorldResult))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);

            _mapper.Map(instance, source, destination);
        }

        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type)!;

            return FormatterServices.GetUninitializedObject(type);
        }
    }
}