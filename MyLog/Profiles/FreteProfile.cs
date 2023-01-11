using AutoMapper;
using MyLog.Data.Dtos;
using MyLog.Models;

namespace MyLog.Profiles;

public class FreteProfile : Profile
{
    public FreteProfile()
    {
        CreateMap<UpdateFreteDto, Frete>();
    }
}