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
    public FunctionType[] sample;
}

[System.Serializable]
public class Options
{
    public Sprite option1, option2;
    public int correct;
    public Animator animator;
}

public enum FunctionType
{
    Function,
    Animation
}


