﻿namespace SchoolManagementSystemAPI.Entities
{
    public class Student
    {
        public int StudentId {  get; set; }
        public  string? FirstName {  get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth {  get; set; }
        public int? ClassId {  get; set; }
    }
}
