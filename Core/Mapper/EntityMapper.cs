using Challenge.Core.Interfaces;
using Challenge.Core.Models.Dtos;
using Challenge.Entities;

namespace Challenge.Core.Mapper
{
    public class EntityMapper : IEntityMapper
    {
        public PersonajeDtoForDisplay PersonajeToPersonajeDtoForDisplay(Personaje personaje)
        {
            return new PersonajeDtoForDisplay
            {
                Imagen = personaje.Image,
                Nombre = personaje.Nombre
            };
        }
        public PersonajeDtoById PersonajeToPersonajeById(Personaje personaje)
        {
            return new PersonajeDtoById
            {
                Edad = personaje.Edad,
                Historia = personaje.Historia,
                Nombre = personaje.Nombre,
                Image = personaje.Image,
                Peso = personaje.Peso
            };
        }
        public Personaje PersonajeDtoForInsertToPersonaje(PersonajeDtoForInsert personajeDto)
        {
            return new Personaje
            {
                Edad = personajeDto.Edad,
                Historia = personajeDto.Historia,
                Image = personajeDto.Image,
                Nombre = personajeDto.Nombre,
                Peso = personajeDto.Peso
            };
        }

        public PeliculaSerieDtoForDisplay PeliculaSerieToPeliculaSerieDtoForDisplay(PeliculaSerie peliculaSerie)
        {
            return new PeliculaSerieDtoForDisplay{
                FechaCreacion = peliculaSerie.FechaCreacion,
                Image = peliculaSerie.Image,
                Titulo = peliculaSerie.Titulo
            };
        }
        public PeliculaSerieDtoById PeliculaSerieToPeliculaSerieById(PeliculaSerie peliculaSerie)
        {
            return new PeliculaSerieDtoById
            {
                Titulo = peliculaSerie.Titulo,
                Calificacion = peliculaSerie.Calificaion,
                FechaCreacion = peliculaSerie.FechaCreacion,
                Image = peliculaSerie.Image
            };
        }
        public PeliculaSerie PeliculaSerieDtoForInsertToPeliculaSerie(PeliculaSerieDtoForInsert peliculaSerieDto)
        {
            return new PeliculaSerie
            {
                Calificaion = peliculaSerieDto.Calificaion,
                FechaCreacion = peliculaSerieDto.FechaCreacion,
                Titulo = peliculaSerieDto.Titulo,
                Image = peliculaSerieDto.Image,
                GeneroId = peliculaSerieDto.IdGenero
            };
        }

        public GeneroDto GeneroToGeneroDto(Genero genero)
        {
            return new GeneroDto
            {
                Image = genero.Image,
                Nombre = genero.Nombre
            };
        }
        public Genero GeneroDtoToGenero(GeneroDto generoDto)
        {
            return new Genero
            {
                Image = generoDto.Image,
                Nombre = generoDto.Nombre
            };
        }

        public User UserRegisterDtoToUser(UserRegisterDto dto)
        {
            return new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password,
            };
        }

        public UserDtoForDisplay UserToUserDtoForDisplay(User user)
        {
            return new UserDtoForDisplay
            {
                UserName = user.UserName,
                Email = user.Email
            };
        }
    }
}
