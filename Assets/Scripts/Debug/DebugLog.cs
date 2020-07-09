using UnityEngine;
using UnityEngine.UI;

public class DebugLog : MonoBehaviour
{
    public Text Xaxis;
    public Text Zaxis;
    public Text Yaxis;
    public Text startAxis;
    public Text nowAxis;

    public BallController ball;

    private void Update()
    {
        Xaxis.text = $"X: {Input.acceleration.x}";
        Zaxis.text = $"Z: {Input.acceleration.z}";
        Yaxis.text = $"Y: {Input.acceleration.y}";
        startAxis.text = $"start: {ball.startAcceleration}";
        nowAxis.text = $"start: {ball.movement}";
    }
}
