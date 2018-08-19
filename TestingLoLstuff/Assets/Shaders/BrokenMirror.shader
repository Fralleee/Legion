// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:Particles/Additive,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:0,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:5303,x:34492,y:32741,varname:node_5303,prsc:2|emission-4412-OUT,alpha-4953-OUT,refract-984-OUT,voffset-6656-OUT;n:type:ShaderForge.SFN_Tex2d,id:6403,x:33155,y:32642,varname:node_6403,prsc:2,tex:24732670f19b29847ab110e98c0d68a6,ntxv:0,isnm:False|UVIN-4628-OUT,TEX-778-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:778,x:33155,y:32473,ptovrint:False,ptlb:ParallaxTexture,ptin:_ParallaxTexture,varname:node_778,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:24732670f19b29847ab110e98c0d68a6,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:9894,x:33155,y:32958,ptovrint:False,ptlb:MaskTexture,ptin:_MaskTexture,varname:node_9894,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f92e4d1de8324ef4a8c805c70f30c335,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:143,x:33155,y:32791,varname:node_143,prsc:2,tex:f92e4d1de8324ef4a8c805c70f30c335,ntxv:0,isnm:False|UVIN-114-UVOUT,TEX-9894-TEX;n:type:ShaderForge.SFN_Multiply,id:9675,x:33404,y:32706,varname:node_9675,prsc:2|A-6403-RGB,B-143-RGB;n:type:ShaderForge.SFN_TexCoord,id:114,x:32533,y:32294,varname:node_114,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:8820,x:32533,y:32488,ptovrint:False,ptlb:U_Speed,ptin:_U_Speed,varname:node_8820,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.4;n:type:ShaderForge.SFN_ValueProperty,id:3475,x:32533,y:32578,ptovrint:False,ptlb:V_Speed,ptin:_V_Speed,varname:node_3475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.4;n:type:ShaderForge.SFN_Append,id:3063,x:32774,y:32488,varname:node_3063,prsc:2|A-8820-OUT,B-3475-OUT;n:type:ShaderForge.SFN_Multiply,id:4860,x:32945,y:32488,varname:node_4860,prsc:2|A-3063-OUT,B-1276-OUT;n:type:ShaderForge.SFN_Time,id:5214,x:32533,y:32808,varname:node_5214,prsc:2;n:type:ShaderForge.SFN_Add,id:4628,x:32945,y:32642,varname:node_4628,prsc:2|A-4860-OUT,B-114-UVOUT;n:type:ShaderForge.SFN_Add,id:4020,x:33917,y:33182,varname:node_4020,prsc:2|A-1169-R,B-1169-G,C-1169-B;n:type:ShaderForge.SFN_ComponentMask,id:1169,x:33743,y:33182,varname:node_1169,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-3327-OUT;n:type:ShaderForge.SFN_Multiply,id:7732,x:32843,y:33337,varname:node_7732,prsc:2|A-6403-RGB,B-3988-A,C-3988-RGB;n:type:ShaderForge.SFN_VertexColor,id:3988,x:32442,y:33038,varname:node_3988,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9384,x:33038,y:33337,varname:node_9384,prsc:2|A-7732-OUT,B-1537-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1537,x:33038,y:33281,ptovrint:False,ptlb:Glow,ptin:_Glow,varname:node_4776,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:3854,x:33234,y:33337,varname:node_3854,prsc:2|A-9384-OUT,B-5337-OUT;n:type:ShaderForge.SFN_DepthBlend,id:5337,x:33234,y:33476,varname:node_5337,prsc:2|DIST-5149-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5149,x:33234,y:33623,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_3936,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:6529,x:33038,y:33476,varname:node_6529,prsc:2|A-9672-OUT,B-5982-R;n:type:ShaderForge.SFN_RemapRange,id:9672,x:32843,y:33476,varname:node_9672,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-3988-A;n:type:ShaderForge.SFN_ValueProperty,id:6555,x:33038,y:33182,ptovrint:False,ptlb:DissolvePower,ptin:_DissolvePower,varname:node_6426,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Power,id:1462,x:33234,y:33182,varname:node_1462,prsc:2|VAL-6529-OUT,EXP-6555-OUT;n:type:ShaderForge.SFN_Multiply,id:8818,x:33400,y:33182,varname:node_8818,prsc:2|A-3854-OUT,B-1462-OUT;n:type:ShaderForge.SFN_Multiply,id:3327,x:33582,y:33182,varname:node_3327,prsc:2|A-8818-OUT,B-9882-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9882,x:33582,y:33119,ptovrint:False,ptlb:FinalOpacity,ptin:_FinalOpacity,varname:node_196,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:4953,x:34103,y:33036,varname:node_4953,prsc:2|A-143-R,B-4020-OUT,C-3988-A;n:type:ShaderForge.SFN_Tex2d,id:5982,x:33038,y:33633,varname:node_5982,prsc:2,tex:24732670f19b29847ab110e98c0d68a6,ntxv:0,isnm:False|TEX-727-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:727,x:32843,y:33672,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_727,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:24732670f19b29847ab110e98c0d68a6,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5523,x:33328,y:32241,varname:node_5523,prsc:2,tex:24732670f19b29847ab110e98c0d68a6,ntxv:0,isnm:False|UVIN-850-OUT,TEX-5358-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:5358,x:33328,y:32070,ptovrint:False,ptlb:SecondaryParallaxTexture,ptin:_SecondaryParallaxTexture,varname:node_5358,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:24732670f19b29847ab110e98c0d68a6,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:6273,x:33580,y:32439,varname:node_6273,prsc:2|A-8139-OUT,B-9675-OUT;n:type:ShaderForge.SFN_ValueProperty,id:362,x:32735,y:32085,ptovrint:False,ptlb:U_Speed_2,ptin:_U_Speed_2,varname:_U_Speed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.6;n:type:ShaderForge.SFN_ValueProperty,id:1023,x:32735,y:32170,ptovrint:False,ptlb:V_Speed_2,ptin:_V_Speed_2,varname:_V_Speed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Append,id:9610,x:32926,y:32087,varname:node_9610,prsc:2|A-362-OUT,B-1023-OUT;n:type:ShaderForge.SFN_Multiply,id:2312,x:33097,y:32087,varname:node_2312,prsc:2|A-9610-OUT,B-8323-OUT;n:type:ShaderForge.SFN_Time,id:3039,x:32926,y:31811,varname:node_3039,prsc:2;n:type:ShaderForge.SFN_Add,id:850,x:33097,y:32241,varname:node_850,prsc:2|A-2312-OUT,B-114-UVOUT;n:type:ShaderForge.SFN_Multiply,id:8139,x:33404,y:32439,varname:node_8139,prsc:2|A-5523-RGB,B-6533-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6533,x:33404,y:32587,ptovrint:False,ptlb:SecondaryTextureIntensity,ptin:_SecondaryTextureIntensity,varname:node_6533,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:4412,x:33810,y:32586,varname:node_4412,prsc:2|A-6273-OUT,B-3988-RGB,C-3988-A;n:type:ShaderForge.SFN_Multiply,id:6656,x:34273,y:33083,varname:node_6656,prsc:2|A-4412-OUT,B-7284-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7284,x:34273,y:33228,ptovrint:False,ptlb:VertexOffset_Strength,ptin:_VertexOffset_Strength,varname:node_7284,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.002;n:type:ShaderForge.SFN_Multiply,id:1276,x:32533,y:32667,varname:node_1276,prsc:2|A-750-OUT,B-5214-T;n:type:ShaderForge.SFN_ValueProperty,id:750,x:32533,y:32211,ptovrint:False,ptlb:GlobalSpeed,ptin:_GlobalSpeed,varname:node_750,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:8323,x:32926,y:31940,varname:node_8323,prsc:2|A-3039-T,B-750-OUT;n:type:ShaderForge.SFN_Multiply,id:9747,x:34103,y:32885,varname:node_9747,prsc:2|A-9057-OUT,B-4412-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9057,x:34103,y:32827,ptovrint:False,ptlb:Distortion_Strength,ptin:_Distortion_Strength,varname:node_9057,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_ComponentMask,id:984,x:34273,y:32885,varname:node_984,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-9747-OUT;proporder:778-9894-8820-3475-1537-5149-6555-9882-727-5358-362-1023-6533-7284-750-9057;pass:END;sub:END;*/

