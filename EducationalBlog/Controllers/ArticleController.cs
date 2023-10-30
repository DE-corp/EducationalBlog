using AutoMapper;
using EducationalBlog.Contracts.Models.Articles;
using EducationalBlog.Data.Models;
using EducationalBlog.Data.Models.UpdateModels;
using EducationalBlog.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EducationalBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        public IUserRepository _user;
        public IArticleRepository _article;
        public IMapper _mapper;
        public ArticleController(IArticleRepository article, IUserRepository user, IMapper mapper)
        {
            _article = article;
            _mapper = mapper;
            _user = user;
        }


        /// <summary>
        /// Получаем все статьи
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllArticles")]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _article.GetArticles();

            var resp = new GetArticlesResponse
            {
                ArticlesCount = articles.Length,
                articleViews = _mapper.Map<Article[], ArticleView[]>(articles)
            };

            return StatusCode(200, resp);
        }


        /// <summary>
        /// Создать статью
        /// </summary>
        /// <param name="reqest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateArticle")]
        public async Task<IActionResult> CreateArticle(AddArticleReqest reqest)
        {
            var user = await _user.GetUserById(reqest.Id);
            if (user != null)
                return StatusCode(400, $"Пользователь {user.FirstName} уже существует!");

            var newArticle = _mapper.Map<AddArticleReqest, Article>(reqest);
            await _article.CreateArticle(newArticle, user);

            return StatusCode(200, newArticle);
        }

        /// <summary>
        /// Получить статью по ID
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetArticleById")]
        public async Task<IActionResult> GetArticleById(AddArticleReqest article)
        {
            var verifiableArticle = await _article.GetArticleById(article.Id);

            return StatusCode(200, verifiableArticle);
        }


        /// <summary>
        /// Изменить статью
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("UpdateArticle")]
        public async Task<IActionResult> UpdateArticle(
            [FromRoute] Guid Id,
            [FromBody] EditArticleRequest request
            )
        {
            var user = _user.GetUserById(Id);
            if (user == null)
                return StatusCode(400, "Пользователь не найден!");

            var article = _article.GetArticleById(Id);
            if (article == null)
                return StatusCode(400, "Статья не найдена");

            var updateArticle = _article.UpdateArticle(
                await article,
                await user,
                new UpdateArticleModel(request.NewArticleName, request.NewArticleContext));

            return StatusCode(200, updateArticle);
        }


        /// <summary>
        /// Удалить статью
        /// </summary>
        /// <param name="reqest"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteArticle")]
        public async Task<IActionResult> DeleteArticle(AddArticleReqest reqest)
        {
            var article = _article.GetArticleById(reqest.Id);
            if (article == null)
                return StatusCode(400, "Статья не найдена!");

            var deliteArticle = _article.DeleteArticle(await article);

            return StatusCode(200, deliteArticle);
        }
    }
}
