using UnityEngine;
using System.Collections;

public class boxChanger : MonoBehaviour {
    public GameObject[] thingsInBox;
    public int thingNumber;    //���ꤺ�e���s��
    int material_Kind = 6;  //��������ƶq

    public bool isGetThis = false;
    bool isGoUp = false;
    //0:�w�]�c�l
    //1:���Y
    //2:��
    //3:��
    //4:�~���H
    //5:�p�q

	// Use this for initialization
	void Start () {
        thingNumber = Random.Range(1, material_Kind); //�H�����ͤ@�ت���
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

    //�̪���s����ܪ���
    void boxChange()
    {
        print(thingNumber);
        for (int i = 0; i < material_Kind; i++)
        {
            thingsInBox[i].SetActive(false);
            if (thingNumber <= 3)
            {
                thingsInBox[0].SetActive(true);
                thingsInBox[i].SetActive(false);    //�i�Ϊ������ܬ��c�l
            }
            else if (thingNumber == i)
                thingsInBox[i].SetActive(true);   //��ܬ��~���H�B�p�q
        }
    }
}
