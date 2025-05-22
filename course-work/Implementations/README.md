# Rent-a-car Project

**Студент:** Факултетен номер: 2301321027  
**Име на проекта:** Rent-a-car

## 📌 Описание

Проектът "Rent-a-car" представлява проста уеб апликация, създадена с ASP.NET MVC, която симулира система за наемане на автомобили. Приложението позволява на потребителите да разглеждат наличните коли, да правят заявки за наем и да управляват своите резервации.

## ⚙️ Технологии, използвани

- ASP.NET MVC
- Entity Framework Core
- Microsoft SQL Server
- Bootstrap

## 🚀 Инструкции за инсталация и стартиране

Следвай стъпките по-долу, за да стартираш проекта локално:

1. **Отвори проекта в Visual Studio** – отвори `.sln` файла.
2. **Отиди до проекта `RentACar.Web`.**
3. **Конфигурирай връзката с базата данни:**
   - Отвори файла `appsettings.json`.
   - Замени стойността на `"DefaultConnection"` с твоята SSMS (SQL Server Management Studio) connection string.
4. **Създай базата данни:**
   - Отвори **Package Manager Console** (Tools > NuGet Package Manager > Package Manager Console).
   - Изпълни командата:
     ```powershell
     Update-Database
     ```
     > Пълната команда е коментирана в началото на `ApplicationDbContext.cs`, ако се нуждаеш от повече детайли.
5. **Стартирай проекта от Visual Studio.**