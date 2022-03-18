using Challenge.Core.Models.Dtos;
using Challenge.Entities;

namespace Challenge.Core.Interfaces
{
    public interface IEntityMapper
    {
        PersonajeDtoForDisplay PersonajeToPersonajeDtoForDisplay(Personaje personaje);
        PersonajeDtoById PersonajeToPersonajeById(Personaje personaje);
        Personaje PersonajeDtoForInsertToPersonaje(PersonajeDtoForInsert personajeDto);
        PeliculaSerieDtoForDisplay PeliculaSerieToPeliculaSerieDtoForDisplay(PeliculaSerie peliculaSerie);
        PeliculaSerieDtoById PeliculaSerieToPeliculaSerieById(PeliculaSerie peliculaSerie);
        PeliculaSerie PeliculaSerieDtoForInsertToPeliculaSerie(PeliculaSerieDtoForInsert peliculaSerieDto);
        GeneroDto GeneroToGeneroDto(Genero genero);
        Genero GeneroDtoToGenero(GeneroDto generoDto);
        User UserRegisterDtoToUser(UserRegisterDto dto);
        UserDtoForDisplay UserToUserDtoForDisplay(User user);
    }
}
