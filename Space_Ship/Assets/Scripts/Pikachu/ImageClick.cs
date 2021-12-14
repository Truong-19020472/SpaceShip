using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
public class ImageClick : MonoBehaviour, IPointerDownHandler
{
    

    String[,] mapToFindLine = new String[12,8];
   
    void MakeStringMap() {
        for(int i = 0; i < 12; i ++) {
            for(int j = 0; j < 8; j ++) {
                if(MapController.map[i,j] == 0) {
                    mapToFindLine[ i, j] = "/";
                }
                else mapToFindLine[ i, j] = "B";
            }
        }
    }
   
     public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log(eventData.selectedObject.gameObject.transform.localPosition);
        
            int selectX =  (int) eventData.selectedObject.gameObject.transform.localPosition.x/ 45;
            int selectY =  (int) eventData.selectedObject.gameObject.transform.localPosition.y/ 45;
            int lastX = (int) eventData.lastPress.gameObject.transform.localPosition.x / 45;
            int lastY = (int) eventData.lastPress.gameObject.transform.localPosition.y / 45;
            //Debug.Log(selectX + " " + lastX);
            //Debug.Log(MapController.map[selectX, 3]);
            // Point1.x = selectX;
            // Point1.y = selectY;
            // Point2.x = lastX;
            // Point2.y = lastY;
            Point Point1 = new Point(selectX, selectY);
            Point Point2 = new Point(lastX, lastY);
            if(MapController.map[selectX, selectY] != MapController.map[lastX, lastY])
            {
                return;
            }
            if(Point.Same(Point1, Point2)) {
                return;
            }
            //Debug.Log(Point1.x);
            CheckPoint(Point1, Point2);
            
    }
    //Check 2 point have the same value x
     private bool checkLineX(int y1, int y2, int x) // check by colums (x)
    {
        Debug.Log("checkX");
        Debug.Log(mapToFindLine[10,3]);
        //bool isStraight= true; 
        // find point have column max and min
        int min = Math.Min(y1, y2);
        int max = Math.Max(y1, y2);
        // consider if 2 points can be directly connected
        for (int y = min; y <= max; y++) {

            if (mapToFindLine[x, y] == "B") { 
                
               return false;
            }
        }
        //Debug.Log("checkX");
        return true;
        
    }
    //Check 2 point have the same value y
    private bool checkLineY(int x1, int x2, int y) // check by row (y)
    {
        Debug.Log("checkY");
        int min = Math.Min(x1, x2);
        int max = Math.Max(x1, x2);
        
        for (int x = min ; x <= max; x++) {
          
            if (mapToFindLine[ x, y] == "B") {
                return false;
                
            }
            
        }
        
        return true;
    }
    // check in rectangle
private int checkRectX(Point p1, Point p2) { // check 3 line Z
    // find point have y min and max
    Point pMinY = p1, pMaxY = p2;
    if (p1.y > p2.y) {
        pMinY = p2;
        pMaxY = p1;
    }
    for (int y = pMinY.y + 1; y < pMaxY.y; y++) {
        // check three line
        if (checkLineX(pMinY.y, y, pMinY.x)
                && checkLineY(pMinY.x, pMaxY.x, y)
                && checkLineX(y, pMaxY.y, pMaxY.x)) {
 
            // if three line is true return column y
            return y;
        }
    }
    // have a line in three line not true then return -1
    return -1;
}
 
private int checkRectY(Point p1, Point p2) {
    // find point have y min
    Point pMinX = p1, pMaxX = p2;
    if (p1.x > p2.x) {
        pMinX = p2;
        pMaxX = p1;
    }
    // find line and y begin
    for (int x = pMinX.x + 1; x < pMaxX.x; x++) {
        if (checkLineY(pMinX.x, x, pMinX.y)
                && checkLineX(pMinX.y, pMaxX.y, x)
                && checkLineY(x, pMaxX.x, pMaxX.y)) {
             
            return x;
        }
    }
    return -1;
}
private int checkMoreLineX(Point p1, Point p2, int type) {//check ]
    // find point have y min
    Point pMinY = p1, pMaxY = p2;
    if (p1.y > p2.y) {
        pMinY = p2;
        pMaxY = p1;
    }
    // find line and y begin
    int y = pMaxY.y;
    int row = pMinY.x;
    if (type == -1) {
        y = pMinY.y;
        row = pMaxY.x;
    }
    // check more
    if (checkLineX(pMinY.y, pMaxY.y, row)) {
        while (y >= 0 && y < 8 && mapToFindLine[pMinY.x, y] != "B"
                && mapToFindLine[pMaxY.x, y] != "B"  ) {
            if (checkLineY(pMinY.x, pMaxY.x, y)) {
                 
                return y;
            }
            y += type;
        }
    }
    return -1;
}
 
