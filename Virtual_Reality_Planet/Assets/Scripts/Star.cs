

public class Star
{
    private float ra;
    private float dec;
    private float mag;
    private float x;
    private float y;
    private float z;
    public float Ra {
        get {return ra;}
    }
    public float Dec {
        get {return dec;}
    }
    
    public float Mag {
        get {return mag;}
    }
    public float X {
        get {return x;}
    }
    public float Y {
        get {return y;}
    }
    public float Z {
        get {return z;}
    }



    public Star(float ra, float dec, float mag, float x, float y, float z){
        this.ra = ra;
        this.dec = dec;
        this.mag = mag;
        this.x = x;
        this.y = y;
        this.z = z;
    }

}
