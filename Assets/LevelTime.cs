// using System.Collections.Generic;
// using UnityEngine;
// using SQLite;

// public class LevelTime
// {
//     [PrimaryKey, AutoIncrement]
//     public int Id { get; set; }
//     public string LevelName { get; set; }
//     public float CompletionTime { get; set; }
// }

// public class DatabaseManager : MonoBehaviour
// {
//     private SQLiteConnection db;
//     private string dbPath;

//     void Awake()
//     {
//         // Ruta de la base de datos
//         dbPath = Application.persistentDataPath + "/GameData.db";
//         db = new SQLiteConnection(dbPath);

//         // Crear la tabla si no existe
//         db.CreateTable<LevelTime>();
//         Debug.Log("Base de datos inicializada: " + dbPath);
//     }

//     /// <summary>
//     /// Guarda el tiempo del nivel en la base de datos.
//     /// Si el nivel ya existe, actualiza el tiempo.
//     /// </summary>
//     public void SaveLevelTime(string levelName, float time)
//     {
//         var existingLevel = db.Table<LevelTime>().FirstOrDefault(l => l.LevelName == levelName);

//         if (existingLevel != null)
//         {
//             existingLevel.CompletionTime = time;
//             db.Update(existingLevel);
//         }
//         else
//         {
//             db.Insert(new LevelTime { LevelName = levelName, CompletionTime = time });
//         }

//         Debug.Log($"Tiempo guardado para {levelName}: {time} segundos");
//     }

//     /// <summary>
//     /// Obtiene el tiempo de un nivel guardado.
//     /// </summary>
//     public float GetLevelTime(string levelName)
//     {
//         var level = db.Table<LevelTime>().FirstOrDefault(l => l.LevelName == levelName);
//         return level != null ? level.CompletionTime : -1f; // -1 significa que no hay datos
//     }

//     /// <summary>
//     /// Devuelve todos los tiempos guardados.
//     /// </summary>
//     public List<LevelTime> GetAllLevelTimes()
//     {
//         return db.Table<LevelTime>().ToList();
//     }
// }

