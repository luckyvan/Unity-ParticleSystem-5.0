using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fire : MonoBehaviour {

	public List<ParticleHelper> particles;
	// Update is called once per frame
	void Update () {
		foreach (var ph in particles) {
			if (ph.varyAlpha) {
				ph.IncreaseAlpha();
			}
			if (ph.varyEmission) {
				ph.IncreaseEmission ();
			}
			if (ph.varyIntensity) {
				ph.IncreaseIntensity ();
			}
			if (ph.varyRange) {
				ph.IncreaseRange ();
			}
		}	
	}
}
