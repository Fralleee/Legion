// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:True,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:0,nrsp:0,vomd:1,spxs:False,tesm:0,olmd:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5955882,fgcg:0.5955882,fgcb:0.5955882,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:2679,x:34203,y:32520,varname:node_2679,prsc:2|custl-3762-OUT,olwid-8220-OUT;n:type:ShaderForge.SFN_NormalVector,id:4256,x:31473,y:32924,prsc:2,pt:True;n:type:ShaderForge.SFN_LightVector,id:4242,x:31473,y:33061,varname:node_4242,prsc:2;n:type:ShaderForge.SFN_Dot,id:121,x:31666,y:32988,varname:node_121,prsc:2,dt:4|A-4256-OUT,B-4242-OUT;n:type:ShaderForge.SFN_Multiply,id:3018,x:31844,y:32998,varname:node_3018,prsc:2|A-121-OUT,B-4022-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:4022,x:31666,y:33149,varname:node_4022,prsc:2;n:type:ShaderForge.SFN_Append,id:466,x:32008,y:32998,varname:node_466,prsc:2|A-3018-OUT,B-3018-OUT;n:type:ShaderForge.SFN_Tex2d,id:1253,x:32008,y:32837,varname:node_4848,prsc:2,tex:2de4a5a1730ba964c9706613effd224d,ntxv:0,isnm:False|UVIN-466-OUT,TEX-9009-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:9009,x:31844,y:32837,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_2957,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2de4a5a1730ba964c9706613effd224d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_LightColor,id:6704,x:32008,y:33137,varname:node_6704,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3168,x:32206,y:32953,varname:node_3168,prsc:2|A-1253-RGB,B-6704-RGB;n:type:ShaderForge.SFN_Tex2d,id:6831,x:31916,y:32597,varname:node_6831,prsc:2,tex:f6b871f55329fe241878576f34f4668c,ntxv:0,isnm:False|UVIN-9921-UVOUT,TEX-159-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:159,x:31647,y:32584,ptovrint:False,ptlb:HalftoneTexture,ptin:_HalftoneTexture,varname:node_159,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f6b871f55329fe241878576f34f4668c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ScreenPos,id:9921,x:31739,y:32409,varname:node_9921,prsc:2,sctp:1;n:type:ShaderForge.SFN_Multiply,id:8648,x:32425,y:32834,varname:node_8648,prsc:2|A-3250-OUT,B-3168-OUT;n:type:ShaderForge.SFN_Multiply,id:4206,x:32614,y:32722,varname:node_4206,prsc:2|A-5160-OUT,B-8648-OUT;n:type:ShaderForge.SFN_Tex2d,id:7448,x:32166,y:32120,varname:node_7448,prsc:2,tex:066d85a7490b40246879928a8e4bdb53,ntxv:0,isnm:False|UVIN-9921-UVOUT,TEX-8427-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:8427,x:31999,y:32120,ptovrint:False,ptlb:DrawingTexture,ptin:_DrawingTexture,varname:node_8427,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:066d85a7490b40246879928a8e4bdb53,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:8220,x:32620,y:33033,ptovrint:False,ptlb:OutlineWidth,ptin:_OutlineWidth,varname:node_8220,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.032;n:type:ShaderForge.SFN_Multiply,id:2799,x:32982,y:32754,varname:node_2799,prsc:2|A-4206-OUT,B-5258-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5258,x:32802,y:32938,ptovrint:False,ptlb:BW_Value,ptin:_BW_Value,varname:node_5258,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_ValueProperty,id:536,x:32166,y:32269,ptovrint:False,ptlb:DrawingAdd,ptin:_DrawingAdd,varname:node_536,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.8;n:type:ShaderForge.SFN_Add,id:5160,x:32433,y:32210,varname:node_5160,prsc:2|A-7448-RGB,B-536-OUT;n:type:ShaderForge.SFN_Tex2d,id:9928,x:32891,y:32517,varname:node_9928,prsc:2,tex:f7b18262daa871c4696f84ddfdadc783,ntxv:0,isnm:False|TEX-4428-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:4428,x:32706,y:32517,ptovrint:False,ptlb:ColorMap,ptin:_ColorMap,varname:node_4428,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f7b18262daa871c4696f84ddfdadc783,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5254,x:33232,y:32611,varname:node_5254,prsc:2|A-4721-OUT,B-2799-OUT;n:type:ShaderForge.SFN_Multiply,id:1961,x:33101,y:32426,varname:node_1961,prsc:2|A-6277-OUT,B-9928-RGB;n:type:ShaderForge.SFN_ValueProperty,id:6277,x:32891,y:32426,ptovrint:False,ptlb:ColorMapValue,ptin:_ColorMapValue,varname:node_6277,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Clamp01,id:1098,x:33439,y:32611,varname:node_1098,prsc:2|IN-4270-OUT;n:type:ShaderForge.SFN_Clamp01,id:4721,x:33319,y:32376,varname:node_4721,prsc:2|IN-1961-OUT;n:type:ShaderForge.SFN_Lerp,id:4270,x:32898,y:32174,varname:node_4270,prsc:2|A-2799-OUT,B-4721-OUT,T-1028-OUT;n:type:ShaderForge.SFN_Multiply,id:8869,x:32393,y:32415,varname:node_8869,prsc:2|A-7448-RGB,B-3250-OUT,C-5988-RGB;n:type:ShaderForge.SFN_ValueProperty,id:6875,x:32429,y:32595,ptovrint:False,ptlb:BW-Colors_Power,ptin:_BWColors_Power,varname:node_6875,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Power,id:1028,x:32553,y:32368,varname:node_1028,prsc:2|VAL-8869-OUT,EXP-6875-OUT;n:type:ShaderForge.SFN_Tex2d,id:5988,x:32166,y:31945,varname:node_5988,prsc:2,tex:066d85a7490b40246879928a8e4bdb53,ntxv:0,isnm:False|UVIN-2457-UVOUT,TEX-8427-TEX;n:type:ShaderForge.SFN_TexCoord,id:8381,x:31771,y:31923,varname:node_8381,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:3762,x:33242,y:32041,varname:node_3762,prsc:2|A-9905-OUT,B-1098-OUT;n:type:ShaderForge.SFN_Panner,id:2457,x:31980,y:31872,varname:node_2457,prsc:2,spu:0.1,spv:0.1|UVIN-8381-UVOUT;n:type:ShaderForge.SFN_Add,id:9905,x:32462,y:31993,varname:node_9905,prsc:2|A-5988-RGB,B-536-OUT;n:type:ShaderForge.SFN_Add,id:2785,x:32150,y:32501,varname:node_2785,prsc:2|A-6831-RGB,B-4803-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4803,x:32092,y:32708,ptovrint:False,ptlb:HalfTone_Add,ptin:_HalfTone_Add,varname:node_4803,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Clamp01,id:3250,x:32292,y:32638,varname:node_3250,prsc:2|IN-2785-OUT;n:type:ShaderForge.SFN_Lerp,id:8337,x:33812,y:32351,varname:node_8337,prsc:2|A-9928-RGB,B-3762-OUT,T-3293-OUT;n:type:ShaderForge.SFN_OneMinus,id:3293,x:33812,y:32476,varname:node_3293,prsc:2|IN-6831-RGB;proporder:9009-159-8427-8220-5258-536-4428-6277-6875-4803;pass:END;sub:END;*/

