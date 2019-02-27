using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasCredits()
        {
            var tracker = new GraduationTracker();
            var diploma = Repository.GetDiploma(1);
            Student[] students = { Repository.GetStudent(1), Repository.GetStudent(2), Repository.GetStudent(3), Repository.GetStudent(4) };
            
            var graduated = new List<Tuple<bool, STANDING>>();

            foreach(var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));      
            }
            Assert.AreEqual(2, graduated.Where(g => !g.Item1 && g.Item2.Equals(STANDING.Remedial)).Count()); // only two students must have failed
            Assert.IsTrue(graduated[2].Item2.Equals(STANDING.SumaCumLaude) && graduated[3].Item2.Equals(STANDING.Average));

        }

        [TestMethod]
        public void TestStudentHasOptedForAllRequiredCourses()
        {
            var tracker = new GraduationTracker();
            var diploma = Repository.GetDiploma(2);
            Student student = Repository.GetStudent(5);

            Tuple<bool, STANDING> result = tracker.HasGraduated(diploma, student);
            Assert.AreEqual(new Tuple<bool, STANDING>(false, STANDING.Remedial), result);

        }

        [TestMethod]
        public void TestStudentHasOptedForAtLeastOneCourses()
        {
            var tracker = new GraduationTracker();
            var diploma = Repository.GetDiploma(2);
            Student student = Repository.GetStudent(5);

            Tuple<bool, STANDING> result = tracker.HasGraduated(diploma, student);
            Assert.AreEqual(new Tuple<bool, STANDING>(false, STANDING.Remedial), result);

        }
    }
}
