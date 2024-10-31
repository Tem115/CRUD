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
        /// �������� ����
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("�������� ����")]
        [DefaultException("�� ������� ������� ����")]
        public IActionResult CreateGame([FromBody] GameInputModel game)
        {
            return Ok(gameService.CreateGame(game));
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
        public IActionResult GetGameList([FromQuery] GameSearchCriteria gameSearchCriteria)
        {
            return Ok(gameService.GetGameList(gameSearchCriteria));
        }

        /// <summary>
        /// ��������� ����
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation("��������� ����")]
        [DefaultException("�� ������� �������� ������ ��������� ����")]
        public IActionResult UpdateGame([FromBody] GameInputModel game)
        {
            return Ok(gameService.UpdateGame(game));
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
        public IActionResult AddGenreGame(Guid gameId, Guid genreId)
        {
            return Ok(gameService.AddGenreGame(gameId, genreId));
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
        public IActionResult AddStudioGame(Guid gameId, Guid studioId)
        {
            return Ok(gameService.AddStudioGame(gameId, studioId));
        }

        /// <summary>
        /// �������� ����
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        [HttpDelete("{gameId:guid}")]
        [SwaggerOperation("�������� ����")]
        [DefaultException("�� ������� ������� ��������� ����")]
        public IActionResult DeleteGame(Guid gameId)
        {
            return Ok(gameService.DeleteGame(gameId));
        }
    }
}
