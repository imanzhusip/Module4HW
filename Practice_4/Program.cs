using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student;
using Zoo_Animal;
using Home_Library;
using Autobase;
using Railway_ticket_office;
using Payment;


namespace Practice_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
                List<Students> students = new List<Students>
            {
                new Students { FullName = "Макс И.И.", GroupNumber = "Группа 1", Grades = new int[] { 5, 4, 3, 3, 4 } },
                new Students { FullName = "Петров П.П.", GroupNumber = "Группа 2", Grades = new int[] { 4, 4, 4, 5, 3 } },
                new Students { FullName = "Галымов И.П.", GroupNumber = "Группа 2", Grades = new int[] { 3, 4, 4, 4, 5 } },
                new Students { FullName = "Гавкин О.Р.", GroupNumber = "Группа 1", Grades = new int[] { 5, 4, 4, 5, 3 } },
                new Students { FullName = "Ялкина К.А.", GroupNumber = "Группа 1", Grades = new int[] { 4, 3, 4, 5, 5 } },
                new Students { FullName = "Лев Т.О.", GroupNumber = "Группа 1", Grades = new int[] { 5, 4, 5, 5, 3 } },
                new Students { FullName = "Гимбер Я.К.", GroupNumber = "Группа 2", Grades = new int[] { 4, 5, 4, 5, 5 } },
                new Students { FullName = "Кузялакомки О.О.", GroupNumber = "Группа 2", Grades = new int[] { 3, 5, 3, 5, 4 } },
                new Students { FullName = "Макгрегор О.О.", GroupNumber = "Группа 1", Grades = new int[] { 5, 5, 5, 5, 5 } },
                new Students { FullName = "Нурмагаметов Х.А.", GroupNumber = "Группа 2", Grades = new int[] { 2, 2, 2, 5, 2 } }
            };

                // Сортировка студентов по среднему баллу
                var sortedStudents = students.OrderBy(s => s.GetAverageGrade()).ToList();

                Console.WriteLine();
                Console.WriteLine("1 question:");

                // Вывод фамилий и номеров групп студентов с оценками 4 и 5
                foreach (var student in sortedStudents)
                {
                    if (student.Grades.All(grade => grade == 4 || grade == 5))
                    {
                        Console.WriteLine($"Фамилия: {student.FullName}, Группа: {student.GroupNumber}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("2 question:");

                List<Animal> animals = new List<Animal>
            {
                new Carnivore { Name = "Лев" },
                new Carnivore { Name = "Леопард" },
                new Omnivore { Name = "Медведь" },
                new Omnivore { Name = "Кабан" },
                new Herbivore { Name = "Зебра" },
                new Herbivore { Name = "Бегемот" },
                new Herbivore { Name = "Антилопа" },
                new Herbivore { Name = "Дикая Лошадь" },

            };

            // a. Упорядочиваем животных по убыванию количества пищи и алфавиту
            var sortedAnimals = animals.OrderByDescending(a => a.CalculateFoodQuantity())
                                   .ThenBy(a => a.Name)
                                   .ToList();

            // b. Вывод первых 5 имен животных
            Console.WriteLine("Первые 5 имен животных:");
            foreach (var animal in sortedAnimals.Take(5))
            {
                Console.WriteLine(animal.Name);
            }
    
            // c. Вывод последних 3 идентификаторов животных
            Console.WriteLine("Последние 3 идентификатора животных:");
            foreach (var animal in sortedAnimals.Skip(Math.Max(0, sortedAnimals.Count - 3)))
            {
                Console.WriteLine(animal.Name);
            }

                Console.WriteLine();
                Console.WriteLine("3 question:");

                Library library = new Library();

                // Добавление книг
                library.AddBook(new Book { Title = "Война и мир", Author = "Лев Толстой", Year = 1869 });
                library.AddBook(new Book { Title = "Преступление и наказание", Author = "Фёдор Достоевский", Year = 1866 });
                library.AddBook(new Book { Title = "1984", Author = "Джордж Оруэлл", Year = 1949 });
                library.AddBook(new Book { Title = "Унесенные ветром", Author = "Маргарет Митчелл", Year = 1936 });
                library.AddBook(new Book { Title = "Анна Каренина", Author = "Лев Толстой", Year = 1877 });

                // Поиск книг по автору
                List<Book> booksByAuthor = library.SearchByAuthor("Лев Толстой");
                Console.WriteLine("Книги по автору 'Лев Толстой':");
                foreach (var book in booksByAuthor)
                {
                    Console.WriteLine($"Название: {book.Title}, Год: {book.Year}");
                }

                // Поиск книг по году издания
                List<Book> booksByYear = library.SearchByYear(1869);
                Console.WriteLine("\nКниги изданные в 1869 году:");
                foreach (var book in booksByYear)
                {
                    Console.WriteLine($"Название: {book.Title}, Автор: {book.Author}");
                }

                // Сортировка книг по названию
                List<Book> sortedBooks = library.SortByTitle();
                Console.WriteLine("\nКниги, отсортированные по названию:");
                foreach (var book in sortedBooks)
                {
                    Console.WriteLine($"Название: {book.Title}, Автор: {book.Author}, Год: {book.Year}");
                }

                Console.WriteLine();
                Console.WriteLine("4 question:");

                Vehicle vehicle1 = new Vehicle { VehicleId = "A123", VehicleType = "Грузовик" };
                Vehicle vehicle2 = new Vehicle { VehicleId = "B456", VehicleType = "Автобус" };

                Driver driver1 = new Driver { DriverId = "D001", Name = "Айлин", Status = "Работает" };
                Driver driver2 = new Driver { DriverId = "D002", Name = "Макс", Status = "Работает" };

                Dispatcher dispatcher = new Dispatcher();

                dispatcher.AssignDriverToVehicle(driver1, vehicle1);
                dispatcher.AssignDriverToVehicle(driver2, vehicle2);

                dispatcher.RecordTripCompletion(driver1);
                dispatcher.RecordTripCompletion(driver2);

                dispatcher.SuspendDriver(driver1);
                dispatcher.RecordTripCompletion(driver1); // Водитель отстранен и не может выполнять рейсы

                Console.WriteLine();
                Console.WriteLine("5 queestion:");

                RailwayTicketSystem ticketSystem = new RailwayTicketSystem();

                Train train1 = new Train { TrainNumber = "T123", DepartureStation = "Алматы", ArrivalStation = "Пекин", Price = 10000 };
                Train train2 = new Train { TrainNumber = "T456", DepartureStation = "Пекин", ArrivalStation = "Алматы", Price = 12000 };

                ticketSystem.AddTrain(train1);
                ticketSystem.AddTrain(train2);

                List<Train> availableTrains = ticketSystem.SearchTrains("Алматы", "Пекин");

                if (availableTrains.Count > 0)
                {
                    Train selectedTrain = availableTrains[0];
                    DateTime departureDateTime = DateTime.Now.AddDays(7);

                    Ticket bookedTicket = ticketSystem.BookTicket(selectedTrain, "Фред А.А.", departureDateTime);

                    Console.WriteLine($"Забронирован билет для {bookedTicket.PassengerName} на поезд {bookedTicket.SelectedTrain.TrainNumber} " +
                                      $"с отправлением в {bookedTicket.DepartureDateTime} по цене {bookedTicket.TotalPrice} тенге.");
                }
                else
                {
                    Console.WriteLine("Подходящих поездов не найдено.");
                }

                Console.WriteLine();
                Console.WriteLine("6 question:");

                BankAccount account1 = new BankAccount { AccountNumber = "123456", Balance = 1000000 };
                BankAccount account2 = new BankAccount { AccountNumber = "789012", Balance = 450 };

                CreditCard card1 = new CreditCard { CardNumber = "1111-2222-3333-4444", LinkedAccount = account1, IsBlocked = false };
                CreditCard card2 = new CreditCard { CardNumber = "5555-6666-7777-8888", LinkedAccount = account2, IsBlocked = false };

                PaymentSystem paymentSystem = new PaymentSystem();
                paymentSystem.AddBankAccount(account1);
                paymentSystem.AddBankAccount(account2);
                paymentSystem.AddCreditCard(card1);
                paymentSystem.AddCreditCard(card2);

                try
                {
                    paymentSystem.MakePayment("123456", "789012", 500);
                    Console.WriteLine("Платеж успешно выполнен.");

                    // Заблокировать кредитную карту
                    paymentSystem.BlockCreditCard("1111-2222-3333-4444");
                    Console.WriteLine("Кредитная карта заблокирована.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
        }
    }
}
