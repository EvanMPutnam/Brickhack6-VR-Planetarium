using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StarPlotter
{


    public const string RA = "ra";
    public const string DEC = "dec";
    public const string MAG = "mag";
    public const string X = "x";
    public const string Y = "y";
    public const string Z = "z";


    //Scaling function.
	public static float Scale_One_Through_Zero_Value(float value, float max, float new_max){
		return 0.0f + (new_max - 0.0f) * ((value-0.0f)/(max-0.0f));
	}

    public static StarContainer Create_Star_Cluster(TextAsset file){
        string[] lines = file.text.Split('\n');

        StarContainer sc = new StarContainer();

        int ra_index = -1;
        int dec_index = -1;
        int mag_index = -1;
        int x_index = -1;
        int y_index = -1;
        int z_index = -1;

        int count = 0;

        bool first_val = true;
        foreach(string line in lines) {
            string[] line_parts = line.Split(',');
            if(first_val){
                for(int i = 0; i < line_parts.Length; i++){
                    if(line_parts[i].ToLower().Equals(RA)){
                        ra_index = i;
                    }
                    if(line_parts[i].ToLower().Equals(DEC)){
                        dec_index = i;
                    }
                    if(line_parts[i].ToLower().Equals(MAG)){
                        mag_index = i;
                    }
                    if(line_parts[i].ToLower().Equals(X)){
                        x_index = i;
                    }
                    if(line_parts[i].ToLower().Equals(Y)){
                        y_index = i;
                    }
                    if(line_parts[i].ToLower().Equals(Z)){
                        z_index = i;
                    }
                }
                first_val = false;
            } else {
                try{
                    float ra_val = float.Parse(line_parts[ra_index]);
                    ra_val = Scale_One_Through_Zero_Value(ra_val, 24f, 360f);
                    float dec_val = float.Parse(line_parts[dec_index]);
                    float mag = float.Parse(line_parts[mag_index]);
                    float x = float.Parse(line_parts[x_index]);
                    float y = float.Parse(line_parts[y_index]);
                    float z = float.Parse(line_parts[z_index]);
                    if(x != 0 && y != 0 && z != 0){
                        Star s = new Star(ra_val, dec_val, mag, x, y, z);
                        sc.AddStar(s);
                    }

                } catch(IndexOutOfRangeException){
                    count += 1;
                }

            }

        }
        Debug.Log(count + " stars without adequate data");
        return sc;
    }


    public static void Plot_Star_Cluster(StarContainer stars, ParticleSystem particle, 
                                        double latitude, double longitude, DateTime dt, bool plot_xyz){
        double dayOffset = (dt - new DateTime(2000, 1, 1, 12, 0, 0, DateTimeKind.Utc)).TotalDays;
        double LST = (100.46 + 0.985647 * dayOffset + longitude + 15 * (dt.Hour + dt.Minute / 60d) + 360) % 360;

        int star_length = stars.Stars.Count;

        particle.Clear();
        for (int i = 0; i < star_length; i++){
			particle.Emit(1);
		}
        ParticleSystem.Particle[] arrParts;
        arrParts = new ParticleSystem.Particle[star_length];
        particle.GetParticles(arrParts);
        for (int i = 0; i < star_length; i++){
            ParticleSystem.Particle par = arrParts[i];
            

            Star s = stars.Stars[i];
            
            double x;
            double y;
            double z;

            //Plot based on XYZ or RA/DEC
            if(!plot_xyz){
                double HA = (LST - s.Ra + 360) % 360;
                x = Math.Cos(HA * (Math.PI / 180)) * Math.Cos(s.Dec * (Math.PI / 180));
                y = Math.Sin(HA * (Math.PI / 180)) * Math.Cos(s.Dec * (Math.PI / 180));
                z = Math.Sin(s.Dec * (Math.PI / 180));
            } else{
                x = s.X;
                y = s.Y;
                z = s.Z;
            }


            Vector3 orig_vec = new Vector3((float)x, (float)z, (float)y);
            Vector3 norm = orig_vec.normalized * Camera.main.farClipPlane * 0.98f;
            
            par.startColor = Color.white * (1.0f - (s.Mag + 1.40f) / 8) * 2;
            par.startSize = 8;
            par.position = norm;
            arrParts[i] = par;

        }
        particle.SetParticles(arrParts, star_length);

    }
}
