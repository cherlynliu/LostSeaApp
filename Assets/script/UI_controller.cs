using UnityEngine;
using System.Collections;

public class UI_controller : MonoBehaviour {
    //健康、體力、天數的數值
    public static int iBarG_width = 300, iBarR_width = 300, iDayPast = 0;   
    //里程數、體力耗損計算-->從player_controller裡面累加(移動時)、健康耗損-->吃到魚扣一點點
    public static float mileage = 0.0f, strengthDecay = 0.0f, healthDecay = 0.0f;
    public GUISkin GUISkin_t;

	// Use this for initialization
	void Start () {
        
	}
	
    // Update is called once per frame
	void Update () {
        iDayPast = DayCounter(mileage); //計算天數(依移動里程增加)
        iBarR_width = 300 - StrengthBarCounter(strengthDecay);  //體力耗損(前進後退扣較多、左右移動較少)
        iBarG_width = 300 - (int)healthDecay;  //健康耗損
        if (iBarR_width > 300) iBarR_width = 300;
        if (iBarG_width > 300) iBarG_width = 300;
        //介面元件更動
        GameObject.Find("GUI green bar").GetComponent<GUITexture>().pixelInset = new Rect(150, -40, iBarG_width, 20);
        GameObject.Find("GUI red bar").GetComponent<GUITexture>().pixelInset = new Rect(150, -60, iBarR_width, 20);
        GameObject.Find("GUI Text_day_num").GetComponent<GUIText>().text = string.Format("{0:D4}",iDayPast).ToString();
	}
    int DayCounter(float value) {
        return (int)value / 10; //係數可以再設定
    }
    int StrengthBarCounter(float value)
    {
        return (int)value / 2;  //係數可以再設定
    }

}
