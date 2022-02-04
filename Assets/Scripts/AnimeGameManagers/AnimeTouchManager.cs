using UnityEngine;
using UnityEngine.Events;

public class AnimeTouchManager : MonoBehaviour
{
    private UnityAction<Vector3> OnStartDrag;
    private UnityAction<Vector3> OnDrag;
    private UnityAction OnEndDrag;


    private void Update()
    {
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");

        Vector3 delta = new Vector3(h, 0, v);

        if(delta.magnitude >0.5)
        {
            //Debug.Log(delta);
            OnDrag?.Invoke(delta);
        }
        else
        {
            OnEndDrag?.Invoke();

        }
    }

    public void SubscribeToOnDrag(UnityAction<Vector3> action)
    {
        OnDrag += action;

    }

    public void UnSubscribeFromOnDrag(UnityAction<Vector3> action)
    {
        OnDrag -= action;
    }

    public void SubscribeToOnEndDrag(UnityAction action)
    {
        OnEndDrag += action;

    }

    public void UnSubscribeFromOnEndDrag(UnityAction action)
    {
        OnEndDrag -= action;
    }

}
