using Academy_2023.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2023.Repositories
{
    public class CourseRepository
    {
        public static List<Course> Courses = new List<Course>();
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Course data)
        {
            _context.Courses.Add(data);

            _context.SaveChanges();
        }

        public Course? Update(int id, Course data)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);

            if (course != null)
            {
                course.Title = data.Title;
                course.Description = data.Description;
                course.Url = data.Url;

                _context.SaveChanges();
            }

            return course;
        }


        public bool Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);

            if (course != null)
            {
                _context.Courses.Remove(course);

                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
