using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickStart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject manager;
    public GameObject audioClick;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        audioClick.SetActive(false);
        audioClick.SetActive(true);
         manager.GetComponent<Manager>().StartGame(other.tag);
    }

}
