Shader "Custom/StylizedCulling" {
  Properties{
    _Color("Color", Color) = (1,1,1,1)
    _MainTex("Albedo (RGB)", 2D) = "white" {}
    _Glossiness("Smoothness", Range(0,1)) = 0.5
    _Metallic("Metallic", Range(0,1)) = 0.0
    _Cull("Cull", Float) = 0.5
    _Color("Color", Color) = (1, 1, 1, 1)
  }
    SubShader{
      Tags { "RenderType" = "Opaque" "StylizedCulling" = "true" }

      CGPROGRAM
      #pragma surface surf Standard addshadow vertex:vert
      #pragma target 3.0

      sampler2D _MainTex;

      struct Input {
        float2 uv_MainTex;
      };

      half _Glossiness;
      half _Metallic;
      float4 _Color;
      float _Cull;


      UNITY_INSTANCING_BUFFER_START(Props)
        // put more per-instance properties here
      UNITY_INSTANCING_BUFFER_END(Props)

      void vert(inout appdata_full v) {
        float cull = _Cull;
        cull *= 4.0 / 3.0;
        cull = clamp(cull, 0, 1);
        float cull2 = ((-4.0 / 5.0) * _Cull) + (8.0 / 5.0);
        cull2 = clamp(cull2, 0, 1);
        cull = cull * cull2;
        cull = (1.0 - (cull * 1.25));

        float4 vertPosition = v.vertex;
        float4 scaleVector = float4(0, 0, 0, 1) - vertPosition;
        scaleVector *= cull;
        vertPosition += scaleVector;
        v.vertex = vertPosition;
      }

      void surf(Input IN, inout SurfaceOutputStandard o) {
        fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
        o.Albedo = c.rgb;
        o.Metallic = _Metallic;
        o.Smoothness = _Glossiness;
        o.Alpha = c.a;
      }

      ENDCG
    }
      Fallback "Diffuse"
}