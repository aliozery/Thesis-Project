using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTaptoPlaceObject : MonoBehaviour
{
    public GameObject gameObjetToInstantiate;

    private GameObject spawnedObject;
    private ARRaycastManager _aRRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();



    private void Awake()
    {
        _aRRaycastManager = GetComponent<ARRaycastManager>();
        spawnedObject=gameObjetToInstantiate;
    }

    bool tryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }
    public bool transform=true;

    void Update()
    {
        if(transform)
        {
            if (!tryGetTouchPosition(out Vector2 touchPosition))
            {
                return;
            }
            if (_aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose;

                spawnedObject.transform.position = hitPose.position;
                // if (spawnedObject == null)
                // {
                //     spawnedObject = Instantiate(gameObjetToInstantiate, hitPose.position, hitPose.rotation);
                // }
                // else
                // {
                //     spawnedObject.transform.position = hitPose.position;
                // }
            }
        }
    }
}
