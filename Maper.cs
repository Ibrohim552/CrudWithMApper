

using AutoMapper;

public class Mapper:Profile
{
    public Mapper()
    { 
        CreateMap<Person, PersonCreateInfo>().ReverseMap();
        CreateMap<Person, PersonUpdateInfo>().ReverseMap();
        CreateMap<Person, PersonReadInfo>().ReverseMap();
    }
}