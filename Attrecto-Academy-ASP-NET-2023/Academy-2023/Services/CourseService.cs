using Academy_2023.Data;
using Academy_2023.Dto;
using Academy_2023.Repositories;

namespace Academy_2023.Services
{
    public class CourseService: ICourseService
    {

        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<CourseDto> GetAll()
        {
            var courses = _courseRepository.GetAll();

            return courses.Select(MapToDto);
        }

        public CourseDto? GetById(int id)
        {
            var course = _courseRepository.GetById(id);

            return course == null ? null : MapToDto(course);
        }

        public void Create(CourseDto courseDto)
        {
            _courseRepository.Create(MapToEntity(courseDto));
        }

        public Course? Update(int id, CourseDto courseDto)
        {
            var course = _courseRepository.GetById(id);

            if (course != null)
            {
                course.Title = courseDto.Title;
                course.Description = courseDto.Description;
                course.Url = courseDto.Url;

                _courseRepository.Update();

            }
            return course;

        }
        public bool Delete(int id)
        {
            return _courseRepository.Delete(id);
        }

        private CourseDto MapToDto(Course course) => new CourseDto { Id = course.Id, Title = course.Title, Description = course.Description, Url = course.Url};

        private Course MapToEntity(CourseDto courseDto) => new Course { Id = courseDto.Id, Title = courseDto.Title, Description = courseDto.Description, Url = courseDto.Url};
    }
}
