
## Markdown
# ✅ To-Do List Web Application

## 📘 Project Overview

This is a fully functional **To-Do List Web Application** built with **ASP.NET Core MVC** using **.NET 9** and **C# 13.0**. The application provides a clean web interface for managing tasks with full CRUD (Create, Read, Update, Delete) functionality. Data is persisted locally using JSON file storage, making it lightweight and easy to deploy without requiring a database server.

The application follows the Model-View-Controller (MVC) architectural pattern and demonstrates best practices in web development, including separation of concerns, error handling, and data persistence.

---

## ✨ Features

- ➕ **Create new tasks** with title and description
- 📝 **Edit existing tasks** to update information
- ✅ **Toggle task completion status** with a single click
- ❌ **Delete tasks** that are no longer needed
- 💾 **Persistent local storage** using JSON files
- 🎨 **Clean and responsive web interface** built with Razor views
- 🧱 **MVC architecture** with organized Controllers, Models, and Views
- 🔄 **Automatic task ID generation** using GUIDs
- 📅 **Task creation timestamps** to track when tasks were added
- 🛡️ **Error handling** for invalid JSON and file system issues

---

## 📂 File Structure
```

ToDoList/
│
├── Controllers/
│   └── TaskController.cs       # Handles all HTTP requests and task operations
│
├── Models/
│   └── TaskItem.cs             # Task entity with Id, Title, Description, IsCompleted, CreatedAt
│
├── Views/
│   └── Task/                   # Razor views for the task interface
│       ├── Index.cshtml        # Main task list view
│       ├── Create.cshtml       # Form for creating new tasks
│       └── Edit.cshtml         # Form for editing existing tasks
│
├── Data/
│   └── tasks.json              # JSON file storing all task data
│
├── wwwroot/                    # Static files (CSS, JavaScript, images)
│
├── Properties/
│   └── launchSettings.json     # Development server configuration
│
├── Program.cs                  # Application entry point and middleware configuration
├── ToDoList.csproj             # Project file with dependencies
└── README.md                   # Project documentation
```
---

## 🧩 Installation Instructions

### 🔧 Requirements

- **.NET 9.0 SDK** or later
- **JetBrains Rider**, **Visual Studio 2022**, or **Visual Studio Code**
- Compatible with **Windows**, **macOS**, and **Linux**

### 💻 Installation Steps

1. **Clone the repository:**
   ```bash
   git clone https://github.com/genarodagotto/ToDoList.git
   cd ToDoList
   ```

2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

3. **Build the project:**
   ```bash
   dotnet build
   ```

4. **Run the application:**
   ```bash
   dotnet run --project ToDoList
   ```

5. **Open your browser:**

   Navigate to `https://localhost:5001` or `http://localhost:5000`

   (Check console output for the exact URL)

6. **Start managing your tasks!**

### 🚀 Alternative: Run in Development Mode

```bash
dotnet watch run --project ToDoList
```
```


This enables hot reload, automatically restarting the server when you make changes.

---

## 🌐 API Usage Details

The application uses standard ASP.NET Core MVC routing patterns. All routes are handled by the `TaskController`.

### Available Routes

| HTTP Method | Route Path | Action | Description |
|------------|------------|--------|-------------|
| **GET** | `/` | `Index()` | Display all tasks (default route) |
| **GET** | `/Task` | `Index()` | Display all tasks |
| **GET** | `/Task/Index` | `Index()` | Display all tasks |
| **GET** | `/Task/Create` | `Create()` | Show create task form |
| **POST** | `/Task/Create` | `Create(TaskItem)` | Submit new task |
| **GET** | `/Task/Edit/{id}` | `Edit(Guid)` | Show edit form for specific task |
| **POST** | `/Task/Edit` | `Edit(TaskItem)` | Submit updated task |
| **GET** | `/Task/Delete/{id}` | `Delete(Guid)` | Delete specific task |
| **GET** | `/Task/ToggleComplete/{id}` | `ToggleComplete(Guid)` | Toggle completion status |

### Route Pattern

The default route pattern is configured as:
```
{controller=Task}/{action=Index}/{id?}
```


### Example Usage

**Creating a Task (Form Submission):**
```
POST /Task/Create HTTP/1.1
Content-Type: application/x-www-form-urlencoded

