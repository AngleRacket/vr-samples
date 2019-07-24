using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ProcessSpawner : MonoBehaviour
{
    public Text processCountLabel;
    public GameObject gameObject;

    private Dictionary<Process, GameObject> gameObjects = new Dictionary<Process, GameObject>();
    private Dictionary<Process, System.TimeSpan> lastTimes = new Dictionary<Process, System.TimeSpan>();

    // Start is called before the first frame update
    void Start()
    {
        var processes = System.Diagnostics.Process.GetProcesses();
        UpdateProcessCount(processes.Length);

        foreach (var process in processes)
        {
            var spreadunits = 15;
            var halfspread = spreadunits / 2;
            var position = new Vector3((UnityEngine.Random.value * spreadunits) - halfspread, 2 + (UnityEngine.Random.value * spreadunits), (UnityEngine.Random.value * spreadunits) - halfspread);
            var obj = Instantiate(gameObject, position, Quaternion.identity);
            obj.layer = 8;

            gameObjects[process] = obj;
            lastTimes[process] = process.TotalProcessorTime;

            UpdateObjInfoPanel(obj, process);
        }
    }

    private void UpdateProcessCount(int count)
    {
        if (processCountLabel == null) return;
        processCountLabel.text = count.ToString();
    }

    private void UpdateObjInfoPanel(GameObject obj, Process process)
    {
        if (obj == null || process == null) return;
        ProcessCubeProperties properties = obj.GetComponent<ProcessCubeProperties>();
        if (properties == null) return;
        if (properties.ProcessNameLabel != null) properties.ProcessNameLabel.text = process.ProcessName;
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Time.frameCount % 120 == 0)
        {
            foreach (var process in gameObjects.Keys)
            {
                var obj = gameObjects[process];
                if (!obj.activeSelf) return;

                process.Refresh();
                var lastTime = lastTimes[process];
                float scale = (float)(process.TotalProcessorTime - lastTime ).TotalMilliseconds / 1000.0f ;
                scale += 0.25f;
                obj.transform.localScale = new Vector3(scale, scale, scale);
                lastTimes[process] = process.TotalProcessorTime;
            }
        }
        //if (UnityEngine.Time.frameCount % 120 == 0)
        //{
        //    var processes = System.Diagnostics.Process.GetProcesses();
        //    processCountLabel.text = processes.Length.ToString();
        //    foreach (var process in processes)
        //    {
        //        var key = process.ProcessName;
        //        GameObject obj = null;
        //        if (!gameObjects.ContainsKey(key))
        //        {
        //            continue;
        //        }

        //        obj = gameObjects[key];
        //        obj.GetComponent<Material>().color = Color.blue;

        //        float scale = (float)process.TotalProcessorTime.TotalSeconds;
        //        obj.transform.localScale = new Vector3(scale,scale, scale);

        //    }

        //}
    }
}
