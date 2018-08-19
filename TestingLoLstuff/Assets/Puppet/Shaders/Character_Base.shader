// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1638,x:34716,y:32544,varname:node_1638,prsc:2|diff-3529-OUT,spec-9175-OUT,gloss-9576-OUT,emission-5816-OUT,olwid-5218-OUT;n:type:ShaderForge.SFN_Tex2d,id:7877,x:32120,y:32685,varname:node_7877,prsc:2,tex:5a6ab38476c407c45818aa3952457744,ntxv:0,isnm:False|TEX-8734-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:8734,x:31899,y:32685,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_8734,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5a6ab38476c407c45818aa3952457744,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7814,x:32450,y:32768,varname:node_7814,prsc:2|A-7877-RGB,B-1777-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1777,x:32234,y:32867,ptovrint:False,ptlb:EmissivePower,ptin:_EmissivePower,varname:node_1777,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Add,id:9401,x:32733,y:32813,varname:node_9401,prsc:2|A-7814-OUT,B-9243-OUT;n:type:ShaderForge.SFN_Color,id:7975,x:32246,y:33050,ptovrint:False,ptlb:HitColor,ptin:_HitColor,varname:node_7975,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:3540,x:32246,y:33239,ptovrint:False,ptlb:HitPower,ptin:_HitPower,varname:node_3540,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:9243,x:32516,y:33043,varname:node_9243,prsc:2|A-7975-RGB,B-3540-OUT;n:type:ShaderForge.SFN_Multiply,id:3529,x:32713,y:32544,varname:node_3529,prsc:2|A-9972-OUT,B-7877-RGB;n:type:ShaderForge.SFN_ValueProperty,id:9972,x:32397,y:32536,ptovrint:False,ptlb:DiffusePower,ptin:_DiffusePower,varname:node_9972,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Add,id:4995,x:33276,y:33196,varname:node_4995,prsc:2|A-9264-OUT,B-904-RGB;n:type:ShaderForge.SFN_Tex2d,id:904,x:32817,y:33022,varname:node_904,prsc:2,ntxv:0,isnm:False|TEX-7855-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:7855,x:32653,y:32995,ptovrint:False,ptlb:EmissiveTexture,ptin:_EmissiveTexture,varname:node_7855,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_SwitchProperty,id:6001,x:33063,y:32767,ptovrint:False,ptlb:HasEmissiveTexture?,ptin:_HasEmissiveTexture,varname:node_6001,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-9401-OUT,B-9264-OUT;n:type:ShaderForge.SFN_Multiply,id:9264,x:33094,y:33196,varname:node_9264,prsc:2|A-904-RGB,B-1855-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1855,x:32832,y:33280,ptovrint:False,ptlb:EmissiveTextureValue,ptin:_EmissiveTextureValue,varname:node_1855,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:4944,x:33454,y:33196,varname:node_4944,prsc:2|A-4995-OUT,B-6391-RGB;n:type:ShaderForge.SFN_Tex2d,id:6391,x:32969,y:33368,varname:node_6391,prsc:2,tex:832d9632ca6c98440afb3695dbe1d34c,ntxv:0,isnm:False|UVIN-4797-OUT,TEX-4563-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:4563,x:32808,y:33368,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_4563,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:832d9632ca6c98440afb3695dbe1d34c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:9975,x:32105,y:33351,ptovrint:False,ptlb:U_Speed,ptin:_U_Speed,varname:node_8820,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:3785,x:32105,y:33446,ptovrint:False,ptlb:V_Speed,ptin:_V_Speed,varname:node_3475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.15;n:type:ShaderForge.SFN_Append,id:8241,x:32315,y:33387,varname:node_8241,prsc:2|A-9975-OUT,B-3785-OUT;n:type:ShaderForge.SFN_Multiply,id:8117,x:32486,y:33387,varname:node_8117,prsc:2|A-8241-OUT,B-465-T;n:type:ShaderForge.SFN_Time,id:465,x:32315,y:33541,varname:node_465,prsc:2;n:type:ShaderForge.SFN_Add,id:4797,x:32486,y:33541,varname:node_4797,prsc:2|A-8117-OUT,B-7938-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:7938,x:32315,y:33682,varname:node_7938,prsc:2,uv:0;n:type:ShaderForge.SFN_SwitchProperty,id:5311,x:33370,y:32810,ptovrint:False,ptlb:HasNoise?,ptin:_HasNoise,varname:node_5311,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-6001-OUT,B-4944-OUT;n:type:ShaderForge.SFN_Multiply,id:5816,x:33734,y:32752,varname:node_5816,prsc:2|A-5311-OUT,B-1022-RGB;n:type:ShaderForge.SFN_Color,id:1022,x:33533,y:32885,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1022,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_SwitchProperty,id:792,x:34068,y:32390,ptovrint:False,ptlb:HasSpecMap?,ptin:_HasSpecMap,varname:node_792,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-5122-OUT,B-2477-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5122,x:33638,y:32396,ptovrint:False,ptlb:SpecValue,ptin:_SpecValue,varname:node_5122,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:3055,x:33466,y:32476,varname:node_3055,prsc:2,tex:12820bd2edc166e469562a6433e4f00e,ntxv:0,isnm:False|TEX-2603-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:2603,x:33237,y:32422,ptovrint:False,ptlb:SpecularMap,ptin:_SpecularMap,varname:node_2603,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:12820bd2edc166e469562a6433e4f00e,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2477,x:33854,y:32480,varname:node_2477,prsc:2|A-3055-RGB,B-9973-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9973,x:33663,y:32634,ptovrint:False,ptlb:SpecMapPower,ptin:_SpecMapPower,varname:node_9973,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_ValueProperty,id:4422,x:34335,y:32334,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_4422,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ComponentMask,id:9175,x:34237,y:32390,varname:node_9175,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-792-OUT;n:type:ShaderForge.SFN_Multiply,id:9576,x:34430,y:32514,varname:node_9576,prsc:2|A-4422-OUT,B-9175-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5218,x:34300,y:32876,ptovrint:False,ptlb:OutlineWidth,ptin:_OutlineWidth,varname:node_5218,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.01;proporder:8734-1777-7975-3540-9972-6001-7855-1855-4563-9975-3785-5311-1022-5122-792-2603-9973-4422-5218;pass:END;sub:END;*/

