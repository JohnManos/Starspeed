using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AsteroidMotionBlur : MonoBehaviour {

    // MotionBlur motionBlur;
    // PostProcessVolume ppv;

    // // Start is called before the first frame update
    // void Start() {
    //     motionBlur = ScriptableObject.CreateInstance<MotionBlur>();
    //     motionBlur.enabled.Override(true);
    //     motionBlur.shutterAngle.Override(360f);
    //     motionBlur.sampleCount.Override(16);

    //     // PostProcessVolume postProcessVolume = GetComponent<PostProcessVolume>();
    //     // var postProcessProfile = postProcessVolume.profile;
    //     // postProcessProfile.AddSettings(motionBlur);

    //     ppv = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, motionBlur);
    // }

    // // Update is called once per frame
    // void Update() {
    //     if (GetComponent<AstroidPatrol>().IsGoingRight()) {
    //         if (transform.position.x >= GetComponent<AstroidPatrol>().GetXMax() || transform.position.x < -1 * GetComponent<AstroidPatrol>().GetXMax() + 5) {
    //             motionBlur.enabled.value = false;
    //         }
    //         else {
    //             motionBlur.enabled.value = true;
    //         }
    //     }
    //     else {
    //         if (transform.position.x <= GetComponent<AstroidPatrol>().GetXMax() || transform.position.x > -1 * GetComponent<AstroidPatrol>().GetXMax() - 5) {
    //             motionBlur.enabled.value = false;
    //         }
    //         else {
    //             motionBlur.enabled.value = true;
    //         }
    //     }
    // }

    // void OnDestroy() {
    //     RuntimeUtilities.DestroyVolume(ppv, true, true);
    // }
}
