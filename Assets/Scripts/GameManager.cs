using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

   


    public DataManager DataManager;
    public UIManager UIManager;

    public int actionIndex,loadedLevelIndex,currentlevel;

    public GameObject menu;
    public GameObject LevelComplete;
    public GameObject LevelFailed;
    public GameObject gameplay;

    public GameObject Light;

    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;

    public GameObject levelObject;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int levelNo)
    {
     //   currentlevel = loadedLevelIndex + 1;

        loadedLevelIndex = levelNo - 1;

        levelObject = Instantiate(DataManager.levels[loadedLevelIndex].LevelPrefab);

        LoadOptions(loadedLevelIndex);


        foreach (Options option in DataManager.levels[loadedLevelIndex].actions)
        {
            option.animator = levelObject.GetComponentInChildren<Animator>();

        }
        //DataManager.levels[loadedLevelIndex].actions[actionIndex].display = GameObject.Find("Wrong");



    }

    public void LoadOptions(int levelNo)
    {
        UIManager.option1Sprite.sprite = DataManager.levels[levelNo].actions[actionIndex].option1;
        UIManager.option2Sprite.sprite = DataManager.levels[levelNo].actions[actionIndex].option2;
    }

    public void Move( Vector3 pos, GameObject obj,float t)
    {
        iTween.MoveTo(obj.gameObject, iTween.Hash( "position",pos , "time", t));
    }

    public void PlayAnim(string animname ,bool check)
    {
        DataManager.levels[loadedLevelIndex].actions[actionIndex].animator.SetBool(animname, check);
    }

    public IEnumerator ShowLevelComplete(float time)
    {
        yield return new WaitForSeconds(time);
        LevelComplete.SetActive(true);
    }

    public void ResetProgress()
    {
        Light.SetActive(true);
        Light1.SetActive(true);
        Light2.SetActive(true);
        Light3.SetActive(true);
    }
}
