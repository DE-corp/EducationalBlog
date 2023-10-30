using AutoMapper;
using EducationalBlog.Contracts.Models.Articles;
using EducationalBlog.Contracts.Models.Comments;
using EducationalBlog.Contracts.Models.User;
using EducationalBlog.Data.Models;
using EducationalBlog.Data.Models.UpdateModels;
using EducationalBlog.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EducationalBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private IMapper _mapper;
        private ICommentRepository _comment;
        private IUserRepository _user;
        private IArticleRepository _article;

        public CommentController(IMapper mapper, ICommentRepository comment, IUserRepository user)
        {
            _mapper = mapper;
            _comment = comment;
            _user = user;
        }



        /// <summary>
        /// Добавляем комментарий
        /// </summary>
        /// <param name="reqest"></param>
        /// <param name="userRequest"></param>
        /// <param name="articlesReqest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateComment")]
        public async Task<IActionResult> CreateComment([FromBody]AddCommentReqest reqest, [FromQuery]UserRequest userRequest, [FromQuery]AddArticleReqest articlesReqest)
        {
            var user = _user.GetUserById(userRequest.Id);
            if (user == null)
                return StatusCode(400, "Пользователь не найден!");

            var comment = _comment.GetCommentById(userRequest.Id);
            if (comment != null)
                return StatusCode(400, "Такой комментарий уже существует!");

            var article = _article.GetArticleById(articlesReqest.Id);
            if (article == null)
                return StatusCode(400, "Такая статья не найдена!");

            var newComment = _mapper.Map<AddCommentReqest, Comment>(reqest);
            await _comment.CreateComment(newComment, await user, await article);

            return StatusCode(200, newComment);
        }




        /// <summary>
        /// Обновление комментария
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="reqest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateComment")]
        public async Task<IActionResult> UpdateComment(
            [FromRoute] Guid Id,
            [FromBody] EditCommentReqest reqest)
        {

            var comment = _comment.GetCommentById(Id);
            if (comment == null)
                return StatusCode(400, "Такой комментарий не существует!");

            var updateComment = _comment.UpdateComment(
                await comment,
                new UpdateCommentModel(reqest.NewContent));

            return StatusCode(200, updateComment);
        }


        /// <summary>
        /// Метод для удаления комментария
        /// </summary>
        /// <param name="reqest"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteComment")]
        public async Task<IActionResult> DeleteComment(AddCommentReqest reqest)
        {
            var comment = _comment.GetCommentById(reqest.Id);
            if (comment == null)
                return StatusCode(400, "Такой комментарий не найден!");

            var deleteComment = _comment.DeleteComment(await comment);

            return StatusCode(200, deleteComment);
        }



        /// <summary>
        /// Мтод для получения всех комментариев
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllComments")]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _comment.GetAllComments();

            var rasp = new GetCommentsResponse
            {
                CommentAmount = comments.Length,
                commentViews = _mapper.Map<Comment[], CommentView[]>(comments)
            };

            return StatusCode(200, rasp);
        }


        /// <summary>
        /// Метод для получения комментария по Id
        /// </summary>
        /// <param name="reqest"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCommentById")]
        public async Task<IActionResult> GetCommentById(AddCommentReqest reqest)
        {
            var comment = await _comment.GetCommentById(reqest.Id);
            if (comment == null)
                return StatusCode(400, "Комментарий не найден!");

            return StatusCode(200, comment);
        }
    }
}
