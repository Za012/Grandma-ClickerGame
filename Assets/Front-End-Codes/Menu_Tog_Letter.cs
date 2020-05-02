using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Tog_Letter : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Grandma;
    public Button ButtonToDeactivate;
    public Button ButtonToDeactivate2;

    private GameObject letter;
    private Text letterStory;
    private Text letterReward;
    private Image character;

    private Text goldText;

    private SoundScript m_soundScript = null;

    private List<GameObject> currentRequestItems;
    public static Menu_Tog_Letter Instance;
    private void Awake()
    {
        Instance = GameObject.Find("Button_Letter").GetComponent<Menu_Tog_Letter>();
        letter = GameObject.Find("Button_Letter").transform.Find("Letter").gameObject;

        GameObject background = letter.transform.Find("Letter_Background").gameObject;
        character = background.transform.Find("Giver").GetComponent<Image>();

        GameObject letterStoryObject = background.transform.Find("LetterStory").gameObject;
        letterStory = letterStoryObject.GetComponent<Text>();

        GameObject reward = letterStoryObject.transform.Find("Reward").gameObject;
        letterReward = reward.transform.Find("LetterReward").GetComponent<Text>();

        GameObject gold = GameObject.Find("TopBar").gameObject;
        goldText = gold.transform.Find("GoldText").GetComponent<Text>();

        m_soundScript = GameObject.Find("Sound").GetComponent<SoundScript>();
    }

    private void Start()
    {
        ChangeGoldText(SaveFile.GetInstance().CoreConfig.player.GetGold().ToString());
    }

    public void ChangeGoldText(string gold)
    {
        goldText.text = gold;
    }
    private bool isOpen;
    public void OpenMenu()
    {
        if (Menu != null)
        {
            if (isOpen)
            {
                m_soundScript.PlaySound("letter_open");
                isOpen = true;
            }
            else
            {
                m_soundScript.PlaySound("letter_close");
                isOpen = false;
            }
            Menu.SetActive(!Menu.activeSelf);
            Grandma.SetActive(!Grandma.activeSelf);
            if (currentRequestItems != null)
            {
                foreach (GameObject item in currentRequestItems)
                {
                    item.SetActive(!item.activeSelf);
                }
            }

            ButtonToDeactivate.interactable = !ButtonToDeactivate.interactable;
            ButtonToDeactivate2.interactable = !ButtonToDeactivate2.interactable;
        }
    }

    public void PopUpLetter()
    {
        OpenMenu();
    }
    public void WriteLetter(string message)
    {
        letterStory.text = message;
        letterReward.text = " ";
        foreach (GameObject item in currentRequestItems)
        {
            Destroy(item);
        }
    }
    public void WriteLetter(Mission mission, List<GameObject> requestedItems)
    {
        letterStory.text = mission.story;
        letterReward.text = mission.reward.ToString();
        character.sprite = mission.GetCharacter();
        if (currentRequestItems != null)
        {
            foreach (GameObject item in currentRequestItems)
            {
                Destroy(item);
            }
        }
        int initX = -100;
        foreach (GameObject item in requestedItems)
        {
            item.SetActive(false);
            item.transform.position += new Vector3(initX, -350, 0);
            initX += 50;
        }
        currentRequestItems = requestedItems;
    }
}
