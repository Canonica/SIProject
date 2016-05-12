// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:5504,x:34459,y:32704,varname:node_5504,prsc:2|diff-1472-OUT,diffpow-5660-OUT,spec-3014-OUT,normal-590-RGB,emission-3700-OUT,clip-1153-R;n:type:ShaderForge.SFN_Tex2d,id:5770,x:32526,y:32280,ptovrint:False,ptlb:diffuse,ptin:_diffuse,varname:node_5770,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:df028a04559a9874d9117e6d2caf7726,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6191,x:32219,y:32682,ptovrint:False,ptlb:spec,ptin:_spec,varname:node_6191,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e789f2907d30b2e45b8ce5417bf78457,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:590,x:32142,y:32940,ptovrint:False,ptlb:normal,ptin:_normal,varname:node_590,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5b922708c05f21b4fb4053dab1061cab,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:1153,x:32549,y:33339,ptovrint:False,ptlb:mask,ptin:_mask,varname:node_1153,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cfd21f659320147449c49946354df9e3,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Fresnel,id:3648,x:31817,y:33203,varname:node_3648,prsc:2|EXP-2323-OUT;n:type:ShaderForge.SFN_Multiply,id:3715,x:32062,y:33286,varname:node_3715,prsc:2|A-3648-OUT,B-3070-RGB;n:type:ShaderForge.SFN_Dot,id:8448,x:31879,y:32442,varname:node_8448,prsc:2,dt:0|A-8300-OUT,B-6554-OUT;n:type:ShaderForge.SFN_NormalVector,id:8300,x:31632,y:32381,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:6554,x:31587,y:32576,varname:node_6554,prsc:2;n:type:ShaderForge.SFN_Clamp,id:2392,x:32041,y:32485,varname:node_2392,prsc:2|IN-8448-OUT,MIN-5601-OUT,MAX-9635-OUT;n:type:ShaderForge.SFN_Vector1,id:5601,x:31713,y:32648,varname:node_5601,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Vector1,id:9635,x:31615,y:32817,varname:node_9635,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:5660,x:32281,y:32468,varname:node_5660,prsc:2|A-2392-OUT,B-3977-OUT;n:type:ShaderForge.SFN_Vector3,id:3977,x:32007,y:32635,varname:node_3977,prsc:2,v1:5,v2:2,v3:2;n:type:ShaderForge.SFN_Multiply,id:3014,x:32404,y:32756,varname:node_3014,prsc:2|A-6191-RGB,B-279-OUT;n:type:ShaderForge.SFN_Vector3,id:279,x:32244,y:32811,varname:node_279,prsc:2,v1:0.2797757,v2:0.1634948,v3:0.3529412;n:type:ShaderForge.SFN_Multiply,id:9145,x:32377,y:32994,varname:node_9145,prsc:2|A-5770-RGB,B-7252-OUT;n:type:ShaderForge.SFN_Vector1,id:7252,x:32254,y:33106,varname:node_7252,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Add,id:3700,x:32550,y:33025,varname:node_3700,prsc:2|A-9145-OUT,B-3715-OUT;n:type:ShaderForge.SFN_Color,id:3070,x:31559,y:33547,ptovrint:False,ptlb:fresnel_color,ptin:_fresnel_color,varname:node_3070,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:2323,x:31383,y:33276,ptovrint:False,ptlb:fresnel_strength,ptin:_fresnel_strength,varname:node_2323,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5.726496,max:10;n:type:ShaderForge.SFN_Tex2d,id:1274,x:32709,y:32078,ptovrint:False,ptlb:Cape_mask,ptin:_Cape_mask,varname:node_1274,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c3ca393e2aff595429632129c19ad55c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:923,x:32906,y:32095,varname:node_923,prsc:2|A-1274-RGB,B-5770-RGB;n:type:ShaderForge.SFN_Multiply,id:1826,x:33139,y:32076,varname:node_1826,prsc:2|A-923-OUT,B-8684-RGB;n:type:ShaderForge.SFN_Color,id:8684,x:32913,y:32421,ptovrint:False,ptlb:cape color,ptin:_capecolor,varname:node_8684,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.1918864,c3:0.6470588,c4:1;n:type:ShaderForge.SFN_Add,id:1472,x:33681,y:32389,varname:node_1472,prsc:2|A-4050-OUT,B-5770-RGB;n:type:ShaderForge.SFN_Add,id:3138,x:33350,y:32229,varname:node_3138,prsc:2|A-1826-OUT,B-3858-OUT;n:type:ShaderForge.SFN_Vector1,id:3858,x:33139,y:32324,varname:node_3858,prsc:2,v1:0.7;n:type:ShaderForge.SFN_Power,id:5686,x:33573,y:32101,varname:node_5686,prsc:2|VAL-3138-OUT,EXP-5184-OUT;n:type:ShaderForge.SFN_Vector1,id:5184,x:33384,y:32048,varname:node_5184,prsc:2,v1:7;n:type:ShaderForge.SFN_Multiply,id:4050,x:33832,y:32110,varname:node_4050,prsc:2|A-1274-RGB,B-5686-OUT;proporder:5770-6191-590-1153-3070-2323-1274-8684;pass:END;sub:END;*/

