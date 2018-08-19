// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:Particles/Additive,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:5303,x:33723,y:32711,varname:node_5303,prsc:2|emission-4412-OUT;n:type:ShaderForge.SFN_Tex2d,id:6403,x:32244,y:32687,varname:node_6403,prsc:2,ntxv:0,isnm:False|UVIN-302-UVOUT,TEX-778-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:778,x:32077,y:32687,ptovrint:False,ptlb:ParallaxTexture,ptin:_ParallaxTexture,varname:node_778,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:9894,x:32077,y:32919,ptovrint:False,ptlb:MaskTexture,ptin:_MaskTexture,varname:node_9894,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:143,x:32244,y:32919,varname:node_143,prsc:2,ntxv:0,isnm:False|UVIN-114-UVOUT,TEX-9894-TEX;n:type:ShaderForge.SFN_Multiply,id:9675,x:32493,y:32751,varname:node_9675,prsc:2|A-6403-RGB,B-143-RGB;n:type:ShaderForge.SFN_Parallax,id:302,x:32077,y:32541,varname:node_302,prsc:2|UVIN-4628-OUT,HEI-2604-OUT;n:type:ShaderForge.SFN_TexCoord,id:114,x:32077,y:33078,varname:node_114,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:2604,x:31834,y:32624,ptovrint:False,ptlb:MainHeight,ptin:_MainHeight,varname:node_2604,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:8820,x:31380,y:32126,ptovrint:False,ptlb:U_Speed,ptin:_U_Speed,varname:node_8820,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:3475,x:31380,y:32221,ptovrint:False,ptlb:V_Speed,ptin:_V_Speed,varname:node_3475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.15;n:type:ShaderForge.SFN_Append,id:3063,x:31590,y:32162,varname:node_3063,prsc:2|A-8820-OUT,B-3475-OUT;n:type:ShaderForge.SFN_Multiply,id:4860,x:31761,y:32162,varname:node_4860,prsc:2|A-3063-OUT,B-5214-T;n:type:ShaderForge.SFN_Time,id:5214,x:31590,y:32316,varname:node_5214,prsc:2;n:type:ShaderForge.SFN_Add,id:4628,x:31761,y:32316,varname:node_4628,prsc:2|A-4860-OUT,B-114-UVOUT;n:type:ShaderForge.SFN_Add,id:4020,x:33059,y:34154,varname:node_4020,prsc:2|A-1169-R,B-1169-G,C-1169-B;n:type:ShaderForge.SFN_ComponentMask,id:1169,x:33059,y:33995,varname:node_1169,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-3327-OUT;n:type:ShaderForge.SFN_Multiply,id:7732,x:31575,y:33948,varname:node_7732,prsc:2|A-6403-RGB,B-3988-A,C-3988-RGB;n:type:ShaderForge.SFN_VertexColor,id:3988,x:31156,y:34120,varname:node_3988,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9384,x:31965,y:33980,varname:node_9384,prsc:2|A-7732-OUT,B-1537-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1537,x:31759,y:34069,ptovrint:False,ptlb:Glow,ptin:_Glow,varname:node_4776,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:3854,x:32181,y:33962,varname:node_3854,prsc:2|A-9384-OUT,B-5337-OUT;n:type:ShaderForge.SFN_DepthBlend,id:5337,x:31810,y:34167,varname:node_5337,prsc:2|DIST-5149-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5149,x:31595,y:34214,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_3936,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.25;n:type:ShaderForge.SFN_Add,id:6529,x:31142,y:34766,varname:node_6529,prsc:2|A-9672-OUT,B-5982-R;n:type:ShaderForge.SFN_RemapRange,id:9672,x:30819,y:34648,varname:node_9672,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-3988-A;n:type:ShaderForge.SFN_ValueProperty,id:6555,x:31690,y:34694,ptovrint:False,ptlb:DissolvePower,ptin:_DissolvePower,varname:node_6426,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Power,id:1462,x:31872,y:34371,varname:node_1462,prsc:2|VAL-6529-OUT,EXP-6555-OUT;n:type:ShaderForge.SFN_Multiply,id:8818,x:32101,y:34268,varname:node_8818,prsc:2|A-3854-OUT,B-1462-OUT;n:type:ShaderForge.SFN_Multiply,id:3327,x:32685,y:34014,varname:node_3327,prsc:2|A-8818-OUT,B-9882-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9882,x:32517,y:34086,ptovrint:False,ptlb:FinalOpacity,ptin:_FinalOpacity,varname:node_196,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:4953,x:32832,y:33105,varname:node_4953,prsc:2|A-143-R,B-4020-OUT;n:type:ShaderForge.SFN_Tex2d,id:5982,x:30354,y:34559,varname:node_5982,prsc:2,ntxv:0,isnm:False|TEX-727-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:727,x:30161,y:34559,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_727,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Parallax,id:9777,x:32335,y:32534,varname:node_9777,prsc:2|UVIN-850-OUT,HEI-9842-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9842,x:32335,y:32473,ptovrint:False,ptlb:SecondaryHeight,ptin:_SecondaryHeight,varname:node_9842,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-3;n:type:ShaderForge.SFN_Tex2d,id:5523,x:32680,y:32367,varname:node_5523,prsc:2,ntxv:0,isnm:False|UVIN-9777-UVOUT,TEX-5358-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:5358,x:32519,y:32367,ptovrint:False,ptlb:SecondaryParallaxTexture,ptin:_SecondaryParallaxTexture,varname:node_5358,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:6273,x:32997,y:32637,varname:node_6273,prsc:2|A-8139-OUT,B-9675-OUT;n:type:ShaderForge.SFN_ValueProperty,id:362,x:31852,y:31903,ptovrint:False,ptlb:U_Speed_2,ptin:_U_Speed_2,varname:_U_Speed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:1023,x:31852,y:31998,ptovrint:False,ptlb:V_Speed_2,ptin:_V_Speed_2,varname:_V_Speed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.15;n:type:ShaderForge.SFN_Append,id:9610,x:32062,y:31939,varname:node_9610,prsc:2|A-362-OUT,B-1023-OUT;n:type:ShaderForge.SFN_Multiply,id:2312,x:32233,y:31939,varname:node_2312,prsc:2|A-9610-OUT,B-3039-T;n:type:ShaderForge.SFN_Time,id:3039,x:32062,y:32093,varname:node_3039,prsc:2;n:type:ShaderForge.SFN_Add,id:850,x:32233,y:32093,varname:node_850,prsc:2|A-2312-OUT,B-114-UVOUT;n:type:ShaderForge.SFN_Multiply,id:8139,x:32812,y:32500,varname:node_8139,prsc:2|A-5523-RGB,B-6533-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6533,x:32812,y:32845,ptovrint:False,ptlb:SecondaryTextureIntensity,ptin:_SecondaryTextureIntensity,varname:node_6533,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.7;n:type:ShaderForge.SFN_Multiply,id:4412,x:33242,y:32768,varname:node_4412,prsc:2|A-6273-OUT,B-3988-RGB,C-4953-OUT;proporder:778-9894-2604-8820-3475-1537-5149-6555-9882-727-5358-9842-362-1023-6533;pass:END;sub:END;*/

