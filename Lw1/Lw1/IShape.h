#pragma once
#include <cstdint>
#include <string>
#include "Point.h"
#include "IDrawable.h"

//std::string ColorToString(std::uint32_t num);

class IShape : public IDrawable
{
public:
	virtual std::uint32_t GetOutlineColor() const = 0;
	/*virtual ~IShape() = default;*/
};