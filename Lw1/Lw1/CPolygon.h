#pragma once
#include "ISolidShape.h"

class CPolygon : public ISolidShape
{
public:
	// Унаследовано через ISolidShape
	void Draw(ICanvas& cnavas) const override;
	std::uint32_t GetOutlineColor() const override;
	std::uint32_t GetFillColor() const override;
	bool SetOutlineColor(const std::uint32_t color);
	bool SetFillColor(const std::uint32_t color);
	CPolygon();
	CPolygon(
		std::vector<Point> data,
		std::uint32_t outlineColor,
		std::uint32_t fillColor);

	bool AddPoint(Point point);
	bool ErasePoint(size_t index);

private:
	std::uint32_t m_outlineColor = 0;
	std::uint32_t m_fillColor = 0;
	std::vector<Point> m_points;
};

