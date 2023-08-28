using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text id;
    public GameObject cirlcePrefab;
    GameObject spawnerCircle;
    GameObject[] circleObj = new GameObject[10];
    Vector2[] mousePos = new Vector2[10];
    private void Start()
    {
        spawnerCircle = new GameObject();
        spawnerCircle.name = "CirlceSpawns";
    }
    private void Update()
    {
        mousePos[0] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            circleObj[0] = SpawnCircle(mousePos[0]);
            QRScanner.instance.StartCoroutine(QRScanner.instance.GetQRCode());
        }
        else if (Input.GetMouseButton(0))
        {
            circleObj[0].transform.localPosition = mousePos[0];

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Destroy(circleObj[0]);
            QRScanner.instance.StopCoroutine(QRScanner.instance.GetQRCode());
        }
        //if (Input.touchCount > 0)
        //{
        //    Touch touch0 = Input.GetTouch(0);

        //    TouchInput(touch0);
        //    //Touch touch1 = Input.GetTouch(1);
        //    //TouchInput(touch1);
        //    //Touch touch2 = Input.GetTouch(2);
        //    //TouchInput(touch2);
        //    //Touch touch3 = Input.GetTouch(3);
        //    //TouchInput(touch3);
        //}
    }
    private void TouchInput(Touch touch)
    {
        mousePos[touch.fingerId] = Camera.main.ScreenToWorldPoint(touch.position);
        QRScanner.instance.StopCoroutine(QRScanner.instance.GetQRCode());
        switch (touch.phase)
        {
            case TouchPhase.Began:
                circleObj[touch.fingerId] = (SpawnCircle(mousePos[touch.fingerId]));
                id.text = touch.fingerId.ToString();
                QRScanner.instance.StartCoroutine(QRScanner.instance.GetQRCode());
                break;
            case TouchPhase.Moved:
                circleObj[touch.fingerId].transform.localPosition = mousePos[touch.fingerId];
                break;
            case TouchPhase.Ended:
                Destroy(circleObj[touch.fingerId]);
                QRScanner.instance.StopCoroutine(QRScanner.instance.GetQRCode());
                break;
        }


    }
 

    private GameObject SpawnCircle(Vector3 objPosition)
    {
        GameObject temp = Instantiate(cirlcePrefab, objPosition, Quaternion.identity);
        temp.transform.parent = spawnerCircle.transform;
        return temp;
    }
}
