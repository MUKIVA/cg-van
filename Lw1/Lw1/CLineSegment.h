#pragma once
#include "Point.h"
#include "IShape.h"
#include <string>
#include <cstdint>

class CLineSegment : public IShape
{
public:
	void Draw(ICanvas& canvas) const override;
	std::uint32_t GetOutlineColor() const override;
	Point GetStartPoint() const;
	Point GetEndPoint() const;
	bool SetStartPoint(Point const& point);
	bool SetEndPoint(Point const& point);
	bool SetOutlineColor(const std::uint32_t color);
	CLineSegment();
	CLineSegment(Point start, Point end, std::uint32_t outlineColor, int lineWidth);

private:
	Point m_startPoint;
	Point m_endPoint;
	std::uint32_t m_outlineColor = 0;
	int m_lineWidth = 4;
};

