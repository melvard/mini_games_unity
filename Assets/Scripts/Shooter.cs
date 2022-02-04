using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Rigidbody shootBall;
    [SerializeField] private float shootForce = 1000f;
    [SerializeField] private float cameraMoveSpeed = 10f;
    [SerializeField] private Transform shootTrans;

    private bool gameIsStarted = false;

    void Update()
    {
        //if (gameIsStarted)
        //{
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        //Debug.Log(string.Format("{0} , {1}", h, v));
        transform.Translate(new Vector3(h, v, 0) * Time.deltaTime * cameraMoveSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            Rigidbody shot = Instantiate(shootBall, transform.position, transform.rotation);
            shot.AddForce(shootTrans.forward * shootForce);
            shot.GetComponent<TrajectoryController>().DrawTrajectory();
        }
        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Return))
        //    {
        //        gameIsStarted = true;
        //    }
        //}
    }

   

}
