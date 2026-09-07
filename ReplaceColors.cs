using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


public static class ReplaceColors
{
    [MenuItem("Tools/Color/Replace")]
    private static void Alright()
    {
        const int div = 16, div2 = div - 1;
        
        Color[] aP = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/flight/4_Textures/RGB_15bits_palette.png").GetPixels();
        List<Color> collected = new List<Color>();
        HashSet<int> f = new HashSet<int>();
        int aLength = aP.Length;
        for (int i = 0; i < aLength; i++)
        {
            Color c = aP[i];
            
            int r = Mathf.RoundToInt(c.r * 127);
            int g = Mathf.RoundToInt(c.g * 127);
            int b = Mathf.RoundToInt(c.b * 127);
            
            int id = r + g * 128 + b * 128 * 128;
            
            if(f.Add(id))
                collected.Add(c);
        }
        
        int cCount = collected.Count;
        
        
        Color[] col = new Color[div * div * div];
        for (int r = 0; r < div; r++)
        for (int g = 0; g < div; g++)
        for (int b = 0; b < div; b++)
        {
            int id = r + g * div + b * div * div;
            Color c = new Color(r * 1f / div2, g * 1f / div2, b * 1f / div2, 0);
                 // c = new Color(1f - Mathf.Pow(1f - c.r, 2), 1f - Mathf.Pow(1f - c.g, 2), 1f - Mathf.Pow(1f - c.b, 2), 1);
            
            Color found = c;
            float bestDist = 100000;
            for (int e = 0; e < cCount; e++)
            {
                float dist = c.Dist(collected[e]);
                if (dist < bestDist)
                {
                    bestDist = dist;
                    found    = collected[e];
                }
            }
            col[id] = found;
        }
        
        Texture2D n = new Texture2D(div * div * div, 1);
        n.SetPixels(col);
        n.Apply();
        
        File.WriteAllBytes("C:/_UNITY_FAST/Crab/Assets/flight/4_Textures/palette.png", n.EncodeToPNG());
        
        AssetDatabase.Refresh();
        
        Debug.Log(col.Length);
    }
    
    
    [MenuItem("Tools/Color/Replace Better")]
    private static void Alright2()
    {
        const int div = 22, div2 = div - 1;
        
        const bool a = true;
        const string source = a? "RGB_15bits_palette" : "atari-256-colour-palette";
        
        Color[] aP = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/flight/4_Textures/" + source + ".png").GetPixels();
        List<Color> collected = new List<Color>();
        HashSet<int> f = new HashSet<int>();
        int aLength = aP.Length;
        for (int i = 0; i < aLength; i++)
        {
            Color c = aP[i];
            
            int r = Mathf.RoundToInt(c.r * 255);
            int g = Mathf.RoundToInt(c.g * 255);
            int b = Mathf.RoundToInt(c.b * 255);
            
            int id = r + g * 256 + b * 256 * 256;
            
            if(f.Add(id))
                collected.Add(c);
        }
        
        int cCount = collected.Count;
        
        const int cc = div * div * div;
        Color[] col = new Color[cc];
        for (int r = 0; r < div; r++)
        for (int g = 0; g < div; g++)
        for (int b = 0; b < div; b++)
        {
            int id = r + g * div + b * div * div;
            Color c = new Color(r * 1f / div2, g * 1f / div2, b * 1f / div2, 0);
            
            Color found = c;
            float bestDist = 100000;
            for (int e = 0; e < cCount; e++)
            {
                float dist = c.Dist(collected[e]);
                if (dist < bestDist)
                {
                    bestDist = dist;
                    found    = collected[e];
                }
            }
            col[id] = found;
        }
        
        List<Color> helper = new List<Color>();
        for (int i = 0; i < cc; i++)
            helper.Add(col[i]);
        
        int check = 0;
        while(check < cc)
            check += 4096;
        
        Debug.Log(check);

        for (int i = cc; i < check; i++)
            helper.Add(Color.black);
        
        col = helper.ToArray();
        
        Texture2D n = new Texture2D(4096, Mathf.Max(1, check / 4096));
        Debug.Log(n.width + " " + n.height + " " + check);
        
        
        n.SetPixels(col);
        n.Apply();
        
        File.WriteAllBytes("C:/_UNITY_FAST/Crab/Assets/flight/4_Textures/palette2.png", n.EncodeToPNG());
        
        AssetDatabase.Refresh();
        
        Debug.Log(col.Length);
    }
    
    
    [MenuItem("Tools/Color/Replace HSV")]
    private static void Alright3()
    {
        const int div = 22, div2 = div - 1;
        
        const bool a = true;
        const string source = a? "RGB_15bits_palette" : "atari-256-colour-palette";
        
        Color[] aP = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/flight/4_Textures/" + source + ".png").GetPixels();
        List<Color> collected = new List<Color>();
        HashSet<int> f = new HashSet<int>();
        int aLength = aP.Length;
        for (int i = 0; i < aLength; i++)
        {
            Color c = aP[i];
            
            int r = Mathf.RoundToInt(c.r * 255);
            int g = Mathf.RoundToInt(c.g * 255);
            int b = Mathf.RoundToInt(c.b * 255);
            
            int id = r + g * 256 + b * 256 * 256;
            
            if(f.Add(id))
                collected.Add(c);
        }
        
        int cCount = collected.Count;
        
        const int cc = div * div * div;
        Color[] col = new Color[cc];
        for (int r = 0; r < div; r++)
        for (int g = 0; g < div; g++)
        for (int b = 0; b < div; b++)
        {
            int id = r + g * div + b * div * div;
            Color c = new Color(r * 1f / div2, g * 1f / div2, b * 1f / div2, 0);
            
            Color found = c;
            float bestDist = 100000;
            for (int e = 0; e < cCount; e++)
            {
                float dist = c.DistHSV(collected[e]);
                if (dist < bestDist)
                {
                    bestDist = dist;
                    found    = collected[e];
                }
            }
            col[id] = found;
        }
        
        List<Color> helper = new List<Color>();
        for (int i = 0; i < cc; i++)
            helper.Add(col[i]);
        
        int check = 0;
        while(check < cc)
            check += 4096;
        
        Debug.Log(check);

        for (int i = cc; i < check; i++)
            helper.Add(Color.black);
        
        col = helper.ToArray();
        
        Texture2D n = new Texture2D(4096, Mathf.Max(1, check / 4096));
        Debug.Log(n.width + " " + n.height + " " + check);
        
        
        n.SetPixels(col);
        n.Apply();
        
        File.WriteAllBytes("C:/_UNITY_FAST/Crab/Assets/flight/4_Textures/palette2.png", n.EncodeToPNG());
        
        AssetDatabase.Refresh();
        
        Debug.Log(col.Length);
    }
    
    
    [MenuItem("Tools/Color/ReplacePico")]
    private static void ReplacePico()
    {
        Color[] source = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/flight/Palettes/windows-95-256-colours-1x.png").GetPixels();
        int cCount = source.Length;
        
        const int cc = 256 * 256 * 256;
        Color[] col = new Color[cc];
        for (byte r = 0; r < 256; r++)
        for (byte g = 0; g < 256; g++)
        for (byte b = 0; b < 256; b++)
        {
            Color c = new Color32(r, g, b, 0);
            
            Color found = Color.white;
            float bestDist = 100000;
            for (int e = 0; e < cCount; e++)
            {
                float dist = c.Dist(source[e]);
                if (dist < bestDist)
                {
                    bestDist = dist;
                    found    = source[e];
                }
            }
            col[r + g * 256 + b * 256 * 256] = found;
        }
        
        Palette result = AssetDatabase.LoadAssetAtPath<Palette>("Assets/flight/Palettes/PICO_OUT.asset");
        if (result == null)
        {
            result = ScriptableObject.CreateInstance<Palette>();
            AssetDatabase.CreateAsset(result, "Assets/flight/Palettes/PICO_OUT.asset");
        }
        
        result.colors = col;
      
        EditorUtility.SetDirty(result);
        AssetDatabase.Refresh();
    }
}