Shader "Custom/Character_Cartoon_v2" {
    Properties {
        _Ramp ("Ramp", 2D) = "white" {}
        _HalftoneTexture ("HalftoneTexture", 2D) = "white" {}
        _DrawingTexture ("DrawingTexture", 2D) = "white" {}
        _OutlineWidth ("OutlineWidth", Float ) = 0.032
        _BW_Value ("BW_Value", Float ) = 3
        _DrawingAdd ("DrawingAdd", Float ) = 0.8
        _ColorMap ("ColorMap", 2D) = "white" {}
        _ColorMapValue ("ColorMapValue", Float ) = 2
        _BWColors_Power ("BW-Colors_Power", Float ) = 2
        _HalfTone_Add ("HalfTone_Add", Float ) = 0.5
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _OutlineWidth;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_FOG_COORDS(0)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos(float4(v.vertex.xyz + normalize(v.vertex)*_OutlineWidth,1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                return fixed4(float3(0,0,0),0);
            }
            ENDCG
        }
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
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform sampler2D _HalftoneTexture; uniform float4 _HalftoneTexture_ST;
            uniform sampler2D _DrawingTexture; uniform float4 _DrawingTexture_ST;
            uniform float _BW_Value;
            uniform float _DrawingAdd;
            uniform sampler2D _ColorMap; uniform float4 _ColorMap_ST;
            uniform float _ColorMapValue;
            uniform float _BWColors_Power;
            uniform float _HalfTone_Add;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 screenPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 node_8755 = _Time + _TimeEditor;
                float2 node_2457 = (i.uv0+node_8755.g*float2(0.1,0.1));
                float4 node_5988 = tex2D(_DrawingTexture,TRANSFORM_TEX(node_2457, _DrawingTexture));
                float4 node_7448 = tex2D(_DrawingTexture,TRANSFORM_TEX(float2(i.screenPos.x*(_ScreenParams.r/_ScreenParams.g), i.screenPos.y).rg, _DrawingTexture));
                float4 node_6831 = tex2D(_HalftoneTexture,TRANSFORM_TEX(float2(i.screenPos.x*(_ScreenParams.r/_ScreenParams.g), i.screenPos.y).rg, _HalftoneTexture));
                float3 node_3250 = saturate((node_6831.rgb+_HalfTone_Add));
                float node_3018 = (0.5*dot(normalDirection,lightDirection)+0.5*attenuation);
                float2 node_466 = float2(node_3018,node_3018);
                float4 node_4848 = tex2D(_Ramp,TRANSFORM_TEX(node_466, _Ramp));
                float3 node_2799 = (((node_7448.rgb+_DrawingAdd)*(node_3250*(node_4848.rgb*_LightColor0.rgb)))*_BW_Value);
                float4 node_9928 = tex2D(_ColorMap,TRANSFORM_TEX(i.uv0, _ColorMap));
                float3 node_4721 = saturate((_ColorMapValue*node_9928.rgb));
                float3 node_3762 = ((node_5988.rgb+_DrawingAdd)*saturate(lerp(node_2799,node_4721,pow((node_7448.rgb*node_3250*node_5988.rgb),_BWColors_Power))));
                float3 finalColor = node_3762;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform sampler2D _HalftoneTexture; uniform float4 _HalftoneTexture_ST;
            uniform sampler2D _DrawingTexture; uniform float4 _DrawingTexture_ST;
            uniform float _BW_Value;
            uniform float _DrawingAdd;
            uniform sampler2D _ColorMap; uniform float4 _ColorMap_ST;
            uniform float _ColorMapValue;
            uniform float _BWColors_Power;
            uniform float _HalfTone_Add;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 screenPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 node_1812 = _Time + _TimeEditor;
                float2 node_2457 = (i.uv0+node_1812.g*float2(0.1,0.1));
                float4 node_5988 = tex2D(_DrawingTexture,TRANSFORM_TEX(node_2457, _DrawingTexture));
                float4 node_7448 = tex2D(_DrawingTexture,TRANSFORM_TEX(float2(i.screenPos.x*(_ScreenParams.r/_ScreenParams.g), i.screenPos.y).rg, _DrawingTexture));
                float4 node_6831 = tex2D(_HalftoneTexture,TRANSFORM_TEX(float2(i.screenPos.x*(_ScreenParams.r/_ScreenParams.g), i.screenPos.y).rg, _HalftoneTexture));
                float3 node_3250 = saturate((node_6831.rgb+_HalfTone_Add));
                float node_3018 = (0.5*dot(normalDirection,lightDirection)+0.5*attenuation);
                float2 node_466 = float2(node_3018,node_3018);
                float4 node_4848 = tex2D(_Ramp,TRANSFORM_TEX(node_466, _Ramp));
                float3 node_2799 = (((node_7448.rgb+_DrawingAdd)*(node_3250*(node_4848.rgb*_LightColor0.rgb)))*_BW_Value);
                float4 node_9928 = tex2D(_ColorMap,TRANSFORM_TEX(i.uv0, _ColorMap));
                float3 node_4721 = saturate((_ColorMapValue*node_9928.rgb));
                float3 node_3762 = ((node_5988.rgb+_DrawingAdd)*saturate(lerp(node_2799,node_4721,pow((node_7448.rgb*node_3250*node_5988.rgb),_BWColors_Power))));
                float3 finalColor = node_3762;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
