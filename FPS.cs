using System.Text;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private float delta;
    private float checkTime;
    private int fps, frames;
    
    
    private void LateUpdate()
    {
        delta += Time.deltaTime;
        frames++;
        float now = Time.realtimeSinceStartup;
        if (now - checkTime > .125f)
        {
            float average = delta / frames;
            fps = Mathf.FloorToInt(1f / average);
            delta = 0;
            frames = 0;
            checkTime = now;
        }
    }
    
    
    private void OnEnable()
    {
        DebugUI.TR += OnDebugUI;
    }
    private void OnDisable()
    {
        DebugUI.TR -= OnDebugUI;
    }
    private void OnDebugUI(StringBuilder builder)
    {
        builder.AppendLine(fps.PrepString());
    }
}
