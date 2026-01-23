# H??ng d?n s?a l?i Category b? l?u chung

## V?n ??
Các category ?ang b? l?u chung vào b?ng `Calendar` thay vì b?ng riêng `WeekCategory`, d?n ??n d? li?u không ???c t? ch?c t?t.

## Gi?i pháp

### B??c 1: Ch?y SQL Script ?? t?o b?ng m?i

1. M? **SQL Server Management Studio** (SSMS)
2. K?t n?i ??n server `duc` và database `ToDoApp`
3. M? file `SQL/CreateWeekCategoryTables.sql`
4. Ch?y toàn b? script (F5)

Script này s? t?o 2 b?ng:
- **WeekCategory**: L?u thông tin các nhóm công vi?c
- **WeekTask**: L?u các task thu?c t?ng category (có th? dùng sau này thay vì Calendar)

### B??c 2: Ki?m tra b?ng ?ã ???c t?o

Ch?y query sau ?? ki?m tra:

```sql
SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME IN ('WeekCategory', 'WeekTask')
```

B?n s? th?y 2 b?ng m?i.

### B??c 3: Clean và Rebuild Solution

1. Trong Visual Studio, ch?n **Build ? Clean Solution**
2. ?óng t?t c? các tab Designer
3. Ch?n **Build ? Rebuild Solution**

### B??c 4: Test l?i ch?c n?ng

1. Ch?y ?ng d?ng (F5)
2. Th? thêm m?t category m?i v?i tu?n khác nhau
3. Ki?m tra b?ng `WeekCategory` trong SSMS:

```sql
SELECT * FROM WeekCategory
```

B?n s? th?y các category ???c l?u riêng bi?t v?i thông tin tu?n ??y ??.

## C?u trúc b?ng m?i

### WeekCategory
- `CategoryId` (INT, PRIMARY KEY, IDENTITY): ID t? t?ng
- `CategoryName` (NVARCHAR(255)): Tên nhóm công vi?c
- `WeekStartDate` (DATE): Ngày b?t ??u tu?n (th? Hai)
- `WeekEndDate` (DATE): Ngày k?t thúc tu?n (Ch? nh?t)
- `OrderIndex` (INT): Th? t? hi?n th?
- `IsActive` (BIT): Tr?ng thái active/inactive
- `CreatedAt`, `UpdatedAt` (DATETIME): Th?i gian t?o/c?p nh?t

### WeekTask (tùy ch?n, có th? dùng sau)
- `TaskId` (INT, PRIMARY KEY, IDENTITY)
- `CategoryId` (INT, FOREIGN KEY ? WeekCategory)
- `WeekStartDate` (DATE)
- `DayOfWeek` (INT): 1=Monday, 7=Sunday
- `Title` (NVARCHAR(500))
- `IsDone` (BIT)
- `OrderIndex` (INT)
- `CreatedAt`, `UpdatedAt` (DATETIME)

## Nh?ng thay ??i trong code

1. **WeekCategoryRepository.cs**: ?ã s?a ?? l?u vào b?ng `WeekCategory` thay vì `Calendar`
2. **WeekTaskRepository.cs**: V?n l?u task vào `Calendar` nh?ng l?y category name t? `WeekCategory`

## L?u ý quan tr?ng

?? **D? li?u c?**: Các category c? trong b?ng `Calendar` s? KHÔNG ???c t? ??ng chuy?n sang. B?n c?n thêm l?i các category t? giao di?n.

?? **Foreign Key**: N?u mu?n chuy?n sang dùng b?ng `WeekTask` hoàn toàn, c?n s?a thêm `WeekTaskRepository` ?? l?u vào `WeekTask` thay vì `Calendar`.
