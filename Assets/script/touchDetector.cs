using UnityEngine;
using System.Collections;

public class touchDetector : MonoBehaviour {
    public delegate void deTouchEvent
    (enTouchType touchType);

    public static event
        deTouchEvent
        evTouchEvent;

    public enum enTouchType
    {
        SwipeLeft,
        SwipeRight,
        SwipeDown,
        SwipeUp,
    }   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (evTouchEvent == null)
            return;

        if (Input.GetKeyDown(KeyCode.UpArrow)) evTouchEvent(enTouchType.SwipeUp);
        if (Input.GetKeyDown(KeyCode.DownArrow)) evTouchEvent(enTouchType.SwipeDown);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) evTouchEvent(enTouchType.SwipeLeft);
        if (Input.GetKeyDown(KeyCode.RightArrow)) evTouchEvent(enTouchType.SwipeRight);

        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                Vector3 swipe = t.deltaPosition * t.deltaTime;

                if (swipe.y > 0.5f) evTouchEvent(enTouchType.SwipeUp);
                if (swipe.y < -0.5f) evTouchEvent(enTouchType.SwipeDown);
                if (swipe.x > 0.5f) evTouchEvent(enTouchType.SwipeRight);
                if (swipe.x < -0.5f) evTouchEvent(enTouchType.SwipeLeft);
            }
        }
	}
}
