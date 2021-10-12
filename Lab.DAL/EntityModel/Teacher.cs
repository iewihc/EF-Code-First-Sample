using System.Collections.Generic;

namespace Lab.DAL.EntityModel
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SchooldId { get; set; }
        public School School { get; set; }
    }
}