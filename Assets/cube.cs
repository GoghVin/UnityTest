using Sentry;
using System;
using UnityEngine;

public class cube : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.LogError("Console");
        SentrySdk.CaptureMessage("Test event");     }

    int i = 0;
    private GameObject testObject = null;
    // Update is called once per frame
    void Update()
    {
        if (i++%600 == 0)
        {
            //Debug.LogError("stacktrace: "+);
            try{
                throw new Exception("error");
            }
            catch(Exception e){
                Debug.LogError("stacktrace:"+e.StackTrace);
            }
          
        }

        if(i == 1000)
        {
            Debug.Log("Captured Log");              // Breadcrumb
            Debug.LogWarning("Captured Warning");   // Breadcrumb
            Debug.LogError("Captured Error");       // Captured Error by default
                                                    // This will throw an unhandled Null Reference Exception
            testObject.GetComponent<Transform>();   // Captured error
        }
    }
}
