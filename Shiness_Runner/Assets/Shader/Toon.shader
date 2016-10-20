// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:8538,x:32921,y:32917,varname:node_8538,prsc:2|emission-8378-OUT,custl-5866-OUT,clip-9262-A,olwid-4199-OUT,olcol-4233-RGB;n:type:ShaderForge.SFN_Tex2d,id:9262,x:31677,y:32304,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_9262,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:8886,x:31663,y:32701,ptovrint:False,ptlb:Diffuse Color,ptin:_DiffuseColor,varname:node_8886,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7379,x:31834,y:32578,varname:node_7379,prsc:2|A-9262-RGB,B-8886-RGB;n:type:ShaderForge.SFN_Color,id:4233,x:32255,y:33985,ptovrint:False,ptlb:Outline Color,ptin:_OutlineColor,varname:node_4233,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:7165,x:32042,y:33760,ptovrint:False,ptlb:Outline Width,ptin:_OutlineWidth,varname:node_7165,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Multiply,id:4199,x:32372,y:33821,varname:node_4199,prsc:2|A-7165-OUT,B-5356-OUT;n:type:ShaderForge.SFN_Vector1,id:5356,x:32148,y:33865,varname:node_5356,prsc:2,v1:0.01;n:type:ShaderForge.SFN_LightColor,id:1679,x:32306,y:33156,varname:node_1679,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:428,x:32306,y:33000,varname:node_428,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5866,x:32550,y:32972,varname:node_5866,prsc:2|A-8265-OUT,B-428-OUT,C-1679-RGB;n:type:ShaderForge.SFN_LightVector,id:7955,x:30688,y:33000,varname:node_7955,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:3073,x:30688,y:32847,prsc:2,pt:True;n:type:ShaderForge.SFN_AmbientLight,id:4676,x:32210,y:32387,varname:node_4676,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9169,x:32396,y:32483,varname:node_9169,prsc:2|A-4676-RGB,B-6423-OUT;n:type:ShaderForge.SFN_Dot,id:6909,x:30877,y:32905,varname:node_6909,prsc:2,dt:0|A-3073-OUT,B-7955-OUT;n:type:ShaderForge.SFN_Multiply,id:8265,x:32332,y:32757,varname:node_8265,prsc:2|A-6423-OUT,B-5392-OUT;n:type:ShaderForge.SFN_Append,id:9665,x:31189,y:33039,varname:node_9665,prsc:2|A-6909-OUT,B-6957-OUT;n:type:ShaderForge.SFN_Vector1,id:6957,x:30936,y:33114,varname:node_6957,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:5788,x:31400,y:33039,ptovrint:False,ptlb:Shadow Ramp,ptin:_ShadowRamp,varname:node_5788,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ae7a10612705c364eb2bcd74761863a6,ntxv:1,isnm:False|UVIN-9665-OUT;n:type:ShaderForge.SFN_Add,id:2675,x:31699,y:32951,varname:node_2675,prsc:2|A-343-OUT,B-5788-RGB,C-670-OUT;n:type:ShaderForge.SFN_Clamp01,id:5392,x:31977,y:32857,varname:node_5392,prsc:2|IN-2675-OUT;n:type:ShaderForge.SFN_Slider,id:4725,x:31139,y:32826,ptovrint:False,ptlb:Ramp Strength,ptin:_RampStrength,varname:node_4725,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_OneMinus,id:343,x:31483,y:32855,varname:node_343,prsc:2|IN-4725-OUT;n:type:ShaderForge.SFN_Slider,id:670,x:31321,y:33260,ptovrint:False,ptlb:Ramp Adjustement,ptin:_RampAdjustement,varname:node_670,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.1538462,max:1;n:type:ShaderForge.SFN_Tex2d,id:5708,x:32554,y:33273,ptovrint:False,ptlb:Alpha Map,ptin:_AlphaMap,varname:node_5708,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:6423,x:32121,y:32620,varname:node_6423,prsc:2|A-8008-OUT,B-7379-OUT,T-5788-R;n:type:ShaderForge.SFN_Multiply,id:8008,x:32006,y:32400,varname:node_8008,prsc:2|A-3265-RGB,B-7379-OUT;n:type:ShaderForge.SFN_Color,id:3265,x:31825,y:32168,ptovrint:False,ptlb:Shadow Color,ptin:_ShadowColor,varname:node_3265,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3793073,c2:0.349481,c3:0.7426471,c4:1;n:type:ShaderForge.SFN_Multiply,id:8378,x:32732,y:32582,varname:node_8378,prsc:2|A-1157-OUT,B-9169-OUT;n:type:ShaderForge.SFN_Slider,id:1157,x:32689,y:32413,ptovrint:False,ptlb:HDR truc,ptin:_HDRtruc,varname:node_1157,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:50;proporder:8886-7165-4233-4725-670-9262-5788-5708-3265-1157;pass:END;sub:END;*/

