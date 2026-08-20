using Ardalis.Result;
using AutoMapper;
using Forge.WebApi.Application.Dto.Auth;
using Forge.WebApi.Application.Operations.Auth.Commands;
using Forge.WebApi.Application.Operations.Auth.Validators;
using Forge.WebApi.Application.Services;
using Forge.WebApi.Domain.Interfaces.User;
using Forge.WebApi.Shared.ExceptionBase;
using MediatR;

namespace Forge.WebApi.Application.Operations.Auth.Handlers
{
    public record LoginUserHandler(IMapper Mapper, IAuthService authService,
        IUserRepository userRepository) 
        : IRequestHandler<LoginUserCommand, Result<UserAuthResponseDto>>
    {      
        private readonly IMapper _mapper = Mapper;
        private readonly IAuthService _authService = authService;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<Result<UserAuthResponseDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var validate = new AuthUserValidator().Validate(request);

            if (!validate.IsValid)
            {
                var errorMessage = validate.Errors.Select(e => e.ErrorMessage);
                throw new ErrorOnValidationException([.. errorMessage]);
            }

            var result = await _userRepository.GetUserByEmail(request.Email);

            var user = result.IsSuccess ? result.Value : null;

            if (user == null)
                return Result.Error("Nenhum usuário encontrado com o email informado");

            if (BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash) is true)
            {
                user.RefreshToken = _authService.GenerateRefreshToken();
                user.RefreshTokenExpirationTime = DateTime.Now.AddDays(7);

                var responseUpdate =  await _userRepository.Update(user);

                if (!responseUpdate.IsSuccess)
                    return Result.Error("Erro inesperado tente novamente");

                UserAuthResponseDto userAuthResponseDto = _mapper.Map<UserAuthResponseDto>(user);
                userAuthResponseDto.TokenJwt = _authService.GenerateJWT(user.Email!, user.UserName!, user.Id);
        

                return Result.Success(userAuthResponseDto);
            }
            else
                return Result.Error("Login ou senha incorretos.");
        }
    }
}
