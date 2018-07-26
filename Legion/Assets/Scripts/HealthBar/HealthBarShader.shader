Shader "Custom/HealthBarShader" {

  Properties{
    _ScaleX("Scale X", Float) = 1.0
    _ScaleY("Scale Y", Float) = 1.0
    _Point("Current Health (percent)", float) = 0.5
    _ColourDamaged("Colour of Damaged section", Color) = (1.0, 0.0, 0.0, 1.0)
    _ColourHealthy("Colour of Healthy section", Color) = (0.0, 1.0, 0.0, 1.0)
  }

    SubShader{
      Pass{
      CGPROGRAM

      #pragma vertex vert  
      #pragma fragment frag
      #include "UnityCG.cginc" 

      uniform float _ScaleX;
      uniform float _ScaleY;
      uniform float _Point;
      uniform float4 _ColourDamaged;
      uniform float4 _ColourHealthy;

      struct vertexInput {
        float4 vertex : POSITION;
        float4 tex : TEXCOORD0;
      };

      struct vertexOutput {
        float4 pos : SV_POSITION;
        float4 scale : TEXCOORD0;
      };

      vertexOutput vert(vertexInput input)
      {
        vertexOutput output;
        output.pos = mul(UNITY_MATRIX_P, mul(UNITY_MATRIX_MV, float4(0.0, 0.0, 0.0, 1.0)) + float4(input.vertex.x, input.vertex.y, 0.0, 0.0) * float4(_ScaleX, _ScaleY, 1.0, 1.0));
        output.scale = (input.vertex / _ScaleX) + float4(0.5, 0.5, 0.5, 0.0);
        return output;
      }


      float4 frag(vertexOutput input) : COLOR
      {
        if (input.scale.x > _Point)
        {
          return _ColourDamaged;
        }
        else
        {
          return _ColourHealthy;
        }
      }

      ENDCG
    }
  }

}
