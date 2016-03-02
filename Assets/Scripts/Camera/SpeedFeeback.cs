using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class SpeedFeeback : MonoBehaviour {

    [SerializeField]
    private DropPod pod;

    [SerializeField]
    private float scale;

    private CameraMotionBlur motionBlur;

	// Use this for initialization
	void Awake () {
        motionBlur = GetComponent<CameraMotionBlur>();

        // Make sure that the velocity starts at zero
        motionBlur.velocityScale = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(pod.Velocity()) > pod.GetMaxLandingVelocity()) motionBlur.velocityScale = scale * (Mathf.Abs(pod.Velocity()) - pod.GetMaxLandingVelocity());
        else motionBlur.velocityScale = 0;

        clamp();
    }

    private void clamp()
    {
        if (motionBlur.velocityScale > motionBlur.maxVelocity) motionBlur.velocityScale = motionBlur.maxVelocity;
        else if (motionBlur.velocityScale < motionBlur.minVelocity) motionBlur.velocityScale = motionBlur.minVelocity;
    }
}
