#pragma once
#include "Point.h"
#include "ISolidShape.h"
#include <cstdint>
#include <string>

class CCircle : public ISolidShape
{
public:
	void Draw(ICanvas& canvas) const override;
	std::uint32_t GetFillColor() const override;
	std::uint32_t GetOutlineColor() const override;
	Point GetCenter() const;
	double GetRadius() const;
	bool SetCenter(const Point& point);
	bool SetRadius(const double radius);
	bool SetOutlineColor(const std::uint32_t color);
	bool SetFillColor(const std::uint32_t color);
	CCircle();
	CCircle(Point center, double radius, std::uint32_t outlineColor, std::uint32_t fillColor);

private:
	double m_radius = 0;
	Point m_center;
	std::uint32_t m_outlineColor = 0;
	std::uint32_t m_fillColor = 0;
};

