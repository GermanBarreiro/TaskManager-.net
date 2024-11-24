using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using System.Collections.Generic;
using System.Linq;

public class TasksController : Controller
{
    private static List<TaskItem> tasks = new List<TaskItem>();

    public IActionResult Index()
    {
        return View(tasks);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        if (ModelState.IsValid)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);
            return RedirectToAction("Index");
        }
        return View(task);
    }

    public IActionResult Edit(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    [HttpPost]
    public IActionResult Edit(TaskItem task)
    {
        var existingTask = tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existingTask == null)
        {
            return NotFound();
        }

        existingTask.Title = task.Title;
        existingTask.Description = task.Description;
        existingTask.IsCompleted = task.IsCompleted;

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            tasks.Remove(task);
        }
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }
}