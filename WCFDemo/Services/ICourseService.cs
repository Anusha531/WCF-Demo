using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFDemo.Services
{
    [ServiceContract]
    public interface ICourseService
    {
        [OperationContract]
        IEnumerable<Courses> GetAll();

        [OperationContract]
        Courses Get(int CourseID);

    }

    [DataContract]
    public class Courses
    {
        [DataMember]
        public int CourseID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Credits { get; set; }
    }
}
