using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikaLine : MonoBehaviour
{
    public Point p1 = new Point();
    public Point p2 = new Point();
 
    public PikaLine(Point _p1, Point _p2) {
        this.p1 = _p1;
        this.p2 = _p2;
    }
    public PikaLine(){

    }
    public bool ExitValue() {
        if(p1.x == null) {
            return false;
        }
        return true;
    }
}
