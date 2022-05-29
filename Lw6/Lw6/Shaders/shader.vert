#version 460 core

layout (location = 0) in vec3 aPos;

out vec2 pos;

void main()
{
	gl_Position = vec4(aPos, 1);
	pos = aPos.xy;
}