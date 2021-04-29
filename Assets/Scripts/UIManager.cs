using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject LevelComplete;
    public GameObject LevelFailed;
    public GameObject gameplay;

    public Image option1Sprite,option2Sprite;

    public Text display;

    public GameObject progress1;
    public GameObject progress2;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions.Length == 2))
        {
            progress1.SetActive(true);
            progress2.SetActive(false);
        }
        if ((GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions.Length > 2))
        {
            progress1.SetActive(false);
            progress2.SetActive(true);
        }

    }



    public void OnActionCliked(int option)
    {
        if (option == GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions[GameManager.Instance.actionIndex].correct)
        {

            display.text = "correct";

            GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions[GameManager.Instance.actionIndex].animator.SetBool("band", true);



            if ((GameManager.Instance.actionIndex + 1) < GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions.Length)
            {
                display.text = "";
                // yield return new WaitForSeconds(2);
            
                GameManager.Instance.actionIndex++;
                GameManager.Instance.LoadOptions(GameManager.Instance.loadedLevelIndex);
                
                
            }
        }
        else if(option != GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions[GameManager.Instance.actionIndex].correct)
        {
            display.text = "not correct";
            gameplay.SetActive(false);
            LevelFailed.SetActive(true);
        }
        
    }

    public void nextLevelButton()
    {
        LevelComplete.SetActive(false);
        gameplay.SetActive(true);
        display.text = "";
     

        Destroy(GameManager.Instance.levelObject);
        GameManager.Instance.LoadLevel(GameManager.Instance.loadedLevelIndex + 2);
        GameManager.Instance.loadedLevelIndex += 1;


    }
    public void StartButton()
    {
        menu.SetActive(false);
        gameplay.SetActive(true);


        if (GameManager.Instance.loadedLevelIndex == 0)
        {
            GameManager.Instance.LoadLevel(1);
        }
        if(GameManager.Instance.loadedLevelIndex != 0)
        {
            GameManager.Instance.LoadLevel(GameManager.Instance.loadedLevelIndex + 1);
        }

        
    }
    public void ShowLevelComplete()
    {
        LevelComplete.SetActive(true);
    }

    public void replay()
    {
        LevelFailed.SetActive(false);
        gameplay.SetActive(true);
        display.text = "";

        Destroy(GameManager.Instance.levelObject);
        GameManager.Instance.LoadLevel(GameManager.Instance.loadedLevelIndex + 1);
      //  GameManager.Instance.loadedLevelIndex += 1;
    }
}
