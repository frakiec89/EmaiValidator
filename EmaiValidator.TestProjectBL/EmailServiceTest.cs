using EmaiValidator.BL;

namespace EmaiValidator.TestProjectBL
{
    public class EmailServiceTest
    {
        EmailService service;

        [SetUp]
        public void Setup()
        {
            service = new EmailService();
        }

        [Test]
        public void IsTryEmaiTest_Trye()
        {
            //arrange 
            string em = "rishat-rus@mai.ru";
            bool expected = true;
            // act 
            var actual = service.IsTryEmai(em);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("")] // ����� 
        [TestCase(" ")] // ������� 
        [TestCase(" / /b")] // �����  ��  ����� 
        [TestCase(" test@mail.ru")] // ������� 
        [TestCase("test@mail.ru ")]
        [TestCase("test @mail.ru")]
        [TestCase("test@mail .ru")]
        [TestCase("test@mail. ru")]
        [TestCase("testmail.ru")]   // ������� 
        [TestCase("test@mailru")]   // ����� 
        [TestCase("test@mail,ru")]
        [TestCase("test!mail.ru")]
        public void IsTryEmaiTest_False(string em)
        {
            //arrange 
            bool expected = true;
            // act 
            var actual = service.IsTryEmai(em);
            Assert.AreEqual(expected, actual);
        }

    }
}