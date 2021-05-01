using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public Level[] levels;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



}

[System.Serializable]
public class Level
{
    public GameObject LevelPrefab;
    public Options[] actions;
   
}

[System.Serializable]
public class Options
{
    public Sprite option1, option2;
    public string animationName;
    public int correct;
    public Animator animator;
    public bool animation;
    public GameObject display;
    public string objName;
}

public enum FunctionType
{
    Function,
    Animation
}


