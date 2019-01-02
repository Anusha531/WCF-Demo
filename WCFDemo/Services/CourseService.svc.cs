using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFDemo.Services
{   
    public class CourseService : ICourseService
    {
        public IEnumerable<Courses> GetAll()
        {
            List<Courses> courses = new List<Courses>();

            using (UniversityContext universityContext = new UniversityContext())
            {
                var course = universityContext.Courses.ToList();

                courses = Converters.CoursesConverter.ConvertToEntities(course).ToList();
            }

            return courses;
        }

        public Courses Get(int CourseID)
        {
            Courses courses = new Courses();

            using (UniversityContext universityContext = new UniversityContext())
            {
                var course = universityContext.Courses.Find(CourseID);

                courses = Converters.CoursesConverter.ConvertToEntity(course);
            }

            return courses;

        }
    }
}
