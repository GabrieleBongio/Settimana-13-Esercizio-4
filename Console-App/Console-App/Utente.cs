using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App
{
    internal class Utente
    {
        private string Username { get; set; }
        private string Password { get; set; }
        private string LoginTime { get; set; }
        private string LogoutTime { get; set; }
        private bool IsLogged { get; set; }

        private static ArrayList ListaAccessi = new ArrayList();

        public Utente()
        {
            Username = "";
            Password = "";
            LoginTime = "";
            LogoutTime = "";
            IsLogged = false;
        }

        public void Login()
        {
            if (!IsLogged)
            {
                string usernameInput;

                do
                {
                    Console.WriteLine("Inserisci l'username");
                    usernameInput = Console.ReadLine();
                    if (usernameInput == "")
                    {
                        Console.WriteLine("Username non valido, riprova");
                        Console.WriteLine("");
                    }
                } while (usernameInput == "");

                string passwordInput;
                string passwordConfirmInput;

                do
                {
                    Console.WriteLine(
                        "Inserisci la Password, deve essere lunga almeno 6 caratteri"
                    );
                    passwordInput = Console.ReadLine();
                    Console.WriteLine("Conferma la Password");
                    passwordConfirmInput = Console.ReadLine();
                    if (passwordConfirmInput != passwordInput)
                    {
                        Console.WriteLine("le due password inserite sono diverse, riprova");
                        Console.WriteLine("");
                    }
                    else if (passwordInput.Length < 6)
                    {
                        Console.WriteLine("La password inserita è troppo corta, riprova");
                        Console.WriteLine("");
                    }
                } while (passwordInput != passwordConfirmInput || passwordInput.Length < 6);

                Username = usernameInput;
                Password = passwordInput;
                DateTime dateTime = DateTime.Now;
                LoginTime = dateTime.ToString();
                IsLogged = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login avvenuto con successo");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sei già loggato");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
            }
        }

        private static void AddToListaAccessi(string accesso)
        {
            ListaAccessi.Add(accesso);
        }

        public void Logout()
        {
            if (IsLogged)
            {
                string passwordInput;

                do
                {
                    Console.WriteLine("Inserisci la password");
                    passwordInput = Console.ReadLine();
                    if (passwordInput != Password)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La password inserita non è corretta, riprova");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                    }
                } while (passwordInput != Password);

                DateTime dateTime = DateTime.Now;
                LogoutTime = dateTime.ToString();
                string accesso =
                    $"Username: {Username},LoginTime: {LoginTime},LogoutTime: {LogoutTime}";
                AddToListaAccessi(accesso);
                Username = "";
                Password = "";
                LoginTime = "";
                LogoutTime = "";
                IsLogged = false;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Logout effettuato con successo");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Non sei loggato in un account");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
            }
        }

        public void OraEDataLogin()
        {
            if (IsLogged)
            {
                Console.WriteLine(LoginTime);
                Console.WriteLine("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Non sei loggato in un account");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
            }
        }

        public static void ScriviListaAccessi()
        {
            if (ListaAccessi.Count > 0)
            {
                foreach (string accesso in ListaAccessi)
                {
                    Console.WriteLine(accesso);
                }
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Lista di accessi vuota");
                Console.WriteLine("");
            }
        }

        public void Menu()
        {
            bool continuare = true;

            do
            {
                Console.WriteLine("===============OPERAZIONI===============");
                Console.WriteLine("");
                Console.WriteLine("Scegli l'operazione da effettuare:");
                Console.WriteLine("");
                Console.WriteLine("1: Login");
                Console.WriteLine("");
                Console.WriteLine("2: Logout");
                Console.WriteLine("");
                Console.WriteLine("3: Verifica ora e data login");
                Console.WriteLine("");
                Console.WriteLine("4: Lista degli accessi");
                Console.WriteLine("");
                Console.WriteLine("5: Esci");
                Console.WriteLine("");
                Console.WriteLine("========================================");
                Console.WriteLine("");

                int scelta = 0;
                try
                {
                    scelta = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    scelta = 0;
                }

                switch (scelta)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Logout();
                        break;
                    case 3:
                        OraEDataLogin();
                        break;
                    case 4:
                        ScriviListaAccessi();
                        break;
                    case 5:
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        Console.WriteLine("");
                        break;
                }
            } while (continuare);
        }
    }
}
