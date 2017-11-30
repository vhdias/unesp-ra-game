using UnityEngine;
using Vuforia;

public class TrackableEventHandler : DefaultTrackableEventHandler,
                                    ITrackableEventHandler
{
    override protected void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            if (!component.CompareTag("NotRender")) component.enabled = true;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }

        // Habilita objetos
        for (int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).CompareTag("ActiveByButton")) transform.GetChild(i).gameObject.SetActive(true);
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }


    override protected void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Desabilita objetos
        for (int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).gameObject.CompareTag("VirtualButton")) transform.GetChild(i).gameObject.SetActive(false);
        }

        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
    }

}
