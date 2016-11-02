using UnityEngine;
using System.Collections;

public class MapSample3 : MonoBehaviour
{
    public TextAsset _layout;
    public GameObject[] _objs;

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

            int j = 0;
            float x1, y1, x2, y2, p1, p2, p3, p4, p5, p6, xmove = 0, ymove = 0;
            x1 = float.Parse(eachInfo[0]);
            y1 = float.Parse(eachInfo[1]);
            x2 = float.Parse(eachInfo[2]);
            y2 = float.Parse(eachInfo[3]);

            p1 = x2 - x1;
            p2 = y2 - y1;

            p5 = System.Math.Abs(p1);
            p6 = System.Math.Abs(p2);

            p3 = p2 / p1;
            p4 = p1 / p2;

            p3 = System.Math.Abs(p3);
            p4 = System.Math.Abs(p4);



            if (p1 == 0 && p2 > 0)
            {
                j = 0;
            }
            else if (p1 == 0 && p2 < 0)
            {
                j = 1;
            }
            else if (p1 >= 0 && p2 >= 0 && p5 > p6)
            {
                j = 20;
            }
            else if (p1 >= 0 && p2 >= 0 && p5 < p6)
            {
                j = 21;
            }
            else if (p1 >= 0 && p2 <= 0 && p5 > p6)
            {
                j = 30;
            }
            else if (p1 >= 0 && p2 <= 0 && p5 < p6)
            {
                j = 31;
            }
            else if (p1 <= 0 && p2 >= 0 && p5 > p6)
            {
                j = 40;
            }
            else if (p1 <= 0 && p2 >= 0 && p5 < p6)
            {
                j = 41;
            }
            else if (p1 >= 0 && p2 >= 0 && p5 > p6)
            {
                j = 50;
            }
            else if (p1 >= 0 && p2 >= 0 && p5 < p6)
            {
                j = 51;
            }




            switch (j)
            {
                case 0:
                    for (float ymove1 = y1; ymove1 < y2; ymove1++)
                    {
                        Vector2 pos = new Vector2(x1, ymove1);
                        this.createObj(obj, pos);
                    }
                    break;
                case 1:
                    for (float ymove1 = y1; ymove1 > y2; ymove1--)
                    {
                        Vector2 pos = new Vector2(x1, ymove1);
                        this.createObj(obj, pos);
                    }
                    break;
                case 20:
                    for (float xmove1 = x1; xmove1 < x2; xmove1++)
                    {
                        Vector2 pos = new Vector2(xmove1, y1 += ymove);
                        this.createObj(obj, pos);
                        ymove = p3;
                    }
                    break;
                case 21:
                    for (float ymove1 = y1; ymove1 < y2; ymove1++)
                    {
                        Vector2 pos = new Vector2(x1 += xmove, ymove1);
                        this.createObj(obj, pos);
                        xmove = p4;
                    }
                    break;
                case 30:
                    for (float xmove1 = x1; xmove1 < x2; xmove1++)
                    {
                        Vector2 pos = new Vector2(xmove1, y1 += ymove);
                        this.createObj(obj, pos);
                        ymove = p3;
                    }
                    break;
                case 31:
                    for (float ymove1 = y1; ymove1 > y2; ymove1--)
                    {
                        Vector2 pos = new Vector2(x1 += xmove, ymove1);
                        this.createObj(obj, pos);
                        xmove = p4;
                    }
                    break;
                case 40:
                    for (float xmove1 = x1; xmove1 > x2; xmove1--)
                    {
                        Vector2 pos = new Vector2(xmove1, y1 += ymove);
                        this.createObj(obj, pos);
                        ymove = p3;
                    }
                    break;
                case 41:
                    for (float ymove1 = y1; ymove1 < y2; ymove1++)
                    {
                        Vector2 pos = new Vector2(x1 += xmove, ymove1);
                        this.createObj(obj, pos);
                        xmove = p4;
                    }
                    break;
                case 50:
                    for (float xmove1 = x1; xmove1 > x2; xmove1--)
                    {
                        Vector2 pos = new Vector2(xmove1, y1 += ymove);
                        this.createObj(obj, pos);
                        ymove = p3;
                    }
                    break;
                case 51:
                    for (float ymove1 = y1; ymove1 > y2; ymove1--)
                    {
                        Vector2 pos = new Vector2(x1 += xmove, ymove1);
                        this.createObj(obj, pos);
                        xmove = p4;
                    }
                    break;
            }
        }
    }



    void createObj(GameObject obj, Vector2 pos)
    {
        GameObject go = Instantiate(obj, new Vector3(pos.x, 0, pos.y), obj.transform.rotation) as GameObject;
    }
}