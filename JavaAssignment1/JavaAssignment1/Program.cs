using System.Security.Cryptography.X509Certificates;

namespace JavaAssignment1
{
    internal class Program
    {
        public static int count0 = 0;
        public static int count1 = 0;
        public static int biggerCount = 0;
        public static Book [] books;
        public static int maxBooks;
        public static int[] inventory;
        static void Main(string[] args)
        { 
            Console.WriteLine("Welcome to the bookstore!");
            Console.WriteLine("What is the maximum number of books do you want in the store?");
            maxBooks=Convert.ToInt32(Console.ReadLine());
            books = new Book[maxBooks];
            inventory=new int[maxBooks];
            for (int i = 0; i < maxBooks; i++) 
            {
                inventory[i] = i+1;
            }
            while (true)
            {
                int choice = mainMenu();
                if (choice == 1) 
                {
                    string input = passwordPrompt(1);
                    if (input.Equals("terminate"))
                        break;
                    if (input.Equals("exit"))
                        continue;
                    addBook();

                }
                else if (choice == 2) 
                {
                    string input=passwordPrompt(2);
                    if (input.Equals("exit"))
                        continue;
                    changeBook();
                }
                else if (choice == 3) 
                { 
                    Console.WriteLine("What is the author's name?");
                    string authorName=Console.ReadLine();
                    int index = 0;
                    while (books[index]!=null)
                    {
                        if (books[index].GetAuthor().Equals(authorName))
                            Console.WriteLine(books[index]);
                        if(index<maxBooks)
                            index++;
                    }
                }
                else if (choice == 4) 
                {
                    Console.WriteLine("What is the price?");
                    double price=Convert.ToDouble(Console.ReadLine());
                    int index = 0;
                    while (books[index] != null)
                    {
                        if (books[index].GetPrice()<price)
                            Console.WriteLine(books[index]);
                        if (index < maxBooks)
                        {
                          index++;   
                        }
                       
                    }
                }
                else if (choice == 5) { break; }
            }

        }
        public static int mainMenu()
        {
            Console.Write("What do you want to do?\r\n1. Enter new books (password required)\r\n2. Change information of a book (password required)\r\n3. Display all books by a specific author\r\n4. Display all books under a certain a price.\r\n5. Quit\r\nPlease enter your choice >");
            int choice=Convert.ToInt32(Console.ReadLine());
            choice = choiceValidator(1, 5, choice);
            return choice;
        }
        public static int choiceValidator(int lowerend, int higherend, int choice)
        {
            while (!(choice>=lowerend && choice<=higherend)) 
            {
                Console.Write("Wrong choice, please enter a valid choice: ");
                choice=Convert.ToInt32(Console.ReadLine());
            }
            return choice;
        }
        private static string passwordVerifier(string password, int choiceOneorTwo)
        {
            string status="all good";
            while (!(password.Equals("249"))) 
            {
                if (choiceOneorTwo==1)
                    count0++;
                else if (choiceOneorTwo==2)
                    count1++;
                if (count0 == 3) 
                {
                    count0= 0;
                    biggerCount++;
                    if (biggerCount!=4) {status = "exit"; }
                    else 
                    { 
                       Console.WriteLine("Program detected suspicious\r\nactivities and will terminate immediately!");
                       status = "terminate";
                        biggerCount = 0;
                    }
                    break;
                    
                }
                if (count1 == 3)
                {
                    count1= 0;
                    status = "exit";
                    break;
                }
                
                Console.Write("Wrong password. Please enter a valid password: ");
                password = Console.ReadLine();
                
            }
            return status;
        }
        public static string passwordPrompt(int choiceOneorTwo) 
        {
            Console.WriteLine("Enter your password:");
            string input= Console.ReadLine();
            return passwordVerifier(input, choiceOneorTwo);
        }
        public static void addBook() 
        {
            int index = 0;
            while (books[index]!= null) 
            {
                index++;
            }
            Console.WriteLine("How many books do want to add? ");
            int bookNumber=Convert.ToInt32(Console.ReadLine());
            int maxToAdd = maxBooks - index;
            if (bookNumber>maxToAdd) 
            {
                Console.WriteLine("That is too many books.\nThe maximum amount of books you can add is "+maxToAdd);
                bookNumber= maxToAdd;
            }
            for (int i=index;i<(index+bookNumber);i++) 
            {
                Console.WriteLine("Enter the title of the book");
                string title= Console.ReadLine();
                Console.WriteLine("Enter the name of the author");
                string author= Console.ReadLine();
                Console.WriteLine("Enter the book's ISBN");
                long isbn= Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter the book's price");
                double price= Convert.ToDouble(Console.ReadLine());
                books[i] = new Book(title,author,isbn,price);
            }
        }
        public static void changeBook() 
        {
            Console.WriteLine("Please enter the book's inventory index ");
            int index = Convert.ToInt32(Console.ReadLine())-1;
            while (books[index]== null) 
            {
                Console.WriteLine("There are no books at this index. Please choose another index.");
                index=Convert.ToInt32(Console.ReadLine())-1;
            }
            Console.WriteLine("Book #"+(index+1));
            Console.WriteLine(books[index]);
            while(true) 
            {
                int choice = changeBookMenu();
                if (choice == 1) 
                {
                    Console.WriteLine("What is the new author's name? ");
                    string author=Console.ReadLine();
                    books[index].SetAuthor(author);
                }
                else if (choice == 2) 
                {
                    Console.WriteLine("What is the updated title for the book? ");
                    string title = Console.ReadLine();
                    books[index].SetTitle(title);
                }
                else if (choice == 3) 
                {
                    Console.WriteLine("What is the book's new ISBN? ");
                    long isbn=Convert.ToInt64(Console.ReadLine());
                    books[index].SetIsbn(isbn);
                }
                else if (choice == 4) 
                {
                    Console.WriteLine("What is the book's new price? ");
                    double price=Convert.ToDouble(Console.ReadLine());
                    books[index].SetPrice(price);
                }
                else if (choice == 5) { break; }
                Console.WriteLine("Book #"+(index+1));
                Console.WriteLine(books[index]);
            }
        }
        public static int changeBookMenu() 
        {
            Console.WriteLine("What information would you like to\r\nchange?\r\n1. author\r\n2. title\r\n3. ISBN\r\n4. price\r\n5. Quit\r\nEnter your choice > \r\n");
            int choice = Convert.ToInt32(Console.ReadLine());
            choice = choiceValidator(1, 5, choice);
            return choice;
        }
        
    }
}
