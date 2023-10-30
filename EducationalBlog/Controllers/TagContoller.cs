using AutoMapper;
using EducationalBlog.Contracts.Models.Tags;
using EducationalBlog.Data.Models;
using EducationalBlog.Data.Models.UpdateModels;
using EducationalBlog.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EducationalBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TegContoller : ControllerBase
    {
        ITagRepository _tag;
        IArticleRepository _article;
        IMapper _mapper;

        public TegContoller(ITagRepository tag, IArticleRepository article, IMapper mapper)
        {
            _tag = tag;
            _article = article;
            _mapper = mapper;
        }



        /// <summary>
        /// Метод для получения всех тегов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            var teg = await _tag.GetTagArray();

            var resp = new GetTagsResponse
            {
                TegAmount = teg.Length,
                TagViews = _mapper.Map<Tag[], TagView[]>(teg)
            };

            return StatusCode(200, resp);
        }


        /// <summary>
        /// Метод для получения тега по Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTagById")]
        public async Task<IActionResult> GetTagById(AddTagRequest request)
        {
            var tag = await _tag.GetTagById(request.Id);
            if (tag == null)
            {
                return StatusCode(400, "Такого тега не существует!");
            }
            else
            {
                return StatusCode(200, tag);
            }
        }


        /// <summary>
        /// Метод для создания нового тега
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateTag")]
        public async Task<IActionResult> CreateTag(AddTagRequest request)
        {
            var teg = _tag.GetTagById(request.Id);
            if (teg == null)
                return StatusCode(400, "Такой тег не найден!");

            var newTeg = _tag.CreateTag(await teg);

            return StatusCode(200, newTeg);
        }


        /// <summary>
        /// Метод для удаления тега
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteTag")]
        public async Task<IActionResult> DeleteTag(AddTagRequest request)
        {
            var tag = _tag.GetTagById(request.Id);
            if (tag == null)
                return StatusCode(400, "Такой тег не найден!");

            var delTag = _tag.DeleteTag(await tag);

            return StatusCode(200, delTag);
        }


        /// <summary>
        /// Метод для обновления тега
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("UpdateTag")]
        public async Task<IActionResult> UpdateTag(
            [FromRoute] Guid Id,
            [FromBody] EditTagRequest request)
        {
            var tag = _tag.GetTagById(Id);
            if (tag == null)
                return StatusCode(400, "Такой тег не существует");

            var updateTag = _tag.UpdateTag(
                await tag,
                new UpdateTagModel(request.NewValue));

            return StatusCode(200, updateTag);
        }
    }
}
