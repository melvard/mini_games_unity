using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersAndCollisions : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(string.Format("T-Heyyyy gameObject {0} entered area", other.gameObject.name));
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(string.Format("T-Ohhh gameObject {0} left the are area", other.gameObject.name));

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(string.Format("C-Heyyyy gameObject {0} entered area", collision.gameObject.name));
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(string.Format("C-Ohhh gameObject {0} left the are area", collision.gameObject.name));

    }


}

