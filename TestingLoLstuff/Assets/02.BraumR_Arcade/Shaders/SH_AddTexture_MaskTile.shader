// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:45,x:34231,y:32466,varname:node_45,prsc:2|emission-4940-OUT;n:type:ShaderForge.SFN_Tex2d,id:8369,x:32174,y:32663,varname:node_8369,prsc:2,tex:3ef1fbbc90b062c41bca10ede1df9e5e,ntxv:0,isnm:False|TEX-6285-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6285,x:31984,y:32663,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_6285,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3ef1fbbc90b062c41bca10ede1df9e5e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1494,x:32403,y:32663,varname:node_1494,prsc:2|A-8369-RGB,B-6410-A,C-6410-RGB;n:type:ShaderForge.SFN_VertexColor,id:6410,x:31984,y:32835,varname:node_6410,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5614,x:32793,y:32695,varname:node_5614,prsc:2|A-1494-OUT,B-4776-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4776,x:32584,y:32793,ptovrint:False,ptlb:Glow,ptin:_Glow,varname:node_4776,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:2284,x:33008,y:32677,varname:node_2284,prsc:2|A-5614-OUT,B-5225-OUT;n:type:ShaderForge.SFN_DepthBlend,id:5225,x:32700,y:32888,varname:node_5225,prsc:2|DIST-3936-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3936,x:32423,y:32929,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_3936,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.25;n:type:ShaderForge.SFN_Multiply,id:1194,x:33351,y:32693,varname:node_1194,prsc:2|A-2284-OUT,B-6665-RGB,C-6665-A;n:type:ShaderForge.SFN_Color,id:6665,x:33056,y:32908,ptovrint:False,ptlb:ColorMain,ptin:_ColorMain,varname:node_6665,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:4940,x:33910,y:32583,varname:node_4940,prsc:2|A-3575-RGB,B-9442-OUT;n:type:ShaderForge.SFN_Tex2d,id:3575,x:33002,y:32124,varname:node_3575,prsc:2,tex:3d7b793b9e014aa418abcd193725fda0,ntxv:0,isnm:False|UVIN-7531-OUT,TEX-1656-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:1656,x:32753,y:32072,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_1656,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3d7b793b9e014aa418abcd193725fda0,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:3909,x:32288,y:32279,varname:node_3909,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:5964,x:32612,y:32332,varname:node_5964,prsc:2|A-3909-V,B-8573-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8499,x:32288,y:32214,ptovrint:False,ptlb:U_Offset,ptin:_U_Offset,varname:node_8499,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:1331,x:32288,y:32444,ptovrint:False,ptlb:V_Offset,ptin:_V_Offset,varname:node_1331,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:7153,x:32559,y:32167,varname:node_7153,prsc:2|A-8499-OUT,B-3909-U;n:type:ShaderForge.SFN_Append,id:7531,x:32753,y:32239,varname:node_7531,prsc:2|A-7153-OUT,B-5964-OUT;n:type:ShaderForge.SFN_RemapRange,id:8573,x:32459,y:32444,varname:node_8573,prsc:2,frmn:1,frmx:0,tomn:-2,tomx:1.5|IN-6410-A;n:type:ShaderForge.SFN_Multiply,id:157,x:32462,y:33207,varname:node_157,prsc:2|A-8369-A,B-765-RGB;n:type:ShaderForge.SFN_Tex2d,id:765,x:32150,y:33212,varname:node_765,prsc:2,tex:3b2a5bf4dbfab1c44beeeee137daf605,ntxv:0,isnm:False|UVIN-509-OUT,TEX-9692-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:9692,x:31962,y:33212,ptovrint:False,ptlb:Mask2,ptin:_Mask2,varname:node_9692,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3b2a5bf4dbfab1c44beeeee137daf605,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:8168,x:31569,y:32853,varname:node_8168,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:3521,x:31152,y:33025,ptovrint:False,ptlb:U_Speed,ptin:_U_Speed,varname:node_3521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.25;n:type:ShaderForge.SFN_ValueProperty,id:2119,x:31152,y:33119,ptovrint:False,ptlb:V_Speed,ptin:_V_Speed,varname:node_2119,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;n:type:ShaderForge.SFN_Append,id:4476,x:31335,y:33055,varname:node_4476,prsc:2|A-3521-OUT,B-2119-OUT;n:type:ShaderForge.SFN_Time,id:1010,x:31323,y:33220,varname:node_1010,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6270,x:31502,y:33055,varname:node_6270,prsc:2|A-4476-OUT,B-1010-T;n:type:ShaderForge.SFN_Add,id:509,x:31726,y:33003,varname:node_509,prsc:2|A-8168-UVOUT,B-6270-OUT;n:type:ShaderForge.SFN_Add,id:9442,x:33586,y:33089,varname:node_9442,prsc:2|A-1194-OUT,B-5215-OUT;n:type:ShaderForge.SFN_Multiply,id:5215,x:33193,y:33242,varname:node_5215,prsc:2|A-157-OUT,B-8335-RGB,C-8335-A,D-6410-A;n:type:ShaderForge.SFN_Color,id:8335,x:32664,y:33380,ptovrint:False,ptlb:Color_Mask,ptin:_Color_Mask,varname:node_8335,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9058823,c2:0.5735294,c3:1,c4:1;proporder:6285-4776-3936-6665-1656-8499-1331-9692-3521-2119-8335;pass:END;sub:END;*/

Shader "Unlit/BraumR_Area" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _Glow ("Glow", Float ) = 1.5
        _Depth ("Depth", Float ) = 0.25
        _ColorMain ("ColorMain", Color) = (1,1,1,1)
        _Mask ("Mask", 2D) = "white" {}
        _U_Offset ("U_Offset", Float ) = 0
        _V_Offset ("V_Offset", Float ) = 0
        _Mask2 ("Mask2", 2D) = "white" {}
        _U_Speed ("U_Speed", Float ) = 0.25
        _V_Speed ("V_Speed", Float ) = 1.5
        _Color_Mask ("Color_Mask", Color) = (0.9058823,0.5735294,1,1)
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 100
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
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
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float _Glow;
            uniform float _Depth;
            uniform float4 _ColorMain;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _U_Offset;
            uniform sampler2D _Mask2; uniform float4 _Mask2_ST;
            uniform float _U_Speed;
            uniform float _V_Speed;
            uniform float4 _Color_Mask;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float2 node_7531 = float2((_U_Offset+i.uv0.r),(i.uv0.g+(i.vertexColor.a*-3.5+1.5)));
                float4 node_3575 = tex2D(_Mask,TRANSFORM_TEX(node_7531, _Mask));
                float4 node_8369 = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float4 node_1010 = _Time + _TimeEditor;
                float2 node_509 = (i.uv0+(float2(_U_Speed,_V_Speed)*node_1010.g));
                float4 node_765 = tex2D(_Mask2,TRANSFORM_TEX(node_509, _Mask2));
                float3 emissive = (node_3575.rgb*(((((node_8369.rgb*i.vertexColor.a*i.vertexColor.rgb)*_Glow)*saturate((sceneZ-partZ)/_Depth))*_ColorMain.rgb*_ColorMain.a)+((node_8369.a*node_765.rgb)*_Color_Mask.rgb*_Color_Mask.a*i.vertexColor.a)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
