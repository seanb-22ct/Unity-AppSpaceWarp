#ifndef MY_COMMON_INCLUDED
#define MY_COMMON_INCLUDED

struct Attributes
{
    float4 positionOS : POSITION;
    float2 uv : TEXCOORD0;
    UNITY_VERTEX_INPUT_INSTANCE_ID
};

struct Varyings
{
    float4 positionCS : SV_POSITION;
    float2 uv : TEXCOORD0;
    UNITY_VERTEX_OUTPUT_STEREO
};

TEXTURE2D(_MainTex);
SAMPLER(sampler_MainTex);

CBUFFER_START(UnityPerMaterial)
    float4 _MainTex_ST;
CBUFFER_END

Varyings vert(Attributes input)
{
    Varyings output = (Varyings)0;
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

    VertexPositionInputs positionInputs = GetVertexPositionInputs(input.positionOS.xyz);
    output.positionCS = positionInputs.positionCS;

    output.uv = TRANSFORM_TEX(input.uv, _MainTex);
    return output;
}

float4 frag(Varyings input) : SV_Target
{
    float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
    clip(color.a - 0.5);
    return color;
}


#endif