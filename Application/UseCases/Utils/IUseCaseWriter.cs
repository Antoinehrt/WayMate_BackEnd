using Application.UseCases.Users.Admin.Dtos;

namespace Application.UseCases.Utils;

public interface IUseCaseWriter<out TOutput, in TInput>
{
    TOutput Execute(TInput input);
}