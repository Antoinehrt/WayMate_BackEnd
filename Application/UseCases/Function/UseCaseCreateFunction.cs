using Application.UseCases.Function.Dtos;
using Application.UseCases.Utils;

namespace Application.UseCases.Function;

public class UseCaseCreateFunction : IUseCaseWriter<DtoOutputFunction, DtoInputCreateFunction>
{
    private readonly IFunctionRepository _functionRepository;

    public UseCaseCreateFunction(IFunctionRepository functionRepository)
    {
        _functionRepository = functionRepository;
    }

    public DtoOutputFunction Execute(DtoInputCreateFunction input)
    {
        var dbFunction = _functionRepository.Create(input.title);
        return Mapper.GetInstance().Map<DtoOutputFunction>(dbFunction);
    }
}