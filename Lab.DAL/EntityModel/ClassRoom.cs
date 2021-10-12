using System.Collections.Generic;

namespace Lab.DAL.EntityModel
{
    public class ClassRoom
    {
        public int ClassRoomId { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<TeacherClassRoom> Teachers { get; set; }
    }
}