Title=Buy+groceries&Description=Milk,+eggs,+bread&IsCompleted=false
```


**Editing a Task:**
```
GET /Task/Edit/3fa85f64-5717-4562-b3fc-2c963f66afa6 HTTP/1.1
```


**Toggling Completion Status:**
```
GET /Task/ToggleComplete/3fa85f64-5717-4562-b3fc-2c963f66afa6 HTTP/1.1
```


**Deleting a Task:**
```
GET /Task/Delete/3fa85f64-5717-4562-b3fc-2c963f66afa6 HTTP/1.1
```


---

## 💾 How Data Is Stored

All task data is stored locally in the **`Data/tasks.json`** file in JSON format. The application automatically creates this directory and file if they don't exist.

### Storage Location

- **Path:** `ToDoList/Data/tasks.json`
- **Format:** JSON array
- **Encoding:** UTF-8

### Storage Format Example

```json
[
  {
    "Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "Title": "Finish Software Project 1",
    "Description": "Submit project and video presentation before deadline",
    "IsCompleted": false,
    "CreatedAt": "2025-10-05T14:30:00"
  },
  {
    "Id": "7c9e6679-7425-40de-944b-e07fc1f90ae7",
    "Title": "Tennis training",
    "Description": "2-hour practice session",
    "IsCompleted": true,
    "CreatedAt": "2025-10-04T10:15:00"
  }
]
```


### Task Object Properties

| Property | Type | Description |
|----------|------|-------------|
| **Id** | `Guid` | Unique identifier for each task (auto-generated) |
| **Title** | `string` | Task title (required field) |
| **Description** | `string` | Detailed task description (optional) |
| **IsCompleted** | `bool` | Completion status (default: false) |
| **CreatedAt** | `DateTime` | Timestamp when task was created (auto-generated) |

### Persistence Behavior

- **Load Operations:** Tasks are loaded from JSON at the start of each HTTP request
- **Save Operations:** Tasks are saved to JSON after every create, update, or delete operation
- **Error Handling:** Invalid or corrupt JSON is automatically reset to an empty task list
- **File Creation:** The Data directory and tasks.json file are created automatically if missing
- **Data Format:** JSON is serialized with indentation for human readability

### Storage Advantages

✅ No database setup required  
✅ Easy to back up (single file)  
✅ Human-readable format  
✅ Cross-platform compatibility

### Storage Limitations

❌ Not suitable for concurrent users  
❌ No transaction support  
❌ Limited scalability  
❌ Risk of data loss if file becomes corrupted

---

## ⚠️ Known Issues / Limitations

### Data & Storage

- **No database backend** – All data is stored in a single JSON file, which is not suitable for production environments with multiple users
- **No concurrent access handling** – Multiple simultaneous requests could potentially cause race conditions and data corruption
- **Limited scalability** – File-based storage becomes inefficient with thousands of tasks
- **No backup mechanism** – No automatic backup or recovery system in place

### Features & Functionality

- **No user authentication** – Single-user application with no login, registration, or user management
- **No search or filtering** – Tasks are displayed in a simple list without search, sort, or filter capabilities
- **No task categories or tags** – Tasks cannot be organized into groups, projects, or with custom labels
- **No due dates or reminders** – No time-based task management features or notifications
- **No task priority levels** – No way to mark tasks as urgent or set priority
- **No task notes or attachments** – Cannot add additional files or rich text notes to tasks

### User Interface

- **Limited validation feedback** – Minimal client-side validation for form inputs
- **No responsive mobile optimizations** – UI may not be optimized for mobile devices
- **No dark mode** – Only light theme available
- **No bulk operations** – Cannot select multiple tasks for batch delete or update

### Technical

- **File permissions required** – The application requires write access to the Data directory
- **No API versioning** – Breaking changes to the TaskItem model will corrupt existing data
- **No logging system** – Limited logging for debugging production issues
- **No unit tests** – No automated test coverage

---

## 🪲 Debugging Summary

During development, several issues were encountered and successfully resolved. Here's a summary of the main challenges and their solutions:

### Issue 1: JSON Deserialization Errors

**Problem:** Application crashed when `tasks.json` contained invalid JSON, was empty, or contained an empty object `{}`

**Symptoms:**
- `JsonException` thrown during deserialization
- Application returning 500 Internal Server Error
- Tasks not loading on Index page

**Solution:**
- Added comprehensive try-catch blocks in `LoadTasks()` method
- Handle `JsonException` specifically to catch malformed JSON
- Reset to empty list when JSON is invalid
- Added null-coalescing operator to handle null deserialization results

---

### Issue 2: Directory Not Found

**Problem:** Application crashed when the Data directory didn't exist on first run

**Symptoms:**
- `DirectoryNotFoundException` when trying to save tasks
- File write operations failing

**Solution:**
- Added directory existence check in `SaveTasks()` method
- Automatically create directory structure if it doesn't exist
- Use `Path.GetDirectoryName()` to extract directory from file path
- Create directory before attempting file write

---

### Issue 3: Task ID Conflicts

**Problem:** Initial implementation used integer IDs which caused conflicts after deletion and re-creation

**Symptoms:**
- Duplicate IDs appearing after deleting tasks
- Edit/Delete operations affecting wrong tasks

**Solution:**
- Switched from `int` to `Guid` for task IDs
- Use `Guid.NewGuid()` for automatic unique ID generation
- Updated all route parameters to accept `Guid` type
- Modified Find operations to use GUID comparison

---

### Issue 4: Task Edit Not Persisting

**Problem:** Edit operation would find the task but updates weren't saved correctly

**Symptoms:**
- Changes made in Edit form not appearing after save
- Old task data still showing after edit

**Solution:**
- Changed to use `FindIndex()` instead of direct list access
- Properly replace task object at the correct index
- Ensure `SaveTasks()` is called after modification

---

### Issue 5: Default Route Configuration

**Problem:** Application returned 404 when navigating to root URL (`/`)

**Symptoms:**
- Homepage not loading
- Required explicit navigation to `/Task/Index`

**Solution:**
- Configured default route pattern in `Program.cs`
- Set default controller to "Task" and default action to "Index"
- Route pattern: `{controller=Task}/{action=Index}/{id?}`

---

### Debugging Tips for Future Development

🔍 **Check Console Logs:** ASP.NET Core provides detailed logging in the console during development

🔍 **Inspect JSON File:** Manually verify the contents of `Data/tasks.json` to ensure proper formatting

🔍 **Browser DevTools:** Use Network tab to inspect HTTP requests, responses, and status codes

🔍 **Developer Exception Page:** Enabled in Development mode for detailed error information

🔍 **Breakpoint Debugging:** Use Rider's debugger to step through controller actions

🔍 **File Permissions:** Ensure the application has read/write access to the Data directory

---

## 🙌 Credits and Acknowledgements

### Development

**Developed by:** Genaro Dagotto  
**Institution:** Newman University  
**Course:** Software Project 1 (Fall 2025)  
**Semester:** Fall 2025

### Special Thanks

- **Course Professor** – For guidance, project requirements, and valuable feedback throughout development
- **Microsoft .NET Team** – For excellent documentation, tutorials, and the robust ASP.NET Core framework
- **JetBrains** – For providing Rider IDE with outstanding support for .NET development on macOS
- **ASP.NET Core Community** – For tutorials, Stack Overflow answers, and best practice guides

### Technologies & Frameworks Used

- **ASP.NET Core MVC 9.0** – Web application framework
- **C# 13.0** – Primary programming language
- **Razor View Engine** – Server-side templating for HTML generation
- **System.Text.Json** – JSON serialization and deserialization
- **.NET Core Runtime** – Cross-platform runtime environment
- **Kestrel Web Server** – High-performance web server

### Development Tools

- **JetBrains Rider** – Primary IDE (macOS)
- **Git** – Version control
- **.NET CLI** – Command-line build and run tools

---

## 🧾 License

This project is licensed under the **MIT License**.

You are free to:
- ✅ Use this code for educational purposes
- ✅ Modify and adapt the code for your needs
- ✅ Distribute copies of the code
- ✅ Use in personal or commercial projects

**Attribution is appreciated but not required.**

---

## 📞 Contact & Support

For questions, suggestions, or issues related to this project:

- **Developer:** Genaro Dagotto
- **Institution:** Newman University
- **Course:** Software Project 1

---

**Happy Task Managing! ✅**

*Last Updated: October 5, 2025*
```

```
