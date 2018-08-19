// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:8224,x:34843,y:32510,varname:node_8224,prsc:2|emission-6529-OUT,alpha-1121-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:2711,x:31580,y:32637,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_2711,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4c6db099bf93f7f4ea3841c6e9ae8e32,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:702,x:31918,y:32616,varname:node_702,prsc:2,tex:4c6db099bf93f7f4ea3841c6e9ae8e32,ntxv:0,isnm:False|UVIN-6454-OUT,TEX-2711-TEX;n:type:ShaderForge.SFN_Sin,id:9279,x:32219,y:33069,varname:node_9279,prsc:2|IN-5743-OUT;n:type:ShaderForge.SFN_Time,id:2688,x:31855,y:33069,varname:node_2688,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5743,x:32037,y:33069,varname:node_5743,prsc:2|A-2688-T,B-3929-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3929,x:31855,y:33247,ptovrint:False,ptlb:Speed1,ptin:_Speed1,varname:node_3929,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Add,id:8263,x:32387,y:33069,varname:node_8263,prsc:2|A-9279-OUT,B-1512-OUT;n:type:ShaderForge.SFN_Vector1,id:1945,x:32219,y:33203,varname:node_1945,prsc:2,v1:1.3;n:type:ShaderForge.SFN_Multiply,id:3854,x:32640,y:32618,varname:node_3854,prsc:2|A-7609-OUT,B-9303-OUT,C-1216-RGB,D-7736-OUT;n:type:ShaderForge.SFN_VertexColor,id:1216,x:31995,y:32792,varname:node_1216,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6480,x:32907,y:32798,varname:node_6480,prsc:2|A-7609-OUT,B-7464-OUT,C-1216-A;n:type:ShaderForge.SFN_ValueProperty,id:506,x:31855,y:33331,ptovrint:False,ptlb:Speed2,ptin:_Speed2,varname:node_506,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:9.15;n:type:ShaderForge.SFN_Multiply,id:4623,x:32037,y:33213,varname:node_4623,prsc:2|A-2688-T,B-506-OUT;n:type:ShaderForge.SFN_Sin,id:8233,x:32219,y:33259,varname:node_8233,prsc:2|IN-4623-OUT;n:type:ShaderForge.SFN_Add,id:8332,x:32399,y:33259,varname:node_8332,prsc:2|A-1512-OUT,B-8233-OUT;n:type:ShaderForge.SFN_Multiply,id:9303,x:32567,y:33069,varname:node_9303,prsc:2|A-8263-OUT,B-8332-OUT;n:type:ShaderForge.SFN_Add,id:7464,x:32865,y:33093,varname:node_7464,prsc:2|A-9303-OUT,B-5740-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8903,x:32681,y:33379,ptovrint:False,ptlb:Add,ptin:_Add,varname:node_8903,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.225;n:type:ShaderForge.SFN_Multiply,id:5740,x:32865,y:33249,varname:node_5740,prsc:2|A-7736-OUT,B-8903-OUT;n:type:ShaderForge.SFN_Multiply,id:6872,x:33173,y:32799,varname:node_6872,prsc:2|A-4164-OUT,B-6480-OUT;n:type:ShaderForge.SFN_DepthBlend,id:4164,x:32900,y:32521,varname:node_4164,prsc:2|DIST-237-OUT;n:type:ShaderForge.SFN_ValueProperty,id:237,x:32610,y:32368,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_237,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:1754,x:33173,y:32640,varname:node_1754,prsc:2|A-3854-OUT,B-4164-OUT;n:type:ShaderForge.SFN_Add,id:7736,x:32418,y:32864,varname:node_7736,prsc:2|A-1216-A,B-8903-OUT;n:type:ShaderForge.SFN_Add,id:1512,x:32422,y:33469,varname:node_1512,prsc:2|A-1945-OUT,B-1657-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1657,x:32085,y:33539,ptovrint:False,ptlb:Minimum,ptin:_Minimum,varname:node_1657,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.4;n:type:ShaderForge.SFN_Multiply,id:5471,x:33641,y:32626,varname:node_5471,prsc:2|A-5962-OUT,B-1754-OUT;n:type:ShaderForge.SFN_Tex2d,id:6996,x:33291,y:32443,varname:node_6996,prsc:2,tex:1fd5bc935ab4bec478f424d23dc096ea,ntxv:0,isnm:False|TEX-876-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:876,x:33073,y:32365,ptovrint:False,ptlb:Character Texture,ptin:_CharacterTexture,varname:node_876,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1fd5bc935ab4bec478f424d23dc096ea,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:3793,x:31325,y:32265,ptovrint:False,ptlb:U_Speed_2,ptin:_U_Speed_2,varname:_U_Speed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:3788,x:31325,y:32360,ptovrint:False,ptlb:V_Speed_2,ptin:_V_Speed_2,varname:_V_Speed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.15;n:type:ShaderForge.SFN_Append,id:8838,x:31535,y:32301,varname:node_8838,prsc:2|A-3793-OUT,B-3788-OUT;n:type:ShaderForge.SFN_Multiply,id:5821,x:31706,y:32301,varname:node_5821,prsc:2|A-8838-OUT,B-4043-T;n:type:ShaderForge.SFN_Time,id:4043,x:31535,y:32455,varname:node_4043,prsc:2;n:type:ShaderForge.SFN_Add,id:6454,x:31706,y:32455,varname:node_6454,prsc:2|A-5821-OUT,B-4565-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:6995,x:31127,y:32498,varname:node_6995,prsc:2,uv:0;n:type:ShaderForge.SFN_ScreenPos,id:4565,x:31234,y:32616,varname:node_4565,prsc:2,sctp:0;n:type:ShaderForge.SFN_Multiply,id:5962,x:33545,y:32346,varname:node_5962,prsc:2|A-8932-RGB,B-6996-RGB;n:type:ShaderForge.SFN_Color,id:8932,x:33261,y:32196,ptovrint:False,ptlb:Character Texture Color,ptin:_CharacterTextureColor,varname:node_8932,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:2140,x:33887,y:32619,varname:node_2140,prsc:2|A-5471-OUT,B-3373-RGB;n:type:ShaderForge.SFN_Color,id:3373,x:33639,y:32854,ptovrint:False,ptlb:FinalColor,ptin:_FinalColor,varname:node_3373,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7609,x:32245,y:32384,varname:node_7609,prsc:2|A-5931-OUT,B-702-R;n:type:ShaderForge.SFN_ValueProperty,id:5931,x:32000,y:32352,ptovrint:False,ptlb:HologramTexturePower,ptin:_HologramTexturePower,varname:node_5931,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:7577,x:34261,y:32566,varname:node_7577,prsc:2|A-200-OUT,B-2140-OUT;n:type:ShaderForge.SFN_Fresnel,id:200,x:34013,y:32449,varname:node_200,prsc:2|EXP-861-OUT;n:type:ShaderForge.SFN_ValueProperty,id:861,x:33789,y:32346,ptovrint:False,ptlb:FresnelExponent,ptin:_FresnelExponent,varname:node_861,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Add,id:6529,x:34561,y:32452,varname:node_6529,prsc:2|A-5600-OUT,B-2140-OUT;n:type:ShaderForge.SFN_Multiply,id:6663,x:34208,y:32256,varname:node_6663,prsc:2|A-8250-RGB,B-200-OUT;n:type:ShaderForge.SFN_Color,id:8250,x:33979,y:32112,ptovrint:False,ptlb:FresnelColor,ptin:_FresnelColor,varname:node_8250,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:4230,x:34085,y:32818,varname:node_4230,prsc:2|A-200-OUT,B-6872-OUT;n:type:ShaderForge.SFN_Add,id:1121,x:34280,y:32843,varname:node_1121,prsc:2|A-4230-OUT,B-2074-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2074,x:34035,y:32984,ptovrint:False,ptlb:FresnelOpacityAdd,ptin:_FresnelOpacityAdd,varname:node_2074,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.25;n:type:ShaderForge.SFN_Multiply,id:5600,x:34397,y:32266,varname:node_5600,prsc:2|A-1230-OUT,B-6663-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1230,x:34284,y:32039,ptovrint:False,ptlb:FresnelPower,ptin:_FresnelPower,varname:node_1230,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:3929-2711-506-8903-237-1657-876-3793-3788-8932-3373-5931-861-8250-2074-1230;pass:END;sub:END;*/

