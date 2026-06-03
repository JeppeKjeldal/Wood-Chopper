using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one instance of data persistence manager in the scene");
        }

        instance = this;
    }

    private void Start()
    {
        /*Application.persitentDataPath = Standard folder for persistent data fra et unity projekt,
        kan ændres, men lad være medmindre vi har en god grund til at gøre det*/

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //Load any saved data from a file using the data handler
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No save data found. Initializing data to defaults");
            NewGame();

            Debug.Log("Loaded gold = " + gameData.gold);
        }

        //push the loaded data to scripts which need it
        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.LoadData(gameData);
        }
        Debug.Log("Loaded score = " + gameData.gold);
    }

    public void SaveGame()
    {
        //Pass the data to other scripts for updating
        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.SaveData(ref gameData);
        }

        Debug.Log("Saved score = " + gameData.gold);

        //Save data to file using data handler (JSON)
        dataHandler.Save(gameData);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
