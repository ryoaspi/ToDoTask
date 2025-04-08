using System;
using System.Collections.Generic;
using System.Text.Json;


public class ToDoApp
{
    static List<ToDoTask> tasks = new List<ToDoTask>();
    static string _saveTask = "Tache.json";

    static void Main(string[] args)
    {
        bool exitApp = false;

        while (!exitApp)
        {
            Console.Clear();
            Console.WriteLine("=====Liste de chose à faire=====");
            Console.WriteLine("1. Ajouter une tâche");
            Console.WriteLine("2. Voir les tâches");
            Console.WriteLine("3. Modifier le statut d'une tâche.");
            Console.WriteLine("4. Retirer une tâche");
            Console.WriteLine("5. Exit");
            // lire les entrées
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    ChangeTask();
                    break;
                case "4":
                    RemoveTask();
                    break;
                case "5":
                    exitApp = true;
                    Console.WriteLine("Quitter l'application");
                    break;
                default:
                    Console.WriteLine("Option invalide. Séléctionne une entrées.");
                    break;
            }
        }
    }
    // méthode pour rajouter une tâche.
    static void AddTask()
    {
        Console.Clear();
        Console.WriteLine("Entrée une tâche :");
        string? nameTask = Console.ReadLine();
      
       

        if (!string.IsNullOrWhiteSpace(nameTask))
        {
            var task = new ToDoTask();
            task.Name = nameTask;
            tasks.Add(task);

            var saveTask = JsonSerializer.Serialize(tasks);
            //Console.WriteLine(saveTask);
            Console.WriteLine($"La tâche \"{nameTask}\"à été ajouté avec succés");
            File.WriteAllText(_saveTask, saveTask);
        }
        else
        {
            Console.WriteLine("La tâche ne peut pas être vide!");
        }
        Console.WriteLine("Appuyer sur entrer pour retourner au menu.");
        Console.ReadLine();
        
    }
    // Méthode pour voir toutes les tâches.
    static void ViewTasks()
    {
        Console.Clear();

        if (tasks.Count == 0)
        {
            Console.WriteLine("Il n'y a pas de tâches.");
        }
        else
        {
            Console.WriteLine("Vos tâches : ");
            string saveTaskAllText = File.ReadAllText("Tache.json");
            List<string>? saveTasks =JsonSerializer.Deserialize<List<string>>(saveTaskAllText);
            // for (int i = 0; i < tasks.Count; i++)
            // {
            //     Console.WriteLine($"{i+1}. {tasks[i]}");
            //     // 
            // }
            Console.WriteLine(saveTasks);
        }
        Console.WriteLine("\n Appuyer sur entrer pour retourner au menu.");
        Console.ReadLine();
    }
    // Méthode pour modifier le status d'une tâche
    static void ChangeTask()
    {
        Console.Clear();
        if (tasks.Count == 0)
        {
            Console.WriteLine("Pas de tâches à modifier.");
            Console.WriteLine("Appuyer sur entrer pour retourner au menu.");
            Console.ReadLine();
            return;
        }
        ViewTasks();
        Console.WriteLine("\n Entrée le numéro de la tâches que vous voulez modifier.");
        if (int.TryParse(Console.ReadLine(), out int taskIndex))
        {
            if (taskIndex >= 1 && taskIndex <= tasks.Count)
            {
                Console.WriteLine($"Voulez-vous l'ouvrir (1), dire quelle progresse (2) ou dire qu'elle est faite (3)");
                string userInput = Console.ReadLine();

                ToDoTask.Status status;
                switch (userInput)
                {
                    case "1":
                        tasks[taskIndex-1].CurrentStatus = ToDoTask.Status.Open;
                        break;
                    case "2":
                        tasks[taskIndex-1].CurrentStatus = ToDoTask.Status.Progress;
                        break;
                    case "3":
                        tasks[taskIndex-1].CurrentStatus =ToDoTask.Status.Dones;
                        break;
                }
                Console.WriteLine($"La tâche \"{tasks[taskIndex-1].CurrentStatus}\" à été modifié");
                
            }
            else
            {
                Console.Write("Le numéro est invalide.");
            }
        }
        else
        {
            Console.WriteLine("Entré un numéro valide.");
        }
        Console.WriteLine("Appuyer sur entrer pour retourner au menu.");
        Console.ReadLine();
        
    }
    
    // Méthode pour retirer une tâche
    static void RemoveTask()
    {
        Console.Clear();
        if (tasks.Count == 0)
        {
            Console.WriteLine("Pas de tâches à retirer.");
            Console.WriteLine("Appuyer sur entrer pour retourner au menu.");
            Console.ReadLine();
            return;
        }
        ViewTasks();
        Console.WriteLine("\n Entrée le numéro de la tâches que vous voulez retirer.");
        if (int.TryParse(Console.ReadLine(), out int taskIndex))
        {
            if (taskIndex >= 1 && taskIndex <= tasks.Count)
            {
                Console.WriteLine($"La tâche \"{tasks[taskIndex-1]}\" à été retiré");
                tasks.RemoveAt(taskIndex - 1);
            }
            else
            {
                Console.Write("Le numéro est invalide.");
            }
        }
        else
        {
            Console.WriteLine("Entré un numéro valide.");
        }
        
        Console.WriteLine("Appuyer sur entrer pour retourner au menu.");
        Console.ReadLine();
    }
    
    
}

internal class ToDoTask
{
    public enum Status
    {
        Open, //0
        Progress, //1
        Dones, //2
    }

    public ToDoTask()
    {
        CurrentStatus = Status.Open;
    }

    public Status CurrentStatus { get; set; }
    public string? Name { get; set; }
}
