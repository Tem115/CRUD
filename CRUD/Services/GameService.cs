using AutoMapper;
using CRUD.Models;
using CRUD.Models.InputModels;
using CRUD.Models.OutputModels;
using Databases.DbContexts;
using Databases.Tables;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CRUD.Services
{
    public class GameService(GamesDbContext _gamesDbContext, IMapper _mapper)
    {
        public GameOutputModel CreateGame(GameInputModel gameModel)
        {
            Game game = _mapper.Map<Game>(gameModel);
            _gamesDbContext.Games.Add(game);
            _gamesDbContext.SaveChanges();
            return _mapper.Map<GameOutputModel>(game);
        }

        public List<GameOutputModel>? GetGameList(GameSearchCriteria gameSearchCriteria)
        {
            IQueryable<Game> games = _gamesDbContext.Games.AsNoTracking().Where(g => g.Visable);
            if (gameSearchCriteria.GenreId.HasValue)
                games = games.Include(g => g.Genres).Include(g => g.Studios).Where(g => g.Visable && g.Genres!.Select(gnr => gnr.Id).Contains(gameSearchCriteria.GenreId.Value));
            return _mapper.Map<List<GameOutputModel>>(games.ToList());
        }

        public GameOutputModel UpdateGame(GameInputModel gameModel)
        {
            Game game = _gamesDbContext.Games.First(g => g.Visable && g.Id.Equals(gameModel.Id));
            Game modifiedGame = _mapper.Map<Game>(gameModel);
            game.Name = modifiedGame.Name;
            _gamesDbContext.Games.Update(game);
            _gamesDbContext.SaveChanges();
            return _mapper.Map<GameOutputModel>(game);
        }

        public GameOutputModel AddGenreGame(Guid gameId, Guid genreId)
        {
            Game game = _gamesDbContext.Games.First(g => g.Visable && g.Id.Equals(gameId));
            Genre genre = _gamesDbContext.Genres.First(g => g.Id.Equals(genreId));
            game.Genres ??= [];
            game.Genres.Add(genre);
            _gamesDbContext.SaveChanges();
            return _mapper.Map<GameOutputModel>(game);
        }

        public GameOutputModel AddStudioGame(Guid gameId, Guid studioId)
        {
            Game game = _gamesDbContext.Games.First(g => g.Visable && g.Id.Equals(gameId));
            Studio studio = _gamesDbContext.Studios.First(g => g.Id.Equals(studioId));
            game.Studios ??= [];
            game.Studios.Add(studio);
            _gamesDbContext.SaveChanges();
            return _mapper.Map<GameOutputModel>(game);
        }

        public GameOutputModel DeleteGame(Guid gameId)
        {
            Game game = _gamesDbContext.Games.First(g => g.Visable && g.Id.Equals(gameId));
            game.Visable = false;
            _gamesDbContext.SaveChanges();
            return _mapper.Map<GameOutputModel>(game);
        }
    }
}
