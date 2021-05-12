#ifndef CUSTOM_LIGHTING_INCLUDED
#define CUSTOM_lIGHTING_INCLUDED

void CalculateMainLight_float(float3 worldPos, out float3 Direction, out float3 Color, out half DistanceAtten, out half ShadowAtten) {
#if SHADERGRAPH_PREVIEW
	Direction = float3(0.5, 0.5, 0);
	Color = 1;
	ShadowAtten = 1;
	DistanceAtten = 1;
#else
	#if SHADOW_SCREEN
		half4 clipPos = TransformWorldToHClip(WorldPos);
		half4 shadowCoord = ComputeScreenPos(clipPos);
	#else
		half4 shadowCoord = TransformWorldToShadowCoord(worldPos);
	#endif
	Light mainLight = GetMainLight(0);
	Direction = mainLight.direction;
	Color = mainLight.color;
	DistanceAtten = mainLight.distanceAttenuation;
	ShadowAtten = mainLight.shadowAttenuation;
#endif
} 

#endif