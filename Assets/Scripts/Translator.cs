using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    private float booster = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            booster += 0.2f;
            transform.Translate(transform.forward * Time.deltaTime*booster, Space.World);
        }
        else booster = 1;
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * Time.deltaTime * booster, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-transform.up *100* Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.up *100* Time.deltaTime, Space.World);
        }
    }
}
