// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:Particles/Additive,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:1,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:0,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5955882,fgcg:0.5955882,fgcb:0.5955882,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:9167,x:33443,y:32572,varname:node_9167,prsc:2|alpha-1469-OUT,refract-711-OUT;n:type:ShaderForge.SFN_Tex2d,id:7618,x:32285,y:32891,varname:node_7618,prsc:2,ntxv:0,isnm:False|TEX-8836-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:8836,x:32118,y:32891,ptovrint:False,ptlb:DistortionTexture,ptin:_DistortionTexture,varname:node_8836,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ComponentMask,id:8810,x:32484,y:32903,varname:node_8810,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-7618-RGB;n:type:ShaderForge.SFN_Multiply,id:9923,x:32682,y:32903,varname:node_9923,prsc:2|A-2276-OUT,B-8810-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2276,x:32484,y:32828,ptovrint:False,ptlb:DistortionPower,ptin:_DistortionPower,varname:node_2276,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_ValueProperty,id:1469,x:32490,y:32526,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_1469,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:8887,x:32869,y:32728,varname:node_8887,prsc:2|A-1915-OUT,B-9923-OUT;n:type:ShaderForge.SFN_DepthBlend,id:1915,x:32621,y:32626,varname:node_1915,prsc:2|DIST-1621-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1621,x:32278,y:32530,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_1621,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:711,x:33174,y:32887,varname:node_711,prsc:2|A-8887-OUT,B-5579-A;n:type:ShaderForge.SFN_VertexColor,id:5579,x:33016,y:33089,varname:node_5579,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:2614,x:32278,y:32712,varname:node_2614,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:2691,x:32844,y:32951,varname:node_2691,prsc:2|A-2614-UVOUT,B-9923-OUT;proporder:8836-2276-1469-1621;pass:END;sub:END;*/

Shader "Custom/Distortion" {
    Properties {
        _DistortionTexture ("DistortionTexture", 2D) = "white" {}
        _DistortionPower ("DistortionPower", Float ) = 2
        _Opacity ("Opacity", Float ) = 0
        _Depth ("Depth", Float ) = 0.1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _DistortionTexture; uniform float4 _DistortionTexture_ST;
            uniform float _DistortionPower;
            uniform float _Opacity;
            uniform float _Depth;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 node_7618 = tex2D(_DistortionTexture,TRANSFORM_TEX(i.uv0, _DistortionTexture));
                float2 node_9923 = (_DistortionPower*node_7618.rgb.rg);
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + ((saturate((sceneZ-partZ)/_Depth)*node_9923)*i.vertexColor.a);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
                float3 finalColor = 0;
                return fixed4(lerp(sceneColor.rgb, finalColor,_Opacity),1);
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
