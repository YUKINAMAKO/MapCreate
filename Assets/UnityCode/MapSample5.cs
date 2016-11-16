using UnityEngine;
using System.Collections;

public class MapSample5 : MonoBehaviour
{
    public TextAsset _layout;
    public GameObject[] _objs;
    public GameObject parentObject;
    public GameObject parentObject2;

    // Use this for initialization
    void Start()
    {
        this.readMap();

    }

    void readMap()
    {

        string[] layoutInfo = _layout.text.Split('\n');
        string[] eachInfo;
        int[,] array = new int[1000, 1000];
        int x_min=0,x_max=0,y_min=0,y_max=0,l;

        for (int i = 0; i < layoutInfo.Length; i++)
        {
            eachInfo = layoutInfo[i].Split(","[0]);
            GameObject obj = _objs[0];
            float x_point1, y_point1, x_point2, y_point2, x_distance, y_distance, x_Midpoint, y_Midpoint, hypotenuse, x_interpolation, y_interpolation, x_distanceAv, y_distanceAv, Deg;

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

            //x1,y1,x2,y2から求められる長さ
            hypotenuse = Mathf.Sqrt((x_distanceAv) * (x_distanceAv) + (y_distanceAv) * (y_distanceAv));

            //x,yのそれぞれの補間
            x_interpolation = x_distance / y_distance;
            y_interpolation = y_distance / x_distance;

            //x,yのそれぞれの補間の絶対値
            y_interpolation = System.Math.Abs(y_interpolation);
            x_interpolation = System.Math.Abs(x_interpolation);

            //2点の角度(Degree)※鋭角
            Deg = Mathf.Atan2(y_distance, x_distance) * Mathf.Rad2Deg;
            if (Deg < 0)
            {
                Deg += 360;    //マイナスのものは360を加算
            }
            //Deg = Vector3.Angle(new Vector3(x_point2, 0, y_point2), new Vector3(x_point1, 0, y_point1));

            //この行の必要性は後で考える
            if (x_distance == 0)
            {
                Deg = 90;
            }
            else if (y_distance == 0)
            {
                Deg = 0;
            }





            Vector2 pos = new Vector2(x_Midpoint, y_Midpoint);
            this.createObj(obj, pos, hypotenuse, Deg);

            //此処から先は、実験的なもの(配列に全てを入れる)



            //xの最大、最小、yの最大、最小を求める
            if(x_min  >x_point1)
            { 
                x_min = (int)x_point1;
            }
            if (x_min > x_point2)
            {
                x_min = (int)x_point2;
            }
            if (x_max < x_point1)
            {
                x_max = (int)x_point1;
            }
            if (x_max < x_point2)
            {
                x_max = (int)x_point2;
            }

            if (y_min > y_point1)
            {
                y_min = (int)y_point1;
            }
            if (y_min > y_point2)
            {
                y_min = (int)y_point2;
            }
            if (y_max < y_point1)
            {
                y_max = (int)y_point1;
            }
            if (y_max < y_point2)
            {
                y_max = (int)y_point2;
            }





            int j=0;
            
            if (x_distance >= 0 && y_distance >= 0 && x_distanceAv < y_distanceAv)//0-45
            {
                j = 10;
            }
            else if (x_distance >= 0 && y_distance >= 0 && x_distanceAv > y_distanceAv)//45-90
            {
                j = 11;
            }
            else if (x_distance >= 0 && y_distance <= 0 && x_distanceAv > y_distanceAv)//90-135
            {
                j = 20;
            }
            else if (x_distance >= 0 && y_distance <= 0 && x_distanceAv < y_distanceAv)//135-180
            {
                j = 21;
            }
            else if (x_distance <= 0 && y_distance <= 0 && x_distanceAv < y_distanceAv)//180-225
            {
                j = 30;
            }
            else if (x_distance <= 0 && y_distance <= 0 && x_distanceAv > y_distanceAv)//225-270
            {
                j = 31;
            }
            else if (x_distance <= 0 && y_distance >= 0 && x_distanceAv > y_distanceAv)//270-315
            {
                j = 40;
            }
            else if (x_distance <= 0 && y_distance >= 0 && x_distanceAv < y_distanceAv)//315-360
            {
                j = 41;
            }



            switch (j)
            {
                case 10://0-45
                    for (float y_position = y_point1; y_position <= y_point2; y_position++)
                    {
                        array[(int)(x_point1 += x_interpolation), (int)y_position] = 1;

                    }
                    break;
                case 11://45-90
                    for (float x_position = x_point1; x_position <= x_point2; x_position++)
                    {
                        array[(int)x_position, (int)(y_point1 += y_interpolation)] = 1;

                    }
                    break;
                case 20://90-135
                    for (float x_position = x_point1; x_position <= x_point2; x_position++)
                    {
                        array[(int)x_position, (int)(y_point1 -= y_interpolation)] = 1;

                    }
                    break;
                case 21://135-180
                    for (float y_position = y_point1; y_position >= y_point2; y_position--)
                    {
                        array[(int)(x_point1 += x_interpolation), (int)y_position] = 1;

                    }
                    break;
                case 30://180-225
                    for (float y_position = y_point1; y_position >= y_point2; y_position--)
                    {
                        array[(int)(x_point1 -= x_interpolation), (int)y_position] = 1;

                    }
                    break;
                case 31://225-270
                    for (float x_position = x_point1; x_position >= x_point2; x_position--)
                    {
                        array[(int)x_position, (int)(y_point1 -= y_interpolation)] = 1;

                    }
                    break;
                case 40://270-315
                    for (float x_position = x_point1; x_position >= x_point2; x_position--)
                    {
                        array[(int)x_position, (int)(y_point1 += y_interpolation)] = 1;

                    }
                    break;
                case 41://315-360
                    for (float y_position = y_point1; y_position <= y_point2; y_position++)
                    {
                        array[(int)(x_point1 -= x_interpolation), (int)y_position] = 1;

                    }
                    break;
            }

        }
        GameObject obj2 = _objs[1];
        int pos2,pos3, hypotenuse2;
        for (l=0;l>=100;l++)
        {
            hypotenuse2 = Random.Range(5, 10);
            pos2 = Random.Range(0, 100);
            pos3 = Random.Range(0, 100);
            Vector2 pos4 = new Vector2(pos2, pos3);
            this.createObj2(obj2, pos4, hypotenuse2);
        }
    }




    void createObj(GameObject obj, Vector2 pos, float hypotenuse, float y_rotation)
    {
        GameObject childObject = Instantiate(obj, new Vector3(-pos.x, 0, pos.y), Quaternion.Euler(0, y_rotation, 0)) as GameObject;//Eulerではジンバルロックに対処できない（今回のプログラムでは発生しない)
        childObject.transform.localScale = new Vector3(hypotenuse, 1, 1);
        childObject.transform.parent = parentObject.transform;

    }

    void createObj2(GameObject obj, Vector2 pos, int hypotenuse)
    {
        GameObject childObject = Instantiate(obj, new Vector3(-pos.x, 0, pos.y), obj.transform.rotation) as GameObject;
        childObject.transform.localScale = new Vector3(hypotenuse, hypotenuse, hypotenuse);
        childObject.transform.parent = parentObject2.transform;

    }
}




