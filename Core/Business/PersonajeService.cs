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
    public class PersonajeService : IPersonajeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityMapper _mapper;

        public PersonajeService(IUnitOfWork unitOfWork, IEntityMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Delete(int id)
        {
            try
            {
                Personaje personaje = await _unitOfWork.PersonajeRepository.GetByIdAsync(id);

                if (personaje != null && !personaje.SoftDelete)
                {
                    personaje.SoftDelete = true;
                    _unitOfWork.SaveChanges();

                    return Result<string>.SuccessResult("Personaje borrado correctamente.");
                }
                else
                {
                    if (personaje == null)
                        return Result.FailureResult("No se encontro ningun Personaje con Id ingresado");
                    else
                        return Result.FailureResult("Personaje con Id ingresado ha sido eliminado previamente");
                }
            }
            catch (Exception ex)
            {
                return Result.FailureResult(ex.Message);
            }
        }

        public async Task<ICollection<PersonajeDtoForDisplay>> GetAll()
        {
            var response = await _unitOfWork.PersonajeRepository.FindByConditionAsync(x => x.SoftDelete == false);

            if (response.Count == 0)
            {
                return null;
            }

            List<PersonajeDtoForDisplay> dto = new();

            foreach (var item in response)
            {
                dto.Add(_mapper.PersonajeToPersonajeDtoForDisplay(item));
            }

            return dto;
        }

        public async Task<Result> GetById(int id)
        {
            try
            {
                Personaje personaje = await _unitOfWork.PersonajeRepository.GetByIdAsync(id);

                if (personaje == null)
                    return Result.FailureResult("No se encontro ningun Personaje con Id ingresado");
                else if (personaje.SoftDelete != false)
                    return Result.FailureResult("Personaje con Id ingresado ha sido eliminado previamente");

                var listConection = await _unitOfWork.PersPeliSerieRepository.FindByConditionAsync(x => x.IdPersonaje == personaje.IdPersonaje);

                var personajeDto = _mapper.PersonajeToPersonajeById(personaje);

                List<PeliculaSerieDtoForDisplay> listPeliSerie = new();

                foreach (var item in listConection)
                {
                    var peliSerie = await _unitOfWork.PeliculaSerieRepository.GetByIdAsync(item.IdPeliculaSerie);

                    listPeliSerie.Add(_mapper.PeliculaSerieToPeliculaSerieDtoForDisplay(peliSerie));
                }

                personajeDto.PeliculasSeries = listPeliSerie;

                return Result<PersonajeDtoById>.SuccessResult(personajeDto);
            }
            catch (Exception ex)
            {
                return Result.ErrorResult(new List<string> { ex.Message });
            }
        }

        public async Task<Result> Insert(PersonajeDtoForInsert personajeDto)
        {
            try
            {
                if (string.IsNullOrEmpty(personajeDto.Image))
                    return Result.FailureResult("Se debe ingresar Imagen");
                if (string.IsNullOrEmpty(personajeDto.Nombre))
                    return Result.FailureResult("Se debe ingresar Texto");
                if (personajeDto.Edad < 1)
                    return Result.FailureResult("Se debe ingresar Edad");
                if (personajeDto.Peso <= 0)
                    return Result.FailureResult("Se debe ingresar Peso");
                if (string.IsNullOrEmpty(personajeDto.Historia))
                    return Result.FailureResult("Se debe ingresar Historia");

                var personajesList = await _unitOfWork.PersonajeRepository.FindByConditionAsync(
                    x => x.Nombre == personajeDto.Nombre && x.Edad == personajeDto.Edad);

                if (personajesList.Count != 0)
                    return Result.FailureResult("El Personaje ha sido Ingresado anteriormente");

                var personaje = _mapper.PersonajeDtoForInsertToPersonaje(personajeDto);

                await _unitOfWork.PersonajeRepository.Create(personaje);
                _unitOfWork.SaveChanges();

                var newPersonajeDto = _mapper.PersonajeToPersonajeDtoForDisplay(personaje);

                return Result<PersonajeDtoForDisplay>.SuccessResult(newPersonajeDto);
            }
            catch (Exception ex)
            {
                return Result.FailureResult(ex.Message);
            }
        }

        public async Task<Result> Update(int id, PersonajeDtoForInsert dto)
        {
            try
            {
                var personaje = await _unitOfWork.PersonajeRepository.GetByIdAsync(id);

                if (personaje != null)
                {
                    if (!string.IsNullOrEmpty(dto.Image))
                        personaje.Image = dto.Image;
                    if (!string.IsNullOrEmpty(dto.Nombre))
                        personaje.Nombre = dto.Nombre;
                    if (dto.Edad >= 1)
                        personaje.Edad = dto.Edad;
                    if (dto.Peso > 0)
                        personaje.Peso = dto.Peso;
                    if (!string.IsNullOrEmpty(dto.Historia))
                        personaje.Historia = dto.Historia;

                    await _unitOfWork.SaveChangesAsync();

                    var personajeDto = _mapper.PersonajeToPersonajeDtoForDisplay(personaje);

                    return Result<PersonajeDtoForDisplay>.SuccessResult(personajeDto);
                }

                return Result.FailureResult("Id de Personaje inexistente.");
            }
            catch (Exception ex)
            {
                return Result.ErrorResult(new List<string> { ex.Message });
            }
        }
    }
}
