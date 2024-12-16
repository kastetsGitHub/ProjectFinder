using AutoMapper;

namespace Service.FindGitHubAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            //  config.CreateMap<Finder, FinderDto>();
            //   config.CreateMap<FinderDto, Finder>();
        });

        return mappingConfig;
    }
}
