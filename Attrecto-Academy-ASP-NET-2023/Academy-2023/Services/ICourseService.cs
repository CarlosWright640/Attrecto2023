using Academy_2023.Data;
using Academy_2023.Dto;

namespace Academy_2023.Services
{
    public interface ICourseService
    {
        void Create(CourseDto courseDto);
        bool Delete(int id);
        IEnumerable<CourseDto> GetAll();
        CourseDto? GetById(int id);
        Course? Update(int id, CourseDto courseDto);
    }
}