Shader "Custom/master_shader" {
    Properties {
        _diffuse ("diffuse", 2D) = "white" {}
        _spec ("spec", 2D) = "white" {}
        _normal ("normal", 2D) = "bump" {}
        _mask ("mask", 2D) = "white" {}
        _fresnel_color ("fresnel_color", Color) = (1,1,1,1)
        _fresnel_strength ("fresnel_strength", Range(0, 10)) = 5.726496
        _Cape_mask ("Cape_mask", 2D) = "white" {}
        _capecolor ("cape color", Color) = (0,0.1918864,0.6470588,1)
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
            uniform sampler2D _diffuse; uniform float4 _diffuse_ST;
            uniform sampler2D _spec; uniform float4 _spec_ST;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform sampler2D _mask; uniform float4 _mask_ST;
            uniform float4 _fresnel_color;
            uniform float _fresnel_strength;
            uniform sampler2D _Cape_mask; uniform float4 _Cape_mask_ST;
            uniform float4 _capecolor;
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
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
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
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _normal_var = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(i.uv0, _normal)));
                float3 normalLocal = _normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _mask_var = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                clip(_mask_var.r - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
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
                float4 _spec_var = tex2D(_spec,TRANSFORM_TEX(i.uv0, _spec));
                float3 specularColor = (_spec_var.rgb*float3(0.2797757,0.1634948,0.3529412));
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = pow(max( 0.0, NdotL), (clamp(dot(i.normalDir,lightDirection),0.2,0.5)*float3(5,2,2))) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Cape_mask_var = tex2D(_Cape_mask,TRANSFORM_TEX(i.uv0, _Cape_mask));
                float4 _diffuse_var = tex2D(_diffuse,TRANSFORM_TEX(i.uv0, _diffuse));
                float3 diffuseColor = ((_Cape_mask_var.rgb*pow((((_Cape_mask_var.rgb*_diffuse_var.rgb)*_capecolor.rgb)+0.7),7.0))+_diffuse_var.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = ((_diffuse_var.rgb*0.2)+(pow(1.0-max(0,dot(normalDirection, viewDirection)),_fresnel_strength)*_fresnel_color.rgb));
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
            uniform sampler2D _diffuse; uniform float4 _diffuse_ST;
            uniform sampler2D _spec; uniform float4 _spec_ST;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform sampler2D _mask; uniform float4 _mask_ST;
            uniform float4 _fresnel_color;
            uniform float _fresnel_strength;
            uniform sampler2D _Cape_mask; uniform float4 _Cape_mask_ST;
            uniform float4 _capecolor;
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
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
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
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _normal_var = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(i.uv0, _normal)));
                float3 normalLocal = _normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _mask_var = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                clip(_mask_var.r - 0.5);
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
                float4 _spec_var = tex2D(_spec,TRANSFORM_TEX(i.uv0, _spec));
                float3 specularColor = (_spec_var.rgb*float3(0.2797757,0.1634948,0.3529412));
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = pow(max( 0.0, NdotL), (clamp(dot(i.normalDir,lightDirection),0.2,0.5)*float3(5,2,2))) * attenColor;
                float4 _Cape_mask_var = tex2D(_Cape_mask,TRANSFORM_TEX(i.uv0, _Cape_mask));
                float4 _diffuse_var = tex2D(_diffuse,TRANSFORM_TEX(i.uv0, _diffuse));
                float3 diffuseColor = ((_Cape_mask_var.rgb*pow((((_Cape_mask_var.rgb*_diffuse_var.rgb)*_capecolor.rgb)+0.7),7.0))+_diffuse_var.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
            uniform sampler2D _mask; uniform float4 _mask_ST;
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
                float4 _mask_var = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                clip(_mask_var.r - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
