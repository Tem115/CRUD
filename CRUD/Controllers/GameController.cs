using CRUD.Abstractions;
using CRUD.Models;
using CRUD.Models.InputModels;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CRUD.Controllers
{
    public class GameController(LoggerService logger, GameService gameService) : CustomControllerBase(logger)
    {

        /// <summary>
        /// Создание игры
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("Создание игры")]
        [DefaultException("Не удалось создать игру")]
        public IActionResult CreateGame([FromBody] GameInputModel game)
        {
            return Ok(gameService.CreateGame(game));
        }

        //TODO: Здесь поидеи надо закинуть интерфейс


        /// <summary>
        /// Получение списка игр с возможностью фильтрации
        /// </summary>
        /// <param name="gameSearchCriteria"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation("Получение списка игр с возможностью фильтрации")]
        [DefaultException("Не удалось получить список игр по заданным фильтрам")]
        public IActionResult GetGameList([FromQuery] GameSearchCriteria gameSearchCriteria)
        {
            return Ok(gameService.GetGameList(gameSearchCriteria));
        }

        /// <summary>
        /// Изменение игры
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation("Изменение игры")]
        [DefaultException("Не удалось изменить данные выбранной игры")]
        public IActionResult UpdateGame([FromBody] GameInputModel game)
        {
            return Ok(gameService.UpdateGame(game));
        }

        /// <summary>
        /// Добавление жанра игры
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="genreId"></param>
        /// <returns></returns>
        [HttpPut("{gameId:guid}/genre/{genreId:guid}")]
        [SwaggerOperation("Добавление жанра игры")]
        [DefaultException("Не удалось добавить жанр игры")]
        public IActionResult AddGenreGame(Guid gameId, Guid genreId)
        {
            return Ok(gameService.AddGenreGame(gameId, genreId));
        }
        
        /// <summary>
        /// Добавление студии игры
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="studioId"></param>
        /// <returns></returns>
        [HttpPut("{gameId:guid}/studio/{studioId:guid}")]
        [SwaggerOperation("Добавление студии игры")]
        [DefaultException("Не удалось добавить студию игры")]
        public IActionResult AddStudioGame(Guid gameId, Guid studioId)
        {
            return Ok(gameService.AddStudioGame(gameId, studioId));
        }

        /// <summary>
        /// Удаление игры
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        [HttpDelete("{gameId:guid}")]
        [SwaggerOperation("Удаление игры")]
        [DefaultException("Не удалось удалить выбранную игру")]
        public IActionResult DeleteGame(Guid gameId)
        {
            return Ok(gameService.DeleteGame(gameId));
        }
    }
}
