using CRUD.Attributes;
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
        public async Task<IActionResult> CreateGameAsync([FromBody] GameInputModel game)
        {
            return Ok(await gameService.CreateGameAsync(game));
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
        public async Task<IActionResult> GetGameListAsync([FromQuery] GameSearchCriteria gameSearchCriteria)
        {
            return Ok(await gameService.GetGameListAsync(gameSearchCriteria));
        }

        /// <summary>
        /// Изменение игры
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation("Изменение игры")]
        [DefaultException("Не удалось изменить данные выбранной игры")]
        public async Task<IActionResult> UpdateGameAsync([FromBody] GameInputModel game)
        {
            return Ok(await gameService.UpdateGameAsync(game));
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
        public async Task<IActionResult> AddGenreGameAsync(Guid gameId, Guid genreId)
        {
            return Ok(await gameService.AddGenreGameAsync(gameId, genreId));
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
        public async Task<IActionResult> AddStudioGameAsync(Guid gameId, Guid studioId)
        {
            return Ok(await gameService.AddStudioGameAsync(gameId, studioId));
        }

        /// <summary>
        /// Удаление игры
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        [HttpDelete("{gameId:guid}")]
        [SwaggerOperation("Удаление игры")]
        [DefaultException("Не удалось удалить выбранную игру")]
        public async Task<IActionResult> DeleteGameAsync(Guid gameId)
        {
            return Ok(await gameService.DeleteGameAsync(gameId));
        }
    }
}
