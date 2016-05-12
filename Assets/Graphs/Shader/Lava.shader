// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5514706,fgcg:0.5474436,fgcb:0.4054931,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4431,x:33277,y:32692,varname:node_4431,prsc:2|normal-1200-RGB,emission-3521-OUT,custl-418-OUT,voffset-4490-OUT,disp-4490-OUT,tess-7959-OUT;n:type:ShaderForge.SFN_Color,id:6043,x:32438,y:32487,ptovrint:False,ptlb:node_6043,ptin:_node_6043,varname:node_6043,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2058824,c2:0.1453287,c3:0.05449828,c4:1;n:type:ShaderForge.SFN_Tex2d,id:2890,x:32164,y:32858,ptovrint:False,ptlb:node_2890,ptin:_node_2890,varname:node_2890,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-2960-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9172,x:31812,y:32847,varname:node_9172,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:2960,x:31993,y:32776,varname:node_2960,prsc:2,spu:0,spv:0.1|UVIN-9172-UVOUT;n:type:ShaderForge.SFN_Fresnel,id:8991,x:32487,y:33144,varname:node_8991,prsc:2|EXP-555-OUT;n:type:ShaderForge.SFN_Tex2d,id:8845,x:32152,y:32604,ptovrint:False,ptlb:node_2890_copy,ptin:_node_2890_copy,varname:_node_2890_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-6673-UVOUT;n:type:ShaderForge.SFN_Panner,id:6673,x:31992,y:32484,varname:node_6673,prsc:2,spu:0.1,spv:0|UVIN-2175-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2175,x:31741,y:32449,varname:node_2175,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:538,x:32321,y:32888,varname:node_538,prsc:2|A-8845-RGB,B-2890-RGB;n:type:ShaderForge.SFN_Add,id:4490,x:32649,y:33005,varname:node_4490,prsc:2|A-538-OUT,B-4941-OUT;n:type:ShaderForge.SFN_Slider,id:4941,x:32164,y:33115,ptovrint:False,ptlb:offset,ptin:_offset,varname:node_4941,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:0.5555556,max:10;n:type:ShaderForge.SFN_Slider,id:7959,x:32196,y:33462,ptovrint:False,ptlb:Tesselation,ptin:_Tesselation,varname:node_7959,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.717698,max:10;n:type:ShaderForge.SFN_Slider,id:555,x:32020,y:33234,ptovrint:False,ptlb:fresnel intensity,ptin:_fresnelintensity,varname:node_555,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:8.672846,max:10;n:type:ShaderForge.SFN_Add,id:418,x:32729,y:32540,varname:node_418,prsc:2|A-6043-RGB,B-8991-OUT;n:type:ShaderForge.SFN_Power,id:9731,x:32535,y:32674,varname:node_9731,prsc:2|VAL-8845-RGB,EXP-5449-OUT;n:type:ShaderForge.SFN_Vector1,id:5449,x:32293,y:32800,varname:node_5449,prsc:2,v1:3;n:type:ShaderForge.SFN_Tex2d,id:1200,x:33006,y:32415,ptovrint:False,ptlb:node_1200,ptin:_node_1200,varname:node_1200,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:53ffcb020e2027c46b3c0ea3466f6154,ntxv:3,isnm:True|UVIN-6673-UVOUT;n:type:ShaderForge.SFN_OneMinus,id:8540,x:32695,y:32698,varname:node_8540,prsc:2|IN-9731-OUT;n:type:ShaderForge.SFN_Multiply,id:3521,x:32917,y:32600,varname:node_3521,prsc:2|A-418-OUT,B-8540-OUT;n:type:ShaderForge.SFN_Clamp,id:7992,x:32376,y:32604,varname:node_7992,prsc:2|IN-8845-RGB,MIN-3383-OUT,MAX-3656-OUT;n:type:ShaderForge.SFN_Vector1,id:3383,x:32262,y:32725,varname:node_3383,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:3656,x:32376,y:32766,varname:node_3656,prsc:2,v1:1;proporder:6043-2890-8845-4941-7959-555-1200;pass:END;sub:END;*/

