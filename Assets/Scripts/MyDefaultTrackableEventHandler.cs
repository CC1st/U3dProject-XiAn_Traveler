/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class MyDefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    public GameObject structurePerfab;
    public GameObject nearLinkPerfab;
    public GameObject cheapLinkPerfab;
    public GameObject recommandPanel;
    private GameObject nearLink;
    private GameObject cheapLink;
//    public GameObject terrianPerfb;
//    public Vector3 terrianOffset;

    //   public float downsize;


    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE) 
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        GameObject structure = GameObject.Instantiate(structurePerfab,transform.position, Quaternion.identity);
        structure.transform.parent = this.transform;
        LightController.instacne.lightSlider.value = 0.5f;
        LightController.instacne.enShowTerrain.isOn = true;

        //推荐面板超链接初始化
        nearLink = GameObject.Instantiate(nearLinkPerfab);
        nearLink.transform.SetParent(recommandPanel.transform);
        nearLink.transform.localPosition = new Vector3(38.6f, 36.82f, 0);
        cheapLink = GameObject.Instantiate(cheapLinkPerfab);
        cheapLink.transform.SetParent(recommandPanel.transform);
        cheapLink.transform.localPosition = new Vector3(39.51f, -6.67f, 0);
    }


    protected virtual void OnTrackingLost()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        Destroy(nearLink);
        Destroy(cheapLink);
    }

    #endregion // PROTECTED_METHODS
}
