# Library Management System

A Windows Forms desktop app (C#, .NET Framework 4.7.2, SQL Server) for a college library:
books, students, borrowing, returns and fines.

## How to run

1. **Create the database:** open `Database/schema.sql` in SQL Server Management Studio and press **Execute**.
   It creates `LibraryDB` with demo data (15 books, 10 students, 30 loans and a few fines).
2. **Set your server name:** in `App.config`, change `Data Source=.\SQLEXPRESS` if your SQL Server has a different name.
3. **Run:** open `Library Management System/Library Manegement System.sln` in Visual Studio and press **F5**.
4. **Sign in** with `admin` / `admin123`.

## Screens

| Screen | What it does |
|---|---|
| Sign in | Checks the username and password (passwords are stored as SHA-256 hashes) |
| Dashboard | Totals, a **chart of loans per month** (each bar is drawn as a book spine) and the overdue list |
| Books | Add / Update / Delete / Search. **Find online** fills the title, author and publisher from the ISBN |
| Students, Librarians | Add / Update / Delete / Search |
| Issue & return | Lend a book (max 3 per student, only books with a free copy). Returning late adds a fine automatically |
| Fines | Filter paid/unpaid, mark as paid, add a fine for a lost or damaged book |
| Reports | Overdue books, most borrowed books, fines by student. **Export to CSV** (opens in Excel) |

## Where each requirement is

| # | Requirement | Where to look |
|---|---|---|
| 1 | GUI | `Forms/LoginForm`, `Forms/MainForm` (sidebar menu) and the 7 pages in `Pages/` |
| 2 | Windows Forms | Every screen is a Form or UserControl with a normal `.Designer.cs` file (it opens in the designer) |
| 3 | Good C# | Each page follows the same pattern (Load, Add, Update, Delete, Clear). All database code is in one class, `Helpers/Db.cs`. The rules are in one place, `Helpers/LibraryRules.cs` |
| 4 | CRUD | Books, Students and Librarians pages (INSERT, SELECT, UPDATE, DELETE) |
| 5 | Database connectivity | `Helpers/Db.cs` (ADO.NET `SqlConnection` / `SqlCommand` with parameters). Connection string in `App.config`. Tables in `Database/schema.sql` |
| 6 | Reports / statistics | `Pages/DashboardPage` (totals and chart) and `Pages/ReportsPage` (3 reports, CSV export) |
| 7 | Exception handling | Every database call is inside `try/catch` and goes to `Helpers/ErrorHelper.cs`, which shows a clear message (for example "this student has loans, so it can't be deleted"). `Program.cs` catches anything left over |
| 8 | Validation | `Helpers/Validation.cs` (name, email, phone, ISBN, amount) with an `ErrorProvider` red icon next to each wrong field. Rules such as "max 3 books" and "due date after issue date" are in `IssuePage` |
| 9 | Search / filter | Search box on Books, Students, Librarians and Issue. Status filter on Issue and Fines. Date range on Reports |
| 10 | GDI+ Graphics | `Helpers/SpineChart.cs`: the dashboard chart is drawn by hand in `OnPaint` with `Graphics.FillRectangle`, `DrawLine` and `DrawString` |
| 11 | Async / multithreading | All database calls use `async`/`await`. The dashboard runs 7 queries **at the same time** with `Task.WhenAll`. CSV export writes the file on a **background thread** with `Task.Run` |
| 12 | Networking | `Helpers/OpenLibrary.cs`: `HttpClient` downloads book details from the Open Library website using the ISBN |

## Project files

```
Database/schema.sql      tables + demo data
Program.cs               starts the app with the login window
App.config               database connection string
Forms/                   LoginForm, MainForm
Pages/                   Dashboard, Books, Students, Librarians, Issue (borrow & return), Fines, Reports
Helpers/
  Db.cs                  all SQL goes through here (async)
  Validation.cs          input checks
  ErrorHelper.cs         friendly error messages
  LibraryRules.cs        14 days loan, 5 EGP per late day, max 3 books
  OpenLibrary.cs         online ISBN lookup (networking)
  SpineChart.cs          the GDI+ chart
  Theme.cs               colours and grid style
```
