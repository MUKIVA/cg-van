#pragma once
#include <vector>
#include <cstdint>
#include "Point.h"


class ICanvas
{
public:
	virtual void DrawLine(Point const& from, Point const& to, const std::uint32_t lineColor, int lineWidth = 4) = 0;
	virtual void FillPolygon(std::vector<Point> const& points, const std::uint32_t fillColor) = 0;
	virtual void DrawCircle(Point const& center, const double radius, std::uint32_t lineColor) = 0;
	virtual void FillCircle(Point const& center, const double radius, std::uint32_t fillColor) = 0;
};