Shader "Custom/ParallaxBackground_Add" {
    Properties {
        _ParallaxTexture ("ParallaxTexture", 2D) = "white" {}
        _MaskTexture ("MaskTexture", 2D) = "white" {}
        _MainHeight ("MainHeight", Float ) = 0.5
        _U_Speed ("U_Speed", Float ) = 0.1
        _V_Speed ("V_Speed", Float ) = 0.15
        _Glow ("Glow", Float ) = 1.5
        _Depth ("Depth", Float ) = 0.25
        _DissolvePower ("DissolvePower", Float ) = 2
        _FinalOpacity ("FinalOpacity", Float ) = 1
        _Noise ("Noise", 2D) = "white" {}
        _SecondaryParallaxTexture ("SecondaryParallaxTexture", 2D) = "white" {}
        _SecondaryHeight ("SecondaryHeight", Float ) = -3
        _U_Speed_2 ("U_Speed_2", Float ) = 0.1
        _V_Speed_2 ("V_Speed_2", Float ) = 0.15
        _SecondaryTextureIntensity ("SecondaryTextureIntensity", Float ) = 0.7
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
            Blend One One
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
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _ParallaxTexture; uniform float4 _ParallaxTexture_ST;
            uniform sampler2D _MaskTexture; uniform float4 _MaskTexture_ST;
            uniform float _MainHeight;
            uniform float _U_Speed;
            uniform float _V_Speed;
            uniform float _Glow;
            uniform float _Depth;
            uniform float _DissolvePower;
            uniform float _FinalOpacity;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _SecondaryHeight;
            uniform sampler2D _SecondaryParallaxTexture; uniform float4 _SecondaryParallaxTexture_ST;
            uniform float _U_Speed_2;
            uniform float _V_Speed_2;
            uniform float _SecondaryTextureIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD5;
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float4 node_3039 = _Time + _TimeEditor;
                float2 node_9777 = (0.05*(_SecondaryHeight - 0.5)*mul(tangentTransform, viewDirection).xy + ((float2(_U_Speed_2,_V_Speed_2)*node_3039.g)+i.uv0));
                float4 node_5523 = tex2D(_SecondaryParallaxTexture,TRANSFORM_TEX(node_9777.rg, _SecondaryParallaxTexture));
                float4 node_5214 = _Time + _TimeEditor;
                float2 node_302 = (0.05*(_MainHeight - 0.5)*mul(tangentTransform, viewDirection).xy + ((float2(_U_Speed,_V_Speed)*node_5214.g)+i.uv0));
                float4 node_6403 = tex2D(_ParallaxTexture,TRANSFORM_TEX(node_302.rg, _ParallaxTexture));
                float4 node_143 = tex2D(_MaskTexture,TRANSFORM_TEX(i.uv0, _MaskTexture));
                float4 node_5982 = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float3 node_1169 = (((((node_6403.rgb*i.vertexColor.a*i.vertexColor.rgb)*_Glow)*saturate((sceneZ-partZ)/_Depth))*pow(((i.vertexColor.a*2.0+-1.0)+node_5982.r),_DissolvePower))*_FinalOpacity).rgb;
                float3 emissive = (((node_5523.rgb*_SecondaryTextureIntensity)+(node_6403.rgb*node_143.rgb))*i.vertexColor.rgb*(node_143.r*(node_1169.r+node_1169.g+node_1169.b)));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Particles/Additive"
    CustomEditor "ShaderForgeMaterialInspector"
}
