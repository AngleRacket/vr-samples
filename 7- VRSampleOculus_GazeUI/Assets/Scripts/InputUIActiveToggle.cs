using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputUIActiveToggle : MonoBehaviour
{

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
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
