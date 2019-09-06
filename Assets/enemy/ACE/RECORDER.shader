Shader "Custom/RECORDER"
{
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
	_Size("Point sprite size", Float) = 64
	}
		SubShader{
		Pass{
		GLSLPROGRAM

		uniform sampler2D _MainTex;
	uniform float _Size;

#ifdef VERTEX
	void main() {
		//ftransform()は固定機能パイプラインと同等の変換を行う
		gl_Position = ftransform();
	}
#endif


#ifdef FRAGMENT
	void main() {
		gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0);
	}
#endif

	ENDGLSL
	}
	}
}

