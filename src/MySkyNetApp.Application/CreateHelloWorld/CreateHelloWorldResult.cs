using System;
using AutoMapper;
using MySkyNetApp.Application.Common.Mappings;
using MySkyNetApp.Domain.Enums;
using MySkyNetApp.Domain.Models;

namespace MySkyNetApp.Application.CreateHelloWorld
{
    public class CreateHelloWorldResult : IMapFrom<HelloWorldResponse>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public UserLevel Level { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HelloWorldResponse, CreateHelloWorldResult>()
                .ForMember(d => d.Level, opt => opt.MapFrom(s => (UserLevel)s.Level))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.UserId));
        }
    }
}