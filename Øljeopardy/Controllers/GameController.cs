﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Oljeopardy.DataAccess;
using Oljeopardy.Models;
using Oljeopardy.Models.JeopardyViewModels;
using Microsoft.Extensions.Caching.Memory;

namespace Oljeopardy.Controllers
{
    public class GameController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameRepository _gameRepository;
        private IMemoryCache _cache;

        public GameController(ICategoryRepository categoryRepository, UserManager<ApplicationUser> userManager, IGameRepository gameRepository, IMemoryCache cache)
        {
            _categoryRepository = categoryRepository;
            _userManager = userManager;
            _gameRepository = gameRepository;
            _cache = cache;
        }

        public IActionResult Add()
        {
            ViewData["Title"] = "Start nyt spil";

            var userId = _userManager.GetUserId(HttpContext.User);
            var model = new AddGameViewModel()
            {
                CategoryList = _categoryRepository.GetCategoriesByUserId(userId)
            };

            return PartialView(model);
        }

        public IActionResult CompleteAdd(AddGameViewModel model)
        {

            var userId = _userManager.GetUserId(HttpContext.User);
            if (model != null && model.ChosenCategoryGuid != Guid.Empty)
            {
                _gameRepository.AddGame(model.GameName, model.ChosenCategoryGuid, userId);
            }

            return RedirectToAction("Game", "Home");
        }

        public IActionResult Participate()
        {
            ViewData["Title"] = "Deltag i et spil";
            var userId = _userManager.GetUserId(HttpContext.User);

            var model = new ParticipateGameViewModel()
            {
                GameList = _gameRepository.GetActiveGames(),
                CategoryList = _categoryRepository.GetCategoriesByUserId(userId)
            };

            return PartialView(model);
        }

        public IActionResult CompleteParticipation(ParticipateGameViewModel model)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            _gameRepository.AddParticipant(model.ChosenGameGuid, model.ChosenCategoryGuid, Enums.TurnType.Guess, userId);
            _gameRepository.IncrementGameVersion(model.ChosenGameGuid);

            return RedirectToAction("Game", "Home");
        }

        public IActionResult SelectWinner(GameViewModel model)
        {
            try
            {
                if (model.ChosenWinnerId != null && model.Game != null)
                {
                    var userId = _userManager.GetUserId(HttpContext.User);
                    _gameRepository.SetAnswerQuestionWinner(model.ChosenWinnerId, model.Game.Id, userId);
                    _gameRepository.IncrementGameVersion(model.Game.Id);
                    return RedirectToAction("Game", "Home");
                }
                throw new Exception("No winner was chosen");
            }
            catch
            {
                throw new Exception("Could not submit winner");
            }
        }

        public IActionResult SelectAnswer(GameViewModel model)
        {
            try
            {
                if (model.ChosenAnswerQuestionGuid != null && model.Game != null)
                {
                    var userId = _userManager.GetUserId(HttpContext.User);
                    _gameRepository.SetSelectedAnswerQuestion(model.Game.Id, userId, model.ChosenAnswerQuestionGuid);
                    _gameRepository.IncrementGameVersion(model.Game.Id);
                    return RedirectToAction("Game", "Home");
                }
                throw new Exception("No answer selected");
            }
            catch
            {
                throw new Exception("Could not submit AnswerQuestion selection");
            }
        }

        public IActionResult EatYourNote()
        {
            try
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                var game = _gameRepository.GetActiveGameForUser(userId);
                if (game != null && game.SelectedAnswerQuestionId != null)
                {
                    _gameRepository.SubmitEatYourNote(game.Id, userId, game.SelectedAnswerQuestionId.Value);
                }
                if (_gameRepository.AllEatYourNotesPressed(game.Id, game.SelectedAnswerQuestionId.Value))
                {
                    _gameRepository.ExecuteEatYourNote(game.Id, game.SelectedAnswerQuestionId.Value);
                    _gameRepository.IncrementGameVersion(game.Id);
                }
                return Ok();
            }
            catch
            {
                throw new Exception("Could not submit Eat Your Note");
            }
        }


        [HttpGet]
        [Route("checkIfGameChanged")]
        public IActionResult CheckIfGameChanged()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var game = _gameRepository.GetActiveGameForUser(userId);

            var cachedVersion = _cache.Get("GameVersion:" + userId);

            if (cachedVersion != null)
            {
                if (game != null && cachedVersion != null && (cachedVersion.ToString() != game.Version.ToString()))
                {
                    return Ok(true);
                }
            }
            return Ok(false);            
        }


    }
}