Shader "Custom/BrokenMirror" {
    Properties {
        _ParallaxTexture ("ParallaxTexture", 2D) = "white" {}
        _MaskTexture ("MaskTexture", 2D) = "white" {}
        _U_Speed ("U_Speed", Float ) = 0.4
        _V_Speed ("V_Speed", Float ) = -0.4
        _Glow ("Glow", Float ) = 1
        _Depth ("Depth", Float ) = 0
        _DissolvePower ("DissolvePower", Float ) = 2
        _FinalOpacity ("FinalOpacity", Float ) = 1
        _Noise ("Noise", 2D) = "white" {}
        _SecondaryParallaxTexture ("SecondaryParallaxTexture", 2D) = "white" {}
        _U_Speed_2 ("U_Speed_2", Float ) = -0.6
        _V_Speed_2 ("V_Speed_2", Float ) = 0.2
        _SecondaryTextureIntensity ("SecondaryTextureIntensity", Float ) = 0.2
        _VertexOffset_Strength ("VertexOffset_Strength", Float ) = 0.002
        _GlobalSpeed ("GlobalSpeed", Float ) = 1
        _Distortion_Strength ("Distortion_Strength", Float ) = 0.2
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
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _ParallaxTexture; uniform float4 _ParallaxTexture_ST;
            uniform sampler2D _MaskTexture; uniform float4 _MaskTexture_ST;
            uniform float _U_Speed;
            uniform float _V_Speed;
            uniform float _Glow;
            uniform float _Depth;
            uniform float _DissolvePower;
            uniform float _FinalOpacity;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _SecondaryParallaxTexture; uniform float4 _SecondaryParallaxTexture_ST;
            uniform float _U_Speed_2;
            uniform float _V_Speed_2;
            uniform float _SecondaryTextureIntensity;
            uniform float _VertexOffset_Strength;
            uniform float _GlobalSpeed;
            uniform float _Distortion_Strength;
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
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                float4 node_3039 = _Time + _TimeEditor;
                float2 node_850 = ((float2(_U_Speed_2,_V_Speed_2)*(node_3039.g*_GlobalSpeed))+o.uv0);
                float4 node_5523 = tex2Dlod(_SecondaryParallaxTexture,float4(TRANSFORM_TEX(node_850, _SecondaryParallaxTexture),0.0,0));
                float4 node_5214 = _Time + _TimeEditor;
                float2 node_4628 = ((float2(_U_Speed,_V_Speed)*(_GlobalSpeed*node_5214.g))+o.uv0);
                float4 node_6403 = tex2Dlod(_ParallaxTexture,float4(TRANSFORM_TEX(node_4628, _ParallaxTexture),0.0,0));
                float4 node_143 = tex2Dlod(_MaskTexture,float4(TRANSFORM_TEX(o.uv0, _MaskTexture),0.0,0));
                float3 node_4412 = (((node_5523.rgb*_SecondaryTextureIntensity)+(node_6403.rgb*node_143.rgb))*o.vertexColor.rgb*o.vertexColor.a);
                v.vertex.xyz += (node_4412*_VertexOffset_Strength);
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
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
                float4 node_3039 = _Time + _TimeEditor;
                float2 node_850 = ((float2(_U_Speed_2,_V_Speed_2)*(node_3039.g*_GlobalSpeed))+i.uv0);
                float4 node_5523 = tex2D(_SecondaryParallaxTexture,TRANSFORM_TEX(node_850, _SecondaryParallaxTexture));
                float4 node_5214 = _Time + _TimeEditor;
                float2 node_4628 = ((float2(_U_Speed,_V_Speed)*(_GlobalSpeed*node_5214.g))+i.uv0);
                float4 node_6403 = tex2D(_ParallaxTexture,TRANSFORM_TEX(node_4628, _ParallaxTexture));
                float4 node_143 = tex2D(_MaskTexture,TRANSFORM_TEX(i.uv0, _MaskTexture));
                float3 node_4412 = (((node_5523.rgb*_SecondaryTextureIntensity)+(node_6403.rgb*node_143.rgb))*i.vertexColor.rgb*i.vertexColor.a);
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (_Distortion_Strength*node_4412).rg;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float3 emissive = node_4412;
                float3 finalColor = emissive;
                float4 node_5982 = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float3 node_1169 = (((((node_6403.rgb*i.vertexColor.a*i.vertexColor.rgb)*_Glow)*saturate((sceneZ-partZ)/_Depth))*pow(((i.vertexColor.a*2.0+-1.0)+node_5982.r),_DissolvePower))*_FinalOpacity).rgb;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,(node_143.r*(node_1169.r+node_1169.g+node_1169.b)*i.vertexColor.a)),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform sampler2D _ParallaxTexture; uniform float4 _ParallaxTexture_ST;
            uniform sampler2D _MaskTexture; uniform float4 _MaskTexture_ST;
            uniform float _U_Speed;
            uniform float _V_Speed;
            uniform sampler2D _SecondaryParallaxTexture; uniform float4 _SecondaryParallaxTexture_ST;
            uniform float _U_Speed_2;
            uniform float _V_Speed_2;
            uniform float _SecondaryTextureIntensity;
            uniform float _VertexOffset_Strength;
            uniform float _GlobalSpeed;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                float4 node_3039 = _Time + _TimeEditor;
                float2 node_850 = ((float2(_U_Speed_2,_V_Speed_2)*(node_3039.g*_GlobalSpeed))+o.uv0);
                float4 node_5523 = tex2Dlod(_SecondaryParallaxTexture,float4(TRANSFORM_TEX(node_850, _SecondaryParallaxTexture),0.0,0));
                float4 node_5214 = _Time + _TimeEditor;
                float2 node_4628 = ((float2(_U_Speed,_V_Speed)*(_GlobalSpeed*node_5214.g))+o.uv0);
                float4 node_6403 = tex2Dlod(_ParallaxTexture,float4(TRANSFORM_TEX(node_4628, _ParallaxTexture),0.0,0));
                float4 node_143 = tex2Dlod(_MaskTexture,float4(TRANSFORM_TEX(o.uv0, _MaskTexture),0.0,0));
                float3 node_4412 = (((node_5523.rgb*_SecondaryTextureIntensity)+(node_6403.rgb*node_143.rgb))*o.vertexColor.rgb*o.vertexColor.a);
                v.vertex.xyz += (node_4412*_VertexOffset_Strength);
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Particles/Additive"
    CustomEditor "ShaderForgeMaterialInspector"
}
