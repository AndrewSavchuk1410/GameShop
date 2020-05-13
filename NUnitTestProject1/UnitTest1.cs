using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using GameShop.Controllers;
using Microsoft.EntityFrameworkCore.Internal;
using EntityFrameworkCore3Mock;
using System.Linq;
using System;
using GameShop.Models;

namespace GameShop.Tests
{
    public class Tests
    {
        public DbContextOptions<GameShopContext> DummyOptions { get; } = new DbContextOptionsBuilder<GameShopContext>().Options;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void add()
        {
            var initialEntities = new[]
                {
                new Games { Id = 1, Name = "Game 1", Info = "Nu da, a sho", Engine = "Engine 1", GenresId = 1},
                new Games { Id = 2, Name = "Game 2", Info = "Info about Game 2 ", Engine = "Engine 2", GenresId = 1},
            };

            var dbContextMock = new DbContextMock<GameShopContext>(DummyOptions);
            var gamesDbSetMock = dbContextMock.CreateDbSetMock(x => x.Games, initialEntities);

            GamesController mc = new GamesController(dbContextMock.Object);
            _ = mc.PostGames(new Games { Id = 3, Name = "Game 3", Info = "Info 3", Engine = "Engine 3", GenresId = 1 });

            Assert.IsTrue(dbContextMock.Object.Games.Any(g => g.Name == "Game 3"));
        }


        [Test]
        public void addSameName()
        {
            var initialEntities = new[]
                {
                new Games { Id = 1, Name = "Game 1", Info = "Nu da, a sho", Engine = "Engine 1", GenresId = 1},
                new Games { Id = 2, Name = "Game 2", Info = "Info about Game 2 ", Engine = "Engine 2", GenresId = 1},
            };

            var dbContextMock = new DbContextMock<GameShopContext>(DummyOptions);
            var gamesDbSetMock = dbContextMock.CreateDbSetMock(x => x.Games, initialEntities);

            GamesController mc = new GamesController(dbContextMock.Object);
            _ = mc.PostGames(new Games { Id = 3, Name = "Game 2", Info = "Info 3", Engine = "Engine 3", GenresId = 1 });

            Assert.AreEqual(dbContextMock.Object.Games.Count(g => g.Name == "Game 2"), 1);
        }


        [Test]
        public void addEmpty()
        {
            var initialEntities = new[]
                {
                new Genres { Id = 1, Name = "Genre 1", Info = "Nu da, a sho" },
                new Genres { Id = 2, Name = "Genre 2", Info = "Info about Genre 2 "},
            };

            var dbContextMock = new DbContextMock<GameShopContext>(DummyOptions);
            var gamesDbSetMock = dbContextMock.CreateDbSetMock(x => x.Genres, initialEntities);

            GenresController mc = new GenresController(dbContextMock.Object);
            _ = mc.PostGenres(new Genres { Id = 3, Name = "", Info = "Info 3" });

            Assert.IsFalse(dbContextMock.Object.Genres.Any(g => g.Name == ""));
        }


        [Test]
        public void Delete()
        {
            var initialEntities = new[]
                {
                new Games { Id = 1, Name = "Game 1", Info = "Nu da, a sho", Engine = "Engine 1", GenresId = 1 },
                new Games { Id = 2, Name = "Game 2", Info = "Info about Game 2 ", Engine = "Engine 2", GenresId = 1},
            };

            var dbContextMock = new DbContextMock<GameShopContext>(DummyOptions);
            var gamesDbSetMock = dbContextMock.CreateDbSetMock(x => x.Games, initialEntities);

            GamesController mc = new GamesController(dbContextMock.Object);
            _ = mc.PostGames(new Games { Id = 3, Name = "Game 3", Info = "Info 3", Engine = "Engine 3", GenresId = 1 });
            _ = mc.DeleteGames(3);

            Assert.IsFalse(dbContextMock.Object.Games.Any(m => m.Name == "Game 3"));
        }
    }


}