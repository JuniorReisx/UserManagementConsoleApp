using System;
using System.Collections.Generic;
using System.Linq;

namespace UserManagementConsoleApp
{
    public class Program
    {
        // Lista para armazenar os usuários cadastrados.
        private static List<User> userList = new List<User>();

        public static void Main(string[] args)
        {
            // Inicia o menu principal
            MainMenu();
        }

        // Função para mostrar o menu principal
        static void MainMenu()
        {
            // Mostra o menu até que o usuário escolha uma opção válida.
            while (true)
            {
                Console.Clear();
                Console.WriteLine("+---------------------------+");
                Console.WriteLine("| 1 - Cadastrar usuário     |");
                Console.WriteLine("| 2 - Lista de usuários     |");
                Console.WriteLine("| 3 - Procurar usuários     |");
                Console.WriteLine("| 4 - Deletar usuário       |");
                Console.WriteLine("| 5 - Sair                  |");
                Console.WriteLine("+---------------------------+");
                Console.Write("Escolha uma opção (apenas números):");
                string response = Console.ReadLine();

                // Tenta transformar a entrada do usuário em um número inteiro. Se falhar, reinicia o loop.
                if (!int.TryParse(response, out int option))
                {
                    Console.WriteLine("Erro: Oops... Só aceitamos números. Tente novamente.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        RegisterUser();
                        break;
                    case 2:
                        ListUsers();
                        break;
                    case 3:
                        SearchUser();
                        break;
                    case 4:
                        DeleteUser();
                        break;
                    case 5:
                        Console.WriteLine("Tchau! Espero te ver em breve : )");
                        return;
                    default:
                        Console.WriteLine("Essa opção não é válida. Tente novamente.");
                        break;
                }
            }
        }

        // Método para cadastrar um novo usuário
        static void RegisterUser()
        {
            // Limpa o console
            Console.Clear();
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("| Cadastrar Usuários        |");
            Console.WriteLine("+---------------------------+");

            // Solicita o nome do usuário
            Console.Write("Nome: ");
            string name = Console.ReadLine();

            string email = "";
            while (true)
            {
                // Solicita o e-mail do usuário
                Console.Write("E-mail: ");
                email = Console.ReadLine();

                // Valida o formato do e-mail (deve conter '@')
                if (!email.Contains("@"))
                {
                    Console.WriteLine("Erro: O e-mail não está no formato correto '@'. Tente novamente.");
                }
                else
                {
                    break;
                }
            }

            int age;
            while (true)
            {
                // Solicita a idade do usuário
                Console.Write("Idade: ");
                string input = Console.ReadLine();

                // Verifica se a idade é um número inteiro
                if (int.TryParse(input, out age))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Erro: A idade deve ser um número e inteiro. Tente novamente.");
                }
            }

            // Instancia o usuário
            var user = new User(name, email, age);

            // Adiciona o usuário à lista de usuários
            userList.Add(user);
            Console.WriteLine($"Usuário cadastrado com sucesso! ID: {user.Id}");
            WaitForKeyPress();  // Chama o novo método para esperar pela tecla
        }

        // Método para listar todos os usuários cadastrados
        static void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("| Lista dos Usuários        |");
            Console.WriteLine("+---------------------------+");

            // Verifica se tem usuários cadastrados.
            if (userList.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
            }
            else
            {
                // Mostra os dados de todos os usuários cadastrados.
                foreach (var user in userList)
                {
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine($"| ID: {user.Id}  Nome: {user.Name}");
                    Console.WriteLine($"| E-mail: {user.Email}   Idade: {user.Age}");
                    Console.WriteLine("+---------------------------+");
                }
            }

            WaitForKeyPress();  // Chama o novo método para esperar pela tecla
        }

        // Método para buscar um usuário pelo nome
        static void SearchUser()
        {
            Console.Clear();
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("| Buscar Usuário            |");
            Console.WriteLine("+---------------------------+");

            // Solicita o nome do usuário a ser buscado.
            Console.Write("Digite o nome do usuário: ");
            string search = Console.ReadLine();

            // Realiza a busca por nome.
            var result = userList.FindAll(u => u.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("| Resultados encontrados:   |");
            Console.WriteLine("+---------------------------+");

            // Verificar se encontrou algum usuário.
            if (result.Count == 0)
            {
                Console.WriteLine("Nenhum usuário encontrado.");
            }
            else
            {
                // Mostrar os dados dos usuários encontrados.
                foreach (var user in result)
                {
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine($"| Nome: {user.Name}        ");
                    Console.WriteLine($"| E-mail: {user.Email}     ");
                    Console.WriteLine($"| Idade: {user.Age}       ");
                    Console.WriteLine("+---------------------------+");
                }
            }

            // Opções depois de buscar.
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("1 - Voltar para o menu");
            Console.WriteLine("2 - Pesquisar outro usuário");

            // Pedir ao usuário escolher uma opção.
            Console.Write("Escolha uma opção: ");
            string menuOption = Console.ReadLine();
            switch (menuOption)
            {
                case "1":
                    MainMenu();
                    break;
                case "2":
                    SearchUser();
                    break;
                default:
                    Console.WriteLine("Tchau, até breve!");
                    break;
            }
        }

        // Método para deletar um usuário pelo nome
        static void DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("| Deletar Usuário           |");
            Console.WriteLine("+---------------------------+");

            // Solicita o nome do usuário a ser deletado
            Console.Write("Digite o nome do usuário que deseja excluir: ");
            string nameToDelete = Console.ReadLine();

            // Busca o usuário pela lista
            var userToDelete =
                userList.FirstOrDefault(u => u.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

            // Verifica se o usuário foi encontrado
            if (userToDelete != null)
            {
                // Remove o usuário da lista
                userList.Remove(userToDelete);
                Console.WriteLine($"Usuário {userToDelete.Name} excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }

            WaitForKeyPress();  // Chama o novo método para esperar pela tecla
        }

        // Novo método para esperar a tecla pressionada antes de retornar ao menu
        static void WaitForKeyPress()
        {
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}

