using AutoMapper;
using JobsityApi.Models;
using JobsityApi.Repositories;
using JobsityApi.Repositories.Interfaces;
using JobsityApi.ViewModels;

namespace JobsityApi.Services;

public class GenericService<T, VM>
    where T : IdentityModel
    where VM : ViewModel
{
    public IMapper _mapper { get; set; }
    public GenericRepository<T> _repository { get; set; }
    public GenericService(IMapper mapper, GenericRepository<T> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IList<VM>> GetAll()
    {
        return (await _repository.GetAll())
            .Select(w => _mapper.Map<T, VM>(w))
            .ToList();
    }
}
