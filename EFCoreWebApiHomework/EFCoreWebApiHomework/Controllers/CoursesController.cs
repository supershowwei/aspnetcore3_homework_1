using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreWebApiHomework.Models;

namespace EFCoreWebApiHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ContosoUniversityContext _context;

        public CoursesController(ContosoUniversityContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
        {
            return await _context.Course.Where(x => !x.IsDeleted).ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Course.SingleOrDefaultAsync(x => x.CourseId.Equals(id) && !x.IsDeleted);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            var isExisted = await _context.Course.AnyAsync(x => x.CourseId.Equals(id) && !x.IsDeleted);
            if (!isExisted)
            {
                return this.NotFound();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            var course = await _context.Course.SingleOrDefaultAsync(x => x.CourseId.Equals(id) && !x.IsDeleted);
            if (course == null)
            {
                return NotFound();
            }

            course.IsDeleted = true;

            await _context.SaveChangesAsync();

            return course;
        }

        [HttpGet("all-students")]
        public async Task<ActionResult<IEnumerable<VwCourseStudents>>> Students()
        {
            return await _context.VwCourseStudents.ToListAsync();
        }

        [HttpGet("{id:int}/students")]
        public async Task<ActionResult<IEnumerable<VwCourseStudents>>> Students(int id)
        {
            return await _context.VwCourseStudents.Where(x => x.CourseId.Equals(id)).ToListAsync();
        }

        [HttpGet("all-student-count")]
        public async Task<ActionResult<IEnumerable<VwCourseStudentCount>>> StudentCount()
        {
            return await _context.VwCourseStudentCount.ToListAsync();
        }

        [HttpGet("{id:int}/student-count")]
        public async Task<ActionResult<VwCourseStudentCount>> StudentCount(int id)
        {
            var studentCount = await _context.VwCourseStudentCount.SingleOrDefaultAsync(x => x.CourseId.Equals(id));

            if (studentCount == null) return this.NotFound();

            return studentCount;
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.CourseId == id);
        }
    }
}
