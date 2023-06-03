using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babaiEvent_1 : MonoBehaviour
{

    public GameObject babai;
    // Start is called before the first frame update
    void Start()
    {
        //babai.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        babai.SetActive(true);
        Debug.Log("BABAI SET ACTIVE");
    }
}
