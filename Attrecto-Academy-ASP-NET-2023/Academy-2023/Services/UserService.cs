using Academy_2023.Data;
using Academy_2023.Dto;
using Academy_2023.Repositories;

namespace Academy_2023.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _userRepository.GetAll();

            return users.Select(MapToDto);
        }

        public UserDto? GetById(int id)
        {
            var user = _userRepository.GetById(id);

            return user == null ? null : MapToDto(user);
        }

        public void Create(UserDto userDto)
        {
            _userRepository.Create(MapToEntity(userDto));
        }

        public User? Update(int id, UserDto userDto)
        {
            var user = _userRepository.GetById(id);

            if (user != null)
            {
                user.Email = userDto.Email;
                user.Password = userDto.Password;
                user.Name = userDto.Name;
                user.Role = userDto.Role;

                _userRepository.Update();
            }

            return user;
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        private UserDto MapToDto(User user) => new UserDto { Id = user.Id, Email = user.Email, Password = user.Password, Name = user.Name, Role = user.Role };

        private User MapToEntity(UserDto userDto) => new User { Id = userDto.Id, Email = userDto.Email, Password = userDto.Password, Name = userDto.Name, Role = userDto.Role };
    }
}
