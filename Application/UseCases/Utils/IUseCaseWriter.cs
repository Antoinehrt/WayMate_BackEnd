using Application.UseCases.Users.Admin.Dtos;
using Application.UseCases.Users.Passenger.Dtos;
using Application.UseCases.Users.User.Dtos;

namespace Application.UseCases.Utils;

public interface IUseCaseWriter<out TOutput, in TInput>
{
    TOutput Execute(TInput input);
}