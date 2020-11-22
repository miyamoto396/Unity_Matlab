using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Call1sController");
    }

    int flag = 1;

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(flag);
    }


    IEnumerator Call1sController() {
        while (true) {
            flag++;

            yield return new WaitForSeconds(1f);
        }


    }


}
