using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
public class ImageTracking : MonoBehaviour
{
    private ARTrackedImageManager _arTracked;
    
    public Camera cam;

    public GameObject image;

    public GameObject manager;
    public GameObject panelStart;

    //public Text text;
    
    private void Start(){
       
    }
    
    private void Awake(){
        _arTracked = FindObjectOfType<ARTrackedImageManager>();


    }

    public void OnEnable(){
        _arTracked.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable(){
        _arTracked.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args){
        foreach(var trackedImage in args.added){
            Vector3 pos = trackedImage.transform.position;
            Vector2 vec = WorldToScreenPoint(cam,pos);
            image.GetComponent<RectTransform>().position =new Vector2(vec.x,vec.y);
         //  text.text = vec.ToString();
           if (manager.GetComponent<Manager>().debug){
               manager.GetComponent<Manager>().SetDebug(false); 
               panelStart.SetActive(true);
           }
        }
    foreach (var updatedImage in args.updated)
    {
        Vector3 pos = updatedImage.transform.position;
            Vector2 vec = WorldToScreenPoint(cam,pos);
             image.GetComponent<RectTransform>().position = new Vector2(vec.x,vec.y);
            //  text.text = vec.ToString();
         //  text.text = image.GetComponent<RectTransform>().position.ToString();
       // set(updatedImage.transform.position);
    }
    foreach (var removeImage in args.removed){

    }

    }

     public static Vector2 WorldToScreenPoint(Camera cam, Vector3 worldPoint)
     {
       if ((Object) cam == (Object) null)
         return new Vector2(worldPoint.x, worldPoint.y);
       return (Vector2) cam.WorldToScreenPoint(worldPoint);
     }
}
