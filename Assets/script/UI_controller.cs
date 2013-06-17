using UnityEngine;
using System.Collections;

public class UI_controller : MonoBehaviour {
    //���d�B��O�B�Ѽƪ��ƭ�
    public static int iBarG_width = 200, iBarR_width = 200, iDayPast = 0;
    int max = 200;
    //���{�ơB��O�ӷl�p��-->�qplayer_controller�̭��֥[(���ʮ�)�B���d�ӷl-->�Y�쳽���@�I�I
    public static float mileage = 0.0f, strengthDecay = 0.0f, healthDecay = 0.0f;
    public GUISkin GUISkin_t;

	// Use this for initialization
	void Start () {
        
	}
	
    // Update is called once per frame
	void Update () {
        iDayPast = DayCounter(mileage); //�p��Ѽ�(�̲��ʨ��{�W�[)
        iBarR_width = max - StrengthBarCounter(strengthDecay);  //��O�ӷl(�e�i��h�����h�B���k���ʸ���)
        iBarG_width = max - (int)healthDecay;  //���d�ӷl
        if (iBarR_width > max) iBarR_width = max;
        if (iBarG_width > max) iBarG_width = max;
        //����������
        GameObject.Find("GUI green bar").GetComponent<GUITexture>().pixelInset = new Rect(100, -40, iBarG_width, 20);
        GameObject.Find("GUI red bar").GetComponent<GUITexture>().pixelInset = new Rect(100, -60, iBarR_width, 20);
        GameObject.Find("GUI Text_day_num").GetComponent<GUIText>().text = string.Format("{0:D4}",iDayPast).ToString();
	}
    int DayCounter(float value) {
        return (int)value / 10; //�Y�ƥi�H�A�]�w
    }
    int StrengthBarCounter(float value)
    {
        return (int)value / 2;  //�Y�ƥi�H�A�]�w
    }

}
