using DIProject_DK.Interfaces;
using DIProject_DK.Model;
using DIProject_DK.Service;
using Moq;

namespace XUnitTestProject
{
    public class StudentServiceTest
    {
        [Fact]
        public void CreateStudentService()
        {
            // Arrange
            Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
            
            // Act
            StudentService s = new StudentService(mockRepository.Object);

            // Assert
            Assert.NotNull(s);
            Assert.True(s is StudentService);
        }

        [Fact]
        public void AddValidStudent()
        {   
            // Arrange
            List<Student> data = new List<Student>();
            Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(r => r.Add(It.IsAny<Student>())).Callback<Student>(s => data.Add(s));
            
            StudentService service = new StudentService(mockRepository.Object);

            Student student = new Student(1, "Name", "Email");

            // Act
            service.AddStudent(student);

            // Assert
            Assert.True(data.Count == 1);
            Assert.Equal(student, data[0]);
            mockRepository.Verify(r => r.Add(student), Times.Once);
        }
    }
}