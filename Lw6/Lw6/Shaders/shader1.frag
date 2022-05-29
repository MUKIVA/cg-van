#version 460 core
out vec4 outColor;

in vec2 pos;

uniform sampler2D uColor;

void main()
{
	if (pos != vec2(0))
		outColor = texture(uColor, pos);
	else
		outColor = vec4(1);
}
