Shader "Teste" {
    Properties {
        _MainTex ("Texture", 2D) = "white" { }
    }

    SubShader {
        Tags { "Queue" = "Overlay" }

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma exclude_renderers gles xbox360 ps3 ps4 xboxone
            ENDCG

            SetTexture[_MainTex] {
                combine primary
            }
        }
    }

    SubShader {
        Tags { "Queue" = "Overlay" }

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma exclude_renderers gles xbox360 ps3 ps4 xboxone
            ENDCG

            ColorMask RGB
            SetTexture[_MainTex] {
                combine texture * texture
            }
        }
    }
}

