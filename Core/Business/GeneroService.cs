using Challenge.Core.Interfaces;
using Challenge.Core.Models.Dtos;
using Challenge.Core.Models.Response;
using Challenge.Entities;
using Challenge.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Core.Business
{
    public class GeneroService : IGeneroService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityMapper _mapper;

        public GeneroService(IUnitOfWork unitOfWork, IEntityMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Delete(int id)
        {
            try
            {
                Genero genero = await _unitOfWork.GeneroRepository.GetByIdAsync(id);

                if (genero != null && !genero.SoftDelete)
                {
                    genero.SoftDelete = true;
                    _unitOfWork.SaveChanges();

                    return Result<string>.SuccessResult("Genero borrado correctamente.");
                }
                else
                {
                    if (genero == null)
                        return Result.FailureResult("No se encontro ningun genero con Id ingresado");
                    else
                        return Result.FailureResult("Genero con Id ingresado ha sido eliminado previamente");
                }
            }
            catch (Exception ex)
            {
                return Result.FailureResult(ex.Message);
            }
        }

        public async Task<ICollection<GeneroDto>> GetAll()
        {
            var response = await _unitOfWork.GeneroRepository.FindByConditionAsync(x => x.SoftDelete == false);
            if (response.Count == 0)
            {
                return null;
            }
            else
            {
                List<GeneroDto> dto = new();
                foreach (var item in response)
                {
                    dto.Add(_mapper.GeneroToGeneroDto(item));
                }
                return dto;
            }
        }

        public async Task<Result> Insert(GeneroDto generoDto)
        {
            try
            {
                if (string.IsNullOrEmpty(generoDto.Image))
                    return Result.FailureResult("Se debe ingresar Imagen");
                if (string.IsNullOrEmpty(generoDto.Nombre))
                    return Result.FailureResult("Se debe ingresar Nombre");

                var genero = _mapper.GeneroDtoToGenero(generoDto);

                await _unitOfWork.GeneroRepository.Create(genero);
                _unitOfWork.SaveChanges();

                var newGeneroDto = _mapper.GeneroToGeneroDto(genero);

                return Result<GeneroDto>.SuccessResult(newGeneroDto);
            }
            catch (Exception ex)
            {
                return Result.FailureResult(ex.Message);
            }
        }
    }
}
