// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1815,x:33883,y:32671,varname:node_1815,prsc:2|diff-9240-RGB,spec-5735-OUT,emission-868-OUT,alpha-7764-OUT;n:type:ShaderForge.SFN_Tex2d,id:9240,x:32275,y:32611,varname:node_9240,prsc:2,tex:a3022d87a9643b24899257f48f2b37cb,ntxv:0,isnm:False|UVIN-3353-UVOUT,TEX-9732-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:9732,x:32100,y:32611,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_9732,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a3022d87a9643b24899257f48f2b37cb,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:5735,x:32100,y:32801,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_5735,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_DepthBlend,id:9390,x:33234,y:33038,varname:node_9390,prsc:2|DIST-3721-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3721,x:33068,y:33038,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_3721,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_TexCoord,id:3353,x:31967,y:32618,varname:node_3353,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:5070,x:32480,y:32801,varname:node_5070,prsc:2,tex:e5f691e14634e0b4e86de2c29cbc76c4,ntxv:0,isnm:False|TEX-7734-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:7734,x:32318,y:32801,ptovrint:False,ptlb:EmissiveTexture,ptin:_EmissiveTexture,varname:node_7734,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e5f691e14634e0b4e86de2c29cbc76c4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:868,x:32948,y:32846,varname:node_868,prsc:2|A-9347-OUT,B-5292-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5292,x:32507,y:33070,ptovrint:False,ptlb:EmissiveValue,ptin:_EmissiveValue,varname:node_5292,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:9347,x:32671,y:32871,varname:node_9347,prsc:2|A-5070-RGB,B-1933-RGB;n:type:ShaderForge.SFN_Color,id:1933,x:32660,y:33112,ptovrint:False,ptlb:EmissiveColor,ptin:_EmissiveColor,varname:node_1933,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.8752537,c2:0.09558821,c3:1,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:9090,x:33171,y:32938,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_9090,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.8;n:type:ShaderForge.SFN_ComponentMask,id:4961,x:33111,y:32685,varname:node_4961,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-868-OUT;n:type:ShaderForge.SFN_Multiply,id:6334,x:33318,y:32707,varname:node_6334,prsc:2|A-4961-OUT,B-9390-OUT;n:type:ShaderForge.SFN_Add,id:5783,x:33487,y:32845,varname:node_5783,prsc:2|A-6334-OUT,B-9390-OUT;n:type:ShaderForge.SFN_Multiply,id:7764,x:33685,y:32818,varname:node_7764,prsc:2|A-5783-OUT,B-9090-OUT;proporder:3721-5735-9732-7734-5292-1933-9090;pass:END;sub:END;*/

Shader "Custom/LambertDepth" {
    Properties {
        _Depth ("Depth", Float ) = 0.5
        _Specular ("Specular", Float ) = 0
        _Diffuse ("Diffuse", 2D) = "white" {}
        _EmissiveTexture ("EmissiveTexture", 2D) = "white" {}
        _EmissiveValue ("EmissiveValue", Float ) = 2
        _EmissiveColor ("EmissiveColor", Color) = (0.8752537,0.09558821,1,1)
        _Opacity ("Opacity", Float ) = 0.8
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
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
            uniform float4 _LightColor0;
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _Specular;
            uniform float _Depth;
            uniform sampler2D _EmissiveTexture; uniform float4 _EmissiveTexture_ST;
            uniform float _EmissiveValue;
            uniform float4 _EmissiveColor;
            uniform float _Opacity;
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
                float4 projPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 node_9240 = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = node_9240.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_5070 = tex2D(_EmissiveTexture,TRANSFORM_TEX(i.uv0, _EmissiveTexture));
                float3 node_868 = ((node_5070.rgb*_EmissiveColor.rgb)*_EmissiveValue);
                float3 emissive = node_868;
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                float node_9390 = saturate((sceneZ-partZ)/_Depth);
                fixed4 finalRGBA = fixed4(finalColor,(((node_868.r*node_9390)+node_9390)*_Opacity));
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _Specular;
            uniform float _Depth;
            uniform sampler2D _EmissiveTexture; uniform float4 _EmissiveTexture_ST;
            uniform float _EmissiveValue;
            uniform float4 _EmissiveColor;
            uniform float _Opacity;
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
                float4 projPos : TEXCOORD3;
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
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 node_9240 = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = node_9240.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                float4 node_5070 = tex2D(_EmissiveTexture,TRANSFORM_TEX(i.uv0, _EmissiveTexture));
                float3 node_868 = ((node_5070.rgb*_EmissiveColor.rgb)*_EmissiveValue);
                float node_9390 = saturate((sceneZ-partZ)/_Depth);
                fixed4 finalRGBA = fixed4(finalColor * (((node_868.r*node_9390)+node_9390)*_Opacity),0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
