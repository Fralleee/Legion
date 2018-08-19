// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5955882,fgcg:0.5955882,fgcb:0.5955882,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4672,x:34398,y:32574,varname:node_4672,prsc:2|diff-1655-OUT,emission-8442-OUT,clip-5306-OUT;n:type:ShaderForge.SFN_RemapRange,id:7889,x:32640,y:32745,varname:node_7889,prsc:2,frmn:0,frmx:0.9,tomn:-1,tomx:1|IN-4430-OUT;n:type:ShaderForge.SFN_Add,id:6754,x:32976,y:32862,varname:node_6754,prsc:2|A-7889-OUT,B-7209-R;n:type:ShaderForge.SFN_Tex2d,id:7209,x:32653,y:32967,varname:node_8959,prsc:2,tex:1f0f3bf8304c4db4faf36d5646db03a2,ntxv:0,isnm:False|TEX-9416-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:9416,x:32453,y:32967,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:_Noise,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1f0f3bf8304c4db4faf36d5646db03a2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Power,id:4746,x:33311,y:32847,varname:node_4746,prsc:2|VAL-894-OUT,EXP-214-OUT;n:type:ShaderForge.SFN_ValueProperty,id:214,x:33118,y:33020,ptovrint:False,ptlb:DissolvePower,ptin:_DissolvePower,varname:_DissolvePower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Slider,id:4430,x:32047,y:32880,ptovrint:False,ptlb:DissolveStep,ptin:_DissolveStep,varname:node_4430,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:0.5;n:type:ShaderForge.SFN_Multiply,id:1655,x:33483,y:32690,varname:node_1655,prsc:2|A-64-RGB,B-5306-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:6923,x:32926,y:32513,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_6923,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ac0d0b6ac33ab6b47ad25a5bed29752a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:64,x:33076,y:32513,varname:node_64,prsc:2,tex:ac0d0b6ac33ab6b47ad25a5bed29752a,ntxv:0,isnm:False|TEX-6923-TEX;n:type:ShaderForge.SFN_Clamp01,id:894,x:33151,y:32847,varname:node_894,prsc:2|IN-6754-OUT;n:type:ShaderForge.SFN_Clamp01,id:5306,x:33483,y:32847,varname:node_5306,prsc:2|IN-4746-OUT;n:type:ShaderForge.SFN_Add,id:1681,x:32186,y:33045,varname:node_1681,prsc:2|A-4430-OUT,B-150-OUT;n:type:ShaderForge.SFN_ValueProperty,id:150,x:31957,y:33136,ptovrint:False,ptlb:GlowWidth,ptin:_GlowWidth,varname:node_150,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.003;n:type:ShaderForge.SFN_RemapRange,id:1399,x:32664,y:33153,varname:node_1399,prsc:2,frmn:0.0015,frmx:0.9,tomn:-1,tomx:1|IN-1681-OUT;n:type:ShaderForge.SFN_Add,id:8912,x:33003,y:33119,varname:node_8912,prsc:2|A-7209-R,B-1399-OUT;n:type:ShaderForge.SFN_Clamp01,id:5081,x:33172,y:33119,varname:node_5081,prsc:2|IN-8912-OUT;n:type:ShaderForge.SFN_Power,id:8350,x:33339,y:33119,varname:node_8350,prsc:2|VAL-5081-OUT,EXP-268-OUT;n:type:ShaderForge.SFN_Clamp01,id:8928,x:33494,y:33119,varname:node_8928,prsc:2|IN-8350-OUT;n:type:ShaderForge.SFN_Subtract,id:2139,x:33683,y:33074,varname:node_2139,prsc:2|A-8928-OUT,B-5306-OUT;n:type:ShaderForge.SFN_Multiply,id:3898,x:33873,y:32909,varname:node_3898,prsc:2|A-163-RGB,B-2139-OUT;n:type:ShaderForge.SFN_Color,id:163,x:33683,y:32909,ptovrint:False,ptlb:GlowColor,ptin:_GlowColor,varname:node_163,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.2689655,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:8442,x:34145,y:32866,varname:node_8442,prsc:2|A-3898-OUT,B-9168-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4613,x:33956,y:33111,ptovrint:False,ptlb:GlowValue,ptin:_GlowValue,varname:node_4613,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Add,id:268,x:32842,y:33349,varname:node_268,prsc:2|A-214-OUT,B-150-OUT;n:type:ShaderForge.SFN_Multiply,id:9168,x:33956,y:33222,varname:node_9168,prsc:2|A-4613-OUT,B-2646-OUT;n:type:ShaderForge.SFN_Vector1,id:2646,x:33956,y:33163,varname:node_2646,prsc:2,v1:100;proporder:9416-214-4430-6923-150-163-4613;pass:END;sub:END;*/

Shader "Custom/DissolveBurnShader_Slider" {
    Properties {
        _Noise ("Noise", 2D) = "white" {}
        _DissolvePower ("DissolvePower", Float ) = 0.2
        _DissolveStep ("DissolveStep", Range(0, 0.5)) = 0.5
        _MainTexture ("MainTexture", 2D) = "white" {}
        _GlowWidth ("GlowWidth", Float ) = 0.003
        _GlowColor ("GlowColor", Color) = (1,0.2689655,0,1)
        _GlowValue ("GlowValue", Float ) = 5
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _DissolvePower;
            uniform float _DissolveStep;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float _GlowWidth;
            uniform float4 _GlowColor;
            uniform float _GlowValue;
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
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 node_8959 = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_4746 = pow(saturate(((_DissolveStep*2.222222+-1.0)+node_8959.r)),_DissolvePower);
                float node_5306 = saturate(node_4746);
                clip(node_5306 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 node_64 = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float3 node_1655 = (node_64.rgb*node_5306);
                float3 diffuseColor = node_1655;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = ((_GlowColor.rgb*(saturate(pow(saturate((node_8959.r+((_DissolveStep+_GlowWidth)*2.225932+-1.003339))),(_DissolvePower+_GlowWidth)))-node_5306))*(_GlowValue*100.0));
/// Final Color:
                float3 finalColor = diffuse + emissive;
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
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _DissolvePower;
            uniform float _DissolveStep;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float _GlowWidth;
            uniform float4 _GlowColor;
            uniform float _GlowValue;
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
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 node_8959 = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_4746 = pow(saturate(((_DissolveStep*2.222222+-1.0)+node_8959.r)),_DissolvePower);
                float node_5306 = saturate(node_4746);
                clip(node_5306 - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 node_64 = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float3 node_1655 = (node_64.rgb*node_5306);
                float3 diffuseColor = node_1655;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
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
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _DissolvePower;
            uniform float _DissolveStep;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 node_8959 = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_4746 = pow(saturate(((_DissolveStep*2.222222+-1.0)+node_8959.r)),_DissolvePower);
                float node_5306 = saturate(node_4746);
                clip(node_5306 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
