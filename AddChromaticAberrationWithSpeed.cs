using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AddChromaticAberrationWithSpeed : MonoBehaviour {

    [SerializeField]
    private GameObject referenceShip;

    ChromaticAberration chromaticAberration;
    PostProcessVolume ppv;
    private ShipControls shipControl;

    // Start is called before the first frame update
    void Start() {
        chromaticAberration = ScriptableObject.CreateInstance<ChromaticAberration>();
        chromaticAberration.enabled.Override(true);
        chromaticAberration.intensity.Override(0f);

        // PostProcessVolume postProcessVolume = GetComponent<PostProcessVolume>();
        // var postProcessProfile = postProcessVolume.profile;
        // postProcessProfile.AddSettings(chromaticAberration);

        ppv = PostProcessManager.instance.QuickVolume(gameObject.layer, 0f, chromaticAberration);

        shipControl = referenceShip.GetComponent<ShipControls>();
    }

    // Update is called once per frame
    void Update() {
        var velocity = shipControl.GetVelocity();
        var maxSpeed = shipControl.maxSpeed;
        chromaticAberration.intensity.value = (velocity/maxSpeed) * .75f;
    }

    void OnDestroy() {
        RuntimeUtilities.DestroyVolume(ppv, true, true);
    }
}
