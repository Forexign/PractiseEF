using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEST_EF.Models;

namespace TEST_EF.Controllers
{
    public class StudentController : Controller
    {
        private readonly RankenContext _context;

        public StudentController(RankenContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Courses = await _context.Courses.ToListAsync();
            return View(await _context.Students.ToListAsync());
        }
        public async Task<IActionResult> ChangeCourse(int courseId)
        {
            List<Student> studentInCourse;
            ViewBag.Courses = await _context.Courses.ToListAsync();
            ViewBag.SelectedCourse = courseId;

            if(courseId != 0)
            {
                studentInCourse = await _context.Students.Where(s => s.Courses.Any(c => c.Id == courseId)).ToListAsync();
            }
            else
            {
                studentInCourse = await _context.Students.ToListAsync();
            }
            return View("Index", studentInCourse);

        }

        [HttpGet]
        public async Task<IActionResult> EnrollNewStudent()
        {
            ViewBag.Courses = await _context.Courses.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnrollNewStudent(Student student, string[] enrolledCourses)
        {
            if(enrolledCourses != null)
            {
                foreach (var courseId in enrolledCourses)
                {
                    var c = await _context.Courses.FindAsync(int.Parse(courseId));
                    student.Courses.Add(c);
                }
            }
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            ViewBag.Courses = await _context.Courses.ToListAsync();
            var students = await _context.Students.ToListAsync();
            return RedirectToAction("Index",students);
        }
        [HttpGet]
        public async Task<IActionResult> ChangeEnrollment(int id)
        {
            var student = await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == id);
            ViewBag.Courses = await _context.Courses.ToListAsync();
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> ModifyStudentEnrolledCourses(Student student, string[] enrolledCourses)
        {
            var studentToUpdate = await _context.Students.Where(s => s.Id == student.Id).Include(s => s.Courses).FirstOrDefaultAsync();
            studentToUpdate.Courses.Clear();
            if (enrolledCourses != null)
            {
                foreach (var courseId in enrolledCourses)
                {
                    var c = await _context.Courses.FindAsync(int.Parse(courseId));
                    studentToUpdate.Courses.Add(c);
                }
            }

            await _context.SaveChangesAsync();
            ViewBag.Courses = await _context.Courses.ToListAsync();
            var students = await _context.Students.ToListAsync();
            return View("Index", students);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteStudent(Student s)
        {
            var student = await _context.Students.Where(st => st.Id == s.Id).Include(st => st.Courses).FirstOrDefaultAsync();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            ViewBag.Courses = await _context.Courses.ToListAsync();
            var students = await _context.Students.ToListAsync();
            return View("Index", students);
        }
    }
}
