using AutoMapper;
using PersonApi.DTOs;
using PersonApi.Entities;

namespace PersonApi.Configuration
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles() 
		{
			/*CreateMap<Person, PersonDto>()
				.ForMember(dest => dest.Age, opt => opt.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year)); */
			CreateMap<Person, PersonDto>();
			// Jesli nazwy pol sie nie zgadzaja
			//CreateMap<Person, PersonDto>()
			//	.ForMember(des => des.Name2, opt => opt.MapFrom(src => src.Name));

			CreateMap<UpsertPersonDto, Person>();
			CreateMap<Person, PersonWithNoAgeDto>();
		}
	}
}
