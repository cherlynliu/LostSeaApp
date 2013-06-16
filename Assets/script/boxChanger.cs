using UnityEngine;
using System.Collections;

public class boxChanger : MonoBehaviour {
    public GameObject[] thingsInBox;
    public int thingNumber;    //物資內容物編號
    int material_Kind = 6;  //物資種類數量

    public bool isGetThis = false;
    bool isGoUp = false;
    //0:預設箱子
    //1:罐頭
    //2:魚
    //3:水
    //4:瓶中信
    //5:小島

	// Use this for initialization
	void Start () {
        thingNumber = Random.Range(1, material_Kind); //隨機產生一種物資
        boxChange();
	}
	
	// Update is called once per frame
	void Update () {
        if (isGetThis)
        {
            isGetThis = false;
            if (thingNumber <= 3)
            {
                thingsInBox[0].SetActive(false);
                thingsInBox[thingNumber].SetActive(true);
                isGoUp = true;
            }
        }
        if (isGoUp)
        {
            if (thingsInBox[thingNumber].gameObject.transform.position.y < 4.5f)
                thingsInBox[thingNumber].gameObject.transform.Translate(0, 4.0f * Time.deltaTime, 0, Space.Self);
            else
            {
                isGoUp = false;
                thingsInBox[thingNumber].SetActive(false);
                Destroy(this.gameObject, 0.05f);
            }
        }
	}

    //依物資編號顯示物件
    void boxChange()
    {
        print(thingNumber);
        for (int i = 0; i < material_Kind; i++)
        {
            thingsInBox[i].SetActive(false);
            if (thingNumber <= 3)
            {
                thingsInBox[0].SetActive(true);
                thingsInBox[i].SetActive(false);    //可用物資先顯示為箱子
            }
            else if (thingNumber == i)
                thingsInBox[i].SetActive(true);   //顯示為瓶中信、小島
        }
    }
}
