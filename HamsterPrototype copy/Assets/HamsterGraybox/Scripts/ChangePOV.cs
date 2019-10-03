using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePOV : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera followCam, mapCam;
    public KeyCode key;
    public bool camSwitch = false;
    void Start()
    {
        followCam.gameObject.SetActive(true);
        mapCam.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            camSwitch = !camSwitch;
            followCam.gameObject.SetActive(!camSwitch);
            mapCam.gameObject.SetActive(camSwitch);

        }
    }
}
