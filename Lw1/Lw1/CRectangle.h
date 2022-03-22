#pragma once
#include "Point.h"
#include "ISolidShape.h"
#include <string>
#include <cstdint>

class CRectangle : public ISolidShape
{
public:
	void Draw(ICanvas& canvas) const override;
	std::uint32_t GetFillColor() const override;
	std::uint32_t GetOutlineColor() const override;
	Point GetLeftTop() const;
	Point GetRightBottom() const;
	double GetWidth() const;
	double GetHeight() const;
	bool SetLeftTop(Point const& point);
	bool SetRightBottom(Point const& point);
	bool SetOutlineColor(const std::uint32_t color);
	bool SetFillColor(const std::uint32_t color);
	CRectangle(Point leftTop, Point rightBottom, std::uint32_t outlineColor, std::uint32_t fillColor);
	CRectangle();

private:
	Point m_leftTop;
	Point m_rightBottom;
	std::uint32_t m_outlineColor = 0;
	std::uint32_t m_fillColor = 0;
};
