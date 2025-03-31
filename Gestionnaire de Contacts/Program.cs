namespace Gestionnaire_de_Contacts
{
    internal class Program
    {
        static List<Contacts> contacts = new List<Contacts>();
        static void Main(string[] args)
        {
            LoadContacts();
            Welcome();
            Menu();
        }

        static void Welcome()
        {
            Console.WriteLine("   ____           _   _                         _                _      \r\n  / ___| ___  ___| |_(_) ___  _ __  _ __   __ _(_)_ __ ___    __| | ___ \r\n | |  _ / _ \\/ __| __| |/ _ \\| '_ \\| '_ \\ / _` | | '__/ _ \\  / _` |/ _ \\\r\n | |_| |  __/\\__ \\ |_| | (_) | | | | | | | (_| | | | |  __/ | (_| |  __/\r\n  \\____|\\___||___/\\__|_|\\___/|_| |_|_| |_|\\__,_|_|_|  \\___|  \\__,_|\\___|\r\n  / ___|___  _ __ | |_ __ _  ___| |_ ___                                \r\n | |   / _ \\| '_ \\| __/ _` |/ __| __/ __|                               \r\n | |__| (_) | | | | || (_| | (__| |_\\__ \\                               \r\n  \\____\\___/|_| |_|\\__\\__,_|\\___|\\__|___/                               \r\n                                                                        ");
        }

        static void Menu()
        {
            Console.WriteLine("******************************\tMENU\t******************************");
            Console.WriteLine("**********\t0 -Afficher les contacts");
            Console.WriteLine("**********\t1 - Ajouter un contact");
            Console.WriteLine("**********\t2 - Supprimer un contact");
            Console.WriteLine("**********\t3 - Menu");
            Console.WriteLine("**********\t4 - Quiter");
            Console.WriteLine("**********************************************************************");
            Check();

        }

        static void Show()
        {
            Console.Clear();
            Console.WriteLine("******************************\tListe des contact\t******************************");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.nom+": "+contact.num);
            }
            Check();

        }
        static void Add()
        {
            Console.Clear();
            Console.WriteLine("******************************\tAjouter des contact\t******************************");
            Console.WriteLine("Nom:");
            string nom = Console.ReadLine();
            Console.WriteLine("Numero:");
            string num = Console.ReadLine();
            contacts.Add(new Contacts(nom, num));
            Console.WriteLine("Contact Enregistré!");
            SaveContacts();
            Check();



        }
        static void Delete()
        {
            Console.Clear();
            Console.WriteLine("******************************\tSupprimer des contact\t******************************");
            Console.WriteLine("nom ou numéro à supprimer");

            string item = Console.ReadLine();
            int countContact = contacts.RemoveAll(contact => contact.nom == item || contact.num == item);

            if (countContact>0)
            {
                Console.WriteLine("Contact(s)Supprimé(s)!");
                SaveContacts();
            }
            else
            {
                Console.WriteLine("Contact non trouvé");
            }
            Check();
        }
        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("bye");
            Environment.Exit(0);
        }

        static void Check(int min=0, int max=4)
        {
            Console.WriteLine("tapez 0 pour afficher les contact,1 pour ajouter, 2 pour supprimer, 3 pour revenir au menu et 4 pour quitter");
            int selector =-1;
            while (selector < min || selector > max)
            {
                if (selector < min|| selector > max)
                {
                    Console.WriteLine("vous devez choisir de "+min+"  à "+max);
                }
                try
                {
                    selector = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Direction(selector);
        }

        static void Direction(int selector)
        {
            //Console.Clear();
            switch (selector)
            {
                case 0: Show(); break;
                case 1: Add(); break;
                case 2: Delete(); break;
                case 3: Menu(); break;
                case 4: Exit(); break;
            }
        }

        static void SaveContacts()
        {
            try
            {
                using (StreamWriter w = new StreamWriter("contacts.txt"))
                {
                    foreach(var contact in contacts)
                    {
                        w.WriteLine(contact.nom + ": " + contact.num);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void LoadContacts()
        {
            if (File.Exists("contacts.txt"))
            {
                try
                {
                    using(StreamReader r = new StreamReader("contacts.txt"))
                    {
                        string line;
                        while((line = r.ReadLine()) != null)
                        {
                            string[] parts = line.Split(':');
                            contacts.Add(new Contacts(parts[0], parts[1]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
