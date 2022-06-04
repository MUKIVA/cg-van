using Lw7.Mathematics;

namespace Lw7.Model
{
    public class SimpleDiffuseShader : IShader
    {
        private SimpleMaterial _material = new();

        public void SetMaterial(SimpleMaterial material)
        {
            _material = material;
        }

        public Vec4d Shade(ShadeContext shadeContext)
        {
			/*
			Получаем сцену из контекста закрашивания для того, чтобы вычислить вклад
			каждого из источников света в освещенность обрабатываемой точки
			*/
			Scene scene = shadeContext.GetScene();

			// Результирующий цвет
			Vec4d shadedColor = Vec4d.Zero;

			int numLights = scene.GetLightCount();

			// Пробегаемся по всем источникам света в сцене
			for (int i = 0; i < numLights; ++i)
			{
				// Получаем источник света
				ILightSource light = scene.GetLight(i);

				// Вычисляем вектор направления на источник света из текущей точке
				Vec3d lightDirection = light.GetDirectionFromPoint(shadeContext.GetSurfacePoint());

				// Вычисляем интенсивность света в направлении от источника к текущей точке
				double lightIntensity = light.GetIntensityInDirection(-lightDirection);

				// Получаем нормаль к поверхности в обрабатываемой точке
				Vec3d n = shadeContext.GetSurfaceNormal();

				// Вычисляем скалярное произведение нормали и орт-вектора направления на источник света
				double nDotL = MathHelper.Max(Vec3d.Dot(n, lightDirection.Normalized()), 0.0);

				// Вычисляем диффузный цвет точки
				Vec4d diffuseColor = (nDotL * lightIntensity) * light.DiffuseIntensity * _material.DiffuseColor;

				// К результирующему цвету прибавляется вычисленный диффузный цвет
				shadedColor += diffuseColor;
			}   // Проделываем данные действия для других источников света

			// Возвращаем результирующий цвет точки
			return shadedColor;
		}
    }
}
