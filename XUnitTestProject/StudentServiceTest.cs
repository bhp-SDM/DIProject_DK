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

            // List keeping the data of the mocked repository
            List<Student> data = new List<Student>();

            // The mock of the repository
            Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
            
            // Setup of the Add method of the Mock to work with the data list.
            mockRepository.Setup(r => r.Add(It.IsAny<Student>())).Callback<Student>(s => data.Add(s));
            
            // StudentService with injected mockRepository (remember to use .Object)
            StudentService service = new StudentService(mockRepository.Object);

            // the student to add
            Student student = new Student(1, "Name", "Email");

            // Act
            service.AddStudent(student);

            // Assert
            Assert.True(data.Count == 1); // one student inserted into the data list
            Assert.Equal(student, data[0]); // and it is indeed the right student !
            mockRepository.Verify(r => r.Add(student), Times.Once); // and the service is using the repository.Add

        }
    }
}