using AutoMapper;
using CRUD.Models;
using CRUD.Models.InputModels;
using CRUD.Models.OutputModels;
using Databases.DbContexts;
using Databases.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Services
{
    public class GameService(GamesDbContext _gamesDbContext, IMapper _mapper)
    {
        public async Task<GameOutputModel> CreateGameAsync(GameInputModel gameModel)
        {
            Game game = new Game()
            {
                Name = gameModel.Name,
                Visible = true
            };
            await _gamesDbContext.Games.AddAsync(game);
            await _gamesDbContext.SaveChangesAsync();
            return _mapper.Map<GameOutputModel>(game);
        }

        public async Task<List<GameOutputModel>> GetGameListAsync(GameSearchCriteria gameSearchCriteria)
        {
            IQueryable<Game> games = _gamesDbContext.Games.AsNoTracking().Where(g => g.Visible);
            if (gameSearchCriteria.GenreId.HasValue)
                games = games.Include(g => g.Genres).Include(g => g.Studios).Where(g => g.Visible && g.Genres!.Any(gnr => gnr.Id.Equals(gameSearchCriteria.GenreId.Value)));
            return _mapper.Map<List<GameOutputModel>>(await games.ToListAsync());
        }

        public async Task<GameOutputModel> UpdateGameAsync(GameInputModel gameModel)
        {
            Game game = _gamesDbContext.Games.First(g => g.Visible && g.Id.Equals(gameModel.Id));
            game.Name = gameModel.Name;
            _gamesDbContext.Games.Update(game);
            await _gamesDbContext.SaveChangesAsync();
            return _mapper.Map<GameOutputModel>(game);
        }

        public async Task<GameOutputModel> AddGenreGameAsync(Guid gameId, Guid genreId)
        {
            Game game = _gamesDbContext.Games.Include(g => g.Genres).First(g => g.Visible && g.Id.Equals(gameId));
            Genre genre = _gamesDbContext.Genres.First(g => g.Id.Equals(genreId));
            game.Genres.Add(genre);
            await _gamesDbContext.SaveChangesAsync();
            return _mapper.Map<GameOutputModel>(game);
        }

        public async Task<GameOutputModel> AddStudioGameAsync(Guid gameId, Guid studioId)
        {
            Game game = _gamesDbContext.Games.Include(g => g.Studios).First(g => g.Visible && g.Id.Equals(gameId));
            Studio studio = _gamesDbContext.Studios.First(g => g.Id.Equals(studioId));
            game.Studios.Add(studio);
            await _gamesDbContext.SaveChangesAsync();
            return _mapper.Map<GameOutputModel>(game);
        }

        public async Task<GameOutputModel> DeleteGameAsync(Guid gameId)
        {
            Game game = _gamesDbContext.Games.First(g => g.Visible && g.Id.Equals(gameId));
            game.Visible = false;
            await _gamesDbContext.SaveChangesAsync();
            return _mapper.Map<GameOutputModel>(game);
        }
    }
}
