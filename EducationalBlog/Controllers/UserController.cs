using AutoMapper;
using EducationalBlog.Contracts.Models.User;
using EducationalBlog.Data.Models;
using EducationalBlog.Data.Models.UpdateModels;
using EducationalBlog.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EducationalBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        IUserRepository _user;
        IMapper _mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            _user = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получаем всех пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _user.GetAllUsers();

            var resp = new GetUserResponse
            {
                UsersCount = user.Length,
                UserView = _mapper.Map<User[], UserView[]>(user)
            };

            return StatusCode(200, resp);
        }

        /// <summary>
        /// Получаем пользователя по ID
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetUserById(UserRequest request)
        {
            var user = await _user.GetUserById(request.Id);
            if (user == null)
            {
                return StatusCode(400, "Такой пользователь не найден!");
            }
            else
            {
                return StatusCode(200, user);
            }
        }

        /// <summary>
        /// Добавляем пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUser(UserRequest request)
        {
            var user = await _user.GetUserById(request.Id);
            if (user != null)
                return StatusCode(400, "Такой пользователь уже существует");

            var resalt = _mapper.Map<UserRequest, User>(request);
            await _user.CreateUser(user);

            return StatusCode(200, resalt);
        }


        /// <summary>
        /// Изменяем пользователя
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("")]
        public async Task<IActionResult> UpdateUser(
            [FromRoute] Guid Id,
            [FromBody] EditUserRequest request)
        {
            var user = _user.GetUserById(request.Id);
            if (user == null)
                return StatusCode(400, "Такой пользователь не существует!");

            var updateUser = _user.UpdateUser(
                await user,
                new UpdateUserModel(
                    request.NewFirstName,
                    request.NewLastName,
                    request.NewEmail,
                    request.NewPassword,
                    request.NewLogin));

            return StatusCode(200, updateUser);
        }


        /// <summary>
        /// Удаляем пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeliteUser(UserRequest request)
        {
            var user = await _user.GetUserById(request.Id);
            if (user == null)
                return StatusCode(400, "Пользователь не найден!");

            var delUser = _user.DeleteUser(user);

            return StatusCode(200, delUser);
        }
    }
}
