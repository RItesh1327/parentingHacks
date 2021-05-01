using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    

    public Image option1Sprite,option2Sprite;

    public Text display;

    public GameObject progress1;
    public GameObject progress2;

    public Animator anim;

    public GameObject right;
    public GameObject wrong;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions.Length == 1))
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

    public void matChange()
    {
        
        
    }

    public void OnActionCliked(int option)
    {
        if (option == GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions[GameManager.Instance.actionIndex].correct)
        {
            //LEVEL 1...........................
                if(GameManager.Instance.loadedLevelIndex == 0)      
                {
                    GameManager.Instance.PlayAnim("bandage",true);
                    GameManager.Instance.Light.SetActive(false);
                    StartCoroutine(GameManager.Instance.ShowLevelComplete(5));
                }
            // LEVEL 2......................   
                if(GameManager.Instance.loadedLevelIndex == 1)          
                {
                 //   display.text = "Level 2";
                    GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions[GameManager.Instance.actionIndex].display.SetActive(false);
                    GameManager.Instance.Light.SetActive(false);

                    StartCoroutine(GameManager.Instance.ShowLevelComplete(3));
                    
                }
            // LEVEL 3......................
                if (GameManager.Instance.loadedLevelIndex == 2)         
                {
                 //   display.text = "Level 3";
                    GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions[GameManager.Instance.actionIndex].display.GetComponent<MeshRenderer>().enabled = true;
                    GameManager.Instance.Light.SetActive(false);

                    StartCoroutine(GameManager.Instance.ShowLevelComplete(3));

                }
            // LEVEL 5......................
                if (GameManager.Instance.loadedLevelIndex == 4)
                {
                    GameObject ob1 = GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions[0].display = GameObject.Find("mattress");
                    GameObject ob2 = GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions[1].display = GameObject.Find("bedsheet");
                    GameObject ob3 = GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions[2].display = GameObject.Find("pillow");

                    if (GameManager.Instance.actionIndex == 0)
                    {
                        GameManager.Instance.Light1.SetActive(false);
                    //    GameManager.Instance.Move( new Vector3(-0.2280466f, 0.178f, 4135417f),ob1,2);
                    }
                    if (GameManager.Instance.actionIndex == 1)
                    {
                         GameManager.Instance.Light2.SetActive(false);
                    //     GameManager.Instance.Move(-0.2280466f, 0.179f, 0.4135417f, ob2, 2);
                }
                    if (GameManager.Instance.actionIndex == 2)
                    {
                         GameManager.Instance.Light3.SetActive(false);
                    //  GameManager.Instance.Move(-0.2280466f, 0.179f, 0.4135417f, ob3, 2);
                    GameManager.Instance.StartCoroutine(("ShowLevelComplete") ,3);
                }
                }




            // LEVEL 9......................
            if (GameManager.Instance.loadedLevelIndex == 8)
            {
                GameObject towel = GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions[0].display = GameObject.Find("towel");
                GameObject necktowel = GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions[1].display = GameObject.Find("necktowel");
                GameObject ball = GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions[2].display = GameObject.Find("volleyball");

                if (GameManager.Instance.actionIndex == 0)
                {
                    towel.GetComponent<SkinnedMeshRenderer>().enabled = false;
                    GameManager.Instance.PlayAnim("short",true);
                }
                else  if (GameManager.Instance.actionIndex == 1)
                {
                    necktowel.GetComponent<SkinnedMeshRenderer>().enabled = true;
                    GameManager.Instance.PlayAnim("towel",true);
                }
                else  if (GameManager.Instance.actionIndex == 2)
                {
                    ball.GetComponent<MeshRenderer>().enabled = true;
                    // GameManager.Instance.PlayAnim("ball");
                }
            }
            



            if ((GameManager.Instance.actionIndex + 1) < GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions.Length)
            {
                display.text = "";
                // yield return new WaitForSeconds(2);

                GameManager.Instance.actionIndex++;
                GameManager.Instance.LoadOptions(GameManager.Instance.loadedLevelIndex);
            } 
        }

        else if (option != GameManager.Instance.DataManager.levels[GameManager.Instance.loadedLevelIndex].actions[GameManager.Instance.actionIndex].correct)
        {
            display.text = "not correct";
            GameManager.Instance.gameplay.SetActive(false);
            GameManager.Instance.LevelFailed.SetActive(true);
        }
        
    }

    public void nextLevelButton()
    {
        GameManager.Instance.LevelComplete.SetActive(false);
        GameManager.Instance.gameplay.SetActive(true);
        GameManager.Instance.ResetProgress();

        display.text = "";
        Destroy(GameManager.Instance.levelObject);
        GameManager.Instance.LoadLevel(GameManager.Instance.loadedLevelIndex + 2);


    }
    public void StartButton()
    {
        GameManager.Instance.menu.SetActive(false);
        GameManager.Instance.gameplay.SetActive(true);
        GameManager.Instance.ResetProgress();

        GameManager.Instance.LoadLevel(9);
    }
  

    public void replay()
    {
        GameManager.Instance.LevelFailed.SetActive(false);
        GameManager.Instance.gameplay.SetActive(true);
        display.text = "";
        GameManager.Instance.ResetProgress();
        GameManager.Instance.actionIndex = 0;
        Destroy(GameManager.Instance.levelObject);
        GameManager.Instance.LoadLevel(GameManager.Instance.loadedLevelIndex + 1);
      //  GameManager.Instance.loadedLevelIndex += 1;
    }
}
