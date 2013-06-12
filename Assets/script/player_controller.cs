using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {
    public Transform BoatAndPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.S)) BoatAndPlayer.transform.Translate(0, 0, -5 * Time.deltaTime);
        if (Input.GetKey(KeyCode.W)) BoatAndPlayer.transform.Translate(0, 0, 7.5f * Time.deltaTime);
        if (Input.GetKey(KeyCode.A)) BoatAndPlayer.transform.Rotate(0, -30 * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.D)) BoatAndPlayer.transform.Rotate(0, 30 * Time.deltaTime, 0);
        //UpdatePlayer(touchDetector.enTouchType);
        GameObject.Find("Plane_compass").transform.position = new Vector3(BoatAndPlayer.transform.position.x, 20, BoatAndPlayer.transform.position.z);

	}
    private void UpdatePlayer()//enTouchType T)
    {
        /*if (T == touchDetector.enTouchType.SwipeDown) { BoatAndPlayer.transform.Translate(0, 0, 7.5f * Time.deltaTime); }
        if (T == touchDetector.enTouchType.SwipeUp) { BoatAndPlayer.transform.Translate(0, 0, -5 * Time.deltaTime); }
        if (T == touchDetector.enTouchType.SwipeLeft) { BoatAndPlayer.transform.Rotate(0, -30 * Time.deltaTime, 0); }
        if (T == touchDetector.enTouchType.SwipeRight) { BoatAndPlayer.transform.Rotate(0, 30 * Time.deltaTime, 0); }*/
    }
}
