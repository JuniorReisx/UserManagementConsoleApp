namespace UserManagementConsoleApp
{
    // Classe para definir a estrutura dos usuários
    public class User
    {
        private static int _idCounter = 1;
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public int Age { get; }

        public User(string name, string email, int age)
        {
            Id = _idCounter++;
            Name = name;
            Email = email;
            Age = age;
        }
    }
}