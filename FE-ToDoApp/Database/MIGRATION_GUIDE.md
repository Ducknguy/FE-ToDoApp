# H??ng d?n chuy?n sang SQLite

## ? ?ã hoàn thành:
1. ? Install SQLite NuGet package
2. ? T?o SQLiteHelper.cs
3. ? S?a WeekCategoryRepository
4. ? S?a WeekTaskRepository  
5. ? S?a WeekCategoryController
6. ? S?a WeekTaskController
7. ? S?a Program.cs ?? kh?i t?o DB

## ?? C?N S?A TH? CÔNG:

### File 1: `FE-ToDoApp\WeekList\WeekGroupMVC.cs`

**Xóa dòng 15 (không c?n n?a):**
```csharp
private const string ConnectionString = "Data Source=duc;Initial Catalog=ToDoApp;Integrated Security=True;Encrypt=False";
```

**Tìm dòng 31-32:**
```csharp
_categoryController = new WeekCategoryController(ConnectionString);
_taskController = new WeekTaskController(ConnectionString);
```

**S?a thành:**
```csharp
_categoryController = new WeekCategoryController();
_taskController = new WeekTaskController();
```

---

### File 2: `FE-ToDoApp\WeekList\Views\WeekItemsControl.cs`

**Xóa dòng 13-14:**
```csharp
public string ConnectionString { get; set; }
```

**Xóa method `Initialize` (dòng 27-30):**
```csharp
public void Initialize(string connectionString)
{
    ConnectionString = connectionString;
    _taskController = new WeekTaskController(connectionString);
}
```

**S?a constructor (dòng 23-26):

**TÌM:**
```csharp
public WeekItemsControl()
{
    InitializeComponent();
}
```

**THAY B?NG:**
```csharp
public WeekItemsControl()
{
    InitializeComponent();
    _taskController = new WeekTaskController();
}
```

---

## Sau khi s?a:

1. **Build l?i project**: Build ? Rebuild Solution
2. **Ch?y app**: File database `ToDoApp.db` s? t? ??ng ???c t?o trong folder exe
3. **V? trí database**: `bin\Debug\net8.0-windows\ToDoApp.db`

---

## L?i ích:

? **Development**: 
- File `ToDoApp.db` trong project
- Commit lên Git ? team clone v? có s?n DB
- Không c?n cài SQL Server

? **Production** (khi package cho user):
- User ch? c?n gi?i nén và ch?y .exe
- Không c?n cài DB engine
- Database ?i kèm app

---

## Troubleshooting:

### N?u g?p l?i "table not found":
- Xóa file `ToDoApp.db` trong `bin\Debug\net8.0-windows\`
- Ch?y l?i app ? database s? ???c t?o l?i

### N?u mu?n xem database:
- Download **DB Browser for SQLite**: https://sqlitebrowser.org/
- M? file `ToDoApp.db`