Shader "Custom/Lava" {
    Properties {
        _node_6043 ("node_6043", Color) = (0.2058824,0.1453287,0.05449828,1)
        _node_2890 ("node_2890", 2D) = "white" {}
        _node_2890_copy ("node_2890_copy", 2D) = "white" {}
        _offset ("offset", Range(-3, 10)) = 0.5555556
        _Tesselation ("Tesselation", Range(0, 10)) = 3.717698
        _fresnelintensity ("fresnel intensity", Range(0, 10)) = 8.672846
        _node_1200 ("node_1200", 2D) = "bump" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform float4 _node_6043;
            uniform sampler2D _node_2890; uniform float4 _node_2890_ST;
            uniform sampler2D _node_2890_copy; uniform float4 _node_2890_copy_ST;
            uniform float _offset;
            uniform float _Tesselation;
            uniform float _fresnelintensity;
            uniform sampler2D _node_1200; uniform float4 _node_1200_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_5024 = _Time + _TimeEditor;
                float2 node_6673 = (o.uv0+node_5024.g*float2(0.1,0));
                float4 _node_2890_copy_var = tex2Dlod(_node_2890_copy,float4(TRANSFORM_TEX(node_6673, _node_2890_copy),0.0,0));
                float2 node_2960 = (o.uv0+node_5024.g*float2(0,0.1));
                float4 _node_2890_var = tex2Dlod(_node_2890,float4(TRANSFORM_TEX(node_2960, _node_2890),0.0,0));
                float3 node_4490 = ((_node_2890_copy_var.rgb*_node_2890_var.rgb)+_offset);
                v.vertex.xyz += node_4490;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                void displacement (inout VertexInput v){
                    float4 node_5024 = _Time + _TimeEditor;
                    float2 node_6673 = (v.texcoord0+node_5024.g*float2(0.1,0));
                    float4 _node_2890_copy_var = tex2Dlod(_node_2890_copy,float4(TRANSFORM_TEX(node_6673, _node_2890_copy),0.0,0));
                    float2 node_2960 = (v.texcoord0+node_5024.g*float2(0,0.1));
                    float4 _node_2890_var = tex2Dlod(_node_2890,float4(TRANSFORM_TEX(node_2960, _node_2890),0.0,0));
                    float3 node_4490 = ((_node_2890_copy_var.rgb*_node_2890_var.rgb)+_offset);
                    v.vertex.xyz += node_4490;
                }
                float Tessellation(TessVertex v){
                    return _Tesselation;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    displacement(v);
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_5024 = _Time + _TimeEditor;
                float2 node_6673 = (i.uv0+node_5024.g*float2(0.1,0));
                float3 _node_1200_var = UnpackNormal(tex2D(_node_1200,TRANSFORM_TEX(node_6673, _node_1200)));
                float3 normalLocal = _node_1200_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
////// Lighting:
////// Emissive:
                float3 node_418 = (_node_6043.rgb+pow(1.0-max(0,dot(normalDirection, viewDirection)),_fresnelintensity));
                float4 _node_2890_copy_var = tex2D(_node_2890_copy,TRANSFORM_TEX(node_6673, _node_2890_copy));
                float3 emissive = (node_418*(1.0 - pow(_node_2890_copy_var.rgb,3.0)));
                float3 finalColor = emissive + node_418;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform sampler2D _node_2890; uniform float4 _node_2890_ST;
            uniform sampler2D _node_2890_copy; uniform float4 _node_2890_copy_ST;
            uniform float _offset;
            uniform float _Tesselation;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 node_2721 = _Time + _TimeEditor;
                float2 node_6673 = (o.uv0+node_2721.g*float2(0.1,0));
                float4 _node_2890_copy_var = tex2Dlod(_node_2890_copy,float4(TRANSFORM_TEX(node_6673, _node_2890_copy),0.0,0));
                float2 node_2960 = (o.uv0+node_2721.g*float2(0,0.1));
                float4 _node_2890_var = tex2Dlod(_node_2890,float4(TRANSFORM_TEX(node_2960, _node_2890),0.0,0));
                float3 node_4490 = ((_node_2890_copy_var.rgb*_node_2890_var.rgb)+_offset);
                v.vertex.xyz += node_4490;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                void displacement (inout VertexInput v){
                    float4 node_2721 = _Time + _TimeEditor;
                    float2 node_6673 = (v.texcoord0+node_2721.g*float2(0.1,0));
                    float4 _node_2890_copy_var = tex2Dlod(_node_2890_copy,float4(TRANSFORM_TEX(node_6673, _node_2890_copy),0.0,0));
                    float2 node_2960 = (v.texcoord0+node_2721.g*float2(0,0.1));
                    float4 _node_2890_var = tex2Dlod(_node_2890,float4(TRANSFORM_TEX(node_2960, _node_2890),0.0,0));
                    float3 node_4490 = ((_node_2890_copy_var.rgb*_node_2890_var.rgb)+_offset);
                    v.vertex.xyz += node_4490;
                }
                float Tessellation(TessVertex v){
                    return _Tesselation;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    displacement(v);
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
