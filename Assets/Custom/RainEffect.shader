Shader "Custom/ToxicRainEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _RainColor ("Rain Color", Color) = (0.4, 1.0, 0.0, 1.0)
        _GlowColor ("Glow Color", Color) = (0.1, 1.0, 0.1, 1.0)
        _RainAmount ("Rain Amount", Float) = 200.0
        _BaseRainSpeed ("Base Rain Speed", Float) = 0.5
        _AdditionalRainSpeed ("Additional Rain Speed", Float) = 0.5
        _Slant ("Slant", Range(-1.0, 1.0)) = 0.2
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _RainColor;
            fixed4 _GlowColor;
            float _RainAmount;
            float _BaseRainSpeed;
            float _AdditionalRainSpeed;
            float _Slant;
            float _Time;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float time = _Time * (_BaseRainSpeed + _AdditionalRainSpeed);
                float remainder = fmod(uv.x - uv.y * _Slant, 1.0 / _RainAmount);
                uv.x = uv.x - uv.y * _Slant - remainder;
                float rn = frac(sin(uv.x * _RainAmount));
                uv.y = frac(uv.y + rn);

                // Simulación de la lluvia tóxica con efecto de resplandor
                fixed4 col = tex2D(_MainTex, i.uv);
                float rainEffect = step(1.0 - _RainAmount, frac(uv.y - time)) * rn;
                col = lerp(col, _RainColor, rainEffect);

                // Agregar resplandor para un aspecto tóxico
                float glow = smoothstep(0.0, 1.0, rainEffect) * 0.5;
                col += _GlowColor * glow;
                
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
