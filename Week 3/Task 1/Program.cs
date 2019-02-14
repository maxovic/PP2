using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Task_1
{
    enum ViewMode
    {
        ShowDirContent,
        ShowFileContent
    }
    class layer // class layer with variables(int,FileSystemInfo[])
    {
        public int selecteditem
        {
            get;
            set;
        }
        public FileSystemInfo[] content
        {
            get;
            set;
        }
        public void paint() // function to make our FAR look interesting
        {
            Console.BackgroundColor = ConsoleColor.Blue; // Our FAR's background is blue
            Console.Clear(); // refreshing

            for (int i = 0; i < content.Length; i++)
            {
                if (i == selecteditem) // Condition which works if the Cursor is equal to the index of the array
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkGray; // selected item has White background with DarkGray text
                }
                else 
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White; // non selected items has Blue background with white text
                }
                Console.WriteLine(content[i].Name);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\git\PP2"); // Предоставляет методы экземпляра класса для создания, 
            // перемещения и перечисления в каталогах и подкаталогах. Этот класс не наследуется.
            Stack<layer> history = new Stack<layer>(); 
            history.Push(new layer { content = dir.GetFileSystemInfos() }); // pushing all content from dirInfo;
            bool mode = false;
            ViewMode viewMode = ViewMode.ShowDirContent;
            
            while (!mode) // Cycle works until Ok is true
            {
                if (viewMode == ViewMode.ShowDirContent)
                {
                    history.Peek().paint(); // paints the first page
                }

                ConsoleKeyInfo CKI = Console.ReadKey(); // reading a key
                switch (CKI.Key) 
                {   
                    case ConsoleKey.UpArrow: 
                        if (history.Peek().selecteditem - 1 < 0) // чтобы не выйти за рамки
                            history.Peek().selecteditem = history.Peek().content.Length - 1;
                        else
                            history.Peek().selecteditem--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (history.Peek().selecteditem + 1 >= history.Peek().content.Length) // чтоб не выйти за рамки
                            history.Peek().selecteditem = 0;
                        else
                            history.Peek().selecteditem++;
                        break;
                    case ConsoleKey.Enter:
                        int enter = history.Peek().selecteditem;
                        FileSystemInfo FSIenter = history.Peek().content[enter];
                        if (FSIenter.GetType() == typeof(DirectoryInfo))
                        {
                            viewMode = ViewMode.ShowDirContent;
                            DirectoryInfo DIenter = FSIenter as DirectoryInfo;
                            history.Push(new layer { content = DIenter.GetFileSystemInfos() }); // если папка то добавляю в стек
                        }
                        else
                        {
                            viewMode = ViewMode.ShowFileContent;
                            using (FileStream FSenter = new FileStream(FSIenter.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader SRenter = new StreamReader(FSenter)) // если файл то читаем
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(SRenter.ReadToEnd());
                                }
                            }
                        }
                        break;

                    case ConsoleKey.Backspace:
                        if (viewMode == ViewMode.ShowDirContent) // if u press backspace, stack pops its element 
                        {
                            history.Pop();
                        }
                        else // else goes back
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            viewMode = ViewMode.ShowDirContent;
                        }
                        break;


                    case ConsoleKey.Delete: 
                        int delete = history.Peek().selecteditem;
                        FileSystemInfo FSIdelete = history.Peek().content[delete]; // checking whether the selected item is File Or DIr
                        history.Peek().selecteditem--;
                        if (FSIdelete.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo DIdelete = FSIdelete as DirectoryInfo;
                            Directory.Delete(FSIdelete.FullName, true); // true for deleting folders with its elements
                            history.Peek().content = DIdelete.Parent.GetFileSystemInfos(); // after deleting selecteditem is previous one
                        }
                        else
                        {
                            FileInfo FIdelete = FSIdelete as FileInfo;
                            File.Delete(FSIdelete.FullName);
                            history.Peek().content = FIdelete.Directory.GetFileSystemInfos(); // after deleting selecteditem is previous one
                        }
                        break;

                    case ConsoleKey.Escape: 
                        mode = true;
                        break;

                    case ConsoleKey.R:
                        Console.BackgroundColor = ConsoleColor.Blue; 
                        Console.Clear();
                        string name = Console.ReadLine();
                        int rename = history.Peek().selecteditem; 
                        FileSystemInfo FSIrename = history.Peek().content[rename]; 
                        if (FSIrename.GetType() == typeof(DirectoryInfo)) // if selected item is dir
                        {
                            DirectoryInfo DIrename = FSIrename as DirectoryInfo; // using FSI as directory info
                            string path = DIrename.Parent.FullName; // путь до файла
                            string Rename = Path.Combine(path, name); // combining the path with new name
                            Directory.Move(FSIrename.FullName, Rename); // function move allows us to rename
                            history.Peek().content = DIrename.Parent.GetFileSystemInfos();
                        }
                        else // if selected item is file
                        {   
                            FileInfo FIrename = FSIrename as FileInfo; // using FSI as file
                            File.Move(FSIrename.FullName, FIrename.Directory.FullName + @"\" + name);
                            history.Peek().content = FIrename.Directory.GetFileSystemInfos();
                        }
                        break;
                }

            }
        }
    }
    }
