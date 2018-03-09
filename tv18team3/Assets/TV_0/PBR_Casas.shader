Shader "Custom/ToDoSurfaceShader_NotPBR" 
{
	Properties 
	{				
		_MainTex ("Albedo", 2D) = "black" {}	
		_Normal ("Normal", 2D) = "bump"{}
		_Smoothness ("Smoothness", 2D) = "black"{}
		_Metallic ("Metallic", 2D) = "black"{}
		_Slider ("Metallic", Range (0,1)) = 1
		_Color ("Color", Color) = (0,0,0,1)

	}
	
	SubShader 
	{		
		CGPROGRAM		
		#pragma surface surf Standard
		#pragma target 3.0 //to get a better lighting

		sampler2D _MainTex, _Normal, _Smoothness, _Metallic;
		float4 _Color;
		half _Slider;
		
		struct Input 
		{
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutputStandard o) 
		{		
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _Color.rgb;
			//o.Normal = UnpackNormal (tex2D(_Normal, IN.uv_MainTex));
			o.Normal = UnpackNormal ( tex2D(_Normal, IN.uv_MainTex));
			//o.Metallic = tex2D(_Smoothness, IN.uv_MainTex).r;				
			o.Metallic =tex2D(_Smoothness, IN.uv_MainTex).r * _Slider;
			//o.Smoothness = tex2D(_Smoothness, IN.uv_MainTex).a						
			o.Smoothness =tex2D(_Smoothness, IN.uv_MainTex).a;
			
		}
		
		ENDCG
	}
	
	FallBack "Diffuse"
}