Shader "Custom/Toon" {
    Properties {
        _DiffuseColor ("Diffuse Color", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", Range(0, 10)) = 0
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _RampStrength ("Ramp Strength", Range(0, 1)) = 1
        _RampAdjustement ("Ramp Adjustement", Range(-1, 1)) = 0.1538462
        _Diffuse ("Diffuse", 2D) = "white" {}
        _ShadowRamp ("Shadow Ramp", 2D) = "gray" {}
        _AlphaMap ("Alpha Map", 2D) = "white" {}
        _ShadowColor ("Shadow Color", Color) = (0.3793073,0.349481,0.7426471,1)
        _HDRtruc ("HDR truc", Range(0, 50)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _OutlineColor;
            uniform float _OutlineWidth;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
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
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*(_OutlineWidth*0.01),1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                clip(_Diffuse_var.a - 0.5);
                return fixed4(_OutlineColor.rgb,0);
            }
            ENDCG
        }
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
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _DiffuseColor;
            uniform sampler2D _ShadowRamp; uniform float4 _ShadowRamp_ST;
            uniform float _RampStrength;
            uniform float _RampAdjustement;
            uniform float4 _ShadowColor;
            uniform float _HDRtruc;
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
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
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
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                clip(_Diffuse_var.a - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float3 node_7379 = (_Diffuse_var.rgb*_DiffuseColor.rgb);
                float2 node_9665 = float2(dot(normalDirection,lightDirection),0.0);
                float4 _ShadowRamp_var = tex2D(_ShadowRamp,TRANSFORM_TEX(node_9665, _ShadowRamp));
                float3 node_6423 = lerp((_ShadowColor.rgb*node_7379),node_7379,_ShadowRamp_var.r);
                float3 emissive = (_HDRtruc*(UNITY_LIGHTMODEL_AMBIENT.rgb*node_6423));
                float3 finalColor = emissive + ((node_6423*saturate(((1.0 - _RampStrength)+_ShadowRamp_var.rgb+_RampAdjustement)))*attenuation*_LightColor0.rgb);
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
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _DiffuseColor;
            uniform sampler2D _ShadowRamp; uniform float4 _ShadowRamp_ST;
            uniform float _RampStrength;
            uniform float _RampAdjustement;
            uniform float4 _ShadowColor;
            uniform float _HDRtruc;
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
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
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
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                clip(_Diffuse_var.a - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 node_7379 = (_Diffuse_var.rgb*_DiffuseColor.rgb);
                float2 node_9665 = float2(dot(normalDirection,lightDirection),0.0);
                float4 _ShadowRamp_var = tex2D(_ShadowRamp,TRANSFORM_TEX(node_9665, _ShadowRamp));
                float3 node_6423 = lerp((_ShadowColor.rgb*node_7379),node_7379,_ShadowRamp_var.r);
                float3 finalColor = ((node_6423*saturate(((1.0 - _RampStrength)+_ShadowRamp_var.rgb+_RampAdjustement)))*attenuation*_LightColor0.rgb);
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
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
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                clip(_Diffuse_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
