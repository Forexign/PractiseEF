﻿namespace TEST_EF.Models
{
    public class Student
    {
        public Student()
        {
            Courses = new List<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string FinancialAidStatus { get; set; }
        public List<Course> Courses { get; set; }
    }
}
