using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public DataManager DataManager;
    public UIManager UIManager;

    public int actionIndex,loadedLevelIndex;


    public GameObject levelObject;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
     //   LoadLevel(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int levelNo)
    {
        levelObject = Instantiate(DataManager.levels[levelNo - 1].LevelPrefab);

        loadedLevelIndex = levelNo-1;

        LoadOptions(loadedLevelIndex);
    }

    public void LoadOptions(int levelNo)
    {
        UIManager.option1Sprite.sprite = DataManager.levels[levelNo].actions[actionIndex].option1;
       
        UIManager.option2Sprite.sprite = DataManager.levels[levelNo].actions[actionIndex].option2;
    }

    public void Move(int x, int y,int z, GameObject obj,int t)
    {
        iTween.MoveTo(obj.gameObject, iTween.Hash("x", x, "y", y, "z", z, "time", t));
    }
}
