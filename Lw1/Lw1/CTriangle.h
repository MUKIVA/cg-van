#pragma once
#include "Point.h"
#include "ISolidShape.h"
#include <string>

class CTriangle : public ISolidShape
{
public:
	void Draw(ICanvas& canvas) const override;
	Point GetVertex1() const;
	Point GetVertex2() const;
	Point GetVertex3() const;
	std::uint32_t GetFillColor() const override;
	std::uint32_t GetOutlineColor() const override;
	bool SetOutlineColor(const std::uint32_t color);
	bool SetFillColor(const std::uint32_t color);
	bool SetVertex1(Point const& point);
	bool SetVertex2(Point const& point);
	bool SetVertex3(Point const& point);
	CTriangle();
	CTriangle(Point p1, Point p2, Point p3, std::uint32_t outlineColor, std::uint32_t fillColor);

private:
	Point m_p1;
	Point m_p2;
	Point m_p3;
	std::uint32_t m_outlineColor = 0;
	std::uint32_t m_fillColor = 0;
};
