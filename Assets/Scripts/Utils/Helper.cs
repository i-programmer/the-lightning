using System;
using System.Collections.Generic;
using UnityEngine;

public class Helper {

    public static T GetRandomEnum<T>() {
        Array A = Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }

    
    // По двум координатам выстраивается линия с интервалом 0.3f
    public static List<Vector3> GetLineEquation(Vector3 position1, Vector3 position2) {
        var touchPos = position1;        
        var touchPos2 = position2;
       
        float x1 = touchPos.x;
        float y1 = touchPos.y;
        float x2 = touchPos2.x;
        float y2 = touchPos2.y;

        if (touchPos.x > touchPos2.x) {
            x1 = touchPos2.x;
            y1 = touchPos2.y;
            x2 = touchPos.x;
            y2 = touchPos.y;
        }
                
        List<Vector3> list = new List<Vector3>();
        float x = x1;

        do {          
            var y = (x * y2 - x * y1 - x1 * y2 + x1 * y1 + y1 * x2 - y1 * x1) / (x2 - x1);

            list.Add(new Vector3(x, y, 10));
            
            x += 0.3f;
        } while (x <= x2);

        return list;
    }
}

