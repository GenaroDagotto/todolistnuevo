using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        private readonly string dataFile = "Data/tasks.json";

        private List<TaskItem> LoadTasks()
        {
            try
            {
                if (!System.IO.File.Exists(dataFile))
                    return new List<TaskItem>();

                var json = System.IO.File.ReadAllText(dataFile);

                if (string.IsNullOrWhiteSpace(json))
                    return new List<TaskItem>();

                var tasks = JsonSerializer.Deserialize<List<TaskItem>>(json);
                return tasks ?? new List<TaskItem>();
            }
            catch (JsonException)
            {
                // Si el JSON es inválido (por ejemplo "{}"), reseteamos a una lista vacía
                var empty = new List<TaskItem>();
                SaveTasks(empty);
                return empty;
            }
            catch
            {
                // Ante cualquier otro error, devolvemos lista vacía para no romper la UI
                return new List<TaskItem>();
            }
        }

        private void SaveTasks(List<TaskItem> tasks)
        {
            var directory = Path.GetDirectoryName(dataFile);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(dataFile, json);
        }

        public IActionResult Index()
        {
            var tasks = LoadTasks();
            return View(tasks);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            var tasks = LoadTasks();
            tasks.Add(task);
            SaveTasks(tasks);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var tasks = LoadTasks();
            var task = tasks.Find(t => t.Id == id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskItem task)
        {
            var tasks = LoadTasks();
            var index = tasks.FindIndex(t => t.Id == task.Id);
            if (index >= 0)
            {
                tasks[index] = task;
                SaveTasks(tasks);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var tasks = LoadTasks();
            tasks.RemoveAll(t => t.Id == id);
            SaveTasks(tasks);
            return RedirectToAction("Index");
        }

        public IActionResult ToggleComplete(Guid id)
        {
            var tasks = LoadTasks();
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                SaveTasks(tasks);
            }
            return RedirectToAction("Index");
        }
    }
}