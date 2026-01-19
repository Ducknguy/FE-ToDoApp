# H??ng d?n chuy?n toàn b? project sang SQLite

## ?? M?C L?C

1. [Week Module](#1-week-module-?-?ã-xong)
2. [Todo List Module](#2-todo-list-module)
3. [Calendar Module](#3-calendar-module)
4. [Chat Module](#4-chat-module)
5. [Login/User Module](#5-loginuser-module)
6. [Thùng Rác Module](#6-thùng-rác-module)

---

## 1. Week Module ? (?ã xong)

- ? WeekCategoryRepository.cs
- ? WeekTaskRepository.cs
- ?? WeekGroupMVC.cs - **C?n s?a th? công**
- ?? WeekItemsControl.cs - **C?n s?a th? công**

---

## 2. Todo List Module

### File c?n s?a:

#### `FE-ToDoApp\Lich Trinh\DatabaseHelper.cs`

**Cách 1: Xóa h?n file này** (khuyên dùng)
- Vì ?ã có `SQLiteHelper.cs` r?i

**Cách 2: S?a l?i ?? dùng SQLite**
```csharp
using System.Data.SQLite;
using FE_ToDoApp.Database;

namespace FE_ToDoApp.Lich_Trinh
{
    public static class DatabaseHelper
    {
        public static SQLiteConnection GetConnection()
        {
            return SQLiteHelper.GetConnection();
        }
    }
}
```

#### Các file DAO/Repository trong `Lich Trinh` folder:

**Tìm ki?m pattern:**
- `using System.Data.SqlClient;` ? `using System.Data.SQLite;`
- `SqlConnection` ? `SQLiteConnection`
- `SqlCommand` ? `SQLiteCommand`
- `SqlDataAdapter` ? `SQLiteDataAdapter`
- `SqlParameter` ? `SQLiteParameter`

**Ví d?:**
```csharp
// TR??C:
using (var conn = new SqlConnection(connectionString))

// SAU:
using (var conn = SQLiteHelper.GetConnection())
```

---

## 3. Calendar Module

### File: `FE-ToDoApp\Calendar\DatabaseHelper.cs`

**T??ng t? Todo List**, ch?n 1 trong 2:

**Cách 1: Xóa file**

**Cách 2: S?a l?i**
```csharp
using System.Data.SQLite;
using FE_ToDoApp.Database;

namespace FE_ToDoApp.Calendar
{
    public static class DatabaseHelper
    {
        public static SQLiteConnection GetConnection()
        {
            return SQLiteHelper.GetConnection();
        }
    }
}
```

---

## 4. Chat Module

### File: `FE-ToDoApp\DAO\ChatDAO.cs`

**Các b??c s?a:**

1. **??i using:**
```csharp
// XÓA:
using System.Data.SqlClient;

// THÊM:
using System.Data.SQLite;
using FE_ToDoApp.Database;
```

2. **S?a t?t c? methods:**

**Ví d? `GetSessions()`:**
```csharp
// TR??C:
using (SqlConnection conn = db.GetConnection())
{
    conn.Open();
    string sql = "SELECT * FROM ChatSessions ORDER BY CreatedAt DESC";
    SqlCommand cmd = new SqlCommand(sql, conn);
    SqlDataReader rd = cmd.ExecuteReader();
    // ...
}

// SAU:
using (var conn = SQLiteHelper.GetConnection())
{
    conn.Open();
    string sql = "SELECT * FROM ChatSessions ORDER BY CreatedAt DESC";
    using (var cmd = new SQLiteCommand(sql, conn))
    using (var rd = cmd.ExecuteReader())
    {
        // ...
    }
}
```

**Áp d?ng t??ng t? cho:**
- `GetMessages()`
- `SaveSession()`
- `SaveMessage()`
- `DeleteSession()`

---

## 5. Login/User Module

### File: `FE-ToDoApp\login\DatabaseHelper.cs`

**Cách 1: Xóa file**

**Cách 2: S?a l?i**
```csharp
using System.Data.SQLite;
using FE_ToDoApp.Database;

namespace FE_ToDoApp.login
{
    public static class DatabaseHelper
    {
        public static SQLiteConnection GetConnection()
        {
            return SQLiteHelper.GetConnection();
        }
    }
}
```

### File: `FE-ToDoApp\login\Login1.cs`

**Tìm method `btnLogin_Click_1`:**
```csharp
// TR??C:
using (SqlConnection connection = DatabaseHelper.GetConnection())
{
    // ...
    using (SqlCommand command = new SqlCommand(query, connection))
    // ...
}

// SAU:
using (var connection = DatabaseHelper.GetConnection()) // Ho?c SQLiteHelper.GetConnection()
{
    // ...
    using (var command = new SQLiteCommand(query, connection))
    // ...
}
```

**??ng quên:**
```csharp
using System.Data.SQLite;
```

---

## 6. Thùng Rác Module

### File: `FE-ToDoApp\ThungRac\DBhelpers.cs`

**Quan tr?ng:** File này s? d?ng nhi?u SQL queries ph?c t?p!

**Cách s?a:**

1. **??i using:**
```csharp
using System.Data.SQLite;
using FE_ToDoApp.Database;
```

2. **S?a `GetData()`:**
```csharp
public static DataTable GetData(string sql)
{
    using var conn = SQLiteHelper.GetConnection();
    using var da = new SQLiteDataAdapter(sql, conn);
    DataTable dt = new DataTable();
    da.Fill(dt);
    return dt;
}
```

3. **S?a `Execute()`:**
```csharp
public static int Execute(string sql, params SQLiteParameter[] ps)
{
    using var conn = SQLiteHelper.GetConnection();
    using var cmd = new SQLiteCommand(sql, conn);
    if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);
    conn.Open();
    return cmd.ExecuteNonQuery();
}
```

4. **S?a `XoaVaoThungRac()`:**
```csharp
// GETDATE() ? datetime('now')
sql = "UPDATE Todo_List_Detail SET IsDeleted = 1, DeletedAt = datetime('now') WHERE id_todo = @id";
```

5. **S?a parameter:**
```csharp
// TR??C:
new SqlParameter("@id", itemId)

// SAU:
new SQLiteParameter("@id", itemId)
```

---

## 7. ConnectSQL.cs (Legacy)

### File: `FE-ToDoApp\DAO\ConnectSQL.cs`

**?? QUAN TR?NG:** File này ???c dùng b?i ChatDAO và có th? UserDAO.

**2 L?A CH?N:**

### **Cách 1: Xóa h?n và refactor** (khuyên dùng)
- S?a `ChatDAO` ?? dùng `SQLiteHelper` tr?c ti?p
- Xóa file `ConnectSQL.cs`

### **Cách 2: S?a l?i ConnectSQL**
```csharp
using System;
using System.Data;
using System.Data.SQLite;
using FE_ToDoApp.Database;
using System.Windows.Forms;

namespace FE_ToDoApp
{
    class ConnectSQL
    {
        private SQLiteConnection conn = null;

        public ConnectSQL()
        {
            conn = SQLiteHelper.GetConnection();
        }

        public SQLiteConnection GetConnection()
        {
            return SQLiteHelper.GetConnection();
        }

        public DataTable LayDuLieu(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(dt);

                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i l?y d? li?u: " + ex.Message);
            }
            return dt;
        }

        public bool ThucHienLenh(string sql)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                int ketqua = cmd.ExecuteNonQuery();

                if (conn.State == ConnectionState.Open) conn.Close();

                return ketqua > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i th?c hi?n l?nh: " + ex.Message);
                return false;
            }
        }
    }
}
```

---

## ?? CHECKLIST T?NG QUÁT

### V?i M?I FILE có SQL Server:

- [ ] 1. ??i `using System.Data.SqlClient;` ? `using System.Data.SQLite;`
- [ ] 2. Thêm `using FE_ToDoApp.Database;`
- [ ] 3. ??i `SqlConnection` ? `SQLiteConnection` ho?c dùng `SQLiteHelper.GetConnection()`
- [ ] 4. ??i `SqlCommand` ? `SQLiteCommand`
- [ ] 5. ??i `SqlDataAdapter` ? `SQLiteDataAdapter`
- [ ] 6. ??i `SqlParameter` ? `SQLiteParameter`
- [ ] 7. ??i `GETDATE()` ? `datetime('now')`
- [ ] 8. ??i `SCOPE_IDENTITY()` ? `last_insert_rowid()`

---

## ?? CÁCH TÌM FILE C?N S?A

### Trong Visual Studio:

**Ctrl + Shift + F** (Find in Files)

**Tìm ki?m:**
1. `using System.Data.SqlClient;`
2. `SqlConnection`
3. `new SqlCommand`
4. `GETDATE()`
5. `SCOPE_IDENTITY()`

? T?t c? k?t qu? c?n s?a theo pattern trên!

---

## ?? L?U Ý QUAN TR?NG

### 1. **Data Types khác bi?t:**

| SQL Server | SQLite | Note |
|---|---|---|
| `bit` | `INTEGER` (0/1) | ? Boolean |
| `nvarchar(MAX)` | `TEXT` | ? No limit |
| `tinyint` | `INTEGER` | ? |
| `IDENTITY` | `AUTOINCREMENT` | ? |

### 2. **Functions khác bi?t:**

| SQL Server | SQLite |
|---|---|
| `GETDATE()` | `datetime('now')` |
| `SCOPE_IDENTITY()` | `last_insert_rowid()` |
| `ISNULL(x, y)` | `IFNULL(x, y)` |

### 3. **Parameters:**
```csharp
// SQL Server:
cmd.Parameters.AddWithValue("@param", value);

// SQLite: GI?NG NHAU!
cmd.Parameters.AddWithValue("@param", value);
```

---

## ? SAU KHI S?A XONG

1. **Build Solution:** `Ctrl + Shift + B`
2. **Fix errors** (n?u có)
3. **Ch?y app:** `F5`
4. **Test t?ng module:**
   - ? Week ? Add/Edit/Delete category & tasks
   - ? Todo List ? Add/Edit/Delete todos
   - ? Calendar ? Add/Edit events
   - ? Chat ? Send messages
   - ? Login ? Login/Register
   - ? Thùng rác ? Delete/Restore

---

## ?? KHI DEPLOY

1. Publish project
2. Copy file `ToDoApp.db` cùng folder v?i `.exe`
3. User ch? c?n:
   - Gi?i nén
   - Ch?y `.exe`
   - **KHÔNG C?N** cài SQL Server!

---

## ?? N?U G?P L?I

### L?i: "table not found"
- Xóa file `ToDoApp.db` trong `bin\Debug\net8.0-windows\`
- Ch?y l?i app

### L?i: "no such function: GETDATE"
- Tìm và ??i t?t c? `GETDATE()` ? `datetime('now')`

### L?i: "database is locked"
- ??m b?o luôn `using` v?i connection
- ?óng connection sau khi dùng xong

---

**B?n có th? s?a t?ng module m?t, test xong r?i m?i s?a module ti?p theo!**
