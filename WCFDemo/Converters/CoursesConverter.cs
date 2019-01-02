using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFDemo.Services;

namespace WCFDemo.Converters
{
    public static class CoursesConverter
    {
        public static Courses ConvertToEntity(Course course)
        {
            Courses courses = new Courses
            {
                CourseID = course.CourseID,
                Credits = course.Credits,
                Title = course.Title
            };

            return courses;
        }

        public static IEnumerable<Courses> ConvertToEntities(IEnumerable<Course> course)
        {
            var courses = new List<Courses>();

            foreach(var item in course)
            {
                courses.Add(ConvertToEntity(item));
            }

            return courses;
        }
    }
}