Shader "Characters/SH_HologramKarthus" {
    Properties {
        _Speed1 ("Speed1", Float ) = 4
        _Texture ("Texture", 2D) = "white" {}
        _Speed2 ("Speed2", Float ) = 9.15
        _Add ("Add", Float ) = 0.225
        _Depth ("Depth", Float ) = 0.1
        _Minimum ("Minimum", Float ) = 0.4
        _CharacterTexture ("Character Texture", 2D) = "white" {}
        _U_Speed_2 ("U_Speed_2", Float ) = 0.1
        _V_Speed_2 ("V_Speed_2", Float ) = 0.15
        _CharacterTextureColor ("Character Texture Color", Color) = (1,1,1,1)
        _FinalColor ("FinalColor", Color) = (1,1,1,1)
        _HologramTexturePower ("HologramTexturePower", Float ) = 1
        _FresnelExponent ("FresnelExponent", Float ) = 1
        _FresnelColor ("FresnelColor", Color) = (1,1,1,1)
        _FresnelOpacityAdd ("FresnelOpacityAdd", Float ) = 0.25
        _FresnelPower ("FresnelPower", Float ) = 1
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
            Blend One OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _Speed1;
            uniform float _Speed2;
            uniform float _Add;
            uniform float _Depth;
            uniform float _Minimum;
            uniform sampler2D _CharacterTexture; uniform float4 _CharacterTexture_ST;
            uniform float _U_Speed_2;
            uniform float _V_Speed_2;
            uniform float4 _CharacterTextureColor;
            uniform float4 _FinalColor;
            uniform float _HologramTexturePower;
            uniform float _FresnelExponent;
            uniform float4 _FresnelColor;
            uniform float _FresnelOpacityAdd;
            uniform float _FresnelPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 screenPos : TEXCOORD3;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float node_200 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelExponent);
                float4 node_6996 = tex2D(_CharacterTexture,TRANSFORM_TEX(i.uv0, _CharacterTexture));
                float4 node_4043 = _Time + _TimeEditor;
                float2 node_6454 = ((float2(_U_Speed_2,_V_Speed_2)*node_4043.g)+i.screenPos.rg);
                float4 node_702 = tex2D(_Texture,TRANSFORM_TEX(node_6454, _Texture));
                float node_7609 = (_HologramTexturePower*node_702.r);
                float4 node_2688 = _Time + _TimeEditor;
                float node_1512 = (1.3+_Minimum);
                float node_9303 = ((sin((node_2688.g*_Speed1))+node_1512)*(node_1512+sin((node_2688.g*_Speed2))));
                float node_7736 = (i.vertexColor.a+_Add);
                float node_4164 = saturate((sceneZ-partZ)/_Depth);
                float3 node_2140 = (((_CharacterTextureColor.rgb*node_6996.rgb)*((node_7609*node_9303*i.vertexColor.rgb*node_7736)*node_4164))*_FinalColor.rgb);
                float3 emissive = ((_FresnelPower*(_FresnelColor.rgb*node_200))+node_2140);
                float3 finalColor = emissive;
                return fixed4(finalColor,((node_200*(node_4164*(node_7609*(node_9303+(node_7736*_Add))*i.vertexColor.a)))+_FresnelOpacityAdd));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
