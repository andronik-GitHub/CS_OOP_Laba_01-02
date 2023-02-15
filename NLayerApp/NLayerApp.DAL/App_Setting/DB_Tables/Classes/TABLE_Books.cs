using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.App_Setting.DB_Tables.Interfaces;
using NLayerApp.DAL.Repositories.Classes;
using NLayerApp.DAL.Repositories.Interfaces;

namespace NLayerApp.DAL.App_Setting.DB_Tables.Classes
{
    public class TABLE_Books : ICID_Table_Books
    {
        public async Task Create(SqlConnection connection)
        {
            var command = new SqlCommand() { Connection = connection };

            try
            {
                command.CommandText = @"
                    CREATE TABLE [Books]
                    (
	                    [Id] INT NOT NULL IDENTITY(1000000, 1),
	                    [BookTitle] NVARCHAR(100) NOT NULL,
	                    [TypeId] INT NOT NULL,
	                    [YearOfRelease] INT NOT NULL,
	                    [Author] NVARCHAR(100) NOT NULL,
	                    [AlternativeBookTitle] NVARCHAR(300) NOT NULL,
	                    [TitleStatus] NVARCHAR(50) NOT NULL,
	                    [TranslationStatus] NVARCHAR(20) NOT NULL DEFAULT N'Оригінал',
	                    [Rating] DECIMAL(2,1) NOT NULL DEFAULT 0.0,
	
	                    PRIMARY KEY ([Id]),
	                    CONSTRAINT FK_TypesOfBooks_To_Books FOREIGN KEY([TypeId])
		                    REFERENCES [TypesOfBooks] ([Id]) ON DELETE CASCADE,
	                    CONSTRAINT CK_Books_Rating CHECK (([Rating]>=(0) AND [Rating]<=(5)))
                    )";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table [Books] created!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Write("\nClick to continue...");
                Console.ReadKey(); Console.Clear();
            }
        }
        public async Task Drop(SqlConnection connection)
        {
            var command = new SqlCommand() { Connection = connection };

            try
            {
                command.CommandText = @"DROP TABLE [Books]";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table [Books] has been deleted!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Write("\nClick to continue...");
                Console.ReadKey(); Console.Clear();
            }
        }
        public async Task Insert(SqlConnection connection)
        {
            var unitOfWork = DB_Collection_Books.services
                .BuildServiceProvider()
                .GetRequiredService<IUnitOfWork>();

            try
            {
                // Generic Repository
                await unitOfWork.Books.CreateAsync(new Book { BookTitle = "Гаррі Поттер і таємна кімната", TypeId = 1000, YearOfRelease = 2016, Author = "Джоан Ролінґ", AlternativeBookTitle = "Гаррі Поттер", TitleStatus = "Завершено", TranslationStatus = "Завершено", Rating = 4.8f });
                await unitOfWork.Books.CreateAsync(new Book { BookTitle = "Гаррі Поттер і Орден Фенікса", TypeId = 1000, YearOfRelease = 2022, Author = "Джоан Ролінґ", AlternativeBookTitle = "Гаррі Поттер", TitleStatus = "Завершено", TranslationStatus = "Завершено", Rating = 4.5f });
                await unitOfWork.Books.CreateAsync(new Book { BookTitle = "Троє проти зла. Частина перша", TypeId = 1001, YearOfRelease = 2021, Author = "Тарас Ярмусь, Ярослав Світ", AlternativeBookTitle = "Троє проти зла", TitleStatus = "Завершено", TranslationStatus = "Завершено", Rating = 4.7f });
                await unitOfWork.Books.CreateAsync(new Book { BookTitle = "Троє проти зла. Частина друга", TypeId = 1001, YearOfRelease = 2021, Author = "Тарас Ярмусь, Ярослав Світ", AlternativeBookTitle = "Троє проти зла", TitleStatus = "Завершено", TranslationStatus = "Завершено", Rating = 4.2f });
                await unitOfWork.Books.CreateAsync(new Book { BookTitle = "Троє проти зла. Частина третя", TypeId = 1001, YearOfRelease = 2022, Author = "Ярослав Світ, Тарас Ярмусь, Ксенія Йоєнко", AlternativeBookTitle = "Троє проти зла", TitleStatus = "Завершено", TranslationStatus = "Завершено", Rating = 4.6f });
                await unitOfWork.Books.CreateAsync(new Book { BookTitle = "Північ", TypeId = 1000, YearOfRelease = 2020, Author = "Ерін Гантер", AlternativeBookTitle = "Коти-вояки", TitleStatus = "Завершено", TranslationStatus = "Завершено", Rating = 4.2f });
                await unitOfWork.Books.CreateAsync(new Book { BookTitle = "Коти-вояки. Вигнанці", TypeId = 1000, YearOfRelease = 2021, Author = "Ерін Гантер", AlternativeBookTitle = "Коти-вояки", TitleStatus = "Завершено", TranslationStatus = "Завершено", Rating = 4.4f });
                await unitOfWork.Books.CreateAsync(new Book { BookTitle = "Пригоди Шерлока Холмса. Заслуга диявола", TypeId = 1000, YearOfRelease = 2020, Author = "Бонні МакБьорд", AlternativeBookTitle = "A Sherlock Holmes Adventure. The Devil''s Due; Пригоди Шерлока Холмса", TitleStatus = "Завершено", TranslationStatus = "Завершено", Rating = 4.8f });
                await unitOfWork.Books.CreateAsync(new Book { BookTitle = "Пригоди Шерлока Холмса та доктора Ватсона", TypeId = 1000, YearOfRelease = 2017, Author = "Артур Конан Дойл", AlternativeBookTitle = "The Adventures of Sherlock Holmes and Doctor Watson; Пригоди Шерлока Холмса", TitleStatus = "Завершено", TranslationStatus = "Завершено", Rating = 4.9f });
                await unitOfWork.Books.CreateAsync(new Book { BookTitle = "Леді для герцога", TypeId = 1000, YearOfRelease = 2022, Author = "Неталі МакКензі", AlternativeBookTitle = "A lady for a duke; Леді для герцога", TitleStatus = "Завершено", TranslationStatus = "Завершено", Rating = 4.4f });

                unitOfWork.Save();
                Console.WriteLine("Table [Books] is filled!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Write("\nClick to continue...");
                Console.ReadKey(); Console.Clear();
            }
        }
    }
}
