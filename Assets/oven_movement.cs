using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class oven_movement : MonoBehaviour
{
    public GameObject spawnpos;
    public Transform cam;
    public bool looking;
    public CanvasGroup cg1;
    public CanvasGroup cg2;
    public CanvasGroup cg3;

    public GameObject fridge;
    public GameObject cup;
    public GameObject cold;
    public TMP_Text wrong;

    public Animator cup_anim;
   // private Quaternion final_rot = Quaternion.Euler(0, 270, 0);

    public iTween.EaseType easeType;
    public iTween.LoopType loopType;
   
    void Start()
    {
        looking = false;
    }
    
    void Update()
    {

        if (looking)
        {
            cam.LookAt(fridge.transform);
        }
    }

    public void display()
    {
        StartCoroutine(ScaleUpAnimation1());
    }
    public void display2()
    {
        StartCoroutine(ScaleUpAnimation2());
    }
    public void display3()
    {
        StartCoroutine(ScaleUpAnimation3());
    }
    public void wrong_sel()
    {
        wrong.text = "Wrong selection";
        
    }
    public void rotate()
    {
        
    }
    IEnumerator ScaleUpAnimation1()
    {
       cup.transform.position = spawnpos.transform.position;
        cup.SetActive(true);
        cg1.alpha = 0;
        cg1.blocksRaycasts = false;
        cg1.interactable = false;
        iTween.ScaleBy(cup.gameObject, iTween.Hash("x", 3, "y", 3, "z", 3, "time", 2, "easetype", "linear"));
        
        yield return new WaitForSecondsRealtime(3);
        iTween.MoveTo(cup.gameObject, iTween.Hash("x", -1.39f, "y", 0.631, "z", 1.285, "time", 3,"delay",2, "easetype", "Ease In Sine"));
        yield return new WaitForSecondsRealtime(5);
        // cup_anim.SetBool("cup", true);
        cup.SetActive(false);
        
        yield return new WaitForSecondsRealtime(1);


        cg2.alpha = 1;
        cg2.blocksRaycasts = true;
        cg2.interactable = true;

    }
    IEnumerator ScaleUpAnimation2()
    {
       cold.transform.position = spawnpos.transform.position;
        cold.SetActive(true);
        cg2.alpha = 0;
        cg2.blocksRaycasts = false;
        cg2.interactable = false;
        iTween.ScaleBy(cold.gameObject, iTween.Hash("x", 3, "y", 3, "z", 3, "time", 2, "easetype", "linear"));
        yield return new WaitForSecondsRealtime(3);
        iTween.MoveTo(cold.gameObject, iTween.Hash("x", -1.39f, "y", 0.631, "z", 1.285, "time", 3, "delay", 2, "easetype", "Ease In Sine"));
        yield return new WaitForSecondsRealtime(5);
      //  cold.SetActive(false);
       
        yield return new WaitForSecondsRealtime(1);
        
        cg3.alpha = 1;
        cg3.blocksRaycasts = true;
        cg3.interactable = true;
        
    }
    IEnumerator ScaleUpAnimation3()
    {
        looking = true;
          fridge.transform.position = spawnpos.transform.position;
        fridge.SetActive(true);
        iTween.ScaleBy(fridge.gameObject, iTween.Hash("x", 8, "y", 8, "z", 8, "time", 2, "easetype", "linear"));
        yield return new WaitForSecondsRealtime(3);
        
        
        iTween.MoveTo(fridge.gameObject, iTween.Hash("x", -2.673, "y", 0.638, "z", -0.726, "time", 3, "delay", 2,"oncomplete","fadingout", "oncompletetarget",fridge.gameObject));
        yield return new WaitForSecondsRealtime(.5f);
      //  looking = false;
        //  iTween.LookTo(cam.gameObject, iTween.Hash("looktarget", fridge.transform.position, "axis", "y","delay",5));
       
    }

    public void fadingout()
    {
        looking = false;
    }
}
