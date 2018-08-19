// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5955882,fgcg:0.5955882,fgcb:0.5955882,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1422,x:33007,y:32609,varname:node_1422,prsc:2|emission-1153-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7323,x:31644,y:32329,ptovrint:False,ptlb:U_Speed,ptin:_U_Speed,varname:node_8820,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:6784,x:31644,y:32424,ptovrint:False,ptlb:V_Speed,ptin:_V_Speed,varname:node_3475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.15;n:type:ShaderForge.SFN_Append,id:2235,x:31854,y:32365,varname:node_2235,prsc:2|A-7323-OUT,B-6784-OUT;n:type:ShaderForge.SFN_Multiply,id:1946,x:32025,y:32365,varname:node_1946,prsc:2|A-2235-OUT,B-8399-T;n:type:ShaderForge.SFN_Time,id:8399,x:31854,y:32519,varname:node_8399,prsc:2;n:type:ShaderForge.SFN_Add,id:5861,x:32025,y:32519,varname:node_5861,prsc:2|A-1946-OUT,B-2770-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2770,x:31854,y:32660,varname:node_2770,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2dAsset,id:2121,x:32220,y:32692,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_2121,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:832d9632ca6c98440afb3695dbe1d34c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5451,x:32427,y:32692,varname:node_5451,prsc:2,tex:832d9632ca6c98440afb3695dbe1d34c,ntxv:0,isnm:False|UVIN-5861-OUT,TEX-2121-TEX;n:type:ShaderForge.SFN_Color,id:165,x:32415,y:32416,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_165,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2058824,c2:0.4742395,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:2495,x:32605,y:32438,varname:node_2495,prsc:2|A-165-RGB,B-4780-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4780,x:32415,y:32593,ptovrint:False,ptlb:ColorPower,ptin:_ColorPower,varname:node_4780,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Multiply,id:1153,x:32734,y:32596,varname:node_1153,prsc:2|A-2495-OUT,B-5451-RGB;proporder:165-4780-2121-7323-6784;pass:END;sub:END;*/

Shader "Custom/OpaqueEmissivePan" {
    Properties {
        _Color ("Color", Color) = (0.2058824,0.4742395,1,1)
        _ColorPower ("ColorPower", Float ) = 4
        _Noise ("Noise", 2D) = "white" {}
        _U_Speed ("U_Speed", Float ) = 0.1
        _V_Speed ("V_Speed", Float ) = 0.15
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _U_Speed;
            uniform float _V_Speed;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float4 _Color;
            uniform float _ColorPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_8399 = _Time + _TimeEditor;
                float2 node_5861 = ((float2(_U_Speed,_V_Speed)*node_8399.g)+i.uv0);
                float4 node_5451 = tex2D(_Noise,TRANSFORM_TEX(node_5861, _Noise));
                float3 emissive = ((_Color.rgb*_ColorPower)*node_5451.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
