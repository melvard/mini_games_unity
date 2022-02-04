using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private Image onPointerDownPoint;
    private Image pointerArrow;

    public Vector2 StartPosition { get; private set; }
    public Vector2 CurrentPosition { get; private set; }
    public Vector2 EndPosition { get; private set; }

    public UnityAction<Vector2> onStart;
    public UnityAction<Vector2> onDrag;
    public UnityAction onEndDrag;


    private void Start()
    {
        pointerArrow = onPointerDownPoint.transform.GetChild(0).gameObject.GetComponent<Image>();
    }
    public Vector2 TotalDeltaPosition
    {
        get
        {
            return EndPosition - StartPosition;
        }
    }
    public Vector2 CurrentDeltaPosition
    {
        get
        {
            return CurrentPosition - StartPosition;
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartPosition = Input.mousePosition;
            //Showing touch point on the screen
            onPointerDownPoint.gameObject.SetActive(true);
            onPointerDownPoint.GetComponent<RectTransform>().position = StartPosition;

            onStart?.Invoke(CurrentDeltaPosition);

        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            CurrentPosition = Input.mousePosition;
            onDrag?.Invoke(CurrentDeltaPosition);

            pointerArrow.gameObject.SetActive(true);
            var ptrArrowRectTrns = pointerArrow.GetComponent<RectTransform>();
            ptrArrowRectTrns.sizeDelta = new Vector2(ptrArrowRectTrns.sizeDelta.x, CurrentDeltaPosition.magnitude);

            Debug.Log(Vector2.SignedAngle(Vector2.up, CurrentDeltaPosition));
            ptrArrowRectTrns.rotation = Quaternion.AngleAxis(Vector2.SignedAngle(Vector2.up, CurrentDeltaPosition), Vector3.forward);

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            onPointerDownPoint.gameObject.SetActive(false); //Hiding touch point from the screen
            pointerArrow.gameObject.SetActive(false);
            EndPosition = Input.mousePosition;
            onEndDrag?.Invoke();
        }

    }

    public void AddOnDragListener(UnityAction<Vector2> action)
    {
        onDrag += action;
    }
    public void RemoveOnDragListener(UnityAction<Vector2> action)
    {
        onDrag -= action;
    }
    public void AddOnStartListener(UnityAction<Vector2> action)
    {
        onStart += action;
    }
    public void RemoveOnStartListener(UnityAction<Vector2> action)
    {
        onStart -= action;
    }
    public void AddOnEndDragListener(UnityAction action)
    {
        onEndDrag += action;
    }
    public void RemoveOnEndDragListener(UnityAction action)
    {
        onEndDrag -= action;
    }


}
