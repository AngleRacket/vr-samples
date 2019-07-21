using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        processCountLabel.text = processes.Length.ToString();
        foreach (var process in processes)
        {
            var spreadunits = 15;
            var halfspread = spreadunits / 2;
            var position = new Vector3((Random.value * spreadunits) - halfspread, 2 + (Random.value * spreadunits), (Random.value * spreadunits) - halfspread);
            var obj = Instantiate(gameObject, position, Quaternion.identity);

            gameObjects[process] = obj;
            lastTimes[process] = process.TotalProcessorTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Time.frameCount % 120 == 0)
        {
            foreach (var obj in gameObjects)
            {
                obj.Key.Refresh();
                var lastTime = lastTimes[obj.Key];
                float scale = (float)(obj.Key.TotalProcessorTime - lastTime ).TotalMilliseconds / 1000.0f ;
                scale += 0.05f;
                obj.Value.transform.localScale = new Vector3(scale, scale, scale);
                lastTimes[obj.Key] = obj.Key.TotalProcessorTime;
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