Shader "Custom/Character_Base" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _EmissivePower ("EmissivePower", Float ) = 0.2
        _HitColor ("HitColor", Color) = (1,1,1,1)
        _HitPower ("HitPower", Float ) = 0
        _DiffusePower ("DiffusePower", Float ) = 2
        [MaterialToggle] _HasEmissiveTexture ("HasEmissiveTexture?", Float ) = 0
        _EmissiveTexture ("EmissiveTexture", 2D) = "white" {}
        _EmissiveTextureValue ("EmissiveTextureValue", Float ) = 0.5
        _Noise ("Noise", 2D) = "white" {}
        _U_Speed ("U_Speed", Float ) = 0.1
        _V_Speed ("V_Speed", Float ) = 0.15
        [MaterialToggle] _HasNoise ("HasNoise?", Float ) = 0
        _Color ("Color", Color) = (1,1,1,1)
        _SpecValue ("SpecValue", Float ) = 0
        [MaterialToggle] _HasSpecMap ("HasSpecMap?", Float ) = 0
        _SpecularMap ("SpecularMap", 2D) = "black" {}
        _SpecMapPower ("SpecMapPower", Float ) = 3
        _Gloss ("Gloss", Float ) = 1
        _OutlineWidth ("OutlineWidth", Float ) = 0.01
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
                o.pos = UnityObjectToClipPos(float4(v.vertex.xyz + v.normal*_OutlineWidth,1) );
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float _EmissivePower;
            uniform float4 _HitColor;
            uniform float _HitPower;
            uniform float _DiffusePower;
            uniform sampler2D _EmissiveTexture; uniform float4 _EmissiveTexture_ST;
            uniform fixed _HasEmissiveTexture;
            uniform float _EmissiveTextureValue;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _U_Speed;
            uniform float _V_Speed;
            uniform fixed _HasNoise;
            uniform float4 _Color;
            uniform fixed _HasSpecMap;
            uniform float _SpecValue;
            uniform sampler2D _SpecularMap; uniform float4 _SpecularMap_ST;
            uniform float _SpecMapPower;
            uniform float _Gloss;
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
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float4 node_3055 = tex2D(_SpecularMap,TRANSFORM_TEX(i.uv0, _SpecularMap));
                float node_9175 = lerp( _SpecValue, (node_3055.rgb*_SpecMapPower), _HasSpecMap ).r;
                float gloss = (_Gloss*node_9175);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(node_9175,node_9175,node_9175);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 node_7877 = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float3 diffuseColor = (_DiffusePower*node_7877.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_904 = tex2D(_EmissiveTexture,TRANSFORM_TEX(i.uv0, _EmissiveTexture));
                float3 node_9264 = (node_904.rgb*_EmissiveTextureValue);
                float4 node_465 = _Time + _TimeEditor;
                float2 node_4797 = ((float2(_U_Speed,_V_Speed)*node_465.g)+i.uv0);
                float4 node_6391 = tex2D(_Noise,TRANSFORM_TEX(node_4797, _Noise));
                float3 emissive = (lerp( lerp( ((node_7877.rgb*_EmissivePower)+(_HitColor.rgb*_HitPower)), node_9264, _HasEmissiveTexture ), ((node_9264+node_904.rgb)*node_6391.rgb), _HasNoise )*_Color.rgb);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float _EmissivePower;
            uniform float4 _HitColor;
            uniform float _HitPower;
            uniform float _DiffusePower;
            uniform sampler2D _EmissiveTexture; uniform float4 _EmissiveTexture_ST;
            uniform fixed _HasEmissiveTexture;
            uniform float _EmissiveTextureValue;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _U_Speed;
            uniform float _V_Speed;
            uniform fixed _HasNoise;
            uniform float4 _Color;
            uniform fixed _HasSpecMap;
            uniform float _SpecValue;
            uniform sampler2D _SpecularMap; uniform float4 _SpecularMap_ST;
            uniform float _SpecMapPower;
            uniform float _Gloss;
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
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float4 node_3055 = tex2D(_SpecularMap,TRANSFORM_TEX(i.uv0, _SpecularMap));
                float node_9175 = lerp( _SpecValue, (node_3055.rgb*_SpecMapPower), _HasSpecMap ).r;
                float gloss = (_Gloss*node_9175);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(node_9175,node_9175,node_9175);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 node_7877 = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float3 diffuseColor = (_DiffusePower*node_7877.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
