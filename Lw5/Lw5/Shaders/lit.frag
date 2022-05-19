#version 460 core

out vec4 outColor;

struct Light
{
	vec3 position;

	vec3 ambient;
	vec3 diffuse;
	vec3 specular;

	float constant;
	float linear;
	float quadratic;
};

uniform Light light;

struct Material
{
	sampler2D diffuse;
	sampler2D specular;
	float shininess;
};

uniform Material material;


uniform vec3 uObjColor;
uniform vec3 uViewPos;

in vec3 normal;
in vec3 fragPos;
in vec2 texCoord;

void main()
{
	float lightDistance = length(light.position - fragPos);
	float attenuation = 1.0 / (light.constant + light.linear * lightDistance + 
    		    light.quadratic * (lightDistance * lightDistance));

	//ambient
	vec3 ambientMap = vec3(texture(material.diffuse, texCoord));
	vec3 specularMap = vec3(texture(material.specular, texCoord));

	vec3 ambient = (light.ambient * ambientMap) * attenuation;
	// diffuse

	vec3 norm = normalize(normal);
	vec3 lightDir = normalize(light.position - fragPos);
	float diff = max(dot(lightDir, norm), 0.0);
	vec3 diffuse = (light.diffuse * (diff * ambientMap)) * attenuation;

	//Specular
	vec3 viewDir = normalize(uViewPos - fragPos);
	vec3 lightReflect = reflect(-lightDir, norm);
	float spec = pow(max(dot(viewDir, lightReflect), 0.0), material.shininess); 
	vec3 specular = 0.0001 * (light.specular * spec * specularMap) * attenuation;

	outColor = vec4((ambient + diffuse + specular), 1.0);
}