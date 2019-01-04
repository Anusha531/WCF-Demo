using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity;

namespace WCFDemo.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
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

        public Courses Update(Courses courses)
        {
            using (UniversityContext universityContext = new UniversityContext())
            {
                var courseInDB = universityContext.Courses.Find(courses.CourseID);

                courseInDB.Credits = courses.Credits;
                courseInDB.Title = courses.Title;


                universityContext.Entry(courseInDB).State = EntityState.Modified;
                universityContext.SaveChanges();                
            }

            return courses;

        }

        public Courses Add(Courses courses)
        {
            using (UniversityContext universityContext = new UniversityContext())
            {
                var courseInDB = universityContext.Courses.Find(courses.CourseID);

                if (courseInDB == null)
                {
                    var itemToAdd = new Course();
                    itemToAdd.Credits = courses.Credits;
                    itemToAdd.Title = courses.Title;
                    itemToAdd.DepartmentID = 4;

                    universityContext.Entry(itemToAdd).State = EntityState.Added;
                    universityContext.SaveChanges();

                    courses.CourseID = itemToAdd.CourseID;
                }
            }

            return courses;
        }
    }
}
