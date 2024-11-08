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
        /// �������� ����
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("�������� ����")]
        [DefaultException("�� ������� ������� ����")]
        public async Task<IActionResult> CreateGameAsync([FromBody] GameInputModel game)
        {
            return Ok(await gameService.CreateGameAsync(game));
        }

        //TODO: ����� ������ ���� �������� ���������


        /// <summary>
        /// ��������� ������ ��� � ������������ ����������
        /// </summary>
        /// <param name="gameSearchCriteria"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation("��������� ������ ��� � ������������ ����������")]
        [DefaultException("�� ������� �������� ������ ��� �� �������� ��������")]
        public async Task<IActionResult> GetGameListAsync([FromQuery] GameSearchCriteria gameSearchCriteria)
        {
            return Ok(await gameService.GetGameListAsync(gameSearchCriteria));
        }

        /// <summary>
        /// ��������� ����
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation("��������� ����")]
        [DefaultException("�� ������� �������� ������ ��������� ����")]
        public async Task<IActionResult> UpdateGameAsync([FromBody] GameInputModel game)
        {
            return Ok(await gameService.UpdateGameAsync(game));
        }

        /// <summary>
        /// ���������� ����� ����
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="genreId"></param>
        /// <returns></returns>
        [HttpPut("{gameId:guid}/genre/{genreId:guid}")]
        [SwaggerOperation("���������� ����� ����")]
        [DefaultException("�� ������� �������� ���� ����")]
        public async Task<IActionResult> AddGenreGameAsync(Guid gameId, Guid genreId)
        {
            return Ok(await gameService.AddGenreGameAsync(gameId, genreId));
        }
        
        /// <summary>
        /// ���������� ������ ����
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="studioId"></param>
        /// <returns></returns>
        [HttpPut("{gameId:guid}/studio/{studioId:guid}")]
        [SwaggerOperation("���������� ������ ����")]
        [DefaultException("�� ������� �������� ������ ����")]
        public async Task<IActionResult> AddStudioGameAsync(Guid gameId, Guid studioId)
        {
            return Ok(await gameService.AddStudioGameAsync(gameId, studioId));
        }

        /// <summary>
        /// �������� ����
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        [HttpDelete("{gameId:guid}")]
        [SwaggerOperation("�������� ����")]
        [DefaultException("�� ������� ������� ��������� ����")]
        public async Task<IActionResult> DeleteGameAsync(Guid gameId)
        {
            return Ok(await gameService.DeleteGameAsync(gameId));
        }
    }
}
