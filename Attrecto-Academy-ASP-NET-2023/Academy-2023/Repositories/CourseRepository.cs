using Academy_2023.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2023.Repositories
{
    public class CourseRepository
    {
        public static List<Course> Courses = new List<Course>();

        public IEnumerable<Course> GetAll()
        {
            return Courses;
        }

        public Course? GetById(int id)
        {
            foreach (var course in Courses)
            {
                if (course.Id == id)
                {
                    return course;
                }
            }

            return null;
        }

        public void Create(Course data)
        {
            Courses.Add(data);
        }

        public Course? Update(int id, Course data)
        {
            foreach (var course in Courses)
            {
                if (course.Id == id)
                {
                    course.FirstName = data.FirstName;
                    course.LastName = data.LastName;
                    course.Description = data.Description;

                    return course;
                }
            }

            return null;
        }


        public bool Delete(int id)
        {
            foreach (var course in Courses)
            {
                if (course.Id == id)
                {
                    Courses.Remove(course);

                    return true;
                }
            }

            return false;
        }
    }
}
