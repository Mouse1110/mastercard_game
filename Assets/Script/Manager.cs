using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    private Vector3 trackedPosition;
    public bool start;
    public GameObject pnStart;
    public GameObject[] pn;
    public GameObject btnYes15;
    public GameObject btnNo15;
    public GameObject panelFinally;
    public bool[] anwser;

    private int init;
    private int index;
    public bool debug;
    public GameObject next;
    public string[] info;
    public GameObject textInfo;
    public GameObject txtInit;
    private bool isNext;
    public GameObject lineTrue;
    public GameObject lineFalse;
    // Start is called before the first frame update
    private int core;

    public Text finallyText;


    public GameObject startButton;

    public Transform posYes;
    public Transform posNo;

    public GameObject canvas;
    public GameObject audioStart;
    void Start()
    {
       // pnStart.SetActive(true);
       // pn15.SetActive(false);
        start = false;
        init = 0;
        core = 0;
        debug = true;
        isNext = false;
    }

    // Update is called once per frame
    public void Click(string tag)
    {
            if (tag=="btnYes")
            {
                if (anwser[index]){
                    btnYes15.GetComponent<RectTransform>().position = new Vector3(Screen.width/2,posYes.position.y,posYes.position.z);
                   btnYes15.GetComponent<Collider2D>().isTrigger = false;
                    btnNo15.SetActive(false);
                    textInfo.GetComponent<Text>().text="ĐÚNG - "+info[index];
                    textInfo.SetActive(true);
                    next.SetActive(true);
                    lineTrue.SetActive(true);
                    core++;
                } else{
                   btnNo15.GetComponent<RectTransform>().position = new Vector3(Screen.width/2,posNo.position.y,posNo.position.z);
                    btnNo15.GetComponent<Collider2D>().isTrigger = false;
                    btnYes15.SetActive(false);
                    textInfo.GetComponent<Text>().text="SAI - "+info[index];
                    textInfo.SetActive(true);
                    next.SetActive(true);
                    lineFalse.SetActive(true);
                }
                
                isNext = true;
            }
            else  if (tag=="btnNo")
            {
                if (!anwser[index]){
                    btnNo15.GetComponent<RectTransform>().position = new Vector3(Screen.width/2,posNo.position.y,posNo.position.z);
                    btnNo15.GetComponent<Collider2D>().isTrigger = false;
                    btnYes15.SetActive(false);
                    textInfo.GetComponent<Text>().text="ĐÚNG - "+info[index];
                    textInfo.SetActive(true);
                    next.SetActive(true);
                    lineTrue.SetActive(true);
                    core++;
                } else{
                    btnYes15.GetComponent<RectTransform>().position = new Vector3(Screen.width/2,posYes.position.y,posYes.position.z);
                    btnNo15.SetActive(false);
                    btnYes15.GetComponent<Collider2D>().isTrigger = false;
                    textInfo.GetComponent<Text>().text="SAI - "+info[index];
                    textInfo.SetActive(true);
                    next.SetActive(true);
                    lineFalse.SetActive(true);
                }
                
                isNext = true;
            }
        
    }

    public void StartGame(string tag)
    {
        if (!debug){
            if (!start)
            {
                if (init == 0){
                    
                    if (tag=="start")
                    {
                        audioStart.SetActive(false);
                        pnStart.SetActive(false);
                        start = true;
                        init = 1;
                        index =  Random.Range(0, pn.Length);
                        pn[index].SetActive(true);
                        txtInit.SetActive(true);
                        btnYes15.GetComponent<RectTransform>().position = posYes.position;
                        btnNo15.GetComponent<RectTransform>().position = posNo.position;
                        btnNo15.GetComponent<Collider2D>().isTrigger = true;
                        btnYes15.GetComponent<Collider2D>().isTrigger = true;
                        btnYes15.SetActive(true);
                        btnNo15.SetActive(true);
                        txtInit.GetComponent<Text>().text = init.ToString()+"/5";
                        textInfo.SetActive(false);
                    }
                } else {
                    
                }
               
            } else
            {
                if (!isNext){
                    Click(tag);
                } else if (tag=="next"){
                      if (init > 0 && init <5)
                    {
                        ++init;
                    pn[index].SetActive(false);
                    RemoveAt(ref pn,index);
                    RemoveAt(ref info,index);
                    next.SetActive(false);
                    lineFalse.SetActive(false);
                    lineTrue.SetActive(false);
                    index =  Random.Range(0, pn.Length);
                    pn[index].SetActive(true);
                    txtInit.SetActive(true);
                    // Set button
                    btnYes15.GetComponent<RectTransform>().position = posYes.position;
                    btnNo15.GetComponent<RectTransform>().position = posNo.position;
                    btnNo15.GetComponent<Collider2D>().isTrigger = true;
                    btnYes15.GetComponent<Collider2D>().isTrigger = true;
                    btnYes15.SetActive(true);
                    btnNo15.SetActive(true);
                    txtInit.GetComponent<Text>().text = init.ToString()+"/5";
                    textInfo.SetActive(false);
                    isNext = false;
                    
                    } else {
                        txtInit.SetActive(false);
                        start = false;
                        panelFinally.SetActive(true);
                        finallyText.text = core.ToString()+"/5";
                        debug = true;
                    }
                }
                
            }
        }
      
    }

    public void LoadScene(){
        SceneManager.LoadScene(0);
    }

    public void SetDebug(bool d){
        if (init == 0){
            debug = d;
            canvas.SetActive(!d);
        } else {
            SceneManager.LoadScene(0);
        }
       
    }

    public static void RemoveAt<T>(ref T[] arr, int index)
  {
       // replace the element at index with the last element
      arr[index] = arr[arr.Length - 1];
        // finally, let's decrement Array's size by one
        System.Array.Resize(ref arr, arr.Length - 1);
  }

}
