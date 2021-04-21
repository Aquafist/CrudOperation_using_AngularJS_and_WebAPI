using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Student_Info.Models;

namespace CrudOperation.api
{
    // Route 
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        // // StudentDBEntities object point
        StudentDBEntities dbContext = null;
        // Constructor 
        public StudentController()
        {
            // create instance of an object
            dbContext = new StudentDBEntities();
        }


        [ResponseType(typeof(StudentTable))]
        [HttpPost]
        public HttpResponseMessage SaveStudent(StudentTable astudent)
        {
            int result = 0;
            try
            {
                dbContext.StudentTables.Add(astudent);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [ResponseType(typeof(StudentTable))]
        [HttpPut]
        public HttpResponseMessage UpdateStudent(StudentTable astudent)
        {
            int result = 0;
            try
            {
                dbContext.StudentTables.Attach(astudent);
                dbContext.Entry(astudent).State = EntityState.Modified;
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [ResponseType(typeof(StudentTable))]
        [HttpDelete]
        public HttpResponseMessage DeleteStudent(int id)
        {
            int result = 0;
            try
            {
                var student = dbContext.StudentTables.Where(x => x.StudentID == id).FirstOrDefault();
                dbContext.StudentTables.Attach(student);
                dbContext.StudentTables.Remove(student);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("GetStudentByID/{studentID:int}")]
        [ResponseType(typeof(StudentTable))]
        [HttpGet]
        public StudentTable GetStudentByID(int studentID)
        {
            StudentTable astudent = null;
            try
            {
                astudent = dbContext.StudentTables.Where(x => x.StudentID == studentID).SingleOrDefault();

            }
            catch (Exception e)
            {
                astudent = null;
            }
            return astudent;
        }

        [ResponseType(typeof(StudentTable))]
        [HttpGet]
        public List<StudentTable> GetStudents()
        {
            List<StudentTable> students = null;
            try
            {
                students = dbContext.StudentTables.ToList();
            }
            catch (Exception e)
            {
                students = null;
            }
            return students;
        }
    }
}