using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Pathfinder : DefaultTrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;

   void OnTrackableStateChange(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
 
        Debug.Log("test");
    }
    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour) { mTrackableBehaviour.RegisterOnTrackableStatusChanged(this); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
