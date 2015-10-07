using UnityEngine;
using System.Collections;

[System.Serializable]
public class ParticleHelper {
	public ParticleSystem particle;
	public Light light;
	#region alpha
	public bool varyAlpha;
	public float minAlpha;
	public float maxAlpha;
	public float alphaIncreaseRate;
	public float alphaDecreaseRate;
	public float alphaVariation;

	public void IncreaseAlpha (){
		if (particle.startColor.a < maxAlpha) {
			Color adjustedColor = particle.startColor;

			adjustedColor.a += alphaIncreaseRate*Time.deltaTime;
			adjustedColor.a += Random.Range (0f, alphaVariation);

			particle.startColor = adjustedColor;
		}
	}

	public void DecreaseAlpha (){
		if (particle.startColor.a > minAlpha) {
			Color adjustedColor = particle.startColor;
			
			adjustedColor.a -= alphaDecreaseRate*Time.deltaTime;
			particle.startColor = adjustedColor;
		}
	}
	#endregion alpha

	#region emission
	public bool varyEmission;
	public float minEmission;
	public float maxEmission;
	public float emissionIncreaseRate;
	public float emissionDecreaseRate;
	public float emissionVariation;
	
	public void IncreaseEmission (){
		if (particle.emissionRate < maxEmission) {
			float adjustedRate = particle.emissionRate;
			
			adjustedRate += emissionIncreaseRate*Time.deltaTime;
			adjustedRate += Random.Range (0f, emissionVariation);
			
			particle.emissionRate = adjustedRate;
		}
	}
	
	public void DecreaseEmission (){
		if (particle.emissionRate > minEmission) {
			float adjustedRate  = particle.emissionRate;
			
			adjustedRate-= emissionDecreaseRate*Time.deltaTime;
			particle.emissionRate= adjustedRate;
		}
	}
	#endregion emission

	#region intensity
	public bool varyIntensity;
	public float minIntensity;
	public float maxIntensity;
	public float intensityIncreaseRate;
	public float intensityDecreaseRate;
	public float intensityVariation;
	
	public void IncreaseIntensity (){
		if (light.intensity < maxIntensity) {
			float adjustedIntensity  = light.intensity;
			
			adjustedIntensity += intensityIncreaseRate*Time.deltaTime;
			adjustedIntensity += Random.Range (0f, intensityVariation);
			
			light.intensity = adjustedIntensity;
		}
	}
	
	public void DecreaseIntensity (){
		if (light.intensity > minIntensity) {
			float adjustedIntensity = light.intensity;
			
			adjustedIntensity -= intensityDecreaseRate*Time.deltaTime;
			light.intensity = adjustedIntensity;
		}
	}
	#endregion intensity

	#region range
	public bool varyRange;
	public float minRange;
	public float maxRange;
	public float rangeIncreaseRate;
	public float rangeDecreaseRate;
	public float rangeVariation;
	
	public void IncreaseRange (){
		if (light.range < maxRange) {
			float adjustedRange  = light.range;
			
			adjustedRange += rangeIncreaseRate*Time.deltaTime;
			adjustedRange += Random.Range (0f, rangeVariation);
			
			light.range = adjustedRange;
		}
	}
	
	public void DecreaseRange (){
		if (light.range > minRange) {
			float adjustedRange = light.range;
			
			adjustedRange -= rangeDecreaseRate*Time.deltaTime;
			light.range = adjustedRange;
		}
	}
	#endregion range
}
