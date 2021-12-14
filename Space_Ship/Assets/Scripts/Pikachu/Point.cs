using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int x;
    public int y;
    public Point(int _x, int _y) {
        x = _x;
        y = _y;
    }
    public Point() {
    }
    public static bool Same(Point p1, Point p2) {
        if(p1.x == p2.x && p2.y == p1.y) {
            return true;
        }
        else return false;
    }
}
