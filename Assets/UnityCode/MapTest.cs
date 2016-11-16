using UnityEngine;
using System.Collections;

public class MapTest : MonoBehaviour
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

            float x1, y1, x2, y2;
            x1 = float.Parse(eachInfo[0]);
            y1 = float.Parse(eachInfo[1]);
            x2 = float.Parse(eachInfo[2]);
            y2 = float.Parse(eachInfo[3]);

            
        }
    }



    void createObj(GameObject obj, Vector2 pos)
    {
        GameObject go = Instantiate(obj, new Vector3(pos.x, 0, pos.y), obj.transform.rotation) as GameObject;
    }
}