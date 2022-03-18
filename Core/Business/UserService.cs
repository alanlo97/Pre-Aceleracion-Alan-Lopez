using Challenge.Core.Helper;
using Challenge.Core.Interfaces;
using Challenge.Core.Models.Dtos;
using Challenge.Core.Models.Response;
using Challenge.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Core.Business
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityMapper _mapper;
        private readonly IJwtHelper _jwtHelper;
        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration, IJwtHelper jwtHelper, IEntityMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            _config = configuration;
        }

        public async Task<Result> Insert(UserRegisterDto dto)

        {
            var errorList = new List<string>();
            var user = _mapper.UserRegisterDtoToUser(dto);

            try
            {
                // verifico que no exista Email en sistema
                var existUser = await this._unitOfWork.UserRepository.FindByConditionAsync(x => x.Email == user.Email);
                var existUserName = await _unitOfWork.UserRepository.FindByConditionAsync(x => x.UserName == user.UserName);

                if (existUser != null && existUser.Count > 0)
                    return Result.FailureResult("Email ya existe en el sistema.");
                if (existUserName != null && existUserName.Count > 0)
                    return Result.FailureResult("Nombre de Usuario está en uso. Por favor ingrese otro.");

                user.Password = EncryptHelper.GetSHA256(user.Password);

                await this._unitOfWork.UserRepository.Create(user);
                await this._unitOfWork.SaveChangesAsync();

                try
                {
                    //se envia mail de bienvenida
                    var emailSender = new EmailSender(_config);
                    var emailBody = $"<h4>Hola {user.UserName}</h4>{_config["MailParams:WelcomeMailBody"]}";
                    var emailContact = string.Format("<a href='mailto:{0}'>{0}</a>", _config["MailParams:WelcomeMailContact"]);

                    await emailSender.SendEmailWithTemplateAsync(user.Email, _config["MailParams:WelcomeMailTitle"], emailBody, emailContact);
                }
                catch (Exception e)
                {
                    errorList.Add($"No se envio email de bienvenida: { e.Message }");
                }

                var userDisplay = _mapper.UserToUserDtoForDisplay(user);
                userDisplay.Token = _jwtHelper.GenerateJwtToken(user);

                var result = Result<UserDtoForDisplay>.SuccessResult(userDisplay);
                result.ErrorList = errorList; // adjunto lista de posibles errores a la respuesta


                return result;
            }
            catch (Exception e)
            {
                errorList.Add(e.Message);
                return Result.ErrorResult(errorList);
            }
        }


        public async Task<Result> LoginAsync(UserLoginDTO userLoginDto)
        {
            try
            {
                var result = await this._unitOfWork.UserRepository.FindByConditionAsync(x => x.Email == userLoginDto.Email);

                if (result.Count > 0)
                {
                    var currentUser = result.FirstOrDefault();
                    if (currentUser != null)
                    {
                        var resultPassword = EncryptHelper.Verify(userLoginDto.Password, currentUser.Password);
                        if (resultPassword)
                        {
                            var userDisplay = _mapper.UserToUserDtoForDisplay(currentUser);
                            userDisplay.Token = _jwtHelper.GenerateJwtToken(currentUser);

                            return Result<UserDtoForDisplay>.SuccessResult(userDisplay);
                        }
                    }
                }

                return Result.FailureResult("No se pudo iniciar sesion, usuario o contrasena invalidos");
            }
            catch (Exception e)
            {
                return Result.ErrorResult(new List<string> { e.Message });
            }
        }
    }
}
