Shader "Custom/Fantasma" 
{
	Properties
	{
		_ColorTint ("Color", Color) = (0.0,0.0,0.0,0.0)
		// Color to tint the mesh
		_NormalMap ("Normal", 2D) = "bump" {}
		// normal map to disturb your grab pass texture => default value = "bump"
		_DisortionFac ("Disortion Factor", Range (0.0, 1.0)) = 0.0
		// Distortion Factor => slider between 0 & 0.1
		_RimRange ("Rim power", Range (0.1, 20)) = 0.1
		_RimColor ("Rim color", Color) = (0.0,0.0,1.0,1.0)
	}
	SubShader
	{
		Tags { "Queue"="Transparent" }

		// First pass
		// Unity "takes a screenshot of what is covered by the mesh".
		GrabPass {}
		
		// Second pass
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			sampler2D _GrabTexture;
			sampler2D _NormalMap;
			float4 _ColorTint;
			half _DisortionFac;
			float _RimRange;
			float4 _RimColor;
			
			struct appdata
			{
				float4 position : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
				// To do 
			};

			struct v2f
			{
				// To do
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
				float4 uv_GrabPass : TEXCOORD1;
				float3 worldSpaceVertex : TEXCOORD2;
				float3 worldSpaceNormal : TEXCOORD3;
			};
			
			v2f vert (appdata v)
			{
				v2f o;
				o.position = UnityObjectToClipPos(v.position);
				// To do...
				o.worldSpaceVertex = mul (unity_ObjectToWorld, v.position).xyz;
				o.worldSpaceNormal = mul(unity_ObjectToWorld, float4(v.normal, 0.0)).xyz;
				o.worldSpaceNormal = normalize(o.worldSpaceNormal);
				// UnityObjectToClipPos(vertex in object space)  => and returns vertex position in clip space
				o.uv_GrabPass = ComputeGrabScreenPos(o.position);
				o.uv = v.uv;
				// Use the function ComputeGrabScreenPos to compute the uv of the grab texture
				// The parameter of this method is the vertex in CLIP SPACE.					
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{		
				float NdotV = 0.0;
				float3 eyeVector = normalize(_WorldSpaceCameraPos - i.worldSpaceVertex);
				float3 N = normalize(i.worldSpaceNormal);
				NdotV = 1.0 -saturate(dot(N, eyeVector));
				float4 rim = _RimColor * pow (NdotV, _RimRange);
				
				half4 normalDistortion = half4(UnpackNormal(tex2D(_NormalMap, i.uv + float2(_Time.x, 0.0))), 0.0);
				// 1.
				// Get the vector from the normal map and save it in a half4 variable. => the w component of a vector = 0.0
				// Call it normalDistortion
				// Use the default uvs to read the texture.
				i.uv_GrabPass += (normalDistortion * _DisortionFac);				
				// 2.
				// Disturb the uvs of the Grab texture by adding an offset => normalDistortion & the slide value
				// Read and return the _GrabTexture texel color.
				// Read it with the function: tex2Dproj(sampler2D NameOfTheTexture, half4 uvs) as we project the texture on the mesh.
				return rim + ( tex2Dproj(_GrabTexture, i.uv_GrabPass) * _ColorTint);
			}
			
			ENDCG
		}
	}
}
