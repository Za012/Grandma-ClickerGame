
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    public List<Mission> missions;
    public bool waitingForNextMission = false;
    public GameObject itemsToCompletePrefab;

    public static MissionController Instance;

    private MissionController() { }
    private void Awake()
    {
        Instance = GameObject.Find("MissionController").GetComponent<MissionController>();

        // all this needs to do is read the missions
        missions = new List<Mission>();

        string json = Resources.Load<TextAsset>($"Missions/" + missions.Count).ToString();
        while (!string.IsNullOrEmpty(json))
        {
            Mission mission = JsonConvert.DeserializeObject<Mission>(json);
            missions.Add(mission);
            TextAsset asset = Resources.Load<TextAsset>($"Missions/{missions.Count}");
            if (asset != null)
            {
                json = asset.ToString();
            }
            else
            {
                json = "";
            }
        }
    }
    public void Start()
    {
        WriteTheLetter();
    }

    public void WriteTheLetter(string message = null)
    {
        if(message != null)
        {
            Menu_Tog_Letter.Instance.WriteLetter(message);
        }
        Mission mission = GetActiveMission();
        if (mission != null)
        {
            List<GameObject> items = new List<GameObject>();
            foreach (ItemRequest request in mission.itemRequests)
            {
                GameObject item = Instantiate(itemsToCompletePrefab, transform);
                item.transform.Find("Amount").GetComponent<Text>().text = "x" + request.amount;
                item.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(SaveFile.GetInstance().CoreConfig.itemInventory.GetItemByName(request.itemName).GetUniversalSprite());
                items.Add(item);
            }
            Menu_Tog_Letter.Instance.WriteLetter(mission, items);
        }
    }

    public Mission GetActiveMission()
    {
        Dictionary<int, MissionStatusEnum> missionStatus = SaveFile.GetInstance().CoreConfig.missions;
        for (int i = 0; i < missionStatus.Count; i++)
        {
            if (missionStatus[i] == MissionStatusEnum.Active)
            {
                return missions[i];
            }
        }
        return null;
    }

    public void BeginCountdownForNextMission()
    {
        waitingForNextMission = true;
        StartCoroutine(NextMission());
    }

    public IEnumerator NextMission()
    {
        Debug.Log("Countdown begun for next Mission");
        yield return new WaitForSeconds(30);
        Dictionary<int, MissionStatusEnum> missionStatus = SaveFile.GetInstance().CoreConfig.missions;

        for (int i = 0; i < missionStatus.Count; i++)
        {
            if (missionStatus[i] != MissionStatusEnum.Completed)
            {
                if (missionStatus[i] == MissionStatusEnum.Unactive)
                {
                    missionStatus[i] = MissionStatusEnum.Active;
                    Debug.Log($"Mission: {i} Activated");
                    waitingForNextMission = false;
                    WriteTheLetter();
                    Menu_Tog_Letter.Instance.PopUpLetter();
                    StopCoroutine(NextMission());
                    break;
                }
            }
        }
    }
}
