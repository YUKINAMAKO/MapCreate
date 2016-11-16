﻿using UnityEngine;
using System.Collections;

public class MapSample4 : MonoBehaviour
{
    public TextAsset _layout;
    public GameObject[] _objs;
    public GameObject parentObject;

    // Use this for initialization
    void Start()
    {
        this.readMap();
    }

    void readMap()
    {

        string[] layoutInfo = _layout.text.Split('\n');
        string[] eachInfo;

        for (int i = 0; i < layoutInfo.Length; i++)
        {
            eachInfo = layoutInfo[i].Split(","[0]);
            GameObject obj = _objs[0];

            float x_point1, y_point1, x_point2, y_point2, x_distance, y_distance, x_Midpoint, y_Midpoint, hypotenuse, x_interpolation, y_interpolation, x_distanceAv, y_distanceAv;

            //x1,y1,x2,y2の座標
            x_point1 = float.Parse(eachInfo[0]);
            y_point1 = float.Parse(eachInfo[1]);
            x_point2 = float.Parse(eachInfo[2]);
            y_point2 = float.Parse(eachInfo[3]);

            //x,yのそれぞれの距離
            x_distance = x_point2 - x_point1;
            y_distance = y_point2 - y_point1;

            //x,yのそれぞれの距離の絶対値
            x_distanceAv = System.Math.Abs(x_distance);
            y_distanceAv = System.Math.Abs(y_distance);

            //x1,y1,x2,y2から求められる中点
            x_Midpoint = (x_point1 + x_point2) / 2;
            y_Midpoint = (y_point1 + y_point2) / 2;

            //x1,y1,x2,y2から求められる長さ()
            hypotenuse = Mathf.Sqrt((x_distanceAv) * (x_distanceAv) + (y_distanceAv) * (y_distanceAv));

            //x,yのそれぞれの補間
            x_interpolation = x_distance / y_distance;
            y_interpolation = y_distance / x_distance;

            //x,yのそれぞれの補間の絶対値
            y_interpolation = System.Math.Abs(y_interpolation);
            x_interpolation = System.Math.Abs(x_interpolation);

            Vector2 pos = new Vector2(x_Midpoint, y_Midpoint);
            this.createObj(obj, pos, hypotenuse);


        }
    }




    void createObj(GameObject obj, Vector2 pos,float hypotenuse)
    {
        GameObject childObject = Instantiate(obj, new Vector3(-pos.x, 0, pos.y), obj.transform.rotation) as GameObject;
        childObject.transform.localScale = new Vector3(hypotenuse, 1, 1);
        childObject.transform.parent = parentObject.transform;

    }
}



