﻿using Newtonsoft.Json;

namespace TaskTracker;

public class TaskTrackerRepository : ITaskTrackerRepository
{
    private const string FileName = "task_tracker.json";
    private readonly string _filePath = Path.Combine(Environment.CurrentDirectory, FileName);

    public List<TaskEntity> LoadAllTasks()
    {
        if (!File.Exists(_filePath))
        {
            SaveJsonData([]);
        }

        var jsonData = File.ReadAllText(_filePath);
        var tasks = JsonConvert.DeserializeObject<List<TaskEntity>>(jsonData) ?? [];

        return tasks;
    }

    public void SaveJsonData(List<TaskEntity> tasks)
    {
        string jsonData = JsonConvert.SerializeObject(tasks);

        using var file = File.CreateText(_filePath);
        file.Write(jsonData);
    }
}