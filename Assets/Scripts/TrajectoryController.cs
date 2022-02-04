using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryController : MonoBehaviour
{
    [SerializeField] private GameObject trajectoryPoint;
    [SerializeField] private Rigidbody rg;
    [SerializeField] private int maxNumberOfPointers;

    public static GameObject pointerContainer;

    public void DrawTrajectory()
    {
        if (pointerContainer) Destroy(pointerContainer);
        StartCoroutine(GenerateTrajectoryPoints(rg));
    }

    private IEnumerator GenerateTrajectoryPoints(Rigidbody sb)
    {
        yield return new WaitForSeconds(0.1f);
        pointerContainer = Instantiate(new GameObject());
        Transform pointerContainerTrns = pointerContainer.transform;
        while (sb.velocity.magnitude > 4 && pointerContainer != null)
        {
            Debug.Log(sb.velocity.magnitude);
            GameObject point = Instantiate(trajectoryPoint, sb.position, sb.rotation);
            point.transform.SetParent(pointerContainerTrns, true);
            if(pointerContainerTrns.childCount >= maxNumberOfPointers)
            {
                Debug.Log("Deleted");
                Destroy(pointerContainerTrns.GetChild(0).gameObject);
            }
            yield return new WaitForSeconds(1f / sb.velocity.magnitude);
            //yield return new WaitForSeconds(0.5f);
        }

    }

    //public static void RemoveAllPointers()
    //{
    //    if (pointers != null) pointers.Clear();
    //}
}