private int checkMoreLineY(Point p1, Point p2, int type) {
    Point pMinX = p1, pMaxX = p2;
    if (p1.x > p2.x) {
        pMinX = p2;
        pMaxX = p1;
    }
    int x = pMaxX.x;
    int col = pMinX.y;
    if (type == -1) {
        x = pMinX.x;
        col = pMaxX.y;
    }
    if (checkLineY(pMinX.x, pMaxX.x, col)) {
        while (x >= 0 && x < 12 && mapToFindLine[x, pMinX.y] != "B"
                && mapToFindLine[x, pMaxX.y] != "B" ) {
            if (checkLineX(pMinX.y, pMaxX.y, x)) {
                return x;
            }
            x += type;
        }
    }
    return -1;
}
    private PikaLine checkTwoPoint(Point p1, Point p2) {
    // check line with x
    Debug.Log(p1.y + " " + p2.y);
    if (p1.x == p2.x) {
        if (checkLineX(p1.y, p2.y, p1.x)) {
            return new PikaLine(p1, p2);
        }
    }
    // check line with y
    if (p1.y == p2.y) {
        if (checkLineY(p1.x, p2.x, p1.y)) {
            PikaLine k = new PikaLine(p1, p2);
           // Debug.Log(p1);
            return k;
            
        }
    }
 
    int t = -1; // t is column find
 
    // check in rectangle with x
    if ((t = checkRectX(p1, p2)) != -1) {
        return new PikaLine(new Point(p1.x, t), new Point(p2.x, t));
    }
 
    // check in rectangle with y
    if ((t = checkRectY(p1, p2)) != -1) {
        return new PikaLine(new Point(t, p1.y), new Point(t, p2.y));
    }
    // check more right
    if ((t = checkMoreLineX(p1, p2, 1)) != -1) {
        return new PikaLine(new Point(p1.x, t), new Point(p2.x, t));
    }
    // check more left
    if ((t = checkMoreLineX(p1, p2, -1)) != -1) {
        return new PikaLine(new Point(p1.x, t), new Point(p2.x, t));
    }
    // check more down
    if ((t = checkMoreLineY(p1, p2, 1)) != -1) {
        return new PikaLine(new Point(t, p1.y), new Point(t, p2.y));
    }
    // check more up
    if ((t = checkMoreLineY(p1, p2, -1)) != -1) {
        return new PikaLine(new Point(t, p1.y), new Point(t, p2.y));
    }
    return null;
}


    void CheckPoint(Point p1, Point p2) {
        //String[][] inputMap = new string[12][8](mapToFindLine); 
        MakeStringMap();
        mapToFindLine[p1.x, p1.y] = "M";
        mapToFindLine[p2.x, p2.y] = "M";
        
        PikaLine linePoint = checkTwoPoint(p1, p2);
        //Debug.Log(linePoint.p1);
        if(linePoint.ExitValue()) {
            Destroy(MapController.pika[p1.x, p1.y]);
            Destroy(MapController.pika[p2.x, p2.y]);
            MapController.map[p1.x, p1.y] = 0;
            MapController.map[p2.x, p2.y] = 0;
            //MakeStringMap();
            mapToFindLine[p1.x, p1.y] = "/";
            mapToFindLine[p2.x, p2.y] = "/";
            //Debug.Log(mapToFindLine[p1.x, p1.y - 1]);
            return;
        }
        mapToFindLine[p1.x, p1.y] = "B";
        mapToFindLine[p2.x, p2.y] = "B";
    }
}
