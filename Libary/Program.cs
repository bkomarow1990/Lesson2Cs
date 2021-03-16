using System;
using System.Linq;

namespace Libary
{
    class Program
    {
        class Book
        {
            private String author;
            private String cipher;
            private String name;
            private int year;
            public String Author
            {
                get {
                    return author;
                }
                set {
                    if (!String.IsNullOrEmpty(value))
                    {
                        author = value;
                    }
                }
            }
            public object Clone()
            {
                return new Book(Author, Cipher, Name, Year);
            }
            public String Cipher
            {
                get
                {
                    return cipher;
                }
                set
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        cipher = value;
                    }
                }
            }
            public String Name
            {
                get
                {
                    return name;
                }
                set
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        name = value;
                    }
                }
            }
            public int Year
            {
                get {
                    return year;
                }
                set {
                    year = value;
                }
            }
            public Book(String author, String cipher, String name, int year)
            {
                Author = author;
                Cipher = cipher;
                Name = name;
                Year = year;
            }
            public static implicit operator CoverBook(Book book) {
                return new CoverBook(book.name, book.author, book.year);
            }
            public void Print() {
                Console.WriteLine($"Author: {author}, Cipher: {cipher}, Name: {name}, Year: {year}");
            }
            public string this[string index]
            {
                get
                {
                    if (index == "year" || index=="Year" || index == "YEAR")
                    {
                        return year.ToString();
                    }
                    if (index == "author")
                    {
                        return author;
                    }
                    if (index == "name")
                    {
                        return name;
                    }
                    if (index == "cipher")
                    {
                        return cipher;
                    }
                    else
                    {
                        throw new Exception("Incorrect index");
                    }
                }
                set
                {
                    if (index == "year" || index == "Year" || index == "YEAR")
                    {
                        this.year = Int32.Parse(value);
                        return;
                    }
                    if (index == "name")
                    {
                        this.Name = value;
                        return;
                    }
                    if (index == "cipher")
                    {
                        this.Cipher = value;
                        return;
                    }
                    if (index == "author")
                    {
                        this.Author = value;
                        return;
                    }
                    throw new Exception("Incorrect index");
                }
            }
        }
        // NEW CLASS CoverBook in 2nd HW
        class CoverBook
        {
            private String name;
            private String author;
            private int year;
            public String Name
            {
                get
                {
                    return name;
                }
                set
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        name = value;
                    }
                }
            }
            public String Author
            {
                get
                {
                    return author;
                }
                set
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        author = value;
                    }
                }
            }
            public int Year
            {
                get => year;
                set
                {
                    year = value;
                }
            }
            public CoverBook(string name, string author, int year)
            {
                this.Name = name;
                this.Author = author;
                this.Year = year;
            }
            public static implicit operator Book(CoverBook cbook)
            {
                return new Book(cbook.author, "NoCipher", cbook.name, cbook.year);
            }
            public void Print()
            {
                Console.WriteLine($"CoverBook:\nName: {name}, Author: {author}, Year: {year}");
            }
        }
        class Library
        {
            private Book[] books;
            public Library(Book book)
            {
                books = new Book[1];
                books[0] = book;
            }
            public void Print() {
                foreach (var item in books)
                {
                    item.Print();
                }
            }
            public void AddBook(Book book)
            {
                if (this.books == null)
                {
                    books = new Book[1];
                    books[0] = (Book)book.Clone();
                    return;
                }
                Book[] tmp = (Book[])books.Clone();
                books = new Book[books.Length + 1];

                for (int i = 0; i < books.Length - 1; i++)
                {
                    books[i] = (Book)tmp[i].Clone();
                }
                Book book1 = book;
                books[books.Length - 1] = book1;


            }
            public void deleteBook(String cipher) {
                int index = Array.FindIndex(books, (e) => { return e.Cipher.Equals(cipher); });
                Book[] tmp = new Book[books.Length];

                if (index != -1)
                {
                    books.CopyTo(tmp, 0);
                    Array.Resize(ref books, books.Length - 1);

                }
                else {
                    Console.WriteLine($" Book isn`t found");
                    return;
                }
                for (int i = books.Length - 1, j = i + 1; 0 <= i; --i)
                {
                    if (index == j)
                    {
                        --j;

                    }
                    books[i] = (Book)tmp[j].Clone();
                    --j;
                }
            }
            public Book this[int index]
            {
                get
                {
                    if (index < 0 || index >= books.Length)
                    {
                        throw new Exception("Incorrect index of book");
                    }
                    return books[index];
                }
                set
                {
                    if (index < 0 || index >= books.Length)
                    {
                        throw new Exception("Incorrect index of book");
                    }
                    if (value == null)
                    {
                        throw new Exception("Your book is null");
                    }
                    this.books[index] = value;
                }
            }
            public Book this[string cipher]
            {
                get
                {
                    var a=Array.Find(books,e => e.Cipher==cipher);
                    if (a == null)
                    {
                        Console.WriteLine("Haven`t book with same cipher");
                        return null;
                    }
                    return a;
                    
                }
                set
                {
                    var a = Array.FindIndex(books, e => e.Cipher == cipher);
                    if (a == -1)
                    {
                        Console.WriteLine("Haven`t book with same cipher");
                        if (value == null)
                        {
                            throw new Exception("Book is null");
                        }
                        return;
                    }
                    Console.WriteLine("Book finded, replaced ");
                    books[a]=value;
                }
            }
            public void sortByAuthor() {
                Array.Sort(books, (e, e2) => { return e.Author.CompareTo(e2.Author); });
            }
            public void sortByYear()
            {
                Array.Sort(books, (e, e2) => { return e.Year.CompareTo(e2.Year); });
            }
            public void searchBookByName(String name) {
                int index=Array.FindIndex(books, (e) => {return e.Name.Equals(name); });
                Console.WriteLine($" Book with same name : ");
                books[index].Print();
            }
        }
        static void Main(string[] args)
        {
            Book book1 = new Book("Oleg Winnik", "chiper", "Sho - nebud", 2020);
            //book1.Print();
            Library library = new Library(book1);
            library.AddBook(new Book("Pawlo Zibrow", "Kaban1", "Zoopark",1969));
            library.AddBook(new Book("Boris Chuck-Norris", "Kaban2", "Zoopark2",1993));
            library.AddBook(new Book("Johnson Rambo", "Kaban3", "Zoopark3", 2005));
            library.deleteBook("Kaban3");
            library.searchBookByName("Zoopark2");
            library.Print();
            // HW part 2
            Console.WriteLine("------------------New HW------------------");
            Console.WriteLine("before (int library index):");
            library.Print();
            Console.WriteLine("after (int library index):");
            library[0] = new Book("New Book", "NB", "What`s new", 2021);
            library.Print();
            Console.WriteLine("after 2 (string library index):");
            library["NB"] = new Book("New Book2", "NB2", "What`s new 2", 2021);
            library.Print();
            Book newbook = new Book("Cast Test", "Test cast", "I", 2021);
            CoverBook cb = (CoverBook)newbook;
            cb.Print();
        }
    }
}
