using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    private SaveManager() { }

    private void Awake()
    {
        Instance = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Debug.Log("Application Paused");
            SaveFile.GetInstance().CoreConfig.TimeWhenQuit = DateTime.Now;
            Save(SaveFile.GetInstance());
        }
    }
    private void OnApplicationQuit()
    {
        Debug.Log("Application Quit");
        SaveFile.GetInstance().CoreConfig.TimeWhenQuit = DateTime.Now;
        Save(SaveFile.GetInstance());
    }
    public bool IsSaveFileCreated()
    {
        Debug.Log("Checking path: " + Application.persistentDataPath + "/save.dat");
        bool isFileCreated = File.Exists(Application.persistentDataPath + "/save.dat");
        if (isFileCreated)
        {
            Debug.Log("SaveFile Exists");
        }
        else
        {
            Debug.Log("SaveFile Missing");
        }
        return isFileCreated;
    }

    public SaveFile Load()
    {
        SaveFile saveFile;
        Debug.Log("Loading Savefile");
        using (FileStream fileStream = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open))
        {
            BinaryFormatter bf = new BinaryFormatter();
            saveFile = bf.Deserialize(fileStream) as SaveFile;
            fileStream.Close();
        }
        Debug.Log("Loading Complete");
        return saveFile;
    }

    public SaveFile Save(SaveFile saveFile)
    {
        Debug.Log("Saving Savefile");
        using (FileStream fileStream = File.Create(Application.persistentDataPath + "/save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fileStream, saveFile);
            fileStream.Close();
        }
        Debug.Log("Saving Complete");
        return saveFile;
    }

    private void DeleteSave()
    {
        File.Delete(Application.persistentDataPath + "/save.dat");
    }

    private void InstantiateGameItems(List<IItemObservable> items)
    {
        Debug.Log("Amount of items: " + items.Count + " Before load");
        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes()
       .Where(mytype => mytype.GetInterfaces().Contains(typeof(IItemObservable))))
        {
            if (type.GetTypeInfo().IsAbstract || type.GetTypeInfo().IsInterface)
            {
                continue;
            }

            bool isGameItemAlreadyCreated = false;

            // Check if game item is already created
            foreach (KeyValuePair<IItemObservable, int> pair in SaveFile.LoadInstance().CoreConfig.itemInventory.GetInventory())
            {
                if (pair.Key.GetName() == type.Name)
                {
                    isGameItemAlreadyCreated = true;
                }
            }
            if (!isGameItemAlreadyCreated)
            {
                Debug.Log("Creating object: " + type.Name);
                IItemObservable item = Activator.CreateInstance(type) as IItemObservable;
                items.Add(item);
                SaveFile.LoadInstance().CoreConfig.itemInventory.GetInventory().Add(item, 0);
            }
        }
        SaveFile.LoadInstance().CoreConfig.items = items;

        if (SaveFile.LoadInstance().CoreConfig.currentItem == null)
        {
            SaveFile.LoadInstance().CoreConfig.currentItem = SaveFile.LoadInstance().CoreConfig.items[0];
        }
    }

    public void PrepareSaveFile()
    {
        if (SaveFile.LoadInstance().CoreConfig.player == null)
        {
            Player player = new Player(); 
            SaveFile.LoadInstance().CoreConfig.player = player;
        }
        List<IItemObservable> items;
        if (SaveFile.LoadInstance().CoreConfig.items == null)
        {
            items = new List<IItemObservable>();
        }
        else
        {
            items = SaveFile.LoadInstance().CoreConfig.items;
        }
        if (SaveFile.LoadInstance().CoreConfig.itemInventory == null)
        {
            SaveFile.LoadInstance().CoreConfig.itemInventory = new ItemInventory();
        }
        if (SaveFile.LoadInstance().CoreConfig.TimeWhenQuit == DateTime.MinValue)
        {
            SaveFile.LoadInstance().CoreConfig.TimeWhenQuit = DateTime.Now;
        }

        
        try
        {
            Debug.Log("Instantiating Game Items");
            PrepareMissionFile();
            InstantiateGameItems(items);
            Debug.Log("Game Items Instantiated");

        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            Debug.Log("SAVE FILE CORRUPTED");
            Debug.Log("DELETING SAVE FILE");
            DeleteSave();
            Debug.Log("RE-INITIATING");

            SaveFile.DeleteInstance();
            SaveFile.GetInstance();
        }
    }

    private void PrepareMissionFile()
    {
        for (int i = 0; i < MissionController.Instance.missions.Count; i++)
        {
            if (SaveFile.LoadInstance().CoreConfig.missions == null)
            {
                SaveFile.LoadInstance().CoreConfig.missions = new Dictionary<int, MissionStatusEnum>();
            }
            if (!SaveFile.LoadInstance().CoreConfig.missions.ContainsKey(i))
            {
                SaveFile.LoadInstance().CoreConfig.missions.Add(i, MissionStatusEnum.Unactive);
            }
        }
    }
}
