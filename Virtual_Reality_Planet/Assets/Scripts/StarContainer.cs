using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarContainer
{
    private List<Star> stars;
    public List<Star> Stars {
        get {return stars;}
    }

    public StarContainer(){
        stars = new List<Star>();
    }

    public void AddStar(Star s){
        stars.Add(s);
    }

}
