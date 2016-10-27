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

            int j=0;
            float x1, y1,x2,y2,p1,p2,p3,p4,ymove=0;
            x1 = float.Parse(eachInfo[0]);
            y1 = float.Parse(eachInfo[1]);
            x2 = float.Parse(eachInfo[2]);
            y2 = float.Parse(eachInfo[3]);

            p1 = x1 - x2;
            p2 = y1 - y2;

            //float s1 = System.Math.Abs(p1);
            //float s2 = System.Math.Abs(p2);

            p3 = p2 / p1;

            if(p1 >= 0 && p2 >= 0)
            {
                j = 1;
            }
            else if(p1 >= 0 && p2 <= 0)
            {
                j = 2;
            }
            else if (p1 <= 0 && p2 >= 0)
            {
                j = 3;
            }
            else
            {
                j = 4;
            }





            switch (j)
            {
                case 1:
                    for (float xmove = p1; xmove < p2; xmove++)
                    {
                        Vector2 pos = new Vector2(float.Parse(eachInfo[0]) + xmove, float.Parse(eachInfo[1]) + ymove);
                        this.createObj(obj, pos);
                        ymove += p3;
                    }
                    break;
                case 2:
                    for (float xmove = p1; xmove < p2; xmove++)
                    {
                        Vector2 pos = new Vector2(float.Parse(eachInfo[0]) + xmove, float.Parse(eachInfo[1]) - ymove);
                        this.createObj(obj, pos);
                        ymove += p3;
                    }
                    break;
                case 3:
                    for (float xmove = p1; xmove > p2; xmove--)
                    {
                        Vector2 pos = new Vector2(float.Parse(eachInfo[0]) + xmove, float.Parse(eachInfo[1]) + ymove);
                        this.createObj(obj, pos);
                        ymove += p3;
                    }
                    break;
                default:
                    for (float xmove = p1; xmove > p2; xmove--)
                    {
                        Vector2 pos = new Vector2(float.Parse(eachInfo[0]) + xmove, float.Parse(eachInfo[1]) - ymove);
                        this.createObj(obj, pos);
                        ymove += p3;
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