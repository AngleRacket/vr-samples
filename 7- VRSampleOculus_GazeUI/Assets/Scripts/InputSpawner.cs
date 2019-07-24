using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSpawner : MonoBehaviour
{
    public Camera camera;
    public GameObject gameObject;
    public OVRInput.Button Button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (OVRInput.GetDown(Button))
        {
            var position = camera.transform.position;
            position += camera.transform.forward*3.0f;

            //spawn object
            Instantiate(gameObject, position, Quaternion.identity);
        }
    }
}
