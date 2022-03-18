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
    public class PeliculaSerieService : IPeliculaSerieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityMapper _mapper;

        public PeliculaSerieService(IUnitOfWork unitOfWork, IEntityMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Delete(int id)
        {
            try
            {
                PeliculaSerie peliculaSerie = await _unitOfWork.PeliculaSerieRepository.GetByIdAsync(id);

                if (peliculaSerie != null && !peliculaSerie.SoftDelete)
                {
                    peliculaSerie.SoftDelete = true;
                    _unitOfWork.SaveChanges();

                    return Result<string>.SuccessResult("PeliculaSerie borrado correctamente.");
                }
                else
                {
                    if (peliculaSerie == null)
                        return Result.FailureResult("No se encontro ningun PeliculaSerie con Id ingresado");
                    else
                        return Result.FailureResult("PeliculaSerie con Id ingresado ha sido eliminado previamente");
                }
            }
            catch (Exception ex)
            {
                return Result.FailureResult(ex.Message);
            }
        }

        public async Task<ICollection<PeliculaSerieDtoForDisplay>> GetAll()
        {
            var response = await _unitOfWork.PeliculaSerieRepository.FindByConditionAsync(x => x.SoftDelete == false);
            if (response.Count == 0)
            {
                return null;
            }
            else
            {
                List<PeliculaSerieDtoForDisplay> dto = new();
                foreach (var item in response)
                {
                    dto.Add(_mapper.PeliculaSerieToPeliculaSerieDtoForDisplay(item));
                }
                return dto;
            }
        }

        public async Task<Result> GetById(int id)
        {
            try
            {
                PeliculaSerie peliculaSerie = await _unitOfWork.PeliculaSerieRepository.GetByIdAsync(id);

                if (peliculaSerie == null)
                    return Result.FailureResult("No se encontro ningun PeliculaSerie con Id ingresado");
                else if (peliculaSerie.SoftDelete != false)
                    return Result.FailureResult("PeliculaSerie con Id ingresado ha sido eliminado previamente");

                var listConection = await _unitOfWork.PersPeliSerieRepository.FindByConditionAsync(x => x.IdPeliculaSerie == peliculaSerie.IdPeliculaSerie);

                var peliculaSerieDto = _mapper.PeliculaSerieToPeliculaSerieById(peliculaSerie);

                List<PersonajeDtoForDisplay> listPersonaje = new();

                foreach (var item in listConection)
                {
                    var personaje = await _unitOfWork.PersonajeRepository.GetByIdAsync(item.IdPersonaje);

                    listPersonaje.Add(_mapper.PersonajeToPersonajeDtoForDisplay(personaje));
                }

                peliculaSerieDto.Personajes = listPersonaje;
                return Result<PeliculaSerieDtoById>.SuccessResult(peliculaSerieDto);
            }
            catch (Exception ex)
            {
                return Result.ErrorResult(new List<string> { ex.Message });
            }
        }

        public async Task<Result> Insert(PeliculaSerieDtoForInsert peliculaSerieDto)
        {
            try
            {
                if (string.IsNullOrEmpty(peliculaSerieDto.Image))
                    return Result.FailureResult("Se debe ingresar Imagen");
                if (string.IsNullOrEmpty(peliculaSerieDto.Titulo))
                    return Result.FailureResult("Se debe ingresar Texto");
                if (peliculaSerieDto.IdGenero < 1)
                    return Result.FailureResult("Se debe ingresar Id para Genero entero y mayor a cero");
                if (peliculaSerieDto.Calificaion < 0)
                    return Result.FailureResult("El numero de Orden debe ser mayor a cero");

                var peliculaSerie = _mapper.PeliculaSerieDtoForInsertToPeliculaSerie(peliculaSerieDto);

                await _unitOfWork.PeliculaSerieRepository.Create(peliculaSerie);
                _unitOfWork.SaveChanges();

                var newPeliculaSerieDto = _mapper.PeliculaSerieToPeliculaSerieDtoForDisplay(peliculaSerie);

                return Result<PeliculaSerieDtoForDisplay>.SuccessResult(newPeliculaSerieDto);
            }
            catch (Exception ex)
            {
                return Result.FailureResult(ex.Message);
            }
        }

        public async Task<Result> Update(int id, PeliculaSerieDtoForInsert dto)
        {
            try
            {
                var peliculaSerie = await _unitOfWork.PeliculaSerieRepository.GetByIdAsync(id);

                if (peliculaSerie != null)
                {
                    peliculaSerie.Titulo = dto.Titulo;
                    peliculaSerie.Calificaion = dto.Calificaion;
                    peliculaSerie.Image = dto.Image;
                    peliculaSerie.FechaCreacion = dto.FechaCreacion;
                    peliculaSerie.GeneroId = dto.IdGenero;

                    if (!string.IsNullOrEmpty(dto.Image))
                        peliculaSerie.Image = dto.Image;
                    if (!string.IsNullOrEmpty(dto.Titulo))
                        peliculaSerie.Titulo = dto.Titulo;
                    if (dto.Calificaion > 0)
                        peliculaSerie.Calificaion = dto.Calificaion;

                    await _unitOfWork.SaveChangesAsync();

                    var peliculaSerieDto = _mapper.PeliculaSerieToPeliculaSerieDtoForDisplay(peliculaSerie);

                    return Result<PeliculaSerieDtoForDisplay>.SuccessResult(peliculaSerieDto);
                }

                return Result.FailureResult("Id de PeliculaSerie inexistente.");
            }
            catch (Exception ex)
            {
                return Result.ErrorResult(new List<string> { ex.Message });
            }
        }
    }
}
