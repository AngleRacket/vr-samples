using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessLookHandler : MonoBehaviour
{
    private Material originalMaterial;

    public GameObject UIContainer;
    public Material SelectedMaterial;
    public Vector3 Offset = new Vector3(1,1,1);

    public void LookEnter()
    {
        Debug.Log("Looked At: gameObject.name");
        var render = GetComponent<MeshRenderer>();
        originalMaterial = render.material;

        render.material = SelectedMaterial;
        UIContainer.SetActive(true);
    }

    public void LookExit()
    {
        var render = GetComponent<MeshRenderer>();
        render.material = originalMaterial;

        UIContainer.SetActive(false);
    }

    //private void FindLookAtObject()
    //{
    //    Vector3 playerPosition = camera.transform.position;
    //    Vector3 forwardDirection = camera.transform.forward;
    //    float rayLength = 7.0f;

    //    Ray lookatRay = new Ray(playerPosition, forwardDirection);
    //    RaycastHit hit;

    //    var lookatRayEndpoint = forwardDirection * rayLength;
    //    Debug.DrawLine(playerPosition, lookatRayEndpoint);

    //    var found = Physics.Raycast(lookatRay, out hit, rayLength);
    //}
}
