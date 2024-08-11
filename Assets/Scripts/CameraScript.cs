using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 2f;
    private float maxZoom = 8f;
    private float velocity = 0f;
    private float smoothTime = 0.15f;

    [SerializeField]
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        zoom = cam.orthographicSize;
        //yield return new WaitForSeconds(10f);
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = 2;
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoomMultiplier, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        
    }